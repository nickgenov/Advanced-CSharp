using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FilterStudentsByEmailDomain
{
    static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student("Zdravko", "Georgiev", 17, 700017525, "0885235625", "igeorgiev@gmail.com", new List<int> { 4, 5, 5, 5, 5, 4, 4, 3 }, 1),
            new Student("Zdravko", "Angelov", 34, 700017501, "0885232585", "zangelov@abv.bg", new List<int> { 6, 6, 5, 5, 6, 4, 6, 4 }, 2),
            new Student("Maria", "Ivanova", 18, 700017230, "0886955628", "m.ivanova@abv.bg", new List<int> { 6, 5, 5, 5, 3, 4 }, 1),
            new Student("Maria", "Angelova", 30, 700035250, "0888524563", "stamat@gmail.com", new List<int> { 6, 6, 5, 5, 3, 4 }, 2),
            new Student("Kiril", "Yakimov", 22, 700017620, "0885285288", "yakimov88@abv.bg", new List<int> { 4, 4, 3, 5, 6, 3 }, 3),
            new Student("Kiril", "Mihaylov", 32, 700036623, "0888556874", "Kiril.Mihaylov@gmail.com", new List<int> { 4, 5, 5, 4, 4, 2 }, 1),
            new Student("Anelia", "Borisova", 24, 700036120, "0888886622", "pencho19@gmail.com", new List<int> { 4, 3, 5, 4, 6, 4 }, 3),
            new Student("Anelia", "Angelova", 33, 700017932, "0888387971", "nickros@gmail.com", new List<int> { 6, 6, 6, 5, 6 }, 3),
        };

        var studentQuery =
            from student in students
            where student.Email.Contains("@abv.bg")
            select new { student.FirstName, student.LastName, student.Email };

        foreach (var student in studentQuery)
        {
            Console.WriteLine("{0} {1}'s email is {2}", student.FirstName, student.LastName, student.Email);
        }
    }
}