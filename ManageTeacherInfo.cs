using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowSchoolDataManagement
{
    public class ManageTeacherInfo
    {
        public void ManageTeacherData()
        {
            string details;
            bool t = true;
            string path = Directory.GetCurrentDirectory()+"\\Test";
            string fullPath = path+"\\Teacher.txt";
            

            while (t)
            {
                Console.WriteLine("Enter a No. to execute:");
                Console.WriteLine("1. View Teacher Info");
                Console.WriteLine("2. Add Teacher Info");
                Console.WriteLine("3. Update Teacher Info");
                Console.WriteLine("4. Exit");
                string n = Console.ReadLine();

                if (n == "4")
                {
                    t = false;
                    break;
                }
                switch (n)
                {
                    case "1":
                        if (File.Exists(fullPath))
                        {
                            Console.WriteLine("Teacher Details::" + "\n");
                            string[] stud = File.ReadAllLines(fullPath);
                            foreach (string line in stud)
                            {
                                Console.WriteLine(line);
                            }

                        }
                        else
                        {
                            Console.WriteLine("No Teacher Details available for display.");
                        }

                        break;
                    case "2":
                        if (!File.Exists(fullPath))
                        {
                            Directory.CreateDirectory(path);
                            File.Create(fullPath);
                        }
                        details = File.ReadAllText(fullPath);
                        Console.WriteLine("Enter details in this format: Id, Name, Class, Section:");
                        string teach = Console.ReadLine();

                        File.WriteAllText(fullPath, details + "\n" + teach);
                        break;

                    case "3":
                        if (File.Exists(fullPath))
                        {
                            string teacher = String.Empty;
                            Console.WriteLine("Enter Teacher Id to Update:");
                            string teacherId = Console.ReadLine();

                            details = File.ReadAllText(fullPath);
                            string[] teacherList = details.Split('\n');
                            List<string> list = teacherList.ToList();

                            for (int i =0; i < teacherList.Length; i++)
                            {
                                if(teacherList[i].Split(',')[0] == teacherId)
                                {
                                    Console.WriteLine("Enter details in this format: Id, Name, Class, Section:");
                                    teacher = Console.ReadLine();
                                    teacherList[i] = teacher;
                                }
                            }

                            if (teacher == String.Empty)
                            {
                                Console.WriteLine("Invalid Teacher Id.");
                                return;
                            }
                            details = string.Empty;
                            for (int i = 0; i < teacherList.Length; i++)
                            {
                                details = details+'\n'+teacherList[i];
                            }
                            File.WriteAllText(fullPath, details);
                        }
                        else
                        {
                            Console.WriteLine("No Teacher Data available to update");
                        }
                        break;

                    case "4":
                        return;
                }
            }
        }
    }
}