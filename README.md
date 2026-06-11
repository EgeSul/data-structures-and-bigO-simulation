# C# Data Structures & Algorithmic Complexity Lab

This repository contains a console-based interactive application built with C# to demonstrate and simulate core data structures and algorithmic complexity concepts (Big O navigation). It serves as a practical laboratory for fundamental computer science topics.



## 🛠️ Features & Concepts Covered

The application consists of 6 interactive modules, each demonstrating a different computer science principle:

1. **Time Complexity ($O(N)$ vs $O(1)$):** Compares a traditional loop-based summation (Brute Force - $O(N)$) against Gauss's Elimination Formula ($O(1)$) to visually demonstrate performance scale.
2. **Dynamic Arrays (`List<T>`):** A basic Library Management Simulation demonstrating dynamic sizing, item addition, and sequential searching/deletion.
3. **Linked Lists (`LinkedList<T>`):** Visualizes sequential data elements where each element points to the next, emphasizing non-contiguous memory allocation.
4. **Stack (LIFO - Last In, First Out):** A Sentence Reverser algorithm that utilizes a Stack to flip the order of words in a given input.
5. **Queue (FIFO - First In, First Out):** A Cinema Ticket Queue simulation displaying fair resource management where the first user in line is the first served.
6. **Dictionary / Hash Table ($O(1)$ Lookups):** A Word Frequency Counter that analyzes an input text and tracks exact word counts with constant-time complexity lookups using hashing.


### Architecture Flowchart

