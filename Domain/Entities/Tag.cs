namespace StravDuro.Domain.Entities
{
    public class Tag
    {
        public string Text { get; set; }
        public bool MatchesSearch(string compareText)
        {
            return compareText == this.Text;
        }
    }
}