using EmployeeService.Application.Interfaces;
using EmployeeService.Domain.Entities;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;

public class EmployeeFunction
{
    private readonly IEmployeeService _employeeService;

    public EmployeeFunction(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [Function("GetEmployees")]
    public async Task<HttpResponseData> GetEmployees(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "employees")] HttpRequestData req)
    {
        var employees = await _employeeService.GetAllAsync();

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(employees);

        return response;
    }

    [Function("CreateEmployee")]
    public async Task<HttpResponseData> CreateEmployee(
    [HttpTrigger(AuthorizationLevel.Function, "post", Route = "employees")] HttpRequestData req)
    {
        var employee = await req.ReadFromJsonAsync<Employee>();

        if (employee == null)
        {
            var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
            await badResponse.WriteStringAsync("Invalid request");
            return badResponse;
        }

        await _employeeService.AddAsync(employee);

        var response = req.CreateResponse(HttpStatusCode.Created);
        await response.WriteAsJsonAsync(employee);

        return response;
    }
}