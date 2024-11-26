# Cumulative Assignment - Teacher Management System

## Overview

This project is a **Teacher Management System** that allows users to add, view, and delete teacher records from the database. It also supports associating courses with teachers and displaying relevant course information. This system is implemented using **ASP.NET Core MVC** and **MySQL** for data storage and interaction.

## Features

- **Add Teacher**: Allows users to add a new teacher's details (name, hire date, employee number, and salary) to the system.
- **View Teachers**: Display all teachers along with the courses they are assigned to.
- **Delete Teacher**: Enables the deletion of a teacher's record from the database.
- **Manage Courses**: Courses are associated with teachers and can be viewed along with teacher information.
  
## Technologies Used

- **ASP.NET Core MVC**: Used for creating the web application and API endpoints.
- **MySQL**: Used for storing teacher and course data.
- **HTML, CSS**: Used for creating the front-end pages.
- **JavaScript**: For client-side interactions (if applicable).

## Requirements

- .NET Core SDK (preferably 6.0 or later)
- MySQL Database

## Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/yourusername/TeacherManagementSystem.git
    cd TeacherManagementSystem
    ```

2. **Install the necessary dependencies:**

    Make sure you have .NET Core SDK installed. You can install it from the official [dotnet](https://dotnet.microsoft.com/download) website.

    ```bash
    dotnet restore
    ```

3. **Set up the MySQL database:**

    - Create a new MySQL database and configure your connection string in the `appsettings.json` file.
    
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "server=localhost;database=teacherdb;user=root;password=yourpassword"
      }
    }
    ```

4. **Run the application:**

    ```bash
    dotnet run
    ```

5. Open your browser and navigate to `http://localhost:5000` to view the Teacher Management System.

## API Endpoints

### 1. **Add Teacher**

- **URL**: `POST /TeacherPage/AddTeacher`
- **Request Body**:
  ```json
  {
    "TeacherFName": "John",
    "TeacherLName": "Doe",
    "TeacherHireDate": "2024-11-01",
    "TeacherEmpNu": "12345",
    "TeacherSalary": 50000
  }
