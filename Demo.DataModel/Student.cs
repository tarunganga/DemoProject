using Demo.Contracts.Models;

namespace Demo.DataModel
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }


        public Student(StudentRequest studentRequest)
        {
            Id = Guid.NewGuid();
            Name = studentRequest.Name;
            Age = studentRequest.Age;
            Grade = studentRequest.Grade;
            CreatedAt = DateTime.Now;
            LastUpdatedAt = DateTime.Now;
        }

        public StudentContract AsStudentContract()
        {
            return new StudentContract
            {
                Id = Id,
                Name = Name,
                Age = Age,
                Grade = Grade
            };
        }
             
    }
}
