using AutoMapper;
using ELI.Data;
using ELI.Data.DTOs.student;
using ELI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController(DataContext context, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll()
    {
        var students = await context.Students.ToListAsync();
        return Ok(mapper.Map<List<StudentDto>>(students));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDto>> GetById(int id)
    {
        var student = await context.Students.FindAsync(id);
        if (student == null) return NotFound();
        return Ok(mapper.Map<StudentDto>(student));
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateStudentDto dto)
    {
        var student = mapper.Map<Student>(dto);
        context.Students.Add(student);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = student.ID}, mapper.Map<StudentDto>(student));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateStudentDto dto)
    {
        var student = await context.Students.FindAsync(id);
        if (student == null) return NotFound();
        mapper.Map(dto, student);
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var student = await context.Students.FindAsync(id);
        if (student == null) return NotFound();
        context.Students.Remove(student);
        await context.SaveChangesAsync();
        return NoContent();
    }
}