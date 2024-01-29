# DigitalThinkersAssignment
# Vending Machine API

## Overview
This ASP.NET API provides endpoints to manage the stock and checkout process for a vending machine that accepts bills and coins in HUF (Hungarian Forint).

## Project preparation guide

1. Clone the repository with the following command: 
**git clone** https://github.com/Ganjaa1/DigitalThinkersAssignment
2. Open the Project in Visual Studio
3. Building and Running with **IIS Express**

## Accessing the Endpoints
> **Swagger UI**:
Open a web browser and navigate to https://localhost:44312/swagger/index.html to access the Swagger UI.
Explore and interact with the API endpoints using the Swagger UI.

## Error Handling
> The API is prepared to handle common exceptions and use cases, providing informative error responses.

# Endpoints

## POST /api/v1/Checkout
Accepts a JSON payload in a POST request, containing bills and coins to be loaded into the vending machine.
**Example JSON payload:**
```json
{
  "1000": 5,
  "500": 10,
  "200": 20,
  "100": 10
}
```

## POST /api/v1/Checkout
Accepts a JSON payload similar to the one used in the POST request for the Stock endpoint. Represents bills and coins inserted by the customer during purchase, including the total price of the purchase and the currency.
**The currecy types can be 0 - HUF , 1 - EUR.**
**Example JSON payload:**
```json
{
  "inserted": {
  "1000": 3,
  "500": 1
  },
  "price": 3200,
  "currency": 0
}
```