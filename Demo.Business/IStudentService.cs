using Demo.Contracts.Models;

namespace Demo.Business
{
    public interface IStudentService
    {
        List<StudentContract> GetAllStudents();
        StudentContract GetStudent(Guid id);
        Guid AddStudent(StudentRequest student);
        void UpdateStudent(Guid id, StudentRequest student);
        void DeleteStudent(Guid id);
    }
}
