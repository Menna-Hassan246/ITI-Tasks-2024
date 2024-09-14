using System;

namespace task4
{
    #region poly 
   
    struct poly
    {
       public int sum(int x,int y) { 
           return x+y;
       }
    
       public float sum(float x, int y)
       {
           return x + y;
       }
    public float sum(int x, float y)
     {
          return x + y;
        }

    }
    #endregion
    #region cal
    class cal
    {
        #region sum
        public int sum(int x,int y,int z)
        {
            return x+ y + z;
        }
        public int sum(int x, int y)
        {
            return x + y ;
        }
        public float sum(float x, int y)
        {
            return x + y;
        }
        public float sum( int x,float y)
        {
            return x + y;
        }
        #endregion
        #region div
        public double div(double x, double y) {
            return x / y;
        }
        public double div(int x, double y)
        {
            return x / y;
        }
        public double div(double x,int y )
        {
            return x / y;
        }
        public int div(int x, int y)
        {
            return x/ y;
        }

        #endregion
    }
    #endregion
    #region student
    class student
    {
        int id;
        int age;
        string name;
        public student(int id, int age, string name)
        {
            this.age = age;
            this.id = id;
            this.name = name;
        }
        public student(int id, int age) : this(id, age, "mennna") { }
        public student(int id) : this(id, 50, "mennna") { }
        public student() : this(12345, 50, "mennna") { }

        public int Id { set; get; }
        public int Age { set{ age = value; } get{ return age; } }

        public string Name { set{ name = value; } get{ return name; }}
    }

        #endregion


        internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("the result of sum ");
            cal cal = new cal();
            Console.WriteLine(cal.sum(17.5f, 2));
            Console.WriteLine(cal.sum(2, 2.5f));
            Console.WriteLine(cal.sum(3, 3));
            Console.WriteLine(cal.sum(3, 6, 9));
            Console.WriteLine("the result of sum ");
            Console.WriteLine(cal.div(18.0, 3.0));
            Console.WriteLine(cal.div(18.0, 6));
            Console.WriteLine(cal.div(18, 3.0));
            Console.WriteLine(cal.div(18, 9));
            Console.WriteLine("the result of CON this ");
            student st = new student();
            student s = new student(1678);
            student t = new student(5678, 67);
            student r = new student(9999, 99, "emly");
            r.Id = 12;
            r.Name = "menna";
            r.Age = 90;
            Console.WriteLine(st.Id);
            Console.WriteLine(st.Age);
            Console.WriteLine(st.Name);
            Console.WriteLine("---------------------------");
            Console.WriteLine(s.Id);
            Console.WriteLine(s.Age);
            Console.WriteLine(s.Name);
            Console.WriteLine("---------------------------");
            Console.WriteLine(t.Id);
            Console.WriteLine(t.Age);
            Console.WriteLine(t.Name);
            Console.WriteLine("---------------------------");
            Console.WriteLine(r.Id);
            Console.WriteLine(r.Age);
            Console.WriteLine(r.Name);
            Console.WriteLine("pilese enter the size ");
            int size= int.Parse(Console.ReadLine());
            student[] stu = new student[size]; 
            for(int i = 0; i < size; i++)
            {
                stu[i]= new student();
                Console.WriteLine($"please  enter  id of the student {i+1}:");
                stu[i].Id=int.Parse(Console.ReadLine());
                Console.WriteLine($"please  enter  age of the student {i + 1}:");
                  stu[i].Age = int.Parse(Console.ReadLine());
                Console.WriteLine($"please  enter  Name of the student {i + 1}:");
                stu[i].Name =(Console.ReadLine());
            }
            for (int i = 0; i < size; i++)
            {
               
                Console.WriteLine($"*******************\nthe data  of the student {i + 1}:");
                Console.WriteLine(stu[i].Id + " " + stu[i].Age + " " + stu[i].Name);



             
            }



        }
    }
}
