using FinalBattle.Characters;

namespace FinalBattle
{
    public interface IItem
    {
        public string? Name { get; }
        public void Use(Monster user);
    }
}
