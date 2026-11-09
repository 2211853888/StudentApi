using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;

namespace StudentApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly AppDbContext _context;

    public StudentController(AppDbContext context)
    {
        _context = context;
    }

    // جلب جميع الطلاب من قاعدة البيانات
    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var students = await _context.Students.ToListAsync();
        return Ok(students);
    }

    // إضافة طالب جديد وحفظه في SQL Server
    [HttpPost]
    public async Task<IActionResult> AddStudent([FromBody] Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return Ok(student);
    }
}