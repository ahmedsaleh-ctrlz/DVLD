# Driving License Management System (Windows Forms)

A desktop application built with **C# Windows Forms** for managing driving licenses.
The system handles user authentication, personal data storage, and license-related operations using **SQL Server** and **T-SQL**.

---

## 🚀 Features

- User authentication (Login system)
- Manage citizens personal data
- Store and retrieve data from SQL Server
- Role-based access (Admin / User)
- Organized using **3-Tier Architecture**
  - Presentation Layer (UI)
  - Business Logic Layer
  - Data Access Layer

---

## 🏗 Architecture

The project follows **3-Tier Architecture** for better separation of concerns:



This structure improves:
- Maintainability
- Scalability
- Code readability

---

## 🛠 Technologies Used

- C#
- Windows Forms
- SQL Server
- T-SQL
- ADO.NET
- Visual Studio

---

## 🗄 Database

- SQL Server database
- Uses T-SQL for queries, procedures, and data manipulation
- Stores:
  - Users
  - Personal information
  - License data

> ⚠️ Database file and connection string should be configured locally.

---

## 🔐 Authentication

- Secure login system
- Validates users before accessing the system
- Credentials stored in the database

---

## 📌 How to Run

1. Clone the repository:
   ```bash
   git clone <repository-url>
