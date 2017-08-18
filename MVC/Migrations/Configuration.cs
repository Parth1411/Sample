namespace MVC.Migrations
{
    using System;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC.Models.MVCContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVC.Models.MVCContext context)
        {
            context.Customers.AddOrUpdate(x => x.CustomerID,
            new Models.Customer() { CustomerID = 1, FirstName = "Chris", LastName = "Lee", BirthDate = Convert.ToDateTime("1987-12-16"), Email = "clee0@mail.ru", Address = "76 Green Ridge Junction"},
            new Models.Customer() { CustomerID = 2, FirstName = "Rachel", LastName = "Snyder", BirthDate = Convert.ToDateTime("1952-05-06"), Email = "rsnyder1@dot.gov", Address = "073 Armistice Plaza"},
            new Models.Customer() { CustomerID = 3, FirstName = "Charles", LastName = "Fernandez", BirthDate = Convert.ToDateTime("1968-09-11"), Email = "cfernandez2@taobao.com", Address = "11 Oak Junction"},
            new Models.Customer() { CustomerID = 4, FirstName = "Cheryl", LastName = "Black", BirthDate = Convert.ToDateTime("1968-10-01"), Email = "cblack3@newyorker.com", Address = "8 Katie Parkway"},
            new Models.Customer() { CustomerID = 5, FirstName = "Adam", LastName = "Johnson", BirthDate = Convert.ToDateTime("1945-09-25"), Email = "ajohnson4@vinaora.com", Address = "528 Glendale Park"},
            new Models.Customer() { CustomerID = 6, FirstName = "Jane", LastName = "Turner", BirthDate = Convert.ToDateTime("1960-04-18"), Email = "jturner5@illinois.edu", Address = "1 Parkside Street"},
            new Models.Customer() { CustomerID = 7, FirstName = "Joshua", LastName = "Griffin", BirthDate = Convert.ToDateTime("1951-12-17"), Email = "jgriffin6@senate.gov", Address = "576 Melody Trail"},
            new Models.Customer() { CustomerID = 8, FirstName = "Doris", LastName = "Hanson", BirthDate = Convert.ToDateTime("1926-08-05"), Email = "dhanson7@skyrock.com", Address = "69 Harper Circle"},
            new Models.Customer() { CustomerID = 9, FirstName = "Betty", LastName = "Carter", BirthDate = Convert.ToDateTime("1935-06-09"), Email = "bcarter8@odnoklassniki.ru", Address = "896 Thackeray Circle"},
            new Models.Customer() { CustomerID = 10, FirstName = "First Name", LastName = "Last Name", BirthDate = Convert.ToDateTime("1962-05-09"), Email = "Test@gmail.com", Address = "45 Berry street "}
                );
            base.Seed(context);
        }
    }
}