```mermaid
flowchart TD
    %% Global Styles
    classDef startEnd fill:#f9f,stroke:#333,stroke-width:2px;
    classDef process fill:#fff,stroke:#333,stroke-width:1px;
    classDef condition fill:#ff9,stroke:#333,stroke-width:1px;
    
    Start([Start Program]) --> Init[Initialize: ProgramCalisiyor = true]
    Init --> MainLoop{while ProgramCalisiyor}
    
    MainLoop -- true --> ShowMenu[Display Main Menu & Get secim]
    MainLoop -- false --> End([End Program])
    
    ShowMenu --> CheckSecim{Is secim Valid Integer?}
    CheckSecim -- No --> InvalidSecim[Print 'Enter numeric value'] --> MainLoop
    CheckSecim -- Yes --> SwitchSecim{secim Value?}

    %% Grouping Case 1
    subgraph Case_1 [1 - Time Complexity]
        C1_Menu[Display Sub-Menu & Get secim2]
        C1_Check{secim2 Value?}
        C1_O_N[Loop 0 to N: Add to sum]
        C1_Print1[Print Loop Result]
        C1_O_1[Calculate Gauss formula]
        C1_Print2[Print Gauss Result]
        C1_Def[Print 'Enter 1 or 2']
    end
    SwitchSecim -- 1 --> C1_Menu
    C1_Check -- 1 (O(N)) --> C1_O_N --> C1_Print1 --> MainLoop
    C1_Check -- 2 (O(1)) --> C1_O_1 --> C1_Print2 --> MainLoop
    C1_Check -- Default --> C1_Def --> MainLoop

    %% Grouping Case 2
    subgraph Case_2 [2 - Library Management List]
        C2_Init[Init: List & ProgramCalisiyor2 = true]
        C2_Loop{while ProgramCalisiyor2}
        C2_Get[Get Action: ekle/sil/listele/cikis]
        C2_Check{Action?}
        C2_Add[Add book to List]
        C2_Del{Book exists?}
        C2_Del_Do[Remove book]
        C2_Del_Err[Print 'Not found']
        C2_List{List Count > 0?}
        C2_Print_List[Print all books]
        C2_Empty_List[Print 'List empty']
        C2_Exit[ProgramCalisiyor2 = false]
        C2_Def2[Print 'Invalid selection']
    end
    SwitchSecim -- 2 --> C2_Init --> C2_Loop
    C2_Loop -- true --> C2_Get --> C2_Check
    C2_Loop -- false --> MainLoop
    C2_Check -- ekle --> C2_Add --> C2_Loop
    C2_Check -- sil --> C2_Del
    C2_Del -- Yes --> C2_Del_Do --> C2_Loop
    C2_Del -- No --> C2_Del_Err --> C2_Loop
    C2_Check -- listele --> C2_List
    C2_List -- Yes --> C2_Print_List --> C2_Loop
    C2_List -- No --> C2_Empty_List --> C2_Loop
    C2_Check -- cikis --> C2_Exit --> C2_Loop
    C2_Check -- Default --> C2_Def2 --> MainLoop

    %% Grouping Case 3
    subgraph Case_3 [3 - Linked List]
        C3_Process[Create LinkedList & Add train cars]
        C3_Print[Print layout: Wagon -> NULL]
    end
    SwitchSecim -- 3 --> C3_Process --> C3_Print --> MainLoop

    %% Grouping Case 4
    subgraph Case_4 [4 - Stack Sentence Reverser]
        C4_Loop{while ProgramCalisiyor3}
        C4_Input[Get text input or 'cikis']
        C4_Check{Input == 'cikis'?}
        C4_Exit[ProgramCalisiyor3 = false]
        C4_Push[Split & Push to Stack]
        C4_PopLoop{while Stack.Count > 0}
        C4_Pop[Pop word & Print]
    end
    SwitchSecim -- 4 --> C4_Loop
    C4_Loop -- true --> C4_Input --> C4_Check
    C4_Loop -- false --> MainLoop
    C4_Check -- Yes --> C4_Exit --> C4_Loop
    C4_Check -- No --> C4_Push --> C4_PopLoop
    C4_PopLoop -- Yes --> C4_Pop --> C4_PopLoop
    C4_PopLoop -- No --> C4_Loop

    %% Grouping Case 5
    subgraph Case_5 [5 - Queue Cinema Ticket]
        C5_Init[Init: Queue & ProgramCalisiyor4 = true]
        C5_Loop{while ProgramCalisiyor4}
        C5_Get[Get Action: kayit/gise/cikis]
        C5_Check{Action?}
        C5_Exit[ProgramCalisiyor4 = false]
        C5_Enqueue[Enqueue name]
        C5_Q_Check{Queue Count > 0?}
        C5_Dequeue[Dequeue & Peek next]
        C5_Q_Empty[Print 'Queue empty']
        C5_Def5[Print 'Invalid']
    end
    SwitchSecim -- 5 --> C5_Init --> C5_Loop
    C5_Loop -- true --> C5_Get --> C5_Check
    C5_Loop -- false --> MainLoop
    C5_Check -- cikis --> C5_Exit --> C5_Loop
    C5_Check -- kayit --> C5_Enqueue --> C5_Loop
    C5_Check -- gise --> C5_Q_Check
    C5_Q_Check -- Yes --> C5_Dequeue --> C5_Loop
    C5_Q_Check -- No --> C5_Q_Empty --> C5_Loop
    C5_Check -- Default --> C5_Def5 --> C5_Loop

    %% Grouping Case 6
    subgraph Case_6 [6 - Dictionary Word Frequency]
        C6_Input[Get text input]
        C6_Split[Normalize & Split text]
        C6_Loop[Foreach word in array]
        C6_DictCheck{Dict Contains Key?}
        C6_Inc[Increment Value]
        C6_Add[Add Key with Value 1]
        C6_Next{More words?}
        C6_Print[Print Table & Count]
    end
    SwitchSecim -- 6 --> C6_Input --> C6_Split --> C6_Loop --> C6_DictCheck
    C6_DictCheck -- Yes --> C6_Inc --> C6_Next
    C6_DictCheck -- No --> C6_Add --> C6_Next
    C6_Next -- Yes --> C6_Loop
    C6_Next -- No --> C6_Print --> MainLoop

    %% Case 7 & Default
    SwitchSecim -- 7 --> C7_Exit[ProgramCalisiyor = false] --> MainLoop
    SwitchSecim -- Default --> Def_Err[Print 'Enter valid number 1-7'] --> MainLoop

    %% Applying styles
    class Start,End startEnd;
    class MainLoop,CheckSecim,SwitchSecim,C1_Check,C2_Loop,C2_Check,C2_Del,C2_List,C4_Loop,C4_Check,C4_PopLoop,C5_Loop,C5_Check,C5_Q_Check,C6_DictCheck,C6_Next condition;
```
---

## 🚀 How to Run

### Prerequisites
* [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or higher recommended)
* An IDE like Visual Studio, Visual Studio Code, or JetBrains Rider.

### Execution
1. Clone the repository:
   ```bash
   https://github.com/EgeSul/data-structures-and-bigO-simulation.git
