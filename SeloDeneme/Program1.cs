using System;
using System.IO;
namespace GradeCalculation
{
    public class data {
        public string name;
        public string surname;
        public string[] lesson; //Classta bilgileri tutma ve kullanma
        public int[] midterm;
        public int[] final;
        public int[] share;
        public double[] avg;
        public double ovrAvg;


    public  void avgCalculate() //Oluşturulan classta yeni method ile ortalama hesaplama ve kaydetme
        {
            ovrAvg = 0;
            for (int i = 0; i < lesson.Length; i++)
            {
                avg[i] = (midterm[i] * 1.0 * (share[i] *1.0 /100)) + (final[i] * 1.0 * (1 - (share[i] * 1.0 / 100)));
                ovrAvg += avg[i];
            }
            

        }


    }
    class Program
    {

        static void Main(string[] args)
        {
            data data = new data();
            string x = " ";
            Console.WriteLine("Enter your name");
            data.name = Console.ReadLine();
            Console.WriteLine("Enter your surname");
            data.surname = Console.ReadLine();
            Console.WriteLine("How many lesson will you enter?");
            int lessonNumber = Convert.ToInt32(Console.ReadLine());
            data.lesson = new string[lessonNumber];
            data.midterm = new int[lessonNumber];      //Creating array elements as many as the number entered by the user
            data.final = new int[lessonNumber];
            data.share = new int[lessonNumber];
            data.avg = new double[lessonNumber];
            for (int i = 0; i < data.lesson.Length; i++)
            {
                Console.WriteLine((i+1)+". Lesson :"); //Retrieving and Saving Course Names
                data.lesson[i] = Console.ReadLine();
            }
            for (int i = 0; i < data.lesson.Length; i++)
            {
                while (true)
                {
                    Console.WriteLine(data.lesson[i] + " lesson percent share:"); //Asking the user for percentage points to be effective
                    data.share[i] = Convert.ToInt32(Console.ReadLine());
                    if (data.share[i] < 0 || data.share[i] > 100) //If the user enters a number less than 0 or greater than 100,
                                                                  //re-enter the number and repeat until correct
                    {
                        Console.WriteLine("Enter a number between 0 and 100");
                    }
                    else
                    {
                        break;
                    }
                }
                while (true)
                {
                    Console.WriteLine(data.lesson[i] + " lesson midterm note:");
                    data.midterm[i] = Convert.ToInt32(Console.ReadLine());
                    if (data.midterm[i] < 0 || data.midterm[i] > 100)
                    {
                        Console.WriteLine("Enter a number between 0 and 100");
                    }
                    else
                    {
                        break;
                    }
                }
                while (true)
                {
                    Console.WriteLine(data.lesson[i] + " lesson final note:");
                    data.final[i] = Convert.ToInt32(Console.ReadLine());
                    if (data.final[i] < 0 || data.final[i] > 100)
                    {
                        Console.WriteLine("Enter a number between 0 and 100");
                    }
                    else
                    {
                        break;
                    }
                }

                

            }
            data.avgCalculate(); //Average calculation by calling method



            Console.WriteLine("------------------------------\nName :"+data.name+"\nSurname :"+data.surname);
            for (int i = 0; i < data.avg.Length; i++)
            {
                if (data.avg[i] <=100 && data.avg[i] >=90) //Letter grade by average range
                {
                    x = "AA";
                }
                else if (data.avg[i] < 90 && data.avg[i] >= 80)
                {
                    x = "BB";
                }
                else if (data.avg[i] < 80 && data.avg[i] >= 70)
                {
                    x = "CC";
                }
                else if (data.avg[i] < 70 && data.avg[i] >= 60)
                {
                    x = "DD";
                }
                else if (data.avg[i] < 60 && data.avg[i] >= 50)
                {
                    x = "EE";
                }
                else if (data.avg[i] < 50 && data.avg[i] >= 0)
                {
                    x = "FF Fail";
                }
                Console.WriteLine(data.lesson[i]+" Lesson Average : " + data.avg[i] +" "+x);
                

            }

            Console.WriteLine("Overall Average : " + (data.ovrAvg * 1.0) / (25 * lessonNumber));

            Console.WriteLine("Do you want to print information? Y or N");
                string control = Console.ReadLine().Trim();
                if (control == "y")

            {
                Console.WriteLine("Enter File Name");
                string fileName = Console.ReadLine();
                Console.WriteLine("Enter username registered on the computer");
                string userName = Console.ReadLine();
                string filePath = @"C:\Users\"+userName+@"\Downloads\" + fileName + @".txt";
                if (!File.Exists(filePath))  //Is there a file with this name?
                {
                    using(StreamWriter sw = File.CreateText(filePath)) //If there isn't, create a new file
                    {
                        sw.WriteLine("------------------------------\nName :" + data.name + "\nSurname :" + data.surname);
                        for (int i = 0; i < data.avg.Length; i++)
                        {
                            if (data.avg[i] <= 100 && data.avg[i] >= 90) //Letter grade by average range
                            {
                                x = "AA";
                            }
                            else if (data.avg[i] < 90 && data.avg[i] >= 80)
                            {
                                x = "BB";
                            }
                            else if (data.avg[i] < 80 && data.avg[i] >= 70)
                            {
                                x = "CC";
                            }
                            else if (data.avg[i] < 70 && data.avg[i] >= 60)
                            {
                                x = "DD";
                            }
                            else if (data.avg[i] < 60 && data.avg[i] >= 50)
                            {
                                x = "EE";
                            }
                            else if (data.avg[i] < 50 && data.avg[i] >= 0)
                            {
                                x = "FF Fail";
                            }
                            sw.WriteLine(data.lesson[i] + " Lesson Average : " + data.avg[i] + " " + x);
                            
                        }
                        sw.WriteLine("Overall Average : " + (data.ovrAvg * 1.0) / (25 * lessonNumber));
                    }
                }
                {

                }
            }
            else
            {
                Console.WriteLine("Program is Closing...");
            }
            
            
            
        }
    }

}