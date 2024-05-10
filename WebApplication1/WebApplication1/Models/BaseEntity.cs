namespace WebApplication1.Models
{
    public class BaseEntity
    {
        //Her classda olmasi lazim olan fieldleri burda yaradiriq
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedTime { get; set; }   

    }
}
