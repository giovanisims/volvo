# 🚗 AutoManage API

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4)
![License](https://img.shields.io/badge/license-MIT-green)

> [!NOTE]
> 🇺🇸 **English:** RESTful API for vehicle dealership management simulation.
>
> 🇧🇷 **Português:** API RESTful para simulação de gerenciamento de concessionária de veículos.

---

## 🗺️ Database Model / Modelagem de Dados

```mermaid
erDiagram
    OWNER ||--|{ VEHICLE : "owns"
    OWNER ||--|{ ADDRESS : "has"
    VEHICLE ||--|{ ACCESSORY : "has"
    SALESPERSON ||--|{ SALE : "makes"
    SALE }|--|| VEHICLE : "sells"

    OWNER {
        int Id PK
        string Name
        string CPF_CNPJ
        string Email
        string Telephone
        DateTime BirthDate
        string CNH
        string AdditionalInfo
    }

    ADDRESS {
        int Id PK
        string CEP
        string State
        string City
        string Neighborhood
        string Street
        string Number
        string Complement
        int OwnerId FK
    }

    VEHICLE {
        int Id PK
        string Chassis
        string Model
        int Year
        string Color
        decimal Value
        double Odometer
        string SystemVersion
        int OwnerId FK
    }

    ACCESSORY {
        int Id PK
        string Name
        int VehicleId FK
    }

    SALESPERSON {
        int Id PK
        string Name
        decimal Salary
    }

    SALE {
        int Id PK
        decimal SalePrice
        DateTime SaleDate
        int VehicleId FK
        int SalespersonId FK
    }
```

## 🚀 Technologies / Tecnologias

*   **.NET 10.0**
*   **C#**
*   **ASP.NET Core Web API**
*   **Entity Framework Core** (SQL Server)
*   **AutoMapper**
*   **Swagger/OpenAPI**
*   **xUnit**

## ✨ Features / Funcionalidades

### 🇺🇸 English
*   **CRUD Operations**: Complete management for Vehicles, Owners, Salespeople, and Sales.
*   **Specific Filtering**: List vehicles ordered by Odometer and filtered by System Version.
*   **Sales Registration**: Register sales linking vehicles and salespeople.
*   **Commission Calculation**: Automated calculation of salesperson salary (Base + 1% of monthly sales).
*   **Complex Queries**: Data retrieval using Entity Framework `Include` for related data (e.g., Vehicle + Owner).

### 🇧🇷 Português
*   **CRUD Completo**: Gerenciamento de Veículos, Proprietários, Vendedores e Vendas.
*   **Listagem Filtrada**: Endpoint para listar veículos ordenados por quilometragem e filtrados por versão do sistema.
*   **Registro de Vendas**: Funcionalidade para registrar vendas associando veículo e vendedor.
*   **Cálculo de Comissões**: Lógica de negócio que calcula o salário final (Salário Base + 1% sobre vendas do mês).
*   **Consultas Complexas**: Retorno de dados completos usando `.Include()` (ex: Veículo + Proprietário).

## 🏃‍♂️ How to Run / Como Executar

### Prerequisites / Pré-requisitos
*   .NET 10.0 SDK
*   SQL Server (LocalDB or Docker container)

### Steps / Passo a Passo

1.  **Clone the repository / Clone o repositório**:
    ```bash
    git clone https://github.com/giovanisims/volvo.git
    cd volvo/AutoManage
    ```

2.  **Configure Database / Configure o Banco**:
    Update `appsettings.json` with your connection string.
    Atualize o `appsettings.json` com sua string de conexão.

    *Example/Exemplo:* `"Server=(localdb)\\mssqllocaldb;Database=AutoManage;Trusted_Connection=True;"`

3.  **Run Migrations / Execute Migrations**:
    ```bash
    dotnet ef database update
    ```

4.  **Start Application / Inicie a Aplicação**:
    ```bash
    dotnet run
    ```

5.  **Documentation / Documentação**:
    Access/Acesse: `http://localhost:5xxx/swagger`
