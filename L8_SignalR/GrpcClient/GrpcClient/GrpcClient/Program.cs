﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
//這邊的Namespace需要與Server端一致
//using gRPCTest.HumanResource;
using L8_SignalR.Protos;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 等待 Server 啟動
            await Task.Delay(3000);

            //如果使用的是http而非https時
            //AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);


            // 建立連接到 http://localhost:5001 的通道
            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            // 建立 EmployeeClient
            var client = new Employee.EmployeeClient(channel);

            // 呼叫 GetEmployee()
            if (true)
            {
                var employee = await client.GetEmployeeAsync(new EmployeeRequest { Id = 1 });

                // 輸出 EmployeeModel 的序列化結果
                Console.WriteLine(JsonSerializer.Serialize(employee, new JsonSerializerOptions { WriteIndented = true }));
            }

            // 呼叫 GetAllEmployees()
            if (false)
            {
                var employeesStream = client.GetAllEmployees(new EmployeeRequest { Id = 0 });

                // 讀取 Employees 串流
                while (await employeesStream.ResponseStream.MoveNext())
                {
                    var employee = employeesStream.ResponseStream.Current;

                    // 輸出 EmployeeModel 的序列化結果
                    Console.WriteLine(JsonSerializer.Serialize(employee, new JsonSerializerOptions { WriteIndented = true }));
                }
            }

            // 呼叫 AddEmployees()
            if (false)
            {
                var employees = new List<EmployeeModel>
                               {
                                   new EmployeeModel
                                   {
                                       Id = 1,
                                       Name = "Johnny",
                                       EmployeeType = EmployeeType.FirstLevel,
                                       PhoneNumbers = { new EmployeeModel.Types.PhoneNumber { Value = "0912345678" } }
                                   },
                                   new EmployeeModel
                                   {
                                       Id = 2,
                                       Name = "Mary",
                                       EmployeeType = EmployeeType.SecondLevel,
                                       PhoneNumbers = { new EmployeeModel.Types.PhoneNumber { Value = "0923456789" } }
                                   },
                                   new EmployeeModel
                                   {
                                       Id = 3,
                                       Name = "Tom",
                                       EmployeeType = EmployeeType.LastLevel,
                                       PhoneNumbers = { new EmployeeModel.Types.PhoneNumber { Value = "0934567890" } }
                                   }
                               };

                AsyncClientStreamingCall<EmployeeModel, EmployeeAddedResult> employeesStream;

                using (employeesStream = client.AddEmployees())
                {
                    foreach (var employee in employees)
                    {
                        await employeesStream.RequestStream.WriteAsync(employee);
                    }

                    // Dispose() 會嘗試將狀態設為 Cancled (https://github.com/grpc/grpc-dotnet/blob/ca6cb660a5b9410d5b50a78387c52590dc31d13e/src/Grpc.Net.Client/Internal/GrpcCall.cs#L166)
                    // CompleteAsync() 則是會將完成的狀態設為 true (https://github.com/grpc/grpc-dotnet/blob/ca6cb660a5b9410d5b50a78387c52590dc31d13e/src/Grpc.Net.Client/Internal/HttpContentClientStreamWriter.cs#L73)
                    // 因此資料傳輸完畢之後，CompleteAsync() 是需要呼叫的。
                    await employeesStream.RequestStream.CompleteAsync();

                    var addedResult = await employeesStream.ResponseAsync;

                    // 輸出 EmployeeAddedResult 的序列化結果
                    Console.WriteLine(JsonSerializer.Serialize(addedResult, new JsonSerializerOptions { WriteIndented = true }));
                }
            }

            Console.ReadKey();
        }
    }
}
