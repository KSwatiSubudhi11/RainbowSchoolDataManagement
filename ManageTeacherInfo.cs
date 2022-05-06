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
                        if (File.Exists(path))
                        {
                            Console.WriteLine("Teacher Details::" + "\n");
                            string[] stud = File.ReadAllLines(path);
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
                        if (!File.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                            File.Create(fullPath);
                        }
                        details = File.ReadAllText(fullPath);
                        Console.WriteLine("Enter details in this format: Id, Name, Class, Section:");
                        string teach = Console.ReadLine();

                        File.WriteAllText(path, details + "\n" + teach);
                        break;

                    case "3":
                        if (!File.Exists(path))
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

                            //string[] subArray = teacher.Split(',');


                            //Teacher teachObj = new Teacher();
                            //teachObj.Id = subArray[0];
                            //teachObj.Name = subArray[1];
                            //teachObj.Class = subArray[2];
                            //teachObj.Section = subArray[3];
                            //list.Add(teachObj);

                            for(int i = 0; i < teacherList.Length; i++)
                            {
                                File.WriteAllText(path, teacherList[i]);
                            }
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