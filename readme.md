# 🚗 DVLD – Driving & Vehicle License Department System  

A full-featured desktop application built using **C# (.NET Framework), Windows Forms, SQL Server, and ADO.NET**.

The system simulates a real-world Driving License Department responsible for managing license issuance, renewals, retests, international licenses, license detention, and user administration.

---

## 🛠 Tech Stack

- C# (.NET Framework)
- Windows Forms
- SQL Server
- ADO.NET (Manual SQL Queries)
- 3-Tier Architecture (Presentation / Business / Data Access)

---

## 🧱 Architecture

The system follows a structured **3-Tier Architecture**:

- **Presentation Layer** – Windows Forms UI
- **Business Layer** – Business rules & validation logic
- **Data Access Layer** – ADO.NET with manual SQL queries

No ORM was used. All database interactions were written manually using ADO.NET.

---

## 📌 Core Modules

### 👤 People Management
- Add, edit, delete persons
- Search by National ID
- Prevent duplicate National IDs
- Store full personal information (Name, DOB, Address, Phone, Email, Nationality, Photo)

---

### 👥 User Management
- Create system users linked to existing persons
- Update / Delete / Freeze users
- Role & permission management
- Track system activity by user

---

### 📄 License Services

1. Issue License (First Time)
2. Retest Service
3. Renew License
4. Replace Lost License
5. Replace Damaged License
6. Release Detained License
7. Issue International License

Each service:
- Generates a request
- Requires fee payment
- Tracks request status (New, Cancelled, Completed)
- Prevents duplicate active requests of same type

---

### 🚘 License Classes

The system supports 7 license categories, each with:

- Minimum allowed age
- Validity period
- License fees
- Class description

Business rules enforced:
- Age validation
- Prevent duplicate license of same class
- Allow multiple license classes per person

---

### 🧪 Testing & Examinations

Applicants must pass:

1. Vision Test  
2. Theory Test  
3. Practical Driving Test  

Features:
- Schedule test appointments
- Record results (Pass / Fail)
- Store scores
- Retest only if previously failed
- Enforce test order
- Require fee payment before scheduling

---

### 🪪 License Issuance

After passing all required tests:

- License number generated
- Issue & expiry dates assigned
- License status tracked (New, Renewal, Replacement)
- Driver record created
- Historical license records preserved

---

### 🌍 International License

- Only available for valid Class 3 licenses
- Prevent duplicate active international licenses
- Maintain historical records

---

### 🚫 License Detention

- Detain license with fine and reason
- Store detention date
- Release after fine payment
- Log release date

---

## 🗄 Database Design Highlights

- Fully relational database
- Foreign key constraints
- Transaction handling
- Normalized structure
- Prevent data duplication
- Activity tracking for system users

---

## 🎯 Key Learning Outcomes

- Strong understanding of 3-Tier Architecture
- Manual SQL query writing using ADO.NET
- Database normalization & relationships
- Implementing complex business rules
- Managing large desktop applications
- Handling transactional workflows
- Designing structured real-world systems

---

## 🚀 Project Purpose

This project was built as a comprehensive desktop system to simulate a real government driving license department with complete business logic enforcement and structured data management.

---

## 📌 Status

Completed – Stable desktop system with full database integration.
