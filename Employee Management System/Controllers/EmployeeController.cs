using Employee_Management_System.Application.DTOs.EmployeeDto;
using Employee_Management_System.Application.Services.Department;
using Employee_Management_System.Application.Services.Employee;
using Employee_Management_System.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_System.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index(FilterEmployeeRequestDto request)
        {
            var response = await _employeeService.GetAllEmployeesAsync(request);

            if (!response.IsSuccess)
            {
                TempData["ErrorMessage"] = response.Error?.ErrorMessage ?? "An error occurred while fetching employees.";
                return View("Error");
            }

            var departmentsResponse = await _departmentService.GetAllDepartmentsAsync();

            ViewBag.Departments = departmentsResponse.Data;
            ViewBag.SortBy = request.SortBy;
            ViewBag.IsDescending = request.IsDescending;

            ViewBag.CurrentPage = response.Data?.CurrentPage ?? 1;
            ViewBag.TotalPages = response.Data?.TotalPages ?? 1;
            ViewBag.TotalItems = response.Data?.TotalItems ?? 0;

            ViewBag.SearchQuery = request.SearchQuery;
            ViewBag.PageNumber = request.PageNumber;
            ViewBag.PageSize = request.PageSize;

            return View(response.Data);
        }


        public async Task<IActionResult> Create()
        {
            var departmentsResponse = await _departmentService.GetAllDepartmentsAsync();
            ViewBag.Departments = departmentsResponse.Data;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmployeeRequestDto request)
        {

            if (!ModelState.IsValid)
            {
                var departmentsResponse = await _departmentService.GetAllDepartmentsAsync();
                ViewBag.Departments = departmentsResponse.Data;
                return View(request);
            }

            var response = await _employeeService.AddEmployeeAsync(request);

            if (!response.IsSuccess)
            {
                TempData["ErrorMessage"] = response.Error?.ErrorMessage ?? "An error occurred while adding employee.";
                return View("Error");
            }

            TempData["SuccessMessage"] = "Employee added successfully.";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _employeeService.GetEmployeeByIdAsync(id);

            var departmentsResponse = await _departmentService.GetAllDepartmentsAsync();
            ViewBag.Departments = departmentsResponse.Data;


            if (!response.IsSuccess)
            {
                TempData["ErrorMessage"] = response.Error?.ErrorMessage ?? "An error occurred while fetching employee details.";
                return View("Error");
            }

            return View(response.Data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateEmployeeRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var response = await _employeeService.UpdateEmployeeAsync(request);

            if (!response.IsSuccess)
            {
                TempData["ErrorMessage"] = response.Error?.ErrorMessage ?? "An error occurred while updating employee details.";
                return View("Error");
            }

            TempData["SuccessMessage"] = "Employee updated successfully.";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _employeeService.DeleteEmployeeAsync(id);

            if (!response.IsSuccess)
            {
                TempData["ErrorMessage"] = response.Error?.ErrorMessage ?? "An error occurred while deleting employee.";
                return View("Error");
            }

            TempData["SuccessMessage"] = "Employee deleted successfully.";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            var response = await _employeeService.GetEmployeeByIdAsync(id);

            if (!response.IsSuccess)
            {
                TempData["ErrorMessage"] = response.Error?.ErrorMessage ?? "An error occurred while fetching employee details.";
                return View("Error");
            }

            return View(response.Data);
        }

    }
}
