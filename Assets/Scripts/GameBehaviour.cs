using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    [SerializeField] private TerrainData[] configuredTerrains;
    [SerializeField] private ResourceData[] configuredResources;
    private Game game;
    
    private void Awake()
    {
        IDictionary<string, Terrain> terrainMap = new Dictionary<string, Terrain>();
        foreach (TerrainData data in configuredTerrains)
        {
            Terrain newTerrain = new Terrain(data.key,
                data.coin, data.food);
            terrainMap[data.key] = newTerrain;
        }

        IDictionary<string, Resource> resourceMap = new Dictionary<string, Resource>();
        foreach (ResourceData data in configuredResources)
        {
            Resource newResource = new Resource(data.key,
                data.coinModifier, data.foodModifier);
            resourceMap[data.key] = newResource;
        }
        
        game = new Game(terrainMap, resourceMap);
    }

    private void Start()
    {
        Tile[,] tiles = new Tile[2, 2];

        tiles[0, 0] = game.Tile("plains", "metals");
        tiles[0, 1] = game.Tile("hills", "animals", "plants");
        tiles[1, 0] = game.Tile("mountain", "metals");
        tiles[1, 1] = game.Tile("desert", "animals");
            
        for (int i = 0; i < tiles.GetLength(0); i++)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                Debug.Log(string.Format("[{0}, {1}] {2}, {3}, {4}",
                    i, j, tiles[i, j].Terrain.Type,
                    tiles[i, j].Coin, tiles[i, j].Food));
            }
        }
    }
}
