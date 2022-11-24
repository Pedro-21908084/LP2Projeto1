public class Resource
{
    public string Type { get; }
    public int CoinModifier { get; }
    public int FoodModifier { get; }
    
    public Resource(string type, int coinModifier, int foodModifier)
    {
        Type = type;
        CoinModifier = coinModifier;
        FoodModifier = foodModifier;
    }
}
