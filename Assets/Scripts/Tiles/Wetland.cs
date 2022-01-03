using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Wetland : Tile
{
    public override TileType TileType => TileType.Wetland;

    //public override GameObject GetPrefab() => Resources.Load(TileType.ToString()) as GameObject;
    //public override GameObject GetTemplate() => Resources.Load(TileType.ToString() + "Template") as GameObject;
    public override IEnumerator LevelUpSurroundingTiles(GridManager gridManager)
    {
        yield return null;
    }

    public override void LevelUpSelf()
    {
        tileLevelManager.LevelUp();
        PlayLevelUpNoise();
        RaiseScoreChangedEvent();
    }
}
