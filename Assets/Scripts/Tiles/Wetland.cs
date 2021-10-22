using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Wetland : Tile
{
    public override TileType TileType => TileType.Wetland;
    public override GameObject GetPrefab() => Resources.Load("Wetland") as GameObject;
    public override IEnumerator LevelUpSurroundingTiles(IGridManager gridManager)
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
