# Company Management App (C# · MySQL)

Databases (Bases de Datos) · UCLM · 2025/2026

**Authors:** David Calzado Olmo, Ignacio Romero Torres, Álvaro Fernández Mora

## What it does

A Windows Forms desktop app to manage the staff and payroll of a company with offices in several countries, backed by a MySQL database.

- **CRUD screens** for countries, offices, employees and positions (an employee's job at an office, with salary and start/end dates)
- **Monthly payments:** generates each employee's gross and net pay for a given month, applying the country's tax base and the office's three-year bonus
- **Reports:** all payments by office, employees by location, expenses by country and month, expenses by office and month, and payments by employee

## Design

Layered architecture:

```
COMPANY/COMPANY/
├── domain/        entities (Country, Office, Employee, Position, MonthlyPayment) and their DAOs
├── persistence/   DBBroker: single MySQL connection (singleton)
└── presentation/  Windows Forms screens and reports
```

## Run it

Requires .NET 10 (Windows) and a MySQL database named `Company` with the tables `countries`, `offices`, `employees`, `positions` and `monthlypayments`.

The connection string is read from the `COMPANY_DB_CONNECTION` environment variable. If it is not set, the app connects to `localhost` as `root` with an empty password.

```
set COMPANY_DB_CONNECTION=server=localhost;database=Company;uid=YOUR_USER;pwd=YOUR_PASSWORD;CharSet=utf8;
```

Then open `COMPANY/COMPANY.slnx` in Visual Studio and run it.

## Known limitations

SQL queries are built by concatenating strings rather than using parameters. A real application should use parameterised queries to avoid SQL injection.
