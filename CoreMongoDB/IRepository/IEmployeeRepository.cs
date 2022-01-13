using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMongoDB.Models;

namespace CoreMongoDB.IRepository
{
    public interface IEmployeeRepository
    {
        Employee Save(Employee employee);
        Employee Get(string employeeId);
        List<Employee> Gets();
        string Delete(string employeeId);
    }
}
