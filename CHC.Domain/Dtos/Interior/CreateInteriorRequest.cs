namespace CHC.Domain.Dtos.Interior
{
    public class CreateInteriorRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public double TotalPrice { get; set; } = 0;
        public string ImageUrl { get; set; } = "img/interior/livingroom1";
        public Guid StaffId { get; set; }
    }
}
