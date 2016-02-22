namespace LostPets.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using Types;

    public class Post : BaseModel<int>
    {
        private ICollection<Photo> gallery;
        private ICollection<Comment> comments;

        public Post()
        {
            this.gallery = new HashSet<Photo>();
            this.comments = new HashSet<Comment>();
        }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Content { get; set; }

        [Required]
        public PostType PostType { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int PetId { get; set; }

        public virtual Pet Pet { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<Photo> Gallery
        {
            get
            {
                return this.gallery;
            }

            set
            {
                this.gallery = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }
    }
}
