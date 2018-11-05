namespace Data
{
    public interface IUnit
    {
        uint Movement { get; }
        Faction Faction { get; }
        bool IgnoresTerrain { get; }
    }
}
