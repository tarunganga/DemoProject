

namespace Demo.DataModel
{
    public class StudentService : IStudentService
    {
        public Guid AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(Guid id)
        {
            throw new NotImplementedException();
        }

        public void GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Student GetStudent(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        List<Student> IStudentService.GetAllStudents()
        {
            throw new NotImplementedException();
        }
    }
}
