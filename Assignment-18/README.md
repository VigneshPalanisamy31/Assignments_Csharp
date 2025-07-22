# Assignment-18: Async/Await, Task Parallel Library, and Multi-Threading in C#

A set of console-based projects to understand and experiment with **asynchronous programming**, **parallelism**, and **multi-threading** in C#. 

---

## Task 1 - Async/Await with HttpClient

Implemented a program that uses **Async/Await** to download content from a URL.

- Created an async method using `HttpClient.GetStringAsync()`.
- Used `await` in the `Main` method to asynchronously fetch and display content.
- Ensured responsiveness of the console app during download.
---

## Task 2 - Task Parallel Library (TPL) with Parallel.ForEach

Implemented a program that uses **Task Parallel Library** to process data concurrently.

- Created an array of integers from 1 to 10,000.
- Used `Parallel.ForEach` to square each number.
---

## Task 3 - Multi-Threading with Thread Class

Implemented a program that demonstrates the use of **Thread** and `Join()` to run tasks in parallel.

- Defined multiple operations like sorting arrays and arithmetic computations.
- Used `Thread` class to run each operation in parallel.
- Used `Join()` to synchronize and combine the results after execution.
---

## Task 4 - Multi-Layered Async Operations

Simulated a real-world async flow with nested async calls and CPU-bound operations.

- `MethodA`: CPU-bound task using `Task.Run()` (e.g., large dataset analysis).
- `MethodB`: Async method that calls `MethodA` and makes an API call using its result.
- `MethodC`: Final async method that parses the API response.
---

## Task 5 - Fixing a Deadlock

Investigated a deadlock issue due to blocking on async code using `.Result`.

- Analyzed and modified `DeadlockMethod()` to use proper `await`.
- Avoided calling `.Result` on the main thread.
- Ensured `"Hello, World!"` is printed after `Task.Delay()` without deadlocking.
---

## Task 6 - ConfigureAwait(false) and Thread Context Tracking

Explored thread context switching with `ConfigureAwait(false)`.

- `MethodA`: Simulated long-running operation using `Task.Delay()`.
  - Printed `Thread.CurrentThread.ManagedThreadId` before and after `await`.
  - Used `ConfigureAwait(false)` to allow resuming on a different thread.
- `MethodB`: Awaited `MethodA` and performed additional processing.
---

## Task 7 - Async Void vs Async Task and Exception Handling

Demonstrated the **difference in exception handling** between `async void` and `async Task`.

- `VoidMethod`: Throws an exception in an `async void` method (uncatchable).
- `TaskMethod`: Throws an exception in an `async Task` method (catchable).
- Used try-catch blocks in `Main` to observe different behaviors.
- Understood why `async void` should be used **only for event handlers**.


