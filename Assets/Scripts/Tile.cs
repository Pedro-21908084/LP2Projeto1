using System.Collections.Generic;

public class Tile
{
    private IList<Resource> resources;

    public Terrain Terrain { get; }
    public ICollection<Resource> Resources { get => resources; }

    /// <summary>
    /// Total coin production from terrain and resources.
    /// <summary>
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
    
    /// <summary>
    /// Total food production from terrain and resources.
    /// </summary>
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