using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebuggingDeadlock
{
    internal class MethodHandler
    {
        //Given Code that causes deadlock .
        //public async Task DeadlockMethod()
        //{
        //    // Note: Do not use .Result or .Wait() in production code.
        //    var result = SomeAsyncOperation().Result;
        //    Console.WriteLine(result.ToString());
        //}
        public async Task<string> SomeAsyncOperation()
        {
            await Task.Delay(1000);
            return "Hello, World";
        }


        //When the SomeAsyncOperation() is called within the Deadlock() the asynchronous task is executed where it awaits a task delay of 1000ms
        //but since we used SomeAsyncOperation().Result it blocks the thread until SomeAsyncOperation() is completed but SomeAsyncOperation() is waiting for the thread to complete .
        //This creates a deadlock which is handled by our code block.

        //Rectified code block that handles the deadlock .
        /// <summary>
        /// Function that awaits for Async task to complete.
        /// </summary>
        /// <returns></returns>
        public async Task DeadlockMethod()
        {
            var result = await SomeAsyncOperation();
            Console.WriteLine(result);
        }
    }
}
