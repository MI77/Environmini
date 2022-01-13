using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;

public static class TileProcessor
{
    private static Dictionary<TileType, Tile> _tiles = new Dictionary<TileType, Tile>();
    private static bool initialized;
    
    private static void Initialize()
    {
        _tiles.Clear();

        var assembly = Assembly.GetAssembly(typeof(Tile));

        var allTileTypes = assembly.GetTypes()
            .Where(t => typeof(Tile).IsAssignableFrom(t) && t.IsAbstract == false);

        foreach (var tileType in allTileTypes)
        {
            Tile tile = Activator.CreateInstance(tileType) as Tile;
            _tiles.Add(tile.TileType, tile);
        }

        initialized = true;
    }
    public static Tile GetRandomTile([Optional] bool withWater)
    {
        if (initialized == false)
            Initialize();
        
        var r = new System.Random().Next(1, 100);
        
        if (r <= 10 && withWater)
        {
            return new River();
        }
        else if (r <= 40)
        {
            return new Grass();
        }
        else if (r <= 60)
        {
            return new Wetland();
        }
        else
        {
            return new Deciduous();
        }

    }
}