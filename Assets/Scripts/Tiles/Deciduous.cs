using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Deciduous : Tile
{
    public override TileType TileType => TileType.Deciduous;
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
            SetTypeOnTile(gridManager, nTile, settings.deciduousPrefab);
        }
        //yield return new WaitForSeconds(Random.Range(0, settings.timeBetweenForestTiles));

        if (tiles.TryGetValue(new Point(position.x, position.z + 1), out nTile))
        {
            SetTypeOnTile(gridManager, nTile, settings.deciduousPrefab);
        }
        //yield return new WaitForSeconds(Random.Range(0, settings.timeBetweenForestTiles));

        if (tiles.TryGetValue(new Point(position.x - 1, position.z), out nTile))
        {
            SetTypeOnTile(gridManager, nTile, settings.deciduousPrefab);
        }
        //yield return new WaitForSeconds(Random.Range(0, settings.timeBetweenForestTiles));

        if (tiles.TryGetValue(new Point(position.x, position.z - 1), out nTile))
        {
            SetTypeOnTile(gridManager, nTile, settings.deciduousPrefab);
        }
        yield return null;
    }

}
