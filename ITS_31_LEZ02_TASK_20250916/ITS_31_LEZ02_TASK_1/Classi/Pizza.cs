namespace ITS_31_LEZ02_TASK_1.Classi
{
    public class Pizza
    {
        public int Id { get; set; }
        public string? Nome { get; set; } = null!;
        public bool IsVegana { get; set; }
        public decimal Prezzo { get; set; }
        public List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();
    }
}
