namespace StudentPortal.Mvc.Models
{
    public class CombinedModel
    {
        public StudentVm Student { get; set; } = new();
        public CourseVm Course { get; set; } = new();
    }
}
