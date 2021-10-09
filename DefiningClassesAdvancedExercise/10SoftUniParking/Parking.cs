using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        List<Car> Cars;
        int capacity;
        public Parking(int capacity)
        {
            Cars = new List<Car>();
            this.capacity = capacity;
        }
        public int Count => Cars.Count;

        public string AddCar(Car car)
        {
            if (Cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (Cars.Count() +1 > capacity)
            {
                return "Parking is full!";
            }
            else
            {
                Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string registrationNumber)
        {
            Car car = Cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
            if (car != null)
            {
                Cars.Remove(car);
                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }
        public Car GetCar(string registrationNumber)
        {
            return Cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            Cars = Cars.Where(x => registrationNumbers.Contains(x.RegistrationNumber)).ToList();
        }
    }
}
