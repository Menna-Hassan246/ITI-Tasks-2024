namespace task5
{
    #region inheritance
    abstract class question
    {
        public int mark { get; set; }
        public string header { get; set; }
        public string body { get; set; }
        public abstract void display();
    }
    class mcq : question
    {
        public new string mark { get; set; }
        //mcq() { }
        public override void display()
        {
            Console.WriteLine($"{header} \n{body}\n {mark}");
        }
    }
    class true_false : question
    {
        public new Boolean mark { get; set; }
        public override void display()
        {
            Console.WriteLine($"{header}\n{body}\n{mark}");
        }
    }
    class complete : question
    {
        public new string mark { get; set; }

        public override void display()
        {
            Console.WriteLine($"\n{header} \n{body} \n{mark}");
        }
    }
    #endregion
    #region demo
    class parent
    {
        public string name { get; set; }
        public int age { get; set; }
       public parent (string name,int age)
        {
            this.name = name;
            this.age = age;
        }
        public virtual void display()
        {
            Console.WriteLine($"the data are :{name}  , {age}");
        }
    }
    class child : parent
    {
        public int id { get; set; }
        public  child(string name,int age,int id) :base (name,age)   
        {
            
            this .id= id;

        }
       
        public override void display()
        {
            Console.WriteLine($"the data are :{id}  ,{name}  , {age}");
        }
    }
    class sub_class : child
    {
        public sub_class(string name,int age ,int id ,int ssn): base(name,age,id)
        {
            this.ssn=ssn;
        }
        public int ssn { get; set; }
        public new void display()
        {
            Console.WriteLine($"the data are :SSN:{ssn}, ID:{id} ,Name:{name},Age:{age}");
        }
    }
    #endregion
    #region static 
    static class calc
    {
        static public int sum(int x, int y)
        {
            return x + y;
        }
        static public int sub(int x, int y)
        {
            return x - y;
        }
        static public int div(int x, int y)
        {
            return x / y;
        }
        static public int mul(int x, int y)
        {
            return x * y;
        }
    }

    #endregion
    #region sealed 
    sealed class test
    {
        public int key { get; set; }
        public void display()
        {
            Console.WriteLine($" your key is :{key}");
        }
    }

    #endregion
    #region student
    class student
    {
        public string name { get; set; }
        public int age { get; set; }
        static public int id = 0;
        public void display()
        {
            id++;
            Console.WriteLine($" the id is :{id} the student name is:{name}  and its age is:{age}");
        }
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            mcq a=new mcq();
            a.header = "chose  about this question";
            a.body = "is the earth  is oval or rectangle?";
            a.mark = "oval";
            a.display();
            true_false b=new true_false();
            b.header = "answer true or false about this question";
            b.body = "is the ant the smallest insects ";
            b.mark = true;
            b.display();
            complete c=new complete();
            c.header = "complete !!!!";
            c.body = " the fastest animal is :";
            c.mark = "sheetah";
            c.display();
            parent d = new child("menna",70,1);
            d.display();
            parent e = new sub_class("huda", 90, 2, 234);
            e.display();

            Console.WriteLine("************************************");
            Console.WriteLine($"sum is: {calc.sum(5, 7)}");
            Console.WriteLine($"division is:{calc.div(10, 5)}");
            Console.WriteLine($"multiplication is :{calc.mul(3, 6)}");
            Console.WriteLine($"subtraction is :{calc.sub(7, 5)}");
            Console.WriteLine("************************************");
            student f= new student();
            f.name = "hany";
            f.age = 88;
            f.display();
            f.name = "kareem";
            f.age = 30;
            f.display();
        }
    }

}

