namespace LostPets.Data.Models
{
    using Common.Models;

    public class Photo : BaseModel<int>
    {
        public byte[] Content { get; set; }

        public string FileExtension { get; set; }
    }
}
