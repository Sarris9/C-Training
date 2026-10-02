using FinalBattle.Characters;


namespace FinalBattle
{
    public interface IAction
    {
        public void Turn(List<Monster> enemies, Monster monster, Inventory inventory, bool IsEnabled);
    }
}
