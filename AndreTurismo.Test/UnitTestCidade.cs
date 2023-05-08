using AndreTurismoAPI.CityService.Controllers;
using AndreTurismoAPI.CityService.Data;
using AndreTurismoAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Owin.BuilderProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoAPI.Test
{
    public class UnitTestCidade
    {/*
        private DbContextOptions<AndreTurismoAPICityServiceContext> options;

        private void InitializeDataBase()
        {
            // Create a Temporary Database
            options = new DbContextOptionsBuilder<AndreTurismoAPICityServiceContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Insert data into the database using one instance of the context
            using (var context = new AndreTurismoAPICityServiceContext(options))
            {
                context.Cidade.Add(new Cidade { IdCidade = 1, Descricao = "City1" });
                context.Cidade.Add(new Cidade { IdCidade = 2, Descricao = "City2" });
                context.Cidade.Add(new Cidade { IdCidade = 3, Descricao = "City3" });
                context.SaveChanges();
            }
        }

        [Fact]
        public void GetAll()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAPICityServiceContext(options))
            {
                AddressesController addressController = new AddressesController(context, null);
                IEnumerable<Address> clients = addressController.GetAddress().Result.Value;

                Assert.Equal(3, clients.Count());
            }
        }

        [Fact]
        public void GetbyId()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAPICityServiceContext(options))
            {
                int clientId = 2;
                AddressesController addressController = new AddressesController(context, null);
                Address client = addressController.GetAddress(clientId).Result.Value;
                Assert.Equal(2, client.Id);
            }
        }

        [Fact]
        public void Create()
        {
            InitializeDataBase();

            Address address = new Address()
            {
                Id = 4,
                Street = "Rua 10",
                CEP = "14804300",
                City = new() { Id = 10, Description = "City 10" }
            };

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAPICityServiceContext(options))
            {
                AddressesController addressController = new AddressesController(context, new PostOfficesService());
                Address ad = addressController.PostAddress(address).Result.Value;
                Assert.Equal("Avenida Alberto Benassi", ad.Street);
            }
        }

        [Fact]
        public void Update()
        {
            InitializeDataBase();

            Address address = new Address()
            {
                Id = 3,
                Street = "Rua 10 Alterada",
                City = new() { Id = 10, Description = "City 10 alterada" }
            };

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAPICityServiceContext(options))
            {
                AddressesController addressController = new AddressesController(context, null);
                Address ad = addressController.PutAddress(3, address).Result.Value;
                Assert.Equal("Rua 10 Alterada", ad.Street);
            }
        }

        [Fact]
        public void Delete()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAPICityServiceContext(options))
            {
                CidadesController cidadeController = new CidadesController(context, null);
                Cidade cidade = cidadeController.DeleteCidade(2).Result.Value;
                Assert.Null(cidade);
            }
        }*/
    }
}
