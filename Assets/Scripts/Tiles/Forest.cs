using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Forest : Tile
{
    public override TileType TileType => TileType.Forest;
    public override GameObject GetPrefab() => Resources.Load("Forest") as GameObject;

    public override void LevelUpSelf()
    {
        tileLevelManager.LevelUp();
        PlayLevelUpNoise();
        RaiseScoreChangedEvent();
    }
    public override IEnumerator LevelUpSurroundingTiles(GridManager gridManager)
    {
        var tiles = gridManager.tiles;

        Tile nTile;
        if (tiles.TryGetValue(new Point(position.x + 1, position.z), out nTile))
        {
            SetTypeOnTile(gridManager, nTile, settings.forestPrefab);
        }
        //yield return new WaitForSeconds(Random.Range(0, settings.timeBetweenForestTiles));

        if (tiles.TryGetValue(new Point(position.x, position.z + 1), out nTile))
        {
            SetTypeOnTile(gridManager, nTile, settings.forestPrefab);
        }
        //yield return new WaitForSeconds(Random.Range(0, settings.timeBetweenForestTiles));

        if (tiles.TryGetValue(new Point(position.x - 1, position.z), out nTile))
        {
            SetTypeOnTile(gridManager, nTile, settings.forestPrefab);
        }
        //yield return new WaitForSeconds(Random.Range(0, settings.timeBetweenForestTiles));

        if (tiles.TryGetValue(new Point(position.x, position.z - 1), out nTile))
        {
            SetTypeOnTile(gridManager, nTile, settings.forestPrefab);
        }
        yield return null;
    }

}
