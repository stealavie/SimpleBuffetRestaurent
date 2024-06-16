﻿using NhaHangBuffetPBL3.Models;
using NhaHangBuffetPBL3.Models.Records;

namespace NhaHangBuffetPBL3.Repository.IRepository
{
    public interface IRepositoryIngredient : IRepository<Ingredient>
    {
        void Update(Ingredient obj);
        bool CheckIngredients(int FoodId, string method, int quantity);
    }
}
