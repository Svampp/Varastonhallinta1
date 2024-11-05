namespace Varastonhallinta
{
    public class Tuote
    {
        public int Id { get; set; }
        public string Tuotenimi { get; set; }
        public int Tuotenhinta { get; set; }
        public int VarastoSaldo { get; set; }
    }
}
