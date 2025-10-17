using AutoMapper;
using ELI.Data;
using ELI.Data.DTOs.teacher;
using ELI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController(DataContext context, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeacherDto>>> GetAll()
    {
        var teachers = await context.Teachers.ToListAsync();
        return Ok(mapper.Map<List<TeacherDto>>(teachers));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TeacherDto>> GetById(int id)
    {
        var teacher = await context.Teachers.FindAsync(id);
        if (teacher == null) return NotFound();
        return Ok(mapper.Map<TeacherDto>(teacher));
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateTeacherDto dto)
    {
        var teacher = mapper.Map<Teacher>(dto);
        context.Teachers.Add(teacher);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = teacher.ID }, mapper.Map<TeacherDto>(teacher));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateTeacherDto dto)
    {
        var teacher = await context.Teachers.FindAsync(id);
        if (teacher == null) return NotFound();
        mapper.Map(dto, teacher);
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var teacher = await context.Teachers.FindAsync(id);
        if (teacher == null) return NotFound();
        context.Teachers.Remove(teacher);
        await context.SaveChangesAsync();
        return NoContent();
    }
}