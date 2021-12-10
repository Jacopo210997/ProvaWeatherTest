namespace Acadeflix.DAL.Entities
{
    public class Media
    {
        public MediaTypeEnum MediaType { get; set; }
        public string MediaUrl { get; set; }

        public int Id { get; set; }
        public int ContentId { get; set; }
    }
}