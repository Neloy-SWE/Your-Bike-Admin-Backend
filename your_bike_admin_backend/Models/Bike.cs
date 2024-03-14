namespace your_bike_admin_backend.Models
{
    public class Bike
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string BrandName { get; set; }
        public double CC { get; set; }
        public int Gears { get; set; }
        public required string MaxPower { get; set; }
        public required string MaxTorque { get; set; }
        public required string Mileage { get; set; }
        public double FuelTankCapacity { get; set; }
        public double EngineOilCapacity { get; set; }
        public double SeatHeight { get; set; }
        public required string FrontSuspension { get; set; }
        public required string RearSuspension { get; set; }
        public required string FrontBreak { get; set; }
        public required string RearBreak { get; set; }
        public required string FrontWheel { get; set; }
        public required string RearWheel { get; set; }
        public required string FrontTyre { get; set; }
        public required string RearTyre { get; set; }
    }
}
