using CRUDApi.Models;
namespace CRUDApi.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        private static List<Student> students = new List<Student>
        {
            new Student{Id=1,Name="Alice",Age=20},
            new Student{Id=2,Name="Indra",Age=22}

        };
        public List<Student> GetAll()
        {
            return students;
        }
        public Student GetById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
        public void Add(Student student)
        {
            var existing = students.FirstOrDefault(s => s.Id == student.Id);
            if (existing != null)
            {
                existing.Name = student.Name;
                existing.Age = student.Age;
                existing.IsActive = true;
            }
        }
        public void Update(Student student)
        {
            var existing=students.FirstOrDefault(s=>s.Id==student.Id)
        }
        public void Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                student.IsActive=false;
            }
        }

    }
}
