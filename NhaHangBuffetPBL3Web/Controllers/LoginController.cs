using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NhaHangBuffetPBL3.Models.Records;
using System.Security.Claims;

using NhaHangBuffetPBL3.Models;
using NhaHangBuffetPBL3.DataAccess.Data;
using NhaHangBuffetPBL3.Repository.IRepository;

namespace NhaHangBuffet.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unitofWork;

        public LoginController(IUnitOfWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }
        #region Login
        [HttpGet]
        public IActionResult Login(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRecord model, string? ReturnUrl)
        {

            if (ModelState.IsValid)
            {
                var nhanvien = _unitofWork.Staff.GetFirstOrDefault(
                    nv => nv.Username == model.Username);
                if (nhanvien == null)
                {
                    ModelState.AddModelError("loi", "không có nhân viên này");
                }
                else if (nhanvien.Username != model.Username) { ModelState.AddModelError("loi", "Sai thông tin đăng nhập"); }
                else
                {
                    List<Claim> claims;
                    string role;
                    if (model.Username == "Admin" && BCrypt.Net.BCrypt.Verify(model.Password, nhanvien.Password))
                    {
                        claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, nhanvien.Username),
                            new Claim(ClaimTypes.Role, "Admin")
                        };
                        role = "Admin";
                    }
                    else
                    {
                        claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, nhanvien.Username),
                            new Claim(ClaimTypes.Role,"Staff")
                        };
                        role = "Staff";
                    }

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                 claimsPrincipal,
                                                 new AuthenticationProperties
                                                 {
                                                     IsPersistent = false
                                                 });

                    if (role != null )
                    {
                        if(ReturnUrl == null)
                        {
                            switch (role)
                            {
                                case "Admin":
                                    return RedirectToAction("Index", "AdminHome", new { area = "Admin" });
                                case "Staff":
                                    return RedirectToAction("Index", "Staff", new { area = "Staff" });
                            }   
                        }
                        return Redirect(ReturnUrl);
                    }
                }
            }
            return View();
        }
        #endregion        
    }
}


