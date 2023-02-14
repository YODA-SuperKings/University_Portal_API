using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Model.Models;
using MongoDB.Driver;

namespace BusinessLogic.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly IMongoCollection<Country> _countriesCollection;
        public CountriesService()
        {
            var mongoClient = new MongoClient(Globals.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(Globals.DatabaseName);
            _countriesCollection = mongoDatabase.GetCollection<Country>("Countries");
        }
        public List<Countrry> GetCountries()
        {
            List<Countrry> countrries = new List<Countrry>();
            List<Country> countries = new List<Country>();
            countries = _countriesCollection.Find(c => true).ToList();
            foreach (var item in countries)
            {
                Countrry country = new Countrry();
                country.label = item.Countries;
                country.value = item.Countries;
                countrries.Add(country);
            }
            return countrries;
        }
    }
}
