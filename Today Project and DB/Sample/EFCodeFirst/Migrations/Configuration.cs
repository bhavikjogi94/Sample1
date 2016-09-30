namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFCodeFirst.BAL.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EFCodeFirst.BAL.EFContext context)
        {
            //context.Countries.AddOrUpdate(x => x.CountryID,
            //    new BAL.Country() { CountryID = 1, CountryName = "USA" },
            //    new BAL.Country() { CountryID = 2, CountryName = "Canada" },
            //    new BAL.Country() { CountryID = 3, CountryName = "India" }
            //    );

            //context.Provinces.AddOrUpdate(x => x.ProvinceID,
            //    new BAL.Province() { ProvinceID = 1, CountryID = 1, ProvinceName = "Alabama" },
            //    new BAL.Province() { ProvinceID = 2, CountryID = 1, ProvinceName = "Alaska" },
            //    new BAL.Province() { ProvinceID = 3, CountryID = 1, ProvinceName = "Arizona" },
            //    new BAL.Province() { ProvinceID = 4, CountryID = 1, ProvinceName = "Arkansas" },
            //    new BAL.Province() { ProvinceID = 5, CountryID = 1, ProvinceName = "California" },
            //    new BAL.Province() { ProvinceID = 6, CountryID = 1, ProvinceName = "Colorado" },
            //    new BAL.Province() { ProvinceID = 7, CountryID = 1, ProvinceName = "Connecticut" },
            //    new BAL.Province() { ProvinceID = 8, CountryID = 1, ProvinceName = "Delaware" },
            //    new BAL.Province() { ProvinceID = 9, CountryID = 1, ProvinceName = "District Of Columbia" },
            //    new BAL.Province() { ProvinceID = 10, CountryID = 1, ProvinceName = "Florida" },
            //    new BAL.Province() { ProvinceID = 11, CountryID = 1, ProvinceName = "Georgia" },
            //    new BAL.Province() { ProvinceID = 12, CountryID = 1, ProvinceName = "Hawaii" },
            //    new BAL.Province() { ProvinceID = 13, CountryID = 1, ProvinceName = "Idaho" },
            //    new BAL.Province() { ProvinceID = 14, CountryID = 1, ProvinceName = "Illinois" },
            //    new BAL.Province() { ProvinceID = 15, CountryID = 1, ProvinceName = "Indiana" },
            //    new BAL.Province() { ProvinceID = 16, CountryID = 1, ProvinceName = "Iowa" },
            //    new BAL.Province() { ProvinceID = 17, CountryID = 1, ProvinceName = "Kansas" },
            //    new BAL.Province() { ProvinceID = 18, CountryID = 1, ProvinceName = "Kentucky" },
            //    new BAL.Province() { ProvinceID = 19, CountryID = 1, ProvinceName = "Louisiana" },
            //    new BAL.Province() { ProvinceID = 20, CountryID = 1, ProvinceName = "Maine" },
            //    new BAL.Province() { ProvinceID = 21, CountryID = 1, ProvinceName = "Maryland" },
            //    new BAL.Province() { ProvinceID = 22, CountryID = 1, ProvinceName = "Massachusetts" },
            //    new BAL.Province() { ProvinceID = 23, CountryID = 1, ProvinceName = "Michigan" },
            //    new BAL.Province() { ProvinceID = 24, CountryID = 1, ProvinceName = "Minnesota" },
            //    new BAL.Province() { ProvinceID = 25, CountryID = 1, ProvinceName = "Mississippi" },
            //    new BAL.Province() { ProvinceID = 26, CountryID = 1, ProvinceName = "Missouri" },
            //    new BAL.Province() { ProvinceID = 27, CountryID = 1, ProvinceName = "Montana" },
            //    new BAL.Province() { ProvinceID = 28, CountryID = 1, ProvinceName = "Nebraska" },
            //    new BAL.Province() { ProvinceID = 29, CountryID = 1, ProvinceName = "Nevada" },
            //    new BAL.Province() { ProvinceID = 30, CountryID = 1, ProvinceName = "New Hampshire" },
            //    new BAL.Province() { ProvinceID = 31, CountryID = 1, ProvinceName = "New Jersey" },
            //    new BAL.Province() { ProvinceID = 32, CountryID = 1, ProvinceName = "New Mexico" },
            //    new BAL.Province() { ProvinceID = 33, CountryID = 1, ProvinceName = "New York" },
            //    new BAL.Province() { ProvinceID = 34, CountryID = 1, ProvinceName = "North Carolina" },
            //    new BAL.Province() { ProvinceID = 35, CountryID = 1, ProvinceName = "North Dakota" },
            //    new BAL.Province() { ProvinceID = 36, CountryID = 1, ProvinceName = "Ohio" },
            //    new BAL.Province() { ProvinceID = 37, CountryID = 1, ProvinceName = "Oklahoma" },
            //    new BAL.Province() { ProvinceID = 38, CountryID = 1, ProvinceName = "Oregon" },
            //    new BAL.Province() { ProvinceID = 39, CountryID = 1, ProvinceName = "Pennsylvania" },
            //    new BAL.Province() { ProvinceID = 40, CountryID = 1, ProvinceName = "Rhode Island" },
            //    new BAL.Province() { ProvinceID = 41, CountryID = 1, ProvinceName = "South Carolina" },
            //    new BAL.Province() { ProvinceID = 42, CountryID = 1, ProvinceName = "South Dakota" },
            //    new BAL.Province() { ProvinceID = 43, CountryID = 1, ProvinceName = "Tennessee" },
            //    new BAL.Province() { ProvinceID = 44, CountryID = 1, ProvinceName = "Texas" },
            //    new BAL.Province() { ProvinceID = 45, CountryID = 1, ProvinceName = "Utah" },
            //    new BAL.Province() { ProvinceID = 46, CountryID = 1, ProvinceName = "Vermont" },
            //    new BAL.Province() { ProvinceID = 47, CountryID = 1, ProvinceName = "Virginia" },
            //    new BAL.Province() { ProvinceID = 48, CountryID = 1, ProvinceName = "Washington" },
            //    new BAL.Province() { ProvinceID = 49, CountryID = 1, ProvinceName = "West Virginia" },
            //    new BAL.Province() { ProvinceID = 50, CountryID = 1, ProvinceName = "Wisconsin" },
            //    new BAL.Province() { ProvinceID = 51, CountryID = 1, ProvinceName = "Wyoming" },
            //    new BAL.Province() { ProvinceID = 52, CountryID = 2, ProvinceName = "Alberta" },
            //    new BAL.Province() { ProvinceID = 53, CountryID = 2, ProvinceName = "British Columbia" },
            //    new BAL.Province() { ProvinceID = 54, CountryID = 2, ProvinceName = "Manitoba" },
            //    new BAL.Province() { ProvinceID = 55, CountryID = 2, ProvinceName = "New Brunswick" },
            //    new BAL.Province() { ProvinceID = 56, CountryID = 2, ProvinceName = "Newfoundland and Labrador" },
            //    new BAL.Province() { ProvinceID = 57, CountryID = 2, ProvinceName = "Nova Scotia" },
            //    new BAL.Province() { ProvinceID = 58, CountryID = 2, ProvinceName = "Ontario" },
            //    new BAL.Province() { ProvinceID = 59, CountryID = 2, ProvinceName = "Prince Edward Island" },
            //    new BAL.Province() { ProvinceID = 60, CountryID = 2, ProvinceName = "Quebec" },
            //    new BAL.Province() { ProvinceID = 61, CountryID = 2, ProvinceName = "Saskatchewan" },
            //    new BAL.Province() { ProvinceID = 62, CountryID = 2, ProvinceName = "Northwest Territories" },
            //    new BAL.Province() { ProvinceID = 63, CountryID = 2, ProvinceName = "Nunavut" },
            //    new BAL.Province() { ProvinceID = 64, CountryID = 2, ProvinceName = "Yukon" },
            //    new BAL.Province() { ProvinceID = 65, CountryID = 3, ProvinceName = "Andaman and Nicobar Islands" },
            //    new BAL.Province() { ProvinceID = 66, CountryID = 3, ProvinceName = "Andhra Pradesh" },
            //    new BAL.Province() { ProvinceID = 67, CountryID = 3, ProvinceName = "Arunachal Pradesh" },
            //    new BAL.Province() { ProvinceID = 68, CountryID = 3, ProvinceName = "Assam" },
            //    new BAL.Province() { ProvinceID = 69, CountryID = 3, ProvinceName = "Bihar" },
            //    new BAL.Province() { ProvinceID = 70, CountryID = 3, ProvinceName = "Chandigarh" },
            //    new BAL.Province() { ProvinceID = 71, CountryID = 3, ProvinceName = "Chhattisgarh" },
            //    new BAL.Province() { ProvinceID = 72, CountryID = 3, ProvinceName = "Dadra and Nagar Haveli" },
            //    new BAL.Province() { ProvinceID = 73, CountryID = 3, ProvinceName = "Daman and Diu" },
            //    new BAL.Province() { ProvinceID = 74, CountryID = 3, ProvinceName = "Delhi" },
            //    new BAL.Province() { ProvinceID = 75, CountryID = 3, ProvinceName = "Goa" },
            //    new BAL.Province() { ProvinceID = 76, CountryID = 3, ProvinceName = "Gujarat" },
            //    new BAL.Province() { ProvinceID = 77, CountryID = 3, ProvinceName = "Haryana" },
            //    new BAL.Province() { ProvinceID = 78, CountryID = 3, ProvinceName = "Himachal Pradesh" },
            //    new BAL.Province() { ProvinceID = 79, CountryID = 3, ProvinceName = "Jammu and Kashmir" },
            //    new BAL.Province() { ProvinceID = 80, CountryID = 3, ProvinceName = "Jharkhand" },
            //    new BAL.Province() { ProvinceID = 81, CountryID = 3, ProvinceName = "Karnataka" },
            //    new BAL.Province() { ProvinceID = 82, CountryID = 3, ProvinceName = "Kerala" },
            //    new BAL.Province() { ProvinceID = 83, CountryID = 3, ProvinceName = "Lakshadweep" },
            //    new BAL.Province() { ProvinceID = 84, CountryID = 3, ProvinceName = "Madhya Pradesh" },
            //    new BAL.Province() { ProvinceID = 85, CountryID = 3, ProvinceName = "Maharashtra" },
            //    new BAL.Province() { ProvinceID = 86, CountryID = 3, ProvinceName = "Manipur" },
            //    new BAL.Province() { ProvinceID = 87, CountryID = 3, ProvinceName = "Meghalaya" },
            //    new BAL.Province() { ProvinceID = 88, CountryID = 3, ProvinceName = "Mizoram" },
            //    new BAL.Province() { ProvinceID = 89, CountryID = 3, ProvinceName = "Nagaland" },
            //    new BAL.Province() { ProvinceID = 90, CountryID = 3, ProvinceName = "Odisha" },
            //    new BAL.Province() { ProvinceID = 91, CountryID = 3, ProvinceName = "Puducherry" },
            //    new BAL.Province() { ProvinceID = 92, CountryID = 3, ProvinceName = "Punjab" },
            //    new BAL.Province() { ProvinceID = 93, CountryID = 3, ProvinceName = "Rajasthan" },
            //    new BAL.Province() { ProvinceID = 94, CountryID = 3, ProvinceName = "Sikkim" },
            //    new BAL.Province() { ProvinceID = 95, CountryID = 3, ProvinceName = "Tamil Nadu" },
            //    new BAL.Province() { ProvinceID = 96, CountryID = 3, ProvinceName = "Telengana" },
            //    new BAL.Province() { ProvinceID = 97, CountryID = 3, ProvinceName = "Tripura" },
            //    new BAL.Province() { ProvinceID = 98, CountryID = 3, ProvinceName = "Uttar Pradesh" },
            //    new BAL.Province() { ProvinceID = 99, CountryID = 3, ProvinceName = "Uttarakhand" },
            //    new BAL.Province() { ProvinceID = 100, CountryID = 3, ProvinceName = "West Bengal" }
            //                    );

            //context.Customers.AddOrUpdate(x => x.CustomerID,
            //new BAL.Customer() { CustomerID = 1, FirstName = "Chris", LastName = "Lee", BirthDate = Convert.ToDateTime("1987-12-16"), Email = "clee0@mail.ru", Address = "76 Green Ridge Junction", ProvinceID = 53, CountryID = 2, CreatedDate = DateTime.Now, CreatedByID = 1, ModifiedDate = DateTime.Now, ModifiedByID = 1, IsActive = true, IsDeleted = false },
            //new BAL.Customer() { CustomerID = 2, FirstName = "Rachel", LastName = "Snyder", BirthDate = Convert.ToDateTime("1952-05-06"), Email = "rsnyder1@dot.gov", Address = "073 Armistice Plaza", ProvinceID = 78, CountryID = 3, CreatedDate = DateTime.Now, CreatedByID = 1, ModifiedDate = DateTime.Now, ModifiedByID = 1, IsActive = true, IsDeleted = false },
            //new BAL.Customer() { CustomerID = 3, FirstName = "Charles", LastName = "Fernandez", BirthDate = Convert.ToDateTime("1968-09-11"), Email = "cfernandez2@taobao.com", Address = "11 Oak Junction", ProvinceID = 22, CountryID = 1, CreatedDate = DateTime.Now, CreatedByID = 1, ModifiedDate = DateTime.Now, ModifiedByID = 1, IsActive = true, IsDeleted = false },
            //new BAL.Customer() { CustomerID = 4, FirstName = "Cheryl", LastName = "Black", BirthDate = Convert.ToDateTime("1968-10-01"), Email = "cblack3@newyorker.com", Address = "8 Katie Parkway", ProvinceID = 60, CountryID = 2, CreatedDate = DateTime.Now, CreatedByID = 1, ModifiedDate = DateTime.Now, ModifiedByID = 1, IsActive = true, IsDeleted = false },
            //new BAL.Customer() { CustomerID = 5, FirstName = "Adam", LastName = "Johnson", BirthDate = Convert.ToDateTime("1945-09-25"), Email = "ajohnson4@vinaora.com", Address = "528 Glendale Park", ProvinceID = 79, CountryID = 3, CreatedDate = DateTime.Now, CreatedByID = 1, ModifiedDate = DateTime.Now, ModifiedByID = 1, IsActive = true, IsDeleted = false },
            //new BAL.Customer() { CustomerID = 6, FirstName = "Jane", LastName = "Turner", BirthDate = Convert.ToDateTime("1960-04-18"), Email = "jturner5@illinois.edu", Address = "1 Parkside Street", ProvinceID = 23, CountryID = 1, CreatedDate = DateTime.Now, CreatedByID = 1, ModifiedDate = DateTime.Now, ModifiedByID = 1, IsActive = true, IsDeleted = false },
            //new BAL.Customer() { CustomerID = 7, FirstName = "Joshua", LastName = "Griffin", BirthDate = Convert.ToDateTime("1951-12-17"), Email = "jgriffin6@senate.gov", Address = "576 Melody Trail", ProvinceID = 23, CountryID = 1, CreatedDate = DateTime.Now, CreatedByID = 1, ModifiedDate = DateTime.Now, ModifiedByID = 1, IsActive = true, IsDeleted = false },
            //new BAL.Customer() { CustomerID = 8, FirstName = "Doris", LastName = "Hanson", BirthDate = Convert.ToDateTime("1926-08-05"), Email = "dhanson7@skyrock.com", Address = "69 Harper Circle", ProvinceID = 51, CountryID = 1, CreatedDate = DateTime.Now, CreatedByID = 1, ModifiedDate = DateTime.Now, ModifiedByID = 1, IsActive = true, IsDeleted = false },
            //new BAL.Customer() { CustomerID = 9, FirstName = "Betty", LastName = "Carter", BirthDate = Convert.ToDateTime("1935-06-09"), Email = "bcarter8@odnoklassniki.ru", Address = "896 Thackeray Circle", ProvinceID = 79, CountryID = 3, CreatedDate = DateTime.Now, CreatedByID = 1, ModifiedDate = DateTime.Now, ModifiedByID = 1, IsActive = true, IsDeleted = false },
            //new BAL.Customer() { CustomerID = 10, FirstName = "First Name", LastName = "Last Name", BirthDate = Convert.ToDateTime("1962-05-09"), Email = "Test@gmail.com", Address = "45 Berry street ", ProvinceID = 57, CountryID = 2, CreatedDate = DateTime.Now, CreatedByID = 1, ModifiedDate = DateTime.Now, ModifiedByID = 1, IsActive = true, IsDeleted = false }
            //    );
            //base.Seed(context);
        }
    }
}
