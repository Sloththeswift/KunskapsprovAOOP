using KunskapsprovAOOP.Context;
using KunskapsprovAOOP.Migrations;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;
using System.Runtime.Remoting.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Runtime.InteropServices.ComTypes;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Runtime.Remoting.Services;

namespace KunskapsprovAOOP
{
    public class CrudBear : ICrudBear
    {
        protected BearsDbContext DbContext { get; private set; }

        public void CreateNew()
        {
            using (var db = new BearsDbContext())
            {
                var Menu = new Menu();

                var bear = new Bear();
                Console.WriteLine("Enter you're favourite bears first name");
                bear.FirstName = Console.ReadLine();
                Console.WriteLine("Enter you're favourite bears last name");
                bear.LastName = Console.ReadLine();
                Console.WriteLine("Enter you're favourite bears clothing of choice");
                bear.ClothingOfChoice = Console.ReadLine();
                Console.WriteLine("Enter you're favourite bears address");
                bear.Address = Console.ReadLine();
                db.Add(bear);
                db.SaveChanges();
                Console.Clear();
                Menu.RunMainMenu();

            }

        }

        public void Delete()
        {
            using (var db = new BearsDbContext())
            {
                var Menu = new Menu();
                var bear = new Bear();
                Console.WriteLine("Enter the first name of the bear you would like to remove");
                var bearToDelete = Console.ReadLine();
                var deletebear = (from d in db.favouritebears
                                  where d.FirstName == bearToDelete
                                  select d).Single();

                db.favouritebears.Remove(deletebear);
                db.SaveChanges();
                Console.WriteLine("hmmm");
                Console.ReadLine();
                Console.Clear();
                Menu.RunMainMenu();

            }
        }

        public void FindAll()
        {
            var Menu = new Menu();
            using (var db = new BearsDbContext())
            {
                foreach (var i in db.favouritebears)
                {
                    Console.WriteLine($"Id:{i.Id}. Firstname: {i.FirstName}. Lastname: {i.LastName}. Clothing: {i.ClothingOfChoice}. Address: {i.Address}.");

                }
                Console.ReadLine();
                Console.Clear();
                Menu.RunMainMenu();
            }
                   
        }


        public void FindOne()
        {
            var Menu = new Menu();
            using (var db = new BearsDbContext())
            {
                
                var bear = new Bear();
                Console.WriteLine("Enter the first name of the bear you would like to see the details separately");
                var singlebear = Console.ReadLine();
                var row = db.favouritebears.FirstOrDefault(r => r.FirstName == singlebear);
                if (row.FirstName != null)
                {
                    Console.WriteLine($"Id:{row.Id}. Firstname: {row.FirstName}. Lastname: {row.LastName}. Clothing: {row.ClothingOfChoice}. Address: {row.Address}.");
                      
                }
 
                Console.ReadLine();
                Console.Clear();
                Menu.RunMainMenu();

            }


        }

        public void Update()
        {
            var Menu = new Menu();
            using (var db = new BearsDbContext())
            {
                Console.WriteLine("Which bear would you like to update, enter first name");
                var bear = new Bear(); 
                var bearToUpdate = Console.ReadLine();
                var updateBear = (from d in db.favouritebears
                                  where d.FirstName == bearToUpdate
                                  select d).Single();

                Console.WriteLine("Enter you're favourite bears first name");
                updateBear.FirstName = Console.ReadLine();
                Console.WriteLine("Enter you're favourite bears last name");
                updateBear.LastName = Console.ReadLine();
                Console.WriteLine("Enter you're favourite bears clothing of choice");
                updateBear.ClothingOfChoice = Console.ReadLine();
                Console.WriteLine("Enter you're favourite bears address");
                updateBear.Address = Console.ReadLine();

                db.favouritebears.Update(updateBear);
                db.SaveChanges();
                Console.Clear();
                Menu.RunMainMenu();



            }
        }
    }
}
