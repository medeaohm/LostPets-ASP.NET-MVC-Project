namespace LostPets.Web.ViewModels.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        [Required]
        [StringLength(1000, MinimumLength = 2)]
        public string Content { get; set; }

        public User Author { get; set; }

        public int PostId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
