# Survivor Competition API

This project is a Web API application for the "Survivor" competition. It manages the competitors and categories in the competition and provides CRUD (Create, Read, Update, Delete) operations for both entities. The application is built to handle one-to-many relationships, where a competitor can belong to one category, and each category can have multiple competitors.

## Technologies Used
- ASP.NET Web API
- Entity Framework Core
- Swagger for API documentation and testing

## Entities

### 1. Competitors (Yarışmacılar)
The `Competitor` entity represents a competitor in the competition. Below is a sample representation:

| Id  | CreatedDate           | ModifiedDate          | isDeleted | FirstName | LastName | CategoryId |
| --- | --------------------- | --------------------- | --------- | --------- | -------- | ---------- |
| 1   | 2024-01-01 10:00:00    | 2024-01-01 10:00:00    | false     | Acun      | Ilıcalı  | 1          |
| 2   | 2024-01-01 10:00:00    | 2024-01-01 10:00:00    | false     | Hakan     | Akdoğan  | 1          |
| ... | ...                   | ...                   | ...       | ...       | ...      | ...        |

### 2. Category (Kategoriler)
The `Category` entity represents the category of competitors. A competitor can belong to one category. Below is a sample representation:

| Id  | CreatedDate           | ModifiedDate          | isDeleted | Name       |
| --- | --------------------- | --------------------- | --------- | ---------- |
| 1   | 2024-01-01 10:00:00    | 2024-01-01 10:00:00    | false     | Ünlüler    |
| 2   | 2024-01-01 10:00:00    | 2024-01-01 10:00:00    | false     | Gönüllüler |

## API Endpoints

The application exposes the following endpoints for CRUD operations:

### CompetitorController

- `GET /api/competitors` - Retrieve a list of all competitors.
- `GET /api/competitors/{id}` - Retrieve a specific competitor by ID.
- `GET /api/competitors/categories/{categoryId}` - Retrieve competitors by category.
- `POST /api/competitors` - Create a new competitor.
- `PUT /api/competitors/{id}` - Update an existing competitor.
- `DELETE /api/competitors/{id}` - Soft delete a competitor.

### CategoryController

- `GET /api/categories` - Retrieve a list of all categories.
- `GET /api/categories/{id}` - Retrieve a specific category by ID.
- `POST /api/categories` - Create a new category.
- `PUT /api/categories/{id}` - Update an existing category.
- `DELETE /api/categories/{id}` - Soft delete a category.

