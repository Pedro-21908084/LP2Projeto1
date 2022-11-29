using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LoadSystem
{
    private const string MAP_TYPE = "*.map4x";
    private const string FOLDER_NAME = "map4xfiles";
    private const string COMMENT_SYMBOL = "#";
    
    public List<string> MapsFound{get; private set;}
    private string path;

    public LoadSystem(string folder = FOLDER_NAME)
    {
        path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            folder);

        MapsFound = new List<string>();
    }

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
                foreach(string file in files)
                {
                    MapsFound.Add(file);
                }
            }
            
        }else
        {
            Debug.Log("Error: Path doesn't exist");
        }
    }

    public Tile[][] LoadMapAt(int index, Game game)
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
                            string[] resources = new string[commands.Length-1];

                            if(commands.Length > 1)
                            {
                                for(int l = 1; l < commands.Length; l ++)
                                {
                                    resources[l-1] = commands[l];
                                }
                            }
                            map[i][j] = game.Tile(commands[0], resources);

                            
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
