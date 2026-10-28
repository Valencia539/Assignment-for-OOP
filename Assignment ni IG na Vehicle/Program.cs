using System;
using System.Collections.Generic;

class Program
{
    static void Main(String[] args)
    {
        List<Vehicle> vehicles = new List<Vehicle>
        {
            new Car("101", "Toyota", 100, 5),
            new Motorcycle("102", "Yamaha", 50, 150)
        };

        Console.WriteLine("=== Vehicle Rental Costs ===");

        foreach (Vehicle vehicle in vehicles)
        {
            vehicle.displayInfo();

            double cost = vehicle.calculateRentalCost(3);

            Console.WriteLine(
                $"Cost for {3} days: {cost:F2}\n");
        }

        Customer customer = new Customer("Alice", "AB1234");

        customer.rentVehicle(vehicles[0]);

        customer.printRentalSummary(5);
    }
}

class Customer
{
    private string name;
    private string licenseNumber;
    private Vehicle rentedVehicle;

    public Customer(string name, string licenseNumber)
    {
        this.name = name;
        this.licenseNumber = licenseNumber;
    }

    public void rentVehicle(Vehicle v)
    {
        rentedVehicle = v;
    }

    public void returnVehicle()
    {
        rentedVehicle = null;
    }

    public virtual void printRentalSummary(int days)
    {
        Console.WriteLine("\n=== Customer Rental Summary ===");
        Console.WriteLine($"Customer: {name} (License: {licenseNumber})");

        if (rentedVehicle != null)
        {
            double totalCost = rentedVehicle.calculateRentalCost(days);

            Console.WriteLine($"Rented: {rentedVehicle.Brand} Car");
            Console.WriteLine($"Total Cost for {days} days: ${totalCost:F2}");
        }
        else
        {
            Console.WriteLine("No vehicle currently rented.");
        }
    }
}
class Vehicle
{
    protected string vehicleId;
    protected string brand;
    protected double dailyRate;

    public Vehicle(string vehicleId, string brand, double dailyRate)
    {
        this.vehicleId = vehicleId;
        this.brand = brand;
        this.dailyRate = dailyRate;
    }
    public string Brand
    {
        get { return brand; }
    }

    public virtual double calculateRentalCost(int days)
    {
        return dailyRate * days;
    }

    public virtual void displayInfo()
    {
        Console.Write($"=== Vehicle Rental Costs ===\nVehicle [ID={vehicleId}, Brand={brand}] -> ");
    }
}

class Car : Vehicle
{
    private int numSeats;

    public Car(string id, string brand, double rate, int seats): base(id, brand, rate)
    {
        numSeats = seats;
    }

    public override double calculateRentalCost(int days)
    {
        return base.calculateRentalCost(days)*1.10;
    }

    public override void displayInfo()
    {
        Console.Write($"Car [ID={vehicleId}, Brand={brand}, Seats={numSeats}] -> ");
    }
}

class Motorcycle : Vehicle
{
    private int engineCapacity;

    public Motorcycle(string id, string brand, double rate, int cc): base(id, brand, rate)
    {
        engineCapacity = cc;
    }

    public override double calculateRentalCost(int days)
    {
        return base.calculateRentalCost(days)*0.95;
    }

    public override void displayInfo()
    {
        Console.Write($"Motorcycle [ID={vehicleId}, Brand={brand}, CC={engineCapacity}] -> ");
    }
}
