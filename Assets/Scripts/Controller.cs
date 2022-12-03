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
    public IGameView View{get; private set;}

    private GameData gameData;

    public Tile[][] Map{get;private set;}
    public LoadSystem LoadSystem{get; private set;}
    

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

        LoadSystem = new LoadSystem();

        if(viewObject is IGameView)
        {
            View = viewObject as IGameView;
            View.SetupDisplay(this, XPadding, YPadding, gameData, GetComponent<MenusController>());
        }
            

        LoadMap();
    }

    private void Update()
    {
        
    }

    private void LoadMap()
    {
        int? mapIndex = LoadSystem.MapToLoad();
        
        if(mapIndex.HasValue)
        {
            Map = LoadSystem.LoadMapAt(mapIndex.Value, gameData);
            mapSize =  new Vector2(Map[0].Length, Map.Length);

            View.ShowMap(Map);
        }

        
    }
}
