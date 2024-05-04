namespace API.Entities
{
    public class PictureUrl
    {

        public Guid Id { get; set; }
        public string Url { get; set; }

        //Navigation property
        public Product Product { get; set; }
        //Foreign Key
        public Guid ProductId { get; set; }

        public PictureUrl()
        {
            Id = Guid.NewGuid();
        }
    }
}
