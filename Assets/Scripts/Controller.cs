using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private ResourceData[] resourcesAvailable;
    [SerializeField] private TerrainData[] terrainsAvailable;
    [field: SerializeField] private Component viewObject;
    private IGameView view;

    private GameData gameData;

    private Tile[][] map;
    private LoadSystem loadSystem;
    

    void Awake()
    {
        IDictionary<string, ResourceData> resourceDictionary = new Dictionary<string, ResourceData>();
        foreach(ResourceData data in resourcesAvailable)
        {
            resourceDictionary.Add(data.key, data);
        }

        IDictionary<string, TerrainData> terrainDictionary = new Dictionary<string, TerrainData>();
        foreach(TerrainData data in terrainsAvailable)
        {
            terrainDictionary.Add(data.key, data);
        }

        gameData = new GameData(terrainDictionary, resourceDictionary);

        loadSystem = new LoadSystem();

        if(viewObject is IGameView)
            view = viewObject as IGameView;

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
            map = loadSystem.LoadMapAt(mapIndex.Value, gameData);

            view.ShowMap(map, gameData);
        }

        
    }

    public void SelectTileAt(int rows, int cols)
    {
        if(map != null)
        {
            view.ShowTileInfo(map[rows][cols], gameData);
        }
    }

}
