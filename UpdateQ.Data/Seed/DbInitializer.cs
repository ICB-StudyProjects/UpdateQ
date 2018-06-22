namespace UpdateQ.Data.Seed
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UpdateQ.Common;
    using UpdateQ.Model.Entities;

    public static class DbInitializer
    {
        public static void SeedDb(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .AddUsers();
        }

        //private static void AddInfoNodes(ModelBuilder modelBuilder)
        //{
        //    var infoNodes = new HashSet<InfoNode>
        //    {
        //        new InfoNode
        //        {
        //            FirstName = "Todor",
        //            LastName = "Vasilev",
        //            Age = 27,
        //            BirthDay = DateTime.Now,
        //            Gender = GenderType.Male,
        //        },
        //        new InfoNode
        //        {
        //            FirstName = "Pesho",
        //            LastName = "Kostov",
        //            Age = 13,
        //            BirthDay = DateTime.Now,
        //            Gender = GenderType.Other,
        //        },
        //        new InfoNode
        //        {
        //            FirstName = "John",
        //            LastName = "Smith",
        //            Age = 46,
        //            BirthDay = DateTime.Now,
        //            Gender = GenderType.Male,
        //        },
        //        new InfoNode
        //        {
        //            FirstName = "Maria",
        //            LastName = "Dimitrova",
        //            Age = 23,
        //            BirthDay = DateTime.Now,
        //            Gender = GenderType.Female,
        //        },
        //    };

        //    modelBuilder.Entity<InfoNode>().HasData(infoNodes);
        //}

        private static void AddUsers(this ModelBuilder modelBuilder)
        {
            var users = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Todor",
                    LastName = "Vasilev",
                    Age = 27,
                    BirthDay = DateTime.Now,
                    Gender = GenderType.Male,
                    IsDeleted = false
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Pesho",
                    LastName = "Kostov",
                    Age = 13,
                    BirthDay = DateTime.Now,
                    Gender = GenderType.Other,
                    IsDeleted = false
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Smith",
                    Age = 46,
                    BirthDay = DateTime.Now,
                    Gender = GenderType.Male,
                    IsDeleted = false
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Maria",
                    LastName = "Dimitrova",
                    Age = 23,
                    BirthDay = DateTime.Now,
                    Gender = GenderType.Female,
                    IsDeleted = false
                },
            };

            modelBuilder.Entity<User>().HasData(users);
        }
    }
}
