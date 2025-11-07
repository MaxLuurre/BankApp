# BankApp

## Overview

BankApp is a **console-based banking management system** built with **C# (.NET)**. It simulates real-world banking operations including account creation, deposits, withdrawals, fund transfers, currency exchange rate management, and loan handling.
The project is designed as a **multi-role system** supporting Customers, Admins, and a System Owner.

This project was developed as a **group school project** to demonstrate key concepts in **object-oriented programming (OOP)** such as inheritance, encapsulation, polymorphism, and abstraction.

---

## Features

### 1. User Roles

* **Customer**

  * Can create regular and savings accounts.
  * Can deposit and withdraw funds.
  * Can transfer funds between own accounts or to other customers.
  * Can apply for loans (based on account balance and bank policies).
  * Can view transaction history.
  * Can view currency exchange rates.

* **Admin**

  * Can register new users (Customers or Admins).
  * Can view all registered users.
  * Can change currency exchange rates.
  * Can process all pending transactions in the system.

* **System Owner**

  * Manages global settings such as loan policy and transfer delays.
  * Has access to all accounts and transactions in the system.
  * Can process all pending transactions globally.

---

## System Components

### 1. Account

Handles basic account functionality including deposits, withdrawals, balance management, and status (Active, Frozen, Closed).
Each account is assigned a unique account number automatically.

### 2. SavingsAccount

Inherits from `Account`.
Adds interest rate functionality and applies interest to the account balance.

### 3. Customer

Inherits from `Admin`.
Represents individual bank customers and provides methods for managing accounts, loans, and transactions.

### 4. Admin

Manages system users.
Handles registration, login, and administrative features such as user listing and currency rate management.

### 5. SystemOwner

Manages high-level system operations, including processing pending transactions and controlling policies like maximum loan multiplier and transfer delays.

### 6. Loan

Encapsulates loan data such as principal, interest rate, and due dates.
Supports payment processing, interest application, and status updates.

### 7. Transaction

Represents a single transaction (Deposit, Withdrawal, or Transfer).
Tracks sender, receiver, amount, status, and timestamp.

### 8. CurrencyRate

Holds a global dictionary of exchange rates between supported currencies (USD, EUR, SEK, JPY).
Includes methods for conversion and updating rates.

### 9. Ui

Handles the main program flow.
Displays menus for Customers and Admins and allows navigation through system functions.

---

## How It Works

1. **Program Startup**

   * The program starts through `Program.cs` by calling `Ui.Run()`.
   * Users can choose to register, log in, or exit.

2. **User Registration & Login**

   * Admins can register new users.
   * Users can log in and access menus based on their role.

3. **Customer Operations**

   * Customers can create new accounts, make deposits/withdrawals, transfer funds, apply for loans, and view transactions.
   * Some actions (like transfers) are added to a **pending transactions** list, processed later by Admin or SystemOwner.

4. **Admin Operations**

   * Admins manage users and currency exchange rates.
   * Admins can process pending transactions.

5. **System Owner Operations**

   * The System Owner can process all transactions and adjust system-wide policies such as transfer delays and loan limits.

---

## Data Structures

* **UsersList** (Admin.cs): Holds user accounts with username, password, role, and status.
* **TransactionList** (SystemOwner.cs): Stores completed transactions.
* **PendingTransactions** (SystemOwner.cs): Holds transactions waiting for admin approval.
* **Accounts** (Customer.cs): List of a customer’s active accounts.
* **Loans** (Customer.cs): List of loans associated with a customer.
* **CurrencyRate.rates**: Static dictionary storing all currency exchange rates.

---

## Supported Currencies

* USD (United States Dollar)
* EUR (Euro)
* SEK (Swedish Krona)
* JPY (Japanese Yen)

---

## Example Program Flow

1. **Launch Application**

   * Choose from:

     * Register User
     * Login
     * Exit

2. **Admin Login**

   * View or register users.
   * Change exchange rates.
   * Process pending transactions.

3. **Customer Login**

   * Create accounts.
   * Deposit or withdraw funds.
   * Transfer money between accounts or to other customers.
   * View transaction history.
   * Apply for a loan.

---

## Technical Details

* **Language:** C#
* **Framework:** .NET
* **Type:** Console Application
* **Design:** Object-Oriented (encapsulation, inheritance, and polymorphism)

---

## Future Improvements

* Add persistent data storage using JSON or a database.
* Implement authentication with password encryption.
* Add GUI (e.g., Windows Forms or WPF).
* Implement automatic interest application over time.
* Add unit testing for major functionalities.

---

## How to Run

1. Clone or download the repository.
2. Open the project in **Visual Studio** or **Visual Studio Code**.
3. Build the solution to restore dependencies.
4. Run the program — the console interface will appear.

---

## Authors

This project was developed collaboratively as a **group school assignment** by students to demonstrate practical OOP design and team-based software development in C#.
