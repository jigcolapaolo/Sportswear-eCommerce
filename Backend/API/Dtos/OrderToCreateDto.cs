namespace API.Dtos
{
    public class OrderToCreateDto
    {
        public Guid basketId { get; set; }
        //shipToAddress
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
    }
}
