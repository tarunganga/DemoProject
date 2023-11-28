namespace ClassLibrary1
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        Student GetStudent(Guid id);
        Guid AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Guid id);


    }
}
