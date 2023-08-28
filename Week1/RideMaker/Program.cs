using System;

Vehicle car1 = new Vehicle("Audi",6,"blue",true); 
Vehicle car2 = new Vehicle("Kia",3,"white",false); 
Vehicle car3 = new Vehicle("Mazda","Grey"); 
Vehicle car4 = new Vehicle("Toyota","green"); 
List<Vehicle> ListCars = new List<Vehicle>();
ListCars.Add(car1);
ListCars.Add(car2);
ListCars.Add(car3);
ListCars.Add(car4);

foreach(Vehicle car in ListCars)
{
    car.ShowInfo();
}
car1.Trip(100);
car1.ShowInfo();