
### Memory Management Profiling

## A Simple Memory Management Profiling to Understand the Working of Memory

---

## Profiling for Infinite Memory Eater

### Initial Memory Usage (10.80s)  
![Initial Memory Usage](Profiling/InfiniteMemoryEater/initial_memory_usage.png)

### Memory Usage After Some Time (73.84s)  
![Final Memory Usage](Profiling/InfiniteMemoryEater/final_memory_usage.png)

---

## Objective

- To fix the memory issue in the provided code snippet and implement memory management best practices.

---

## Profiling for Restricted Infinite Memory Eater

- Improved memory management by clearing the memory when the list exceeds 1000 entries.

### Initial Memory Usage (4.45s)  
![Initial Memory Usage](Profiling/RestrictedInfiniteMemoryEater/initial_memory_usage.png)

### Memory Usage After Some Time (23.34s)  
![Final Memory Usage](Profiling/RestrictedInfiniteMemoryEater/final_memory_usage.png)

---

## Profiling for Improved Memory Eater-II

- Further improved memory management by converting to a finite while loop with a condition (`count < 1000`).

### Initial Memory Usage (4.68s)  
![Initial Memory Usage](Profiling/FiniteMemoryEater/initial_memory_usage.png)

### Memory Usage After Some Time (20.35s)  
![Final Memory Usage](Profiling/FiniteMemoryEater/final_memory_usage.png)

---
