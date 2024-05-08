# FitnessPlace Technical README

## Introduction

Welcome to the FitnessPlace project! This document provides technical insights into this repository's architecture, patterns, and tools to build a scalable and maintainable fitness application.

## Architecture Overview

FitnessPlace follows a three-tier architecture to ensure separation of concerns and maintainability:

1. **Presentation Layer**: This layer represents the user interface and interaction logic. It includes web pages, APIs, or any other interface through which users interact with the application.
   
2. **Business Layer**: The business layer contains the application's business logic, including validation, calculations, and workflows. It serves as an intermediary between the presentation and data layers.
   
3. **Data Layer**: The data layer manages data storage, retrieval, and manipulation. It includes databases, file systems, or any other data storage mechanism.

## Repository Pattern

The repository pattern abstracts data access and provides a consistent interface for interacting with different data sources.

## Specification Pattern

In addition to the repository pattern, FitnessPlace utilizes the Specification Pattern. This pattern defines a set of criteria and enables filtering objects in a collection based on these criteria. By using the Specification Pattern, FitnessPlace achieves a more modular and maintainable approach to defining and applying business rules, enhancing the application's flexibility and adaptability.

## Entity Framework Core

**Entity Framework Core** is the ORM (Object-Relational Mapping) framework for data access in the data layer. It enables developers to work with databases using strongly typed .NET objects, simplifying data access and manipulation tasks.

## AutoMapper and DTOs

**AutoMapper** is utilized to streamline the mapping between domain entities and Data Transfer Objects (DTOs). DTOs are lightweight objects that transfer data between layers and across network boundaries.

## Serilog and Seq Logging
**Serilog** simplifies the Logging process in C# applications through its extensive feature set and user-friendly configuration options, enabling developers to quickly log messages, errors, and other pertinent information. Structured Logging with **Seq** builds upon this foundation by emphasizing structured data, departing from conventional text-based logs. Seq empowers developers to log data in a structured format, facilitating streamlined search, analysis, and visualization of log information. Its web-based interface enables seamless exploration of log data, query execution, and customization of dashboards, enhancing the overall logging experience.

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
2. Run this command to add migrations:
   ```
   dotnet ef database update --project FitnessPlace.API
   ```
