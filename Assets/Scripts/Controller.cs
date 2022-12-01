using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private ResourceData[] resourcesAvailable;
    [SerializeField] private TerrainData[] terrainsAvailable;
    [SerializeField] private TestView view;

    private Game game;

    private Tile[][] map;
    private LoadSystem loadSystem;
    

    void Awake()
    {
        IDictionary<string, Resource> resourceDictionary = new Dictionary<string, Resource>();
        foreach(ResourceData data in resourcesAvailable)
        {
            resourceDictionary.Add(data.key, new Resource(data.key, data.coinModifier, data.foodModifier));
        }

        IDictionary<string, Terrain> terrainDictionary = new Dictionary<string, Terrain>();
        foreach(TerrainData data in terrainsAvailable)
        {
            terrainDictionary.Add(data.key, new Terrain(data.key, data.coin, data.food));
        }

        game = new Game(terrainDictionary, resourceDictionary);

        loadSystem = new LoadSystem();
        

        view.controller = this;

        LoadMap();
    }

    private void Update()
    {
        
    }

    private void LoadMap()
    {
        int? mapIndex = loadSystem.MapToLoad();
        
        if(mapIndex.HasValue)
        {
            map = loadSystem.LoadMapAt(mapIndex.Value, game);

            view.ShowMap(map);
        }

        
    }

    public void SelectTileAt(int rows, int cols)
    {
        if(map != null)
        {
            view.ShowTileInfo(map[rows][cols]);
        }
    }

}
