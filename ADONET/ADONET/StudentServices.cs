using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET
{
    internal class StudentServices
    {
        private static Sql _sql;
        public StudentServices()
        {
            _sql = new Sql();
        }

        public void Add(Students student)
        {
            int result = _sql.ExecuteCommand($"INSERT INTO Students VALUES('{student.name}', '{student.surname}', {student.age})");

            if (result > 0)
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }
        public void Remove(Students student)
        {
            int result = _sql.ExecuteCommand($"DELETE FROM Students WHERE ID = {student.id}");

            if (result > 0)
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }
        public List<Students> GetAll()
        {
            List<Students> students = new List<Students>();

            DataTable dataTable = _sql.ExecuteQuery("SELECT * FROM Students");

            foreach (DataRow row in dataTable.Rows)
            {
                Students student = new Students
                {
                    id = (int)(row["ID"]),
                    name = row["Name"].ToString(),
                    surname = row["Surname"].ToString(),
                    age = Convert.ToInt32(row["Age"])
                };
                students.Add(student);
            }
            return students;
        }
        public Students GetID(int id)
        {
            DataTable dataTable = _sql.ExecuteQuery($"SELECT * FROM Students WHERE ID = {id}");

            Students student = new Students();

            foreach (DataRow row in dataTable.Rows)
            {
                student.id = (int)(row["ID"]);
                student.name = row["Name"].ToString();
                student.surname = row["Surname"].ToString();
                student.age = Convert.ToInt32(row["Age"]);
            }
            return student;
        }
        public void Update(Students student)
        {
            int result = _sql.ExecuteCommand($"UPDATE Students SET Name = {student.name}, Surname = {student.surname}, Age = {student.age} WHERE ID = {student.id}");

            if (result > 0)
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }
}