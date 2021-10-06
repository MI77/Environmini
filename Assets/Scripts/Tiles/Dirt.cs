using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Dirt : Tile
{
    public override TileType TileType => TileType.Dirt;
    public override GameObject GetPrefab() => Resources.Load("Dirt") as GameObject;
    public override IEnumerator LevelUpSurroundingTiles(GridManager gridManager)
    {
        yield return null;
    }

    public override void LevelUpSelf()
    {
 
    }
}