using System;
using System.Collections.Generic;
using System.Net;

class Program
{
    static void Main()
    {
        CleaningRobot cleaningRobot = new CleaningRobot("Clean Freak", new LithiumBattery());
        DeliveryRobot deliveryRobot = new DeliveryRobot("Speedy Delivery", new SolarBattery());

        cleaningRobot.PerformTask();
        deliveryRobot.PerformTask();

        cleaningRobot.Recharge(100);
        cleaningRobot.Recharge(100);
        deliveryRobot.Recharge(10);
        
        cleaningRobot.PerformTask();
        cleaningRobot.PerformTask();

        deliveryRobot.PerformTask();
        deliveryRobot.PerformTask();
        deliveryRobot.PerformTask();
        deliveryRobot.PerformTask();
        deliveryRobot.PerformTask();
        deliveryRobot.PerformTask();
        deliveryRobot.PerformTask();
        deliveryRobot.PerformTask();
        deliveryRobot.PerformTask();
        deliveryRobot.PerformTask();
        deliveryRobot.PerformTask();
        deliveryRobot.PerformTask();
        deliveryRobot.PerformTask();


        List<Robot> robots = new List<Robot>{cleaningRobot, deliveryRobot};

        Console.WriteLine("\nRobots:");
        foreach (Robot robot in robots)
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Name of Robot: " + robot.Name);
            Console.WriteLine("===============================");
        }
    }
}

abstract class Robot 
{
    private IBattery _battery;
    public string Name;
    public Robot(string name, IBattery battery){
        Name = name;
        _battery = battery;
    }
    public void Recharge(int amount)
    {
        _battery.Recharge(amount);
        Console.WriteLine($"Remaining Energy of {Name} after recharge: {_battery.RemainingEnergy}");
    }

    protected void UseEnergy(int amount)
    {
            _battery.Consume(amount);
            Console.WriteLine($"Remaining Energy of {Name}: {_battery.RemainingEnergy}");
        
    }

    public abstract void PerformTask();
}

class CleaningRobot : Robot
{   
    public CleaningRobot(string name, IBattery battery): base(name, battery)
    {
        Console.WriteLine($"A cleaning robot named {name} is created.");
    }
    public override void PerformTask()
    {
        UseEnergy(10);
    }
}

class DeliveryRobot : Robot
{
    public DeliveryRobot(string name, IBattery battery): base(name, battery)
    {
        Console.WriteLine($"A delivery robot named {name} is created.");
    }
    public override void PerformTask()
    {   
        UseEnergy(10);
    }
}

interface IBattery
{
    public int RemainingEnergy{get;}
    public void Consume(int amount);
    public void Recharge(int amount);
}

class LithiumBattery : IBattery
{
    private int _remainingEnergy = 100;

    public int RemainingEnergy
    {
        get{return _remainingEnergy;}
        set
        {
            if (value > 100)
            {
                _remainingEnergy = 100;
            }
            else if (value < 0)
            {
                _remainingEnergy = 0;
            }
            else
            {
                _remainingEnergy = value;
            }
        }
    }

    public void Consume(int amount)
    {
        if (amount > 0)
        {
            if (RemainingEnergy <= 0)
            {
                Console.WriteLine("The robot is out of energy.");
                return;
            }
            else
            {
                RemainingEnergy -= amount;
                Console.WriteLine($"The robot consumed {amount} energy.");
            }
        }
    }

    public void Recharge(int amount)
    {
        if (amount > 0)
        {
            if(RemainingEnergy >= 100)
            {
                return;
            }
            else
            {
                RemainingEnergy += amount;
                Console.WriteLine($"The robot recharged {amount} energy.");
            }
        }
    }
}

class SolarBattery : IBattery
{
    private int _remainingEnergy = 100;
    public int RemainingEnergy
    {
        get{return _remainingEnergy;}
        set
        {
            if (value > 100)
            {
                _remainingEnergy = 100;
            }
            else if (value < 0)
            {
                _remainingEnergy = 0;
            }
            else
            {
                _remainingEnergy = value;
            }
        }
    }

    public void Consume(int amount)
    {
        if (amount > 0)
        {
            if (RemainingEnergy <= 0)
            {
                Console.WriteLine("The robot is out of energy.");
                return;
            }
            else
            {
                RemainingEnergy -= amount;
                Console.WriteLine($"The robot consumed {amount} energy.");
            }
        }
    }

    public void Recharge(int amount)
    {
        if (amount > 0)
        {
            if(RemainingEnergy >= 100)
            {
                return;
            }
            else
            {
                RemainingEnergy += amount;
                Console.WriteLine($"The robot recharged {amount} energy.");
            }
        }
    }
}
