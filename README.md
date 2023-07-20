# Hotel Booking Service Backend

## Description

This backend system powers a hotel booking service, providing a scalable and concurrent-safe environment for real-time room availability checking, booking, and cancellation. The service is built to prevent overbooking scenarios and ensure smooth operation even under heavy load.

## Technologies Used

* Language: C#
* Database: SQLite
* Cloud: Azure Functions (for autoscaling)
* Other: Docker (for containerization), CI/CD (for continuous integration and delivery)

## Features

1. **Real-Time Room Availability**: The system keeps track of room availability in real-time to ensure accurate information display.
2. **Booking and Cancellation**: Users can easily book available rooms and cancel their bookings as needed.
3. **Overbooking Prevention**: Implemented strategies to prevent overbooking situations.
4. **Scalability**: The system is designed to handle increasing demand smoothly, powered by Azure Functions.

## Getting Started

### Prerequisites

Ensure that you have the following installed on your local machine:

* .NET Core 3.1 or later
* SQLite

### Installation 

Clone the repository:
git clone https://github.com/danlin7L/Hotel_Booking_Service.git
