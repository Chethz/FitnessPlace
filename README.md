# FitnessPlace Technical README

## Introduction

Welcome to the FitnessPlace project! This document provides technical insights into the architecture, patterns, and tools used in this repository to build a scalable and maintainable fitness application.

## Architecture Overview

FitnessPlace follows a three-tier architecture to ensure separation of concerns and maintainability:

1. **Presentation Layer**: This layer represents the user interface and interaction logic. It includes web pages, APIs, or any other interface through which users interact with the application.
   
2. **Business Layer**: The business layer contains the application's business logic, including validation, calculations, and workflows. It serves as an intermediary between the presentation and data layers.
   
3. **Data Layer**: The data layer manages data storage, retrieval, and manipulation. It includes databases, file systems, or any other data storage mechanism.

### Repository Pattern

The repository pattern is employed to abstract data access and provide a consistent interface for interacting with different data sources.

### Specification Pattern

In addition to the repository pattern, FitnessPlace utilizes the Specification Pattern. This pattern defines a set of criteria and enables filtering objects in a collection based on these criteria. By using the Specification Pattern, FitnessPlace achieves a more modular and maintainable approach to defining and applying business rules.

### Entity Framework Core

**Entity Framework Core** is utilized as the ORM (Object-Relational Mapping) framework for data access in the data layer. It enables developers to work with databases using strongly typed .NET objects, simplifying data access and manipulation tasks.

## AutoMapper and DTOs

**AutoMapper** is utilized to streamline the mapping between domain entities and Data Transfer Objects (DTOs). DTOs are lightweight objects used to transfer data between layers and across network boundaries.

## Project Structure

The repository follows a structured organization to maintain clarity and modularity:



## Project Structure

The repository follows a structured organization to maintain clarity and modularity:

```
FitnessPlace/
│
├── src/                      # Source code
│   ├── Presentation/         # Presentation layer
│   ├── Business/             # Business layer
│   └── Data/                 # Data layer
│
└── README.md                 # Project README
```

## Getting Started

To set up the project locally, follow these steps:

1. Clone the repository:
   ```
   git clone https://github.com/Chethz/FitnessPlace.git
   ```
2. Run this command to create Database and Tables
   ```
   dotnet ef database update --project FitnessPlace.AP
   ```
