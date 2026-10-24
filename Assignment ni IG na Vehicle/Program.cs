using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        Car car = new Car("103","Honda",100,5);
        Customer customer = new Customer("Alice","AB1234");
        customer.rentVehicle(car);
        customer.printRentalSummary(5);
    }
}

class Customer
{
    private string Name;
    private string licenseNumber;
    private Vehicle rentedVehicle;

    public Customer(string name, string licenseNumber)
    {
        Name = name;
        this.licenseNumber = licenseNumber;
    }

    public void rentVehicle(Vehicle v)
    {
        rentedVehicle = v;
    }

    public void returnVehicle()
    {
        
    }

    public void printRentalSummary(int days)
    {
        
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

    public virtual double calculateRentalCost(int days)
    {
        return dailyRate * days;
    }

    public void displayInfo()
    {
        
    }
}

class Car : Vehicle
{
    private int numSeats;

    public Car(string id, string brand, double rate, int seats)
    {
        vehicleId = id;
        this.brand = brand;
        dailyRate = rate;
        numSeats = seats;
    }

    public override double calculateRentalCost(int days)
    {
        
    }

    public void displayInfo()
    {
        
    }
}

class Motorcycle
{
    private int engineCapacity;

    public Motorcycle(string id, string brand, double rate, int cc)
    {
        
    }

    public double calculateRentalCost(int days)
    {
        
    }

    public void displayInfo()
    {
        
    }
}