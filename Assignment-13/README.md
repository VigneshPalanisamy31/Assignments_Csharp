# Assignment-13: Understanding and Practicing Collections and Generics in C#

A simple console-based application to understand and work with **Lists**, **Stacks**, **Queues**, **Dictionaries**, and **Generics** in C#.

---

## Task 1 – List of Book Titles

Implemented a program that uses a **List** to store a collection of book titles.

- Created a `List<string>` to hold book titles.
- Operations:
  1. **AddBooks()** – Add books to the list.
  2. **RemoveBook()** – Remove books from the list.
  3. **SearchBook()** – Search for a book in the list.
  4. **DisplayBooks()** – Display all books in the list.

---

## Task 2 – Reverse a String Using Stack

Implemented a program that uses a **Stack** to reverse a given string.
  All characters of the inut string are pushed into the stack.
- Utilized `Stack<char>` for reversing string characters.
- Characters in the stack are popped out to attain the reverse order of the given string.


---

## Task 3 – Queue Simulation

Implemented a program that simulates a queue of people waiting in line.

- Used `Queue<string>` to represent people in a line.
- Operations:
  1. **Enqueue** – Add a person to the queue.
  2. **Dequeue** – Remove the first person from the queue.
  3. **Display** – Display all people currently in the queue.

---

## Task 4 – Student Grade Mapping

Implemented a program that maps a student's name to their grade using a **Dictionary**.

- Used `Dictionary<string, char>` where key = student name and value = grade.
- Students and their respective marks appears to be a key value pair within the Dictionary.

---

## Task 5 – Generic Collections

 In this task, I reviewed all the previous implementations to ensure they use generic collections. Since collections like List<T>, Stack<T>, Queue<T>, and Dictionary<TKey, TValue> were already used in Tasks 1–4 there was no need for updations.

---

## Task 6 – Working with Interfaces

### 1. IEnumerable

- Implemented a function `SumOfElements(IEnumerable<int> numbers)` to calculate the sum of elements.
- Tested this function with:
  - An array
  - A list
  - A queue

### 2. IReadOnlyDictionary

- Created and returned a `Dictionary<string, int>` as an `IReadOnlyDictionary<string, int>`.
- Displayed the dictionary contents.
- Attempted modifications and observed compile-time safety, understanding the **read-only** behavior.

---
