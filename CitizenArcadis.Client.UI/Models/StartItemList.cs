namespace CitizenArcadis.Client.UI.Models
{
    public class StartItemList
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; } = "item.svg";

        public string PagePath { get; set; } = "faq";

        public StartItemList(string title)
        {
            this.Title = title;
        }
    }
}
