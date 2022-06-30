using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        private Engine engine;
        public Engine Engine
        {
            set { engine = value; }
            get { return engine; }
        }
        private int weight;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public Car(string model , Engine engine , int weight, string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color; 
        }

        //7
        //private class Engine
        //{
        //    private int speed;
        //    private int power;
        //    public int Speed
        //    {
        //        get { return speed; }
        //        set { speed = value; }
        //    }
        //    public int Power
        //    {
        //        get { return power; }
        //        set { power = value; }
        //    }
        //    public Engine(int power, int speed)
        //    {
        //        this.power = power;
        //        this.speed = speed;
        //    }
        //}
        //public class Cargo
        //{
        //    private string type;
        //    private int weight;
        //    public string Type
        //    {
        //        get { return type; }
        //        set { type = value; }
        //    }
        //    public int Weight
        //    {
        //        get { return weight; }
        //        set { weight = value; }
        //    }
        //    public Cargo(string type,int weight)
        //    {
        //        this.type = type;
        //        this.weight = weight;
        //    }
        //}
        //public string CargoList;
        //public int enginePowerInt;
        //public List<Tires> tires = new List<Tires>();
        //public void Add(Tires tire)
        //{
        //    tires.Add(tire);
        //}
        //public class Tires
        //{
        //    private int age;
        //    public int Age
        //    {
        //        get { return age; }
        //        set { age = value; }
        //    }
        //    private double pressure;
        //    public double Pressure
        //    {
        //        get { return pressure; }
        //        set { pressure = value; }
        //    }
        //    public Tires(int age, double pressure)
        //    {
        //        this.Age = age;
        //        this.Pressure = pressure;
        //    }
        //}
        //public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType,
        //   double tyre1Pressure, int tyre1, double tyre2Pressure, int tyre2, double tyre3Pressure,
        //   int tyre3, double tyre4Pressure, int tyre4)
        //{
        //    this.model = model;
        //    Engine newEngine = new Engine(enginePower,engineSpeed);
        //    enginePowerInt = enginePower;
        //    Cargo cargo = new Cargo(cargoType,cargoWeight);
        //    CargoList = cargoType;
        //    Tires tireOne = new Tires(tyre1, tyre1Pressure);
        //    this.tires.Add(tireOne);
        //    Tires tireTwo = new Tires(tyre2, tyre2Pressure);
        //    this.tires.Add(tireTwo);
        //    Tires tireThree = new Tires(tyre3, tyre3Pressure);
        //    this.tires.Add(tireThree);
        //    Tires tireFour = new Tires(tyre4, tyre4Pressure);
        //    this.tires.Add(tireFour);
        //}
        //public bool Fragile()
        //{
        //    int count = 0;
        //    foreach(var t in this.tires)
        //    {
        //        if (t.Pressure <= 1)
        //        {
        //            count++;
        //        }
        //    }
        //    if (count!=0)
        //        return true;
        //    else
        //        return false;
        //}
        //6
        //private string model;
        //private double fuelAmount;
        //private double travelledDistance;
        //private double fuelConsumptionPerKilometer;
        //public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        //{
        //    this.Model = model;
        //    this.FuelAmount = fuelAmount;
        //    this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        //    this.travelledDistance = 0;

        //}
        //public string Model
        //{
        //    get { return model; }
        //    set { model = value; }
        //}
        //public double FuelAmount
        //{
        //    get { return fuelAmount; }
        //    set { fuelAmount = value; }
        //}
        //public double FuelConsumptionPerKilometer
        //{
        //    get { return fuelConsumptionPerKilometer; }
        //    set { fuelConsumptionPerKilometer = value; }
        //}
        //public double TravelledDistance
        //{
        //    get { return travelledDistance; }
        //    set { travelledDistance = value; }
        //}

        //public void CanItDrive(Car car, double kmNeededToTravel)
        //{
        //    double fuelUsedToTravelKm = car.FuelConsumptionPerKilometer * kmNeededToTravel;
        //    if (car.FuelAmount>=fuelUsedToTravelKm)
        //    {
        //        car.FuelAmount -= fuelUsedToTravelKm;
        //        car.TravelledDistance += kmNeededToTravel;
        //    }
        //    else
        //        Console.WriteLine("Insufficient fuel for the drive");

        //}
    }
}
