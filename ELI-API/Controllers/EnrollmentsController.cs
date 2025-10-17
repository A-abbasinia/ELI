using AutoMapper;
using ELI.Data;
using ELI.Data.DTOs.enrollment;
using ELI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnrollmentsController(DataContext context, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EnrollmentDto>>> GetAll()
    {
        var enrollments = await context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .ToListAsync();

        return Ok(mapper.Map<List<EnrollmentDto>>(enrollments));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EnrollmentDto>> GetById(int id)
    {
        var enrollment = await context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .FirstOrDefaultAsync(e => e.ID == id);

        if (enrollment == null) return NotFound();
        return Ok(mapper.Map<EnrollmentDto>(enrollment));
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateEnrollmentDto dto)
    {
        var enrollment = mapper.Map<Enrollment>(dto);
        context.Enrollments.Add(enrollment);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = enrollment.ID }, mapper.Map<EnrollmentDto>(enrollment));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateEnrollmentDto dto)
    {
        var enrollment = await context.Enrollments.FindAsync(id);
        if (enrollment == null) return NotFound();
        mapper.Map(dto, enrollment);
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var enrollment = await context.Enrollments.FindAsync(id);
        if (enrollment == null) return NotFound();
        context.Enrollments.Remove(enrollment);
        await context.SaveChangesAsync();
        return NoContent();
    }
}
