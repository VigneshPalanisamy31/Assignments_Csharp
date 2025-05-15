# Understanding .NET platform

1. [Explain what the .NET platform is and its primary purpose ](#explain-what-the-net-platform-is-and-its-primary-purpose)
2. [What are the key components of the .NET platform](#2-what-are-the-key-components-of-the-net-platform)
3. [Differentiate between the Common Language Runtime (CLR) and the Common Type System (CTS) in .NET](#3-differentiate-between-the-common-language-runtime-clr-and-the-common-type-system-cts-in-net)
4. [What is the role of the Global Assembly Cache (GAC) in .NET](#4-what-is-the-role-of-the-global-assembly-cache-gac-in-net)
5. [Explain the difference between value types and reference types in C#](#5-explain-the-difference-between-value-types-and-reference-types-in-c)
6. [Describe the concept of garbage collection on .NET and its advantages](#6-describe-the-concept-of-garbage-collection-on-net-and-its-advantages)
7. [What is the purpose of the Globalization and Localization features in .NET](#7-what-is-the-purpose-of-the-globalization-and-localization-features-in-net)
8. [Explain the role of the Common Intermediate Language (CIL) and Just-In-Time (JIT) compilation in the .NET framework](#8-explain-the-role-of-the-common-intermediate-language-cil-and-just-in-time-jit-compilation-in-the-net-framework)
## EXPLORATION QUESTIONS :

### 1. Explain what the .NET platform is and its primary purpose. 

.Net is a software development framework that provides a runtime environment and development tools for building and running applications on Windows. Supports programming languages like C#, F#,VB.Net and supports variety of applications including desktop ,web ,cloud gaming etc ..

### 2. What are the key components of the .NET platform

- Main Components :
    1. Common Language Runtime (CLR)
    2. Framework Class Library (FCL)
        
- Common Language Runtime (CLR)
     acts as a virtual machine that runs the code and manages various services like memory management , security ,thread management .

- Framework Class Library(FCL)
     provides all resuable classes and functions for application development.
     This includes libraries for input/output operation ,networking ,data access ,UI controls etc... 

### 3. Differentiate between the Common Language Runtime (CLR) and the Common Type System (CTS) in .NET

  - CLR
      Common Language Runtime is a virtual machine that runs the code . It handles  memory management, security, thread management . It is responsible for execution of code .

  - CTS
      Common Type System describes the data types that can be used in managed code . It defines  how these data types are declared , used and managed in runtime. 
      For example , C# uses the keyword int to declare an integer but in VB.Net it is declared with keyword Integer .So after compilation both codes utilize the same structure Int32 from CTS . CTS ensures type safety and compatibility across multiple .Net languages

### 4. What is the role of the Global Assembly Cache (GAC) in .NET

   - GAC Global Assembly Cache is a machine-wide code cache . Every system that has CLR installed in it will have GAC . GAC stores the shared assemblies that are specifically shared by several applications. GAC shares assemblies , avoids duplication and version conflicts .
   - Ways to deploy an assembly into GAC
        1. Use an installer designed to work with the Global Assembly Cache
        2. Use a developer tool called the Global Assembly Cache tool (Gacutil.exe), provided by the Windows SDK.

### 5. Explain the difference between value types and reference types in C#. 

   - Value Type variables can be assigned a value directly. They are derived from the class System.ValueType. The value types directly contain data. When you declare an int type, the system allocates memory to store the value.
   - Examples : int , float , char , bool , enum .

   - Reference types store a reference (address) to the actual data, which is stored in the heap.
   variables hold reference and not the actual data .

   - Examples : string , arrays , classes , delegates . 

### 6. Describe the concept of garbage collection on .NET and its advantages
   - Garbage Collection in .NET is an automatic memory management feature provided by the CLR. It automatically frees up memory used by objects that are no longer accessible or needed by the application.

   - Working

     1. Allocation: When a new object is created using new, memory is allocated from the managed heap.

     2. Tracking: The .NET runtime tracks references to each object.

     3. Garbage Collection: When there is low memory or enough unused objects:

Garbage Collector identifies unreferenced objects and frees up the memory used by these objects.

### 7. What is the purpose of the Globalization and Localization features in .NET 

   - Globalization is the process of designing applications that can handle different cultures. By adding support for input, display, and output in specific languages related to specific geographical areas, globalization makes it easier for people from around the world to use these apps.

   - Localization is the process of translating content to match the specific needs of a certain culture or language. This includes transcribing text, as well as formatting numbers, dates and times, using different currencies, and employing various symbols.

### 8. Explain the role of the Common Intermediate Language (CIL) and Just-In-Time (JIT) compilation in the .NET framework
   
   - Common Intermediate Language (CIL) is the CPU-independent set of instructions generated when you compile .NET source code (like C#, VB.NET).

   - CIL acts as a bridge between high-level source code and machine code.Enables cross-language interoperability (C#, F#, VB.NET can all compile to CIL).Ensures platform independence before deployment.

   - Just-In-Time (JIT) compilation is the process where the CIL code is converted into native machine code specific to the operating system and processor at runtime.It translates CIL to native code just before execution.Optimizes performance for the current platform.Runs under the Common Language Runtime (CLR).