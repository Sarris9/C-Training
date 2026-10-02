namespace FinalBattle
{
    public record class MenuItem
    {
        public string? Description { get; set; } = "Choose a gameplay:\n1.Player vs Computer\n2.Computer vs Computer\n3.Player vs Player";
        public (bool,bool) IsEnabled { get; set; }
        public IAction? ActionToPerform { get; set; } = new Action();

    }
}
