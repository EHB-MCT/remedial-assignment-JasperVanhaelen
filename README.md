# Dev V Remedial Assignment

A small Unity project featuring a gem economy system with buying, selling, and fluctuating gem prices. Player data and gem inventory are persistently stored using SQLite.  

## Table of Contents

- [Features](#features)  
- [Installation](#installation)  
- [Usage](#usage)  
- [Database](#database)  
- [Futureproof Project Structure](#futureproof-project-structure)

## Features

- Player can buy and sell gems (Ruby, Emerald, Sapphire, Quartz).  
- Real-time gem price fluctuation system.  
- Persistent player money and gem inventory using SQLite.  
- Transaction logging for all buy/sell operations.  
- Simple and clear UI using TextMeshPro.  

## Installation

1. Clone the repository:  
   ```bash
   git clone <(https://github.com/EHB-MCT/remedial-assignment-JasperVanhaelen.git)>
Open the project in Unity (tested with Unity 2021.3+).

Ensure the following packages are installed via Unity Package Manager:

- TextMeshPro
- SQLite (or SQLite-net Unity plugin)

## Usage
Press Play in Unity.

Use the Buy and Sell buttons to interact with gems.

Observe your money and gem quantities updating in real time.

Prices fluctuate automatically every second.

## Database

Database file location:
C:/Users/<username>/AppData/LocalLow/DefaultCompany/Dev V Remedial assignment/EconomyDB.db

Tables:
- PlayerMoneyData → stores player money.
- GemData → stores gem id, name, price, and quantity.
- TransactionData → logs every buy/sell transaction.

All database operations are handled via EconomyDatabase.cs.

## Futureproof Project Structure

```
Assets/
├── Plugins/
│   └── x86_64/
├── Scripts/
│   ├── Managers/
│   ├── Models/
│   ├── Services/
│   ├── UI/
│   └── Utils/
├── Art/
│   ├── Sprites/
│   ├── Materials/
│   └── Fonts/
├── Prefabs/
├── Scenes/
│   └── Main.unity
├── UI/
│   ├── Canvas/
│   └── Elements/
├── Resources/
└── Tests/
```

## Sources

**Project Structure**
* [Unity Official Guide to Project Organization](https://unity.com/how-to/organizing-your-project)

**SQLite Implementation**
* [Unity & SQLite Quick Start Guide (Part 1)](https://michaelhayter.medium.com/unity-sqlite-quick-start-guide-part-1-8cba7ed22b9a)
* [SQLite Official Quickstart Documentation](https://sqlite.org/quickstart.html)

**Tools & Assistants**
* [ChatGPT Conversation for Database Logic](https://chatgpt.com/share/68a27001-50d0-8006-bead-33b917843a50)
* [NuGet Package Manager for Unity](https://www.nuget.org/)

ChatGPT for smaller questions and bug/error fixes
