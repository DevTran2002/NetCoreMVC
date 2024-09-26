namespace Template.Models
{
    public class Repository
    {
        public static List<StudentDetail> student = new List<StudentDetail>();
        private static int id = 1; // Change id to static
        public static List<StudentDetail> GetStudents()
        {
            return student;
        }

        public static void AddStudent(StudentDetail std)
        {
            std.Id = id++; // This will now work as id is static
            student.Add(std);
        }
        public static StudentDetail? GetStudentById(int id) // Add nullable return type
        {
            return student.FirstOrDefault(e => e.Id == id);
        }
        public static void UpdateStudent(StudentDetail std)
        {
            var existingStudent = GetStudentById(std.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = std.Name;
                existingStudent.Email = std.Email;
                existingStudent.Address = std.Address;
                existingStudent.Phone = std.Phone;
            }
        }
        public static void DeleteStudent(int id)
        {
            var existingStudent = GetStudentById(id);
            if (existingStudent != null)
            {
                student.Remove(existingStudent);
            }
        }
    }
}
