# Assignment-15: Working with Files and Streams in C#

A hands-on assignment to understand how to work with files, streams, and asynchronous operations in C#.

---

## Task 1: Implement a File Data Processor

- Implemented a program that reads data from a source file, processes it, and writes the processed data to a new file.
- Key Features:
  1. Reads data from a large file (created for testing).
  2. Uses **`BufferedStream`** and **`FileStream`** for efficient reading.
  3. Processes the data read from the file.
  4. Writes processed data to a new file using **`MemoryStream`**.

---

## Task 2: Implement a File Data Processor with Asynchronous Methods

- Implemented a fully **asynchronous version** of the file data processor.
- Key Features:
  1. Used **`async`/`await`** with `FileStream`, `MemoryStream`, and `BufferedStream`.
  2. Compared **synchronous** and **asynchronous** execution performance.
  3. Observed how asynchronous methods improve responsiveness and performance in large-scale file operations.

---

## Task 3: Investigate Issues in Basic File Usage

- Investigated a starter code with memory and performance inefficiencies.
- Key Actions:
  1. **Identified issues** like unnecessary buffering, improper stream disposal, and blocking operations.
  2. **Fixed memory issues** by using proper stream handling and disposing patterns (`using` statements).
  3. Improved code efficiency and ensured safe file operations.

---

## Task 4: Analyze and Resolve Performance Issues in a Logging System for Multiple Users

- Investigated and improved a concurrent logging system to ensure thread safety and performance.
- Key Actions:
  1. Identified **concurrency issues** in file access.
  2. Improved file writing using proper locking mechanisms or asynchronous file writing.
  3. Ensured each user's logs are written to **independent error files** to avoid conflicts.

---

Through this assignment, a comprehensive understanding of **streams, buffering, async file I/O**, and **thread-safe logging** in C# was achieved.
