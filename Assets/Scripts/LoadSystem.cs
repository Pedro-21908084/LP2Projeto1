using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LoadSystem
{
    private const string MAP_TYPE = "*.map4x";
    private const string FOLDER_NAME = "map4xfiles";
    private const string COMMENT_SYMBOL = "#";
    private const string MAP_TO_LOAD = "MapToLoad";
    
    public List<string> MapsFound{get; private set;}
    public List<string> MapsName{get; private set;}
    private string path;

    /// <summary>
    /// Saves the string given,map , to load after.
    /// </summary>
    public static void SaveMapName(string map)
    {
        PlayerPrefs.SetString(MAP_TO_LOAD, map);
    }

    /// <summary>
    /// Checks if exist a map with the the map name saved.
    /// </summary>
    public int? MapToLoad()
    {
        string mapToLoad = PlayerPrefs.GetString(MAP_TO_LOAD);

        if(MapsFound.Contains(mapToLoad))
        {
            return MapsFound.FindIndex( 0, MapsFound.Count, x => x==mapToLoad);
        }else
        {
            return null;
        }
    }

    public LoadSystem(string folder = FOLDER_NAME)
    {
        path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            folder);

        MapsFound = new List<string>();
        MapsName = new List<string>();
        SearchForMaps();
    }

    /// <summary>
    /// Searchs for maps in the given folder, storing them and their name.
    /// </summary>
    public void SearchForMaps()
    {
        if(Directory.Exists(path))
        {
            string [] files = Directory.GetFiles(path, MAP_TYPE);
        
            if(files.Length == 0)
            {
                Debug.Log("Error: No maps found");
            }else
            {
                MapsFound.Clear();
                MapsName.Clear();
                foreach(string file in files)
                {
                    MapsFound.Add(file);
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    MapsName.Add(fileName.Split(".")[0]);
                }
            }
            
        }else
        {
            Debug.Log("Error: Path doesn't exist");
        }
    }

    /// <summary>
    /// Loads the map in the path of the given index using the gamedata passed.
    /// </summary>
    public Tile[][] LoadMapAt(int index, GameData game)
    {
        Tile[][] map;
        
        if(index < 0 || index >= MapsFound.Count)
        {
            Debug.Log("Error: Index invalid");
            return null;
        }

        if(File.Exists(MapsFound[index]))
        {
            FileStream mapFile = File.OpenRead(MapsFound[index]);
            StreamReader mapRead = new StreamReader(mapFile);
            int rows =  0, cols = 0;

            bool findMapSize = false;

            do
            {
                string line = mapRead.ReadLine();
                string noComments =  line.Split(COMMENT_SYMBOL)[0];
                
                if(noComments.Length > 0)
                {
                    string[] commands = noComments.Split(" ");
                    if(commands.Length >=2 && int.TryParse(commands[0], out rows) 
                        && int.TryParse(commands[1], out cols))
                    {
                        findMapSize  = true;
                    }
                }

                
            }while(!findMapSize || mapRead.EndOfStream);
            
            if(!findMapSize)
            {
                map = null;
            }else
            {
                map = new Tile[rows][];

                for(int  i = 0; i < rows; i++)
                {
                    map[i] = new Tile[cols];

                    for(int j = 0; j < cols; j++)
                    {
                        string line = mapRead.ReadLine();
                        string noComments =  line.Split(COMMENT_SYMBOL)[0];
                        if(noComments.Length > 0)
                        {
                            string[] commands = noComments.Trim().Split(" ");

                            TerrainData tData = game.GetTerrain(commands[0]);
                            Terrain terrain = new Terrain(tData.key, tData.coin, tData.food);

                            Resource[] resources = new Resource[commands.Length-1];

                            if(commands.Length > 1)
                            {
                                for(int l = 1; l < commands.Length; l ++)
                                {
                                    ResourceData rData = game.GetResource(commands[l]);
                                    
                                    resources[l-1] = new Resource(rData.key, 
                                        rData.coinModifier, rData.foodModifier);
                                }
                            }
                            map[i][j] = new Tile(terrain, resources);
                        }
                    }
                }
            }

        }else
        {
            Debug.Log("Error: Map not found");
            map = null;
        }
        return map;
    }
}
