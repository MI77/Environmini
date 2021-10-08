using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

public class Dirt : Tile
{
    public MeshRenderer block;
    public override TileType TileType => TileType.Dirt;
    public override GameObject GetPrefab() => Resources.Load("Dirt") as GameObject;
    public override IEnumerator LevelUpSurroundingTiles(GridManager gridManager)
    {
        yield return null;
    }

    public override void LevelUpSelf()
    {
 
    }

    private void Awake()
    {
        RandomizeColor();
    }
    private void RandomizeColor()
    {
        Material mat = block.materials[0];
        
        Color color = mat.color;
        int r = UnityEngine.Random.Range(-8, 8);
        int d = 400;

        color.r += (float)r / d;
        color.g += (float)r / d;
        color.b += (float)r / d;

        mat.color = color;
    }

}