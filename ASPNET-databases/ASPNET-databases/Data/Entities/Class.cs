namespace ASPNET_databases.Data.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Tank>? Products { get; set; }
    }
}
