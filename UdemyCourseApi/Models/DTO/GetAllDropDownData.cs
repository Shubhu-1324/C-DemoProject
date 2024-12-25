namespace UdemyCourseApi.Models.DTO
{
    public class GetAllDropDownData
    {
        public List<DropDownItemDtocs>? Sizes { get; set; }
        public List<DropDownItemDtocs>? Subcategories { get; set; }
        public List<DropDownItemDtocs>? Cities { get; set; }
        public List<DropDownItemDtocs>? Categories { get; set; }
    }
}
