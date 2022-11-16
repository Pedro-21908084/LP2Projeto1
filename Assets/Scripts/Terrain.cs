public class Terrain
{
    public string Type { get; }
    public int Coin { get; }
    public int Food { get; }
    
    public Terrain(string type, int coin, int food)
    {
        Type = type;
        Coin = coin;
        Food = food;
    }
}
