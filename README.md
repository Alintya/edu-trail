# EduTrail

EduTrail is a Blazor web application designed to create and manage configurable learning trails for students. It provides teachers with tools to monitor progress, manage assignments, and attach materials for enhanced learning experiences.

---

## Overview

## Features

### For Students

- **Learning Trails:** Structured, easy-to-follow learning paths with rich content, such as documents, videos, and links.
- **Progress Tracking:** Monitor individual progress through trail modules and assignments.
- **Assignment Submission:** Upload assignments directly for teacher review and feedback.

### For Teachers

- **Class Management:** Organize students into classes and assign tailored learning trails.
- **Progress Monitoring:** View the progress of individual students and entire classes.
- **Assignment Management:** Create, assign, and review student submissions with detailed feedback.
- **Content Uploads:** Attach materials like videos, documents, and links to learning modules.

### General

- **Clean Architecture:** Separation of concerns ensures scalability and maintainability.
- **Built with EF Core:** Smooth integration with relational databases for data persistence.

---

## Getting Started

### Prerequisites

- .NET 9.0 or later
- Preferably PostgresSQL Server or any compatible database
- Visual Studio 2022 or any IDE with .NET support

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/edutrail.git
   ```

2. Navigate to the project directory:

   ```bash
   cd edutrail
   ```

3. Configure the database connection in `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=EduTrailDB;Trusted_Connection=True;"
   }
   ```

4. Apply migrations to set up the database:

   ```bash
   dotnet ef database update
   ```

5. Run the application:

   ```bash
   dotnet run
   ```

6. Open a browser and navigate to `http://localhost:5000`.

---

## Usage

### For Teachers

1. **Create Classes:** Add classes and assign students.
2. **Design Learning Trails:** Define learning trails with modules and attach materials.
3. **Monitor Progress:** View reports on student performance and completion rates.

### For Students

1. **Access Trails:** View assigned learning trails and start modules.
2. **Submit Assignments:** Upload your work through the portal.
3. **Track Progress:** Use the dashboard to keep track of completed modules and assignments.

---

## Screenshots

### Student Dashboard

![Student Dashboard](path/to/screenshot-student-dashboard.png)

### Teacher Dashboard

![Teacher Dashboard](path/to/screenshot-teacher-dashboard.png)

---

## Architecture Overview

EduTrail follows Clean Architecture principles, consisting of:

- **Domain Layer:** Core business logic and entities (e.g., `LearningTrail`, `TrailModule`, `StudentProgress`).
- **Application Layer:** Service interfaces, validation, and mapping.
- **Infrastructure Layer:** Data access with EF Core, repositories, and external integrations.
- **Presentation Layer:** Startup project with Blazor components for the UI.

---

## Contributing

Contributions are welcome! To contribute:

1. Fork the repository.
2. Create a new branch for your feature/fix.
3. Submit a pull request with a clear description of your changes.

---

## License

TODO
