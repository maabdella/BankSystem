# National Bank Management System 🏦

### EF Core Code-First Data Layer Implementation

This project is a comprehensive **Data Access Layer** for a National Bank Management System, built as part of the **ASP.NET Course**. The system is designed to track bank branches, managers, customers (Individuals & Businesses), accounts (including joint accounts), and all financial transactions. [cite: 5, 6]

##  Project Objectives

The main goal was to build a reliable **EF Core Code-First** data layer that can be integrated into future UI or API projects

  * **Database Modeling:** Translating a complex ER diagram into C\# entity classes.
  * **Fluent API Configuration:** Defining relationships, constraints, and business rules explicitly
  * **Migrations:** Generating and managing the SQL Server database schema.
  * **Data Seeding:** Initializing the database with realistic test data for Branches and Managers.

### Database Schema (ERD)
    Branch ||--|| Manager : "Managed by"
    Branch ||--o{ Account : "Belongs to"
    Account ||--o{ Transaction : "Has"
    Customer ||--o{ CustomerAccount : "Have"
    Account ||--o{ CustomerAccount : "Have"

## Functional Features (Interactive Menu)

The application includes a console-based interface to perform the following operations:

1.  **Add New Customer:** Supports both Individual and Business types with full validation.
2.  **Open New Account:** Links customers to accounts with specific ownership roles (Primary or Co-Holder).
3.  **Update Account Status:** Toggle accounts between Active and Closed states.
4.  **Remove Account Link:** Safely delete the link between a customer and an account.
5.  **List All Customers:** A detailed report showing customers and their associated accounts, balances, and branch info.

## Technical Implementation Highlights

  * **EF Core 10.0:** Leveraging the latest features for performance and stability.
  * **Input Validation:** The system is designed to handle invalid inputs (like letters in numeric fields) without crashing.
  * **Business Logic:** Verification of Branch and Customer existence before account creation.
  * **Clean Code:** Separation of Entity classes and Configuration logic.

## 🏁 Getting Started

1.  Clone the repository.
2.  Ensure you have **SQL Server** installed.
3.  Update the connection string in the `DbContext` class.
4.  Run the following command in the Package Manager Console:
    ```bash
    Update-Database
    ```
5.  Run the application to start the interactive menu
