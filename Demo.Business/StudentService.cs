using Demo.Contracts.Models;
using Demo.DataModel;

namespace Demo.Business
{
    public class StudentService(UniversityContext universityContext) : IStudentService
    {
        public Guid AddStudent(StudentRequest student)
        {
            var studentEntity = new Student(student);
            universityContext.Students.Add(studentEntity);
            return studentEntity.Id;
        }

        public void DeleteStudent(Guid id)
        {
            var existingStudent = universityContext.Students.Find(id);

            if (existingStudent != null)
            {
                universityContext.Students.Remove(existingStudent);
                universityContext.SaveChanges();
            }

        }

        public List<StudentContract> GetAllStudents()
        {
            return
            [
                .. universityContext.Students.Select(s => new StudentContract
                {
                    Id = s.Id,
                    Name = s.Name,
                    Age = s.Age,
                    Grade = s.Grade
                })
            ];
        }

        public StudentContract GetStudent(Guid id)
        {
            var student = universityContext.Students.Find(id);
            if (student != null)
            {
                return student.AsStudentContract();
            }
            else
            {
                throw new Exception("Student not found");
            }
        }

        public void UpdateStudent(Guid id, StudentRequest student)
        {
            var existingStudent = universityContext.Students.Find(id);

            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Age = student.Age;
                existingStudent.Grade = student.Grade;
                existingStudent.LastUpdatedAt = DateTime.UtcNow;
            }

            universityContext.SaveChanges();
        }
    }
}
