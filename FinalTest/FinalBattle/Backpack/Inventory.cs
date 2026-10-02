
namespace FinalBattle
{
    public class Inventory
    {
        public List<IItem> Items { get; set; } = new List<IItem>();
        public List<IGear> Gears { get; set; } = new List<IGear>();
    }
}
