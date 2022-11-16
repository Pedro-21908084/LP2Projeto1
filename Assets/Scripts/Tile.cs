using System.Collections.Generic;

public class Tile
{
    private IList<Resource> resources;

    public Terrain Terrain { get; }
    public IEnumerable<Resource> Resources { get; }

    public int Coin
    {
        get
        {
            int total = 0;

            total += Terrain.Coin;

            foreach (Resource r in resources)
            {
                total += r.CoinModifier;
            }

            return total;
        }
    }
    
    public int Food
    {
        get
        {
            int total = 0;
            
            total += Terrain.Food;
            
            foreach (Resource r in resources)
            {
                total += r.FoodModifier;
            }
            
            return total;
        }
    }
    
    public Tile(Terrain terrain, IEnumerable<Resource> resources)
    {
        Terrain = terrain;
        
        this.resources = new List<Resource>(resources);
    }
}