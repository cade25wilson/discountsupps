namespace supps.Models
{
    public class MyData
    {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public required List<DiscountsuppSupplement> Items { get; set; }

    }
}
