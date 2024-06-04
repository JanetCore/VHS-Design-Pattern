# VHS Design Pattern

The VHS (View-Handler-Service) Design Pattern is a structured approach for building WPF applications using a clear separation of concerns. This project serves as a template and guide for organizing WPF projects to achieve maintainability, testability, and scalability.

## Project Structure

The solution consists of three main projects:
- `VHS.Core`: Contains the core logic, base classes, and interfaces.
- `VHS.Data`: Manages data access and database operations.
- `VHS.Gui`: A sample GUI project demonstrating how to use the Core and Data projects.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 or later

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/JanetCore/VHS-Design-Pattern.git
    ```

2. Open the solution in Visual Studio.

3. Restore NuGet packages:
    ```sh
    dotnet restore
    ```

4. Build the solution:
    ```sh
    dotnet build
    ```

### Usage

1. Customize the Core and Data projects to fit your application needs.
2. Use the sample GUI project as a reference to integrate your own UI components.

## VHS Pattern Overview

- **View**: Contains XAML files and code-behind, responsible for UI rendering.
- **Handler**: Manages user interactions and bridges the View with Services.
- **Service**: Contains business logic and data manipulation, ensuring separation from UI concerns.

## Custom Error Handling

### Core/ErrorHandling/ErrorHandler.cs

```csharp
using System;

namespace VHS.Core.ErrorHandling
{
    public static class ErrorHandler
    {
        public static void HandleError(Exception ex)
        {
            // Log the error (implement logging with Serilog or similar)
            Console.WriteLine($"Error: {ex.Message}");

            // You can extend this method to include more detailed logging or custom actions
        }
    }
}