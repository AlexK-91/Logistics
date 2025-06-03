namespace Logistics.Dto.Warehouses
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<Grid> Grids { get; set; } = new List<Grid>();
        public List<Dock> Docks { get; set; } = new List<Dock>();
    }
}
