using System.Collections.Immutable;

class Subject
{
    //(Code, Name) 
    public int Code { get; set; }
    public string Name { get; set; }
}
class Student
{//(ID, FirstName, LastName , Subject [])
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ID { get; set; }
    public Subject [] Subjects {  get; set; }

}
namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region task1


            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };
            var q1 = numbers.OrderBy(item => item).Distinct();
            foreach (var i in q1) {
                Console.WriteLine(i);
            }
            Console.WriteLine("__________________________________________");
            foreach (var i in q1)
            {
                Console.WriteLine($"the Number =  {i}  , Multiply = {i * i}");
            }

            #endregion
            #region task2
            Console.WriteLine("___________________________");
            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };

            var q3 = names.Select(item => item);
            foreach (var i in q3) {
                if (i.Length == 3)

                    Console.WriteLine(i);
            }
            Console.WriteLine("___________________________");
            var q4 = names.Where(item => item.Contains('a') || item.Contains("A")).OrderBy(item => item.Length);

            foreach (var i in q4) {
                Console.WriteLine(i);
            }
            Console.WriteLine("___________________________");
            var q5 = names.Take(2);
            foreach (var i in q5) {
                Console.WriteLine(i);
            }

            #endregion

            #region TASK 3
            List<Student> students = new List<Student>(){new Student(){ ID=1, FirstName="Ali", LastName="Mohammed",Subjects=new Subject[]{ new Subject(){ Code=22,Name="EF"}, new Subject(){Code=33,Name="UML"}}},
                new Student(){ ID=2, FirstName="Mona", LastName="Gala",Subjects=new Subject []{ new Subject(){ Code=22,Name="EF"}, new Subject (){Code=34,Name="XML"},new Subject (){ Code=25, Name="JS"}}},
                new Student(){ ID=3, FirstName="Yara", LastName="Yousf", Subjects=new Subject[]{ new Subject (){ Code=22,Name="EF"}, new Subject (){Code=25,Name="JS"}}},
                 new Student(){ ID=1, FirstName="Ali", LastName="Ali",Subjects=new Subject []{ new Subject (){ Code=33,Name="UML"}}},

 };
            Console.WriteLine("--------------------------");
            var q6 = students.Select(x => new { FullName = x.FirstName + " " + x.LastName, NOOfSubjects = x.Subjects.Count() });
            foreach (var student in q6)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("--------------------------");
            var q7 = students.OrderByDescending(x => x.FirstName).ThenBy(x => x.LastName).Select(x => x.FirstName + "  " + x.LastName);
            foreach (var student in q7)
            { Console.WriteLine(student); }
            Console.WriteLine("--------------------------");
            var q8 = students.SelectMany(Z =>Z.Subjects,( X,Y)=>new { StudentName = X.FirstName + " " + X.LastName, SubjectName = Y.Name});
            foreach (var student in q8)
            {
            Console.WriteLine(student);
            }
            Console.WriteLine("--------------------------");
            var q9 = students.SelectMany(Z => Z.Subjects, (X, Y) => new { StudentName = X.FirstName + " " + X.LastName, SubjectName = Y.Name }).GroupBy(
        result => result.StudentName);
            foreach (var student in q9)
            {
                Console.WriteLine($"{student.Key}");
                foreach (var subject in student)
                {
                    Console.WriteLine($"    {subject.SubjectName}");

                }
            }

            #endregion

        }
    }
}
