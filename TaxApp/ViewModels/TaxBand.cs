namespace TaxApp.ViewModels
{
    public class TaxBand
    {
        public string Name { get; set; }
        public int LowerLimit { get; set; }
        public int? UpperLimit { get; set; }
        public int TaxRate { get; set; }
    }
}
