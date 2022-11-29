using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private ResourceData[] resourcesAvailable;
    [SerializeField] private TerrainData[] terrainsAvailable;

    private Game game;

    private Tile[][] map;
    private LoadSystem loadSystem;
    
    // Start is called before the first frame update
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

        loadSystem = FindObjectOfType<LoadSystem>();
    }

    private void Update()
    {
        
    }

    public void LoadMap(int index)
    {
        map = loadSystem.LoadMapAt(index, game);
        PrintMap();
    }

    private void PrintMap()
    {
        for(int i = 0; i < map.Length; i++)
        {
            string line = "";
            for(int j = 0; j < map[i].Length; j++)
            {
                line += "|"+ map[i][j].Terrain.Type;
            }
            line+="|";
            Debug.Log(line);
        }
    }


}
