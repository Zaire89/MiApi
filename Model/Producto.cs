namespace MyFirstAPI.Model
{
    public class Producto
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int IdUser { get; set; }

        public int SelPrice { get; set; }

    }
}
