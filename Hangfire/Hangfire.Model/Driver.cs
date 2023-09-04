namespace Hangfire.Model
{
    public class Driver
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DriveNumber { get; set; }
        public int Status { get; set; }
    }
}