using System.Collections.Generic;

public class Game
{
    private IDictionary<string, Terrain> terrains;
    private IDictionary<string, Resource> resources;

    public Game(IDictionary<string, Terrain> terrains,
        IDictionary<string, Resource> resources)
    {
        this.terrains = terrains;
        this.resources = resources;
    }

    public Tile Tile(string terrainKey, params string[] resourceKeys)
    {
        Terrain t = terrains[terrainKey];

        IList<Resource> rs = new List<Resource>();
        foreach (string k in resourceKeys)
        {
            rs.Add(this.resources[k]);
        }

        return new Tile(t, rs);
    }
}
