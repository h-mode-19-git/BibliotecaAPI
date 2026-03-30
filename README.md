# Biblioteca API

## ✅ 1. Clonar el repositorio
git clone https://github.com/tu-usuario/BibliotecaAPI.git
cd BibliotecaAPI

## ▶️ 2. Crear DB: 
## Crear la db en SQL Server: "CREATE DATABASE [BibliotecaDB]"

## ✅ 2. Configurar la base de datos
## Editar el archivo appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=BibliotecaDb;Trusted_Connection=True;TrustServerCertificate=True;"
}

## ✅ 3. Aplicar migraciones
dotnet ef database update
## ⚠️ Asegurate de tener instalada la herramienta:
dotnet tool install --global dotnet-ef

✅ 4. Ejecutar la API
dotnet run
## La API estará disponible en:
## https://localhost:5001
## http://localhost:5000

## 🔗 Endpoints

GET /api/libros/GetAll
GET /api/libros/GetById/{id}
POST /api/libros/Add
PUT /api/libros/Update/{id}
DELETE /api/libros/Delete/{id}

## 🧪 Tests

dotnet test
