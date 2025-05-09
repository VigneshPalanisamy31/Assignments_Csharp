using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ErrorHandling
{
    internal class ErrorHandling
    {

        //Task-5

        static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Console.WriteLine("Unhandled exception caught: " + ex.Message+"\n"+ex.StackTrace+"\n\n");
            Console.WriteLine("----------Stack Trace Interpretation----------\n");
            StackTrace stackTrace = new StackTrace(ex,true);
            StackFrame []frames = stackTrace.GetFrames();
            if(frames!=null)
            {
                foreach (StackFrame frame in frames)
                {
                    MethodBase method = frame.GetMethod();
                    string className = method.DeclaringType!=null?method.DeclaringType.FullName:"Unknown";
                    string methodName= method.Name;
                    string fileName=frame.GetFileName();
                    int lineNumber=frame.GetFileLineNumber();

                    Console.WriteLine($"Class : {className} \nMethod : {methodName} \nLine Number : {lineNumber} \nFilename : {fileName}\n");
                    
                }
                 
            }

           
        }

        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);
            bool exit = false;
            while (!exit)
            {
                try
                {
                    Console.WriteLine("___________Error Handling__________");
                    Console.WriteLine("1.Divide");
                    Console.WriteLine("2.SearchInArray");
                    Console.WriteLine("3.Exit");
                    int.TryParse(Console.ReadLine(),out int _choice);
                    switch (_choice)
                    {
                        case 1:
                            Task1.Divide();
                            break;
                        case 2:
                            Task2.AccessArrayElement(Task2.GetArrayElements());
                            break;
                        case 3:exit = true;
                            break;
                    }
                   

                }
                catch (InvalidUserInputException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }
    }
}
