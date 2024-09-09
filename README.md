# MultiSource Tour API

This project aggregates tour data from multiple sources and provides a unified search interface.

## Features

- Aggregates tour data from three different sources: Internal (The Tour Guy), SomeOtherGuy, and TheBigGuy
- Provides a unified search endpoint with various filter options
- Supports pagination of results


## API Usage

The main endpoint for searching tours is:

```
GET /api/v1/tours
```

### Query Parameters

- `guests` : Number of guests (min: 1)
- `name` (optional): Tour name to search for
- `destination` (optional): Destination code (e.g., "MX" for Mexico)
- `supplier` (optional): Supplier enum (1: Internal, 2: SomeOtherGuy, 3: TheBigGuy)
- `maxPrice` (optional): Maximum price for tours
- `pageSize` (optional, default: 10): Number of results per page
- `pageIndex` (optional, default: 0): Page number (0-indexed)

### Example Requests

1. Basic search for 2 guests:
   ```
   https://localhost:7094/api/v1/tours?guests=2
   ```

2. Search for adventure tours in Mexico for 2 guests with a max price of $200:
   ```
   https://localhost:7094/api/v1/tours?guests=2&name=adventure&destination=MX&maxPrice=200&pageSize=10&pageIndex=0
   ```

3. Search for tours from a specific supplier (TheBigGuy) for 4 guests:
   ```
   https://localhost:7094/api/v1/tours?guests=4&supplier=3
   ```

## Project Structure

- `MultiSource.API`: Contains the API controllers and services
- `MultiSource.Domain`: Contains domain models, DTOs, and interfaces
- `MultiSource.Infrastructure`: Contains repository implementations