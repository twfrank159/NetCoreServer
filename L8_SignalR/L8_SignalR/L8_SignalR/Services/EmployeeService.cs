﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using L8_SignalR.Protos;
using Grpc.Core;

namespace L8_SignalR.Services
{
    public class EmployeeService : Employee.EmployeeBase
    {
        private readonly ILogger<EmployeeService> logger;

        public EmployeeService(ILogger<EmployeeService> logger)
        {
            this.logger = logger;
        }

        public override Task<EmployeeModel> GetEmployee(EmployeeRequest request, ServerCallContext context)
        {
            //這邊是模擬從伺服器抓回資料
            //Emulate get an employee
            var employee = new EmployeeModel
            {
                Id = 1,
                Name = "John",
                EmployeeType = EmployeeType.FirstLevel,
                PhoneNumbers = { new EmployeeModel.Types.PhoneNumber { Value = "0912345678" } },
                ModifiedTime = new DateTime(2019, 10, 03, 17, 45, 00).ToUnixTimeMilliseconds()
            };

            return Task.FromResult(employee);
        }

        public override async Task GetAllEmployees(EmployeeRequest request, IServerStreamWriter<EmployeeModel> responseStream, ServerCallContext context)
        {
            //這邊是模擬從伺服器抓回資料
            // Emulate get all employees.
            var allEmployees = new List<EmployeeModel>
                               {
                                   new EmployeeModel
                                   {
                                       Id = 1,
                                       Name = "Johnny",
                                       EmployeeType = EmployeeType.FirstLevel,
                                       PhoneNumbers = { new EmployeeModel.Types.PhoneNumber { Value = "0912345678" } },
                                       ModifiedTime = new DateTime(2019, 10, 3, 17, 45, 00).ToUnixTimeMilliseconds()
                                   },
                                   new EmployeeModel
                                   {
                                       Id = 2,
                                       Name = "Mary",
                                       EmployeeType = EmployeeType.SecondLevel,
                                       PhoneNumbers = { new EmployeeModel.Types.PhoneNumber { Value = "0923456789" } },
                                       ModifiedTime = new DateTime(2019, 10, 4, 9, 21, 00).ToUnixTimeMilliseconds()
                                   },
                                   new EmployeeModel
                                   {
                                       Id = 3,
                                       Name = "Tom",
                                       EmployeeType = EmployeeType.LastLevel,
                                       PhoneNumbers = { new EmployeeModel.Types.PhoneNumber { Value = "0934567890" } },
                                       ModifiedTime = new DateTime(2019, 10, 5, 10, 34, 00).ToUnixTimeMilliseconds()
                                   }
                               };

            foreach (var employee in allEmployees)
            {
                await responseStream.WriteAsync(employee);
            }
        }

        public override Task<EmployeeAddedResult> AddEmployee(EmployeeModel request, ServerCallContext context)
        {
            request.ModifiedTime = DateTime.Now.ToUnixTimeMilliseconds();

            //這邊是模擬存取資料到資料庫
            // ... Do add an employee.

            return Task.FromResult(new EmployeeAddedResult { IsSuccess = true });
        }

        public override async Task<EmployeeAddedResult> AddEmployees(IAsyncStreamReader<EmployeeModel> requestStream, ServerCallContext context)
        {
            var employees = new List<EmployeeModel>();

            while (await requestStream.MoveNext())
            {
                employees.Add(requestStream.Current);
            }

            // ... Do batch add employees.
            //這邊是模擬存取資料到資料庫

            return new EmployeeAddedResult { IsSuccess = true };
        }
    }

    internal static class DateTimeExtension
    {
        private static readonly System.DateTime InitialTime = new System.DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long ToUnixTimeMilliseconds(this System.DateTime me)
        {
            return Convert.ToInt64(me.ToUniversalTime().Subtract(InitialTime).TotalMilliseconds);
        }

        public static System.DateTime ToDateTime(this long me)
        {
            return InitialTime.AddMilliseconds(me).ToLocalTime();
        }

    }
}
