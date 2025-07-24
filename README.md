# MongoDB API Setup Guide

This project is based on the official [ASP.NET Core + MongoDB tutorial.](https://learn.microsoft.com/es-es/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-8.0&tabs=visual-studio)

## 📦 Technologies Used
* ASP.NET Core 8.0
* MongoDB Community Edition
* MongoDB Shell (`mongosh`)
* C#
* RESTful API

## ⚙️ Prerequisites
* [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download)
* Install `mongosh` based on your operating system using the official [MongoDB Shell Installation Guide.](https://www.mongodb.com/docs/mongodb-shell/install/)
* Install MongoDB Community Edition according to your platform using the [MongoDB Installation Manual.](https://www.mongodb.com/docs/manual/installation/)

## 🚀 Getting Started

### 🛠️ Database Setup
Once your local environment is set up, follow these steps to prepare the database:

1. Connect to MongoDB using:

    ```bash
    mongosh --port 27017
    ```

2. Create the database:

    ```bash
    use ApiMongoDB
    ```

3. Create the `Users` collection:

    ```bash
    db.createCollection('Users')
    ```

4. Insert a sample user:

    ```bash
    db.Users.insertOne({
      email: 'johndoe@email.com',
      password: 'p@ssw0rD',
      first_name: 'John',
      last_name: 'Doe'
    })
    ```

5. Verify the insertion:

    ```bash
    db.Users.find({ first_name: 'John' })
    ```

> *Note: If you choose a different database name, make sure to update the connection string in `appsettings.json` accordingly.*

### ▶️ Running the Application

1. Clone the repository:

    ```bash
    git clone https://github.com/GinaFraMi/ApiMongoDB.git
    ```

2. Navigate to the project directory:

    ```bash
    cd ApiMongoDB
    ```

3. Restore dependencies and build the project:

    ```bash
    dotnet restore
    dotnet build
    ```

4. Run the application:

    ```bash
    dotnet run
    ```

## 📮 API Endpoints

| Method | Endpoint          | Description             |
|:------:|:-----------------:|:-----------------------:|
| GET    | `/api/users`      | Get all users           |
| GET    | `/api/users/{id}` | Get a user by ID        |
| POST   | `/api/users`      | Create a new user       |
| PUT    | `/api/users/{id}` | Update an existing user |
| DELETE | `/api/users/{id}` | Delete a user           |

## 📋 Schemas

**User**

```json
{
  "id": "string (nullable)",
  "email": "string (nullable)",
  "password": "string (nullable)",
  "firstName": "string (nullable)",
  "lastName": "string (nullable)"
}
