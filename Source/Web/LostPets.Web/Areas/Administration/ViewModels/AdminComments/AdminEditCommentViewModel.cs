namespace LostPets.Web.Areas.Administration.ViewModels.AdminComments
{
    using System.ComponentModel.DataAnnotations;

    using Data.Common.Models;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminEditCommentViewModel : BaseModel<int>, IMapFrom<Comment>
    {
        [Required]
        [UIHint("MultiLineText")]
        public string Content { get; set; }
    }
}
