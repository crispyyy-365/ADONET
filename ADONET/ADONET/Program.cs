namespace ADONET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentServices studentServices = new StudentServices();

            Students student1 = new Students { name = "Huseyn", surname = "Abbasov", age = 19 };
            Students student2 = new Students { name = "Nihat", surname = "Abbasov", age = 18 };
            Students student3 = new Students { name = "Slippin", surname = "Jimmy", age = 45 };

            studentServices.Add(student1);
            studentServices.Add(student2);
            studentServices.Add(student3);

            studentServices.Remove(student3);

            List<Students> students = studentServices.GetAll();

            student1.name = "Milo";
            student1.surname = "Aukerman";

            studentServices.Update(student1);

            foreach (Students student in students)
            {
                Console.WriteLine($"{student.id} {student.name} {student.surname} {student.age}");
            }

            Students studentgotID = studentServices.GetID(2);

            Console.WriteLine(studentgotID.id + " " + studentgotID.name + " " + studentgotID.surname + " " + studentgotID.age);
        }
    }
}