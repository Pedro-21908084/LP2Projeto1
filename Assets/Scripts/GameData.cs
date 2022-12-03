using System.Collections.Generic;

/// <summary>
/// Stores and provides information about configured terrains
/// and resources (ScriptableObjects).
/// An instance of this class is set up by the controller.
/// </summary>
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
