using Employee_Management_System.Application.DTOs.DepartmentDto;
using Employee_Management_System.Application.Services.Department;
using Employee_Management_System.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_System.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _departmentService.GetAllDepartmentsAsync();
            if (!response.IsSuccess)
            {
                TempData["Error"] = "Failed to load departments.";
                return View(new List<GetDepartmentResponseDto>());
            }
            return View(response.Data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDepartmentRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var response = await _departmentService.AddDepartmentAsync(request);
            if (!response.IsSuccess)
            {
                TempData["Error"] = "Failed to add department.";
                return View(request);
            }
            TempData["Success"] = "Department added successfully.";
            return RedirectToAction("Index");
        }

    }
}
