# Library Management System
## Introduction

This repository contains my solution to the "Library Management System" programming challenge. The challenge emphasizes creating a basic library management system with class design, LINQ queries, asynchronous operations, and unit tests. Below is a detailed description of the implementation and how to use it.

## Design Decisions
- **API Setup**: I've chosen a minimal API setup which I find preferable over the traditional controller-based setup, regardless of project size.

- **Dependency Injection**: Utilized dependency injection for the dbcontext and Library class methods. While the Library can be refactored into a service for better semantics, its current implementation suffices for this project.

- **Database**: I opted for the SQLite database for this challenge, focusing on functionality over complex configurations. It also helps to quickly get the system up and running.

- **Unit Tests**: I've written unit tests for the three main Library methods, concentrating on successful path scenarios. An in-memory database was utilized for these tests to ensure isolated conditions.

- **Seed Data**: The application initializes with some seed data, making it easier to test both the endpoints and unit tests right out of the box.

## Endpoints

After running the application, you can test the system using the following endpoints:

- List all books: `/books`
- Get books by an author (e.g. Tolkien): `/books/author/Tolkien`
- Check out a book (e.g. isbn=123): `POST request to http://localhost:5222/books/checkout?isbn=123`
- List borrowed books: `/books/checkedout`

## Conclusion

Thank you for taking the time to review the Library Management System. I hope you find it up to the mark.
