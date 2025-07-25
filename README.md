﻿# BookManagement

Book Management System

This project provides a simple yet effective way for users to manage a collection of books. It features a clean, user-friendly frontend developed using Angular and a robust backend built with ASP.NET Core.
Features

    Add Books: Users can add new books by providing details such as title, author, and ISBN.

    View Books: The full list of books is displayed with all relevant details.

    Edit Books: Users can update existing book information as needed.

    Delete Books: Unwanted books can be removed from the collection.

Architecture

The backend maintains an in-memory list to store book data, which includes key properties like title, author, and ISBN. This choice simplifies data management and avoids external database dependencies, making the project lightweight and easy to run locally.

The frontend interacts with the backend through a well-defined RESTful API, sending HTTP requests to perform create, read, update, and delete (CRUD) operations. This separation of concerns ensures a clean architecture and allows for easy future scalability or integration with different frontends or databases.
