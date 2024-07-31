# NhaHangBuffet: Restaurant Buffet Management System

Welcome to the NhaHangBuffet project! 

This is a simple management website, developed as a course project, aimed at enhancing understanding of the C# programming language and the .NET Core framework. It delves into the practical application of key design patterns—Repository, Unit of Work, and Dependency Injection—and explores their synergy in creating a maintainable and testable application. The project also demonstrates how to build a functional website with minimal reliance on external frameworks, highlighting the core capabilities of .NET Core.

Enter in the Url "../login/login" to access the login page of staff 

## Features

* **Menu Management:** Easily create, update, and categorize buffet items.
* **Reservations:** Manage customer reservations: table assignments.
* **Order Processing:** Efficiently track customer orders and generate bills.
* **Payment Integration:** Integrate with VNPay payment gateways for seamless transactions.
* **Inventory Tracking:** Monitor ingredient levels and receive alerts for low stock.
* **Reporting:** Generate detailed reports on sales, revenue, and customer trends.
* **And more:** Discover additional features as you explore the system!

## Getting Started

Follow these steps to set up NhaHangBuffet on your local machine:

### Prerequisites

1. **SQL Server:** Ensure you have Microsoft SQL Server installed. If you don't have a full version, you can download the free [SQL Server Express edition](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).
2. **.NET 8.0 SDK:** Verify that you have the .NET 8.0 SDK installed. You can download it from the [official Microsoft website](https://dotnet.microsoft.com/download/dotnet/8.0).

### Installation

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/stealavie/SimpleBuffetRestaurent.git
2. **Configuration:** Follow the instruction in the app.conf and NhaHangBuffetContext.cs
3. **Database Update:**

   * Open **Package Manager Console**: In Visual Studio, go to **Tools** -> **NuGet Package Manager** -> **Package Manager Console**.
   * **Run Command:** In the Package Manager Console, execute the following command to create the database:

   ```bash
   update-database

