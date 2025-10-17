using AutoMapper;
using ELI.Data;
using ELI.Data.DTOs.course;
using ELI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController(DataContext context, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAll()
        {
            var courses = await context.Courses.Include(c => c.Teacher).ToListAsync();
            return Ok(mapper.Map<List<CourseDto>>(courses));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetById(int id)
        {
            var course = await context.Courses.Include(c => c.Teacher).FirstOrDefaultAsync(c => c.ID == id);
            if (course == null) return NotFound();
            return Ok(mapper.Map<CourseDto>(course));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCourseDto dto)
        {
            var course = mapper.Map<Course>(dto);
            context.Courses.Add(course);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = course.ID }, mapper.Map<CourseDto>(course));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCourseDto dto)
        {
            var course = await context.Courses.FindAsync(id);
            if (course == null) return NotFound();
            mapper.Map(dto, course);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var course = await context.Courses.FindAsync(id);
            if (course == null) return NotFound();
            context.Courses.Remove(course);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
    