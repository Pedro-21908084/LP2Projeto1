using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private ResourceData[] resourcesAvailable;
    [SerializeField] private TerrainData[] terrainsAvailable;

    public Dictionary<string, TerrainData> TerrainDictionary{get; private set;}
    public Dictionary<string, ResourceData> ResourceDictionary{get; private set;}
    private Tile[][] map;
    private LoadSystem loadSystem;
    
    // Start is called before the first frame update
    void Awake()
    {
        ResourceDictionary = new Dictionary<string, ResourceData>();
        foreach(ResourceData data in resourcesAvailable)
        {
            ResourceDictionary.Add(data.key, data);
        }

        TerrainDictionary = new Dictionary<string, TerrainData>();
        foreach(TerrainData data in terrainsAvailable)
        {
            TerrainDictionary.Add(data.key, data);
        }

        loadSystem = FindObjectOfType<LoadSystem>();
    }

    private void Update()
    {
        
    }

    public void LoadMap(int index)
    {
        map = loadSystem.LoadMapAt(index, TerrainDictionary, ResourceDictionary);
    }


}
