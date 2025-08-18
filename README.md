# Dev V Remedial Assignment

A small Unity project featuring a gem economy system with buying, selling, and fluctuating gem prices. Player data and gem inventory are persistently stored using SQLite.  

## Table of Contents

- [Features](#features)  
- [Installation](#installation)  
- [Usage](#usage)  
- [Database](#database)  
- [Project Structure](#project-structure)  
- [Contributing](#contributing)  
- [License](#license)  

## Features

- Player can buy and sell gems (Ruby, Emerald, Sapphire, Quartz).  
- Real-time gem price fluctuation system.  
- Persistent player money and gem inventory using SQLite.  
- Transaction logging for all buy/sell operations.  
- Simple and clear UI using TextMeshPro.  

## Installation

1. Clone the repository:  
   ```bash
   git clone <repo-url>
Open the project in Unity (tested with Unity 2021.3+).

Ensure the following packages are installed via Unity Package Manager:

TextMeshPro

SQLite (or SQLite-net Unity plugin)

Usage
Press Play in Unity.

Use the Buy and Sell buttons to interact with gems.

Observe your money and gem quantities updating in real time.

Prices fluctuate automatically every second.

Database
Database file location:
C:/Users/<username>/AppData/LocalLow/DefaultCompany/Dev V Remedial assignment/EconomyDB.db

Tables:

PlayerMoneyData → stores player money.

GemData → stores gem id, name, price, and quantity.

TransactionData → logs every buy/sell transaction.

All database operations are handled via EconomyDatabase.cs.

Project Structure
pgsql
Copy
Edit
Assets/
├─ Scripts/
│  ├─ Managers/
│  │  └─ EconomyManager.cs
│  ├─ Services/
│  │  └─ EconomyDatabase.cs
│  └─ Utils/
│     └─ Database.cs
├─ Prefabs/
│  └─ Gem.prefab
├─ Scenes/
│  └─ MainScene.unity
