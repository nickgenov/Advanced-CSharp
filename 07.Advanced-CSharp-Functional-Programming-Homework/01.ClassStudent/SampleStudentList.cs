using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SampleStudentList
{
    static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student("Ivan", "Georgiev", 20, 700017525, "0885235625", "igeorgiev@gmail.com", new List<int> { 4, 5, 5, 5, 5, 4, 4, 3 }, 1),
            new Student("Petar", "Angelov", 34, 700017501, "0885232585", "pangelov@gmail.com", new List<int> { 6, 6, 5, 5, 6, 4, 6, 4 }, 2),
            new Student("Maria", "Ivanova", 26, 700017230, "0886955628", "m.ivanova@hotmail.com", new List<int> { 6, 5, 5, 5, 3, 4 }, 1),
            new Student("Stamat", "Stamatov", 30, 700035250, "0888524563", "stamat@gmail.com", new List<int> { 6, 6, 5, 5, 3, 4 }, 2),
            new Student("Minka", "Petkova", 22, 700017620, "0885285288", "mincheto@abv.bg", new List<int> { 4, 4, 3, 5, 6, 3 }, 3),
            new Student("Kiril", "Mihaylov", 32, 700036623, "0888556874", "Kiril.Mihaylov@gmail.com", new List<int> { 4, 5, 5, 4, 4, 2 }, 1),
            new Student("Pencho", "Penchev", 27, 700036120, "0888886622", "pencho19@gmail.com", new List<int> { 4, 3, 5, 4, 6, 4 }, 3),
            new Student("Nikolay", "Rosenov", 33, 700017932, "0888387971", "nickros@gmail.com", new List<int> { 6, 6, 6, 5, 6 }, 3),
        };

        foreach (var student in students)
        {
            Console.WriteLine("{0} {1} is {2} years old.", student.FirstName, student.LastName, student.Age);
        }
    }
}