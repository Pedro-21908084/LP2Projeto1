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
        loadSystem.SearchForMaps();

        view.controller = this;
    }

    private void Update()
    {
        
    }

    public void LoadMap(int index)
    {
        map = loadSystem.LoadMapAt(index, game);

        view.ShowMap(map);
    }

    public void SelectTileAt(int rows, int cols)
    {
        if(map != null)
        {
            view.ShowTileInfo(map[rows][cols]);
        }
    }

}
