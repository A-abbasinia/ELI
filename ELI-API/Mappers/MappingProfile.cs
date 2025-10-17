using AutoMapper;
using ELI.Entities;
using ELI.Data.DTOs.student;
using ELI.Data.DTOs.teacher;
using ELI.Data.DTOs.course;
using ELI.Data.DTOs.enrollment;

namespace ELI.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Student mappings
        CreateMap<Student, StudentDto>();
        CreateMap<CreateStudentDto, Student>();
        CreateMap<UpdateStudentDto, Student>();

        // Teacher mappings
        CreateMap<Teacher, TeacherDto>();
        CreateMap<CreateTeacherDto, Teacher>();
        CreateMap<UpdateTeacherDto, Teacher>();

        // Course mappings
        CreateMap<Course, CourseDto>()
            .ForMember(dest => dest.Teachername, opt => opt.MapFrom(src => src.Teacher.Username));
        CreateMap<CreateCourseDto, Course>();
        CreateMap<UpdateCourseDto, Course>();

        // Enrollment mappings
        CreateMap<Enrollment, EnrollmentDto>()
            .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.Username))
            .ForMember(dest => dest.CourseTitle, opt => opt.MapFrom(src => src.Course.Title));
        CreateMap<CreateEnrollmentDto, Enrollment>();
        CreateMap<UpdateEnrollmentDto, Enrollment>();
    }
}