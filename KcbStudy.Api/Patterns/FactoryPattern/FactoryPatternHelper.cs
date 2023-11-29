using Kcb.Common;

namespace KcbStudy.Api.Patterns.FactoryPattern
{
    public interface IVehicle
    {
        string ChesisNo { get; set; }
        string Type { get; set; }
        void Drive();
    }

    public class Car : IVehicle
    {
        public string Type { get; set; }
        public string ChesisNo { get; set; }

        public Car()
        {
            Type = "CAR";
            ChesisNo = CommonMethods.GenerateRandomString(5);
        }

        public void Drive()
        {
            Console.WriteLine("Driving a car");
        }
    }

    public class Motorcycle : IVehicle
    {
        public string Type { get; set; }
        public string ChesisNo { get; set; }

        public Motorcycle()
        {
            Type = "MOTOR-CYCLE";
            ChesisNo = CommonMethods.GenerateRandomString(5);
        }

        public void Drive()
        {
            Console.WriteLine("Riding a motorcycle");
        }
    }

    public class VehicleFactory
    {
        public IVehicle CreateVehicle(string vehicleType)
        {
            switch (vehicleType.ToLower())
            {
                case "car":
                    return new Car();
                case "motorcycle":
                    return new Motorcycle();
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
        }
    }
}
