# Biblioteca API


## ✅ 1. Clonar el repositorio
git clone https://github.com/tu-usuario/tu-repo.git
cd tu-repo




## ▶️ Crear DB: 

## 1) Crear la db en SQL Server: "CREATE DATABASE [BibliotecaDB]"
## 2) Modificar el "ConnectionStrings" (Parametro Server -> XXXXX) en "appsettings.json" item "DefaultConnection": "Server=XXXXX;Database=BibliotecaDB;Trusted_Connection=True;TrustServerCertificate=True;"
## 3) Posicionarse en "**/BibliotecaAPI.API"
## 4) cd BibliotecaAPI.API
dotnet ef database update

## ▶️ Ejecutar

dotnet restore
dotnet ef database update
dotnet run

## 🔗 Endpoints

GET /api/libros/GetAll
GET /api/libros/{id}
POST /api/libros
PUT /api/libros/{id}
DELETE /api/libros/{id}

## 🧪 Tests

dotnet test