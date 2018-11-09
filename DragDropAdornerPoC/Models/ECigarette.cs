namespace DragDropAdornerPoC.Models
{
    public class ECigarette
    {
        public string Model { get; set; }
        public string Type { get; set; }

        public ECigarette(string model, string type)
        {
            this.Model = model;
            this.Type = type;
        }
    }
}
