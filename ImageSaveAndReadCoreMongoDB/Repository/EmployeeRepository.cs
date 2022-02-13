using System.Linq;
using ImageSaveAndReadCoreMongoDB.IRepository;
using ImageSaveAndReadCoreMongoDB.Models;
using MongoDB.Driver;

namespace ImageSaveAndReadCoreMongoDB.Repository
{
    public class EmployeeRepository :IEmployeeRepository
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Employee> _employeeTable = null;

        public EmployeeRepository()
        {
            _mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
            _database = _mongoClient.GetDatabase("OfficeDB");
            _employeeTable = _database.GetCollection<Employee>("Employees");
        }
        public Employee Save(Employee employee)
        {
            var emp = _employeeTable.Find(x => x.Id == employee.Id).FirstOrDefault();
            if (emp == null)
            {
                _employeeTable.InsertOne(employee);
            }
            else
            {
                _employeeTable.ReplaceOne(x => x.Id == employee.Id, employee);
            }

            return employee;
        }

        public Employee GetSaveEmployee()
        {
            return _employeeTable.Find(FilterDefinition<Employee>.Empty).ToList().FirstOrDefault();
        }
    }
}