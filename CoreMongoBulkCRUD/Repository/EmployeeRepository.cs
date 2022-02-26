using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMongoBulkCRUD.IRepository;
using ImageSaveAndReadCoreMongoDB.Models;
using MongoDB.Driver;

namespace CoreMongoBulkCRUD.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Employee> _empTable = null;

        public EmployeeRepository()
        {
            _mongoClient = new MongoClient("mongodb://127.0.0.1:27017");
            _database = _mongoClient.GetDatabase("OfficeDB");
            _empTable = _database.GetCollection<Employee>("Employees");
        }

        public EmployeeRepository(MongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public void BulkSave()
        {
            var emps = new List<Employee>();
            for (int i = 1; i < 9; i++)
            {
                emps.Add(new Employee()
                {
                    Name = "Emp"+i,
                    Age = this.GetRandomAge()
                });
            }
            _empTable.InsertMany(emps);
        }

        private int GetRandomAge()
        {
            var ages = new[] { 20, 21, 22, 23 };
            Random random = new Random();
            return ages[random.Next(ages.Length)];
        }

        public void BulkUpdate()
        {
            var emps = _empTable.Find(FilterDefinition<Employee>.Empty).ToList();
            var filter = Builders<Employee>.Filter.In(x => x.Id, emps.Select(x => x.Id));
            var update = Builders<Employee>.Update.Set(x=> x.Age,30);
            _empTable.UpdateMany(filter, update);
        }

        public void BulkDeleteByPropertyValue()
        {
            _empTable.DeleteMany(x=> x.Age == 20);
        }

        public void BulkDelete()
        {
            var emps = _empTable.Find(FilterDefinition<Employee>.Empty).ToList();
            emps.RemoveAt(emps.Count -1);
            var filter = Builders<Employee>.Filter.In(x => x.Id, emps.Select(x => x.Id));
            _empTable.DeleteMany(filter);
        }
    }
}
