# Arena Battle Simulation

This project is a solution to a coding interview task. It simulates a battle arena where different types of heroes (Archers, Cavalry, and Swordsmen) fight according to specific rules. The battle continues until there is at most one hero left standing.

## Project Structure

- **ArenaBattle**: The main project containing the implementation of the battle simulation.
  - **Controllers**: Contains the API controllers.
  - **Models**: Contains the hero classes and other data models.
  - **Services**: Contains the business logic for the battle simulation.
- **ArenaBattle.Tests**: The test project containing unit tests for the application.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Getting Started

1. **Clone the repository**:
    ```bash
    git clone https://github.com/tigyijanos/ArenaBattle.git
    cd ArenaBattle
    ```

2. **Navigate to the main project directory**:
    ```bash
    cd ArenaBattle
    ```

3. **Restore the dependencies**:
    ```bash
    dotnet restore
    ```

4. **Build the project**:
    ```bash
    dotnet build
    ```

5. **Run the project**:
    ```bash
    dotnet run
    ```

6. **Access the API**:
    Open your browser and navigate to `https://localhost:5001/swagger` to see the Swagger UI and test the API endpoints.

## API Endpoints

- `POST /api/Arena/create`: Creates a new arena with a specified number of heroes.
- `POST /api/Arena/battle/{arenaId}`: Simulates a battle in the specified arena.

## Running Tests

1. **Navigate to the test project directory**:
    ```bash
    cd ../ArenaBattle.Tests
    ```

2. **Run the tests**:
    ```bash
    dotnet test
    ```

## Hero Types

- **Archer**:
  - Initial Health: 100
  - Attacks: Has specific rules for attacking Cavalry, Swordsmen, and other Archers.
  
- **Cavalry**:
  - Initial Health: 150
  - Attacks: Has specific rules for attacking Cavalry, Swordsmen, and Archers.
  
- **Swordsman**:
  - Initial Health: 120
  - Attacks: Has specific rules for attacking Cavalry, Swordsmen, and Archers.

## Code Structure

- **Hero Base Class**:
  - Abstract base class for all hero types.
  - Contains properties for ID, Type, and Health.
  - Methods for reducing and increasing health.

- **Derived Hero Classes**:
  - `Archer`, `Cavalry`, `Swordsman`
  - Inherit from `Hero` base class and implement type-specific logic.

- **Arena Service**:
  - Contains the main logic for creating arenas and simulating battles.
  - Methods for resolving attacks and managing hero health.

## Contribution

If you find any issues or have suggestions for improvements, feel free to open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
