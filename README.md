
# Template Project

The Template Project is a foundational template for building modern .NET applications with Azure Functions, Entity Framework, and a clean architecture approach. It includes built-in support for various Azure services, dependency injection, FluentValidation, and more.

## Table of Contents

1. [Introduction](#introduction)
2. [Features](#features)
3. [Tech Stack](#tech-stack)
5. [Usage](#usage)
6. [Configuration](#configuration)
7. [Contributing](#contributing)

## Introduction

The Template Project provides a comprehensive starting point for developing .NET applications with best practices and modern tools. It includes pre-configured integrations with Azure services, a clean architecture pattern, and extensive use of dependency injection and validation.

## Features

- **Azure Functions:** Serverless compute with function triggers including HTTP, Service Bus, Timer, and Blob.
- **Entity Framework Core:** Integration for data access and management.
- **FluentValidation:** Fluent API for validating models and request bodies.
- **Dependency Injection:** Configurable services and options.
- **OpenAPI Documentation:** API documentation and testing capabilities.

## Tech Stack

- **Backend:** .NET 8, Azure Functions v4
- **Database:** SQL Server (via Entity Framework Core)
- **Validation:** FluentValidation
- **Configuration & Secrets Management:** Azure App Configuration, Azure Key Vault

## Usage

1. **Deploy the functions to Azure Functions.**
2. **Configure Azure App Configuration and Key Vault with necessary secrets.**
3. **Use the provided API endpoints for various triggers (HTTP, Service Bus, Timer, Blob).**

## Configuration

### DatabaseOption

- **ConnectionString:** The connection string for the SQL Server database.

### TemplateOptions

- **Option1:** Configuration option 1.
- **Option2:** Configuration option 2.

```csharp
public class TemplateOptions
{
    public string Option1 { get; set; }
    public string Option2 { get; set; }
}
```
