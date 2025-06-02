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
    3. Common Type System (CTS)
    4. Base Class Library (BCL)
    5. Dynamic Language Runtime (DLR)

- Common Language Runtime (CLR)
     acts as a virtual machine that runs the code and manages various services like memory management , security ,thread management .

- Framework Class Library(FCL)
     provides all resuable classes and functions for application development.
     This includes libraries for input/output operation ,networking ,data access ,UI controls etc... 

- Common Type System (CTS)
     cts defines how data types are declared, used and managed in the runtime.
     it facilitates cross language integration , type safety and high-performance code execution.
     Example: C# has int data type, VB.Net has Integer data type but after compilation both uses the same structure Int32 from CTS. 
- Base Class Library (BCL)
     Base Class Library (BCL) is a fundamental component of the .NET Framework. It provides the core set of classes that serve as the basic API of the Common Language Runtime (CLR). The BCL includes essential types such as System.String, System.DateTime, and other fundamental classes that are necessary for everyday programming tasks

     BCL is a subset of the Framework Class Library (FCL). While the FCL encompasses a broader range of libraries, including ASP.NET, WinForms, ADO.NET, and more, the BCL focuses on providing the most essential and commonly used types and functionalities of classes in namespaces like System, System.Diagnostics, System.Globalization, System.Resources, System.Text, System.Runtime.Serialization, and System.Data etc .

- Dynamic Language Runtime (DLR)
     DLR is a runtime environment that adds a set of services for dynamic languages to the CLR
     Dynamic languages can identify the type of an object at run time, whereas in statically typed languages like C#  we must specify object types at design time. Examples of dynamic languages are Lisp, Smalltalk, JavaScript, PHP, Ruby, Python, ColdFusion, Lua, Cobra, and Groovy.

### 3. Differentiate between the Common Language Runtime (CLR) and the Common Type System (CTS) in .NET

  - CLR
      Common Language Runtime is a virtual machine that runs the code . It handles  memory management, security, thread management . It is responsible for execution of code .

  - CTS
      Common Type System describes the data types that can be used in managed code . It defines  how these data types are declared , used and managed in runtime.
      CTS ensures that objects written in different .NET languages (like C#, VB.NET, F#) can interact with each other seamlessly.
      Language interoperability: Types defined in one .NET language can be used in another.
      Type safety: Ensures reliable and secure code execution.
      Standardization: Provides a common set of data types. 
   - CTS plays a crucial role in enabling cross-language integration by:
      Unifying type definitions across all .NET languages.
      Ensuring that all types, regardless of the language they were written in, compile down to a common type structure.
      This unified structure is executed by the Common Language Runtime (CLR).
      For example, an int in C#, Integer in VB.NET, and System.Int32 in IL all refer to the same CTS type.

### 4. What is the role of the Global Assembly Cache (GAC) in .NET

   - GAC Global Assembly Cache is a machine-wide code cache . Every system that has CLR installed in it will have GAC . GAC stores the shared assemblies that are specifically shared by several applications. GAC shares assemblies , avoids duplication and version conflicts .It enables code reuse and avoids duplication by allowing multiple applications to access a single copy of a strongly named assembly.
   - Ways to deploy an assembly into GAC
        1. Use an installer designed to work with the Global Assembly Cache
        2. Use a developer tool called the Global Assembly Cache tool (Gacutil.exe), provided by the Windows SDK.
   - Naming Requirement
     Assemblies stored in the GAC must be strongly named, which includes assembly name,version, culture(optional), public key token.
     Strong-naming adds a layer of identity, versioning, and security, ensuring that:
     Assemblies are uniquely identifiable
     Different versions of the same assembly can coexist
     Assemblies can't be easily tampered with

### 5. Explain the difference between value types and reference types in C#. 

   - Value Type variables can be assigned a value directly. They are derived from the class System.ValueType. The value types directly contain data. When you declare an int type, the system allocates memory to store the value.
   - Examples : int , float , char , bool , enum .

   - Reference types store a reference (address) to the actual data, which is stored in the heap.
   variables hold reference and not the actual data .When you assign a reference type to another variable, both variables refer to the same object.

   - Examples : string , arrays , classes , delegates . 
   Although string is a reference type, it behaves somewhat like a value type in terms of immutability.
string is a reference type, stored on the heap but it is immutable, meaning its contents cannot be changed after creation
Any operation that appears to "change" a string (e.g., concatenation or reassignment) creates a new string object

### 6. Describe the concept of garbage collection on .NET and its advantages
   - Garbage Collection in .NET is an automatic memory management feature provided by the CLR. It automatically frees up memory used by objects that are no longer accessible or needed by the application.

   - Working

     1. Allocation: When a new object is created using new, memory is allocated from the managed heap.

     2. Tracking: The .NET runtime tracks references to each object.

     3. Garbage Collection: When there is low memory or enough unused objects:

Garbage Collector identifies unreferenced objects and frees up the memory used by these objects.When there isn't enough memory to allocate an object ,the GC(garbage collector) must collect and dispose of garbage memory to take the memory available for new allocations.

.NET uses a Generational Garbage Collection model, which improves performance by dividing objects into generations:

Generation	Description
- Gen 0	Short-lived objects (most are collected quickly)
- Gen 1	Objects that survived Gen 0 collection
- Gen 2	Long-lived objects (e.g., static data, app-wide caches)
The GC prioritizes collecting Gen 0 objects frequently and Gen 2 objects less frequently, optimizing the performance.

Phases in Garbage Collection:
1. Marking: It will create the list of live object. All of the objects that are not on the list of live objects are potentially deleted from the heap memory.
2. Relocate: It will update the reference object. The references of all the objects that were on the list of all the live objects are updated in the relocating phase so that they point to the new location where the objects will be relocated to in the compacting phase.
3. Compacting: It will clear the unused object from the memory.


### 7. What is the purpose of the Globalization and Localization features in .NET 

   - Globalization is the process of designing applications that can handle different cultures. By adding support for input, display, and output in specific languages related to specific geographical areas, globalization makes it easier for people from around the world to use these apps.

   - Localization is the process of translating content to match the specific needs of a certain culture or language. This includes transcribing text, as well as formatting numbers, dates and times, using different currencies, and employing various symbols.

### 8. Explain the role of the Common Intermediate Language (CIL) and Just-In-Time (JIT) compilation in the .NET framework
   
   - Common Intermediate Language (CIL) is the CPU-independent set of instructions generated when you compile .NET source code (like C#, VB.NET).

   - CIL acts as a bridge between high-level source code and machine code.Enables cross-language interoperability (C#, F#, VB.NET can all compile to CIL).Ensures platform independence before deployment.

   - Just-In-Time (JIT) compilation is the process where the CIL code is converted into native machine code specific to the operating system and processor at runtime.It translates CIL to native code just before execution.Optimizes performance for the current platform.Runs under the Common Language Runtime (CLR).