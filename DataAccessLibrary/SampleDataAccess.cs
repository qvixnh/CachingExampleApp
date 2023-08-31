using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public  class SampleDataAccess
    {
        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> output = new();

            output.Add(new() { FirstName = "Tim", LastName = "Corey" });
            output.Add(new() { FirstName = "Sue", LastName = "Storm" });
            output.Add(new() { FirstName = "Jane", LastName = "Jones" });

            Thread.Sleep(3000);

            return output;
        }
        public async Task<List<EmployeeModel>> GetEmployeesAsync()
        {
            List<EmployeeModel> output = new();

            output.Add(new() { FirstName = "Tim", LastName = "Corey" });
            output.Add(new() { FirstName = "Sue", LastName = "Storm" });
            output.Add(new() { FirstName = "Jane", LastName = "Jones" });

            await Task.Delay(3000);//asynchronously call this awaiting

            return output;
        }


    }
}
