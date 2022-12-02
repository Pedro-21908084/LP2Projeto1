using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private ResourceData[] resourcesAvailable;
    [SerializeField] private TerrainData[] terrainsAvailable;
    [field: SerializeField] private Component viewObject;
    [field: SerializeField] public float XPadding{get; private set;}
    [field: SerializeField] public float YPadding{get; private set;}
    public Vector2 mapSize{get; private set;}
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
        {
            view = viewObject as IGameView;
            view.SetupDisplay(this, XPadding, YPadding, gameData);
        }
            

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
            mapSize =  new Vector2(map[0].Length, map.Length);

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
