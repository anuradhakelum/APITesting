# ApiTesting

A behaviour-driven API test automation framework built with [Reqnroll](https://reqnroll.net/), .NET, and xUnit.

## Overview

This project provides a structured approach to API testing using BDD (Behaviour-Driven Development) principles. Tests are written in plain English using Gherkin syntax, making them readable and understandable by both technical and non-technical stakeholders.

## Tech Stack

- **.NET** — Application framework
- **Reqnroll** — BDD test framework (Gherkin/SpecFlow successor for .NET)
- **xUnit** — Underlying test runner
- **Microsoft.Extensions.Configuration** — JSON-based configuration management
- **Microsoft.Extensions.DependencyInjection** — Dependency injection for shared services

## Project Structure
```
ApiTesting/
├── Features/        # Gherkin .feature files describing test scenarios
├── Steps/           # Step definitions that map Gherkin steps to code
├── Hooks/           # Reqnroll hooks for setup and teardown (e.g. DI configuration)
├── Models/          # Strongly-typed models (e.g. ConfigurationFile)
├── Config.json      # Base configuration (base URLs, credentials, etc.)
└── Config.local.json # Local overrides — not committed to source control
```

## Configuration

Tests are configured via `Config.json`. To override settings locally (e.g. for a different environment), create a `Config.local.json` file in the project root. This file is optional and should be excluded from source control via `.gitignore`.
```json
{
  "BaseUrl": "https://api.example.com",
  "ApiKey": "your-api-key"
}
```

## Running the Tests
```bash
dotnet test
```

To run a specific feature or tag:
```bash
dotnet test --filter "Category=smoke"
```

## Writing Tests

Tests follow standard Gherkin syntax in `.feature` files:
```gherkin
Feature: User API

  Scenario: Get user by ID returns 200
    Given I have a valid user ID
    When I send a GET request to "/users/{id}"
    Then the response status code should be 200
    And the response body should contain the user details
```