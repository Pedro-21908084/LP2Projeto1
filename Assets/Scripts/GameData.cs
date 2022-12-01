public class GameData
{
    private IDictionary<string, TerrainData> terrains;
    private IDictionary<string, ResourceData> resources;
    
    public GameData(IDictionary<string, TerrainData> terrains,
        IDictionary<string, ResourceData> resources)
    {
        this.terrains = terrains;
        this.resources = resources;
    }
    
    public TerrainData GetTerrain(string key)
    {
        return terrains[key];
    }
    
    public ResourceData GetResource(string key)
    {
        return resources[key];
    }
}
