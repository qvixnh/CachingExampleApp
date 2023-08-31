﻿using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public  class SampleDataAccess
    {
        private readonly IMemoryCache _memoryCache;

        public SampleDataAccess(IMemoryCache memoryCache)
        {
            this._memoryCache = memoryCache;
        }
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
        public async Task<List<EmployeeModel>> GetEmployeesCache()
        {
            List<EmployeeModel> output;

            //key
            output = _memoryCache.Get<List<EmployeeModel>>("employees");
            if (output is null) {
                output = new();

                output.Add(new() { FirstName = "Tim", LastName = "Corey" });
                output.Add(new() { FirstName = "Sue", LastName = "Storm" });
                output.Add(new() { FirstName = "Jane", LastName = "Jones" });
                await Task.Delay(3000);//asynchronously call this awaiting
                _memoryCache.Set("employees", output, TimeSpan.FromMinutes(1));//cache live for 1 minute
            }

            return output;
        }


    }
}
