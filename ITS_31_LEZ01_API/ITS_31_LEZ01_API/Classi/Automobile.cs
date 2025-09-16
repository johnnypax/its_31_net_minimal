namespace ITS_31_LEZ01_API.Classi
{
    public class Automobile
    {
        public int Id { get; set; }
        public string? Targa { get; set; }
        public string Marca { get; set; } = null!;
        public string Modello { get; set; } = null!;
        public decimal Prezzo { get; set; }
    }
}
