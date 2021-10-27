using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Grass : Tile
{
    public override TileType TileType => TileType.Grass;
    public override GameObject GetPrefab() => Resources.Load("Grass") as GameObject;
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
