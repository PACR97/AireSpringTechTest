using AireSpring.Application.Features.Employees.Commands.CreateEmployee;
using AireSpring.Application.Features.Employees.Commands.DeleteEmployee;
using AireSpring.Application.Features.Employees.Commands.UpdateEmployee;
using AireSpring.Application.Features.Employees.Queries.GetEmployeeById;
using AireSpring.Application.Features.Employees.Queries.GetEmployees;
using AireSpring.Infrastructure.Dtos;
using AireSpring.Web.Extensions;
using AireSpring.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AireSpring.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// View index contain a table with Employee records 
        /// </summary>
        /// <param name="filterDto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index([Bind(Prefix = "Filter")] FilterEmployee filterDto)
        {
            try
            {
                var query = new GetEmployeesQuery(filterDto);
                var employees = await mediator.Send(query);
                var vm = new EmployeeIndexVm()
                {
                    Employees = employees,
                    Filter = filterDto
                };
                return View(vm);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// This action get the form to add or edit a Employee record
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="JsonResult"/></returns>
        [HttpGet]
        public async Task<IActionResult> GetAddOrEditEmployeeForm(Guid id)
        {
            try
            {
                var dto = new CreateOrEditEmployeeDto();
                if (id != Guid.Empty)
                {
                    var query = new GetEmployeeByIdQuery()
                    {
                        Id = id
                    };
                    var employee = await mediator.Send(query);
                    dto = new CreateOrEditEmployeeDto()
                    {
                        EmployeeFirstName = employee.EmployeeFirstName,
                        EmployeeId = employee.EmployeeId,
                        EmployeeLastName = employee.EmployeeLastName,
                        EmployeePhone = employee.EmployeePhone,
                        EmployeeZip = employee.EmployeeZip,
                        HireDate = employee.HireDate
                    };
                }
                string title = id != Guid.Empty ? "Edit" : "Create";
                string html = await this.RenderViewAsync("_CreateOrEditForm", dto, true);
                return Json(new { Ok = true, html, title });
            }
            catch (Exception e)
            {
                return Json(new { Ok = false, e.Message });
            }
        }

        /// <summary>
        /// Action to save a Employee record
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SaveEmployee(CreateOrEditEmployeeDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { ok = false, message = "The model is incorrec, try again" });
                }
                if (dto.EmployeeId == Guid.Empty)
                {
                    var command = new CreateEmployeeCommand()
                    {
                        EmployeeFirstName = dto.EmployeeFirstName,
                        EmployeeLastName = dto.EmployeeLastName,
                        EmployeePhone = dto.EmployeePhone,
                        EmployeeZip = dto.EmployeeZip
                    };
                    var employeeCreated = await mediator.Send(command);
                    return Json(new { ok = true, message = "Emplyee created" });
                }
                else
                {
                    var command = new UpdateEmployeeCommand()
                    {
                        EmployeeFirstName = dto.EmployeeFirstName,
                        EmployeeLastName = dto.EmployeeLastName,
                        EmployeePhone = dto.EmployeePhone,
                        EmployeeZip = dto.EmployeeZip,
                        EmployeeId = dto.EmployeeId
                    };
                    var employeeUpdated = await mediator.Send(command);
                    return Json(new { ok = true, message = "Emplyee updated" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Action to delete a Employee record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                var command = new DeleteEmployeeCommand(id);
                await mediator.Send(command);
                return Json(new { ok = true });
            }
            catch (Exception e)
            {
                return Json(new {ok = false, message = e.Message});
            }
        }
    }
}
