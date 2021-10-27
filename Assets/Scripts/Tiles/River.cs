using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class River : Tile
{
    public override TileType TileType => TileType.Water;
    public override GameObject GetPrefab() => Resources.Load("River") as GameObject;
    public override bool CanSetTile => false;
    public GridManager gridManager;

    public override void LevelUpSelf()
    {
        if (Score < 1)
        {
            tileLevelManager.LevelUp();
            PlayLevelUpNoise();
            RaiseScoreChangedEvent();
        }
    }

    private void Update()
    {
        CheckBanks(this, gridManager);
    }

    private void Awake()
    {
        gridManager = (GridManager)FindObjectOfType(typeof(GridManager));
        levelUpNoise = this.gameObject.AddComponent<AudioSource>();
    }
    public override IEnumerator LevelUpSurroundingTiles(GridManager gridManager)
    {
        var tiles = gridManager.Tiles;
        Tile nTile;

        bool stopNeg = false, stopPos = false;
        int i = 0;
        // Keep checking until we hit the edge of the board, to deal with arbitrary-sized/shaped grids
        // (can't handle gaps or u-shaped boards, but maybe that's ok? Water wouldn't flow over the gaps!)
        while (!stopPos && !stopNeg)
        {
            if (tiles.TryGetValue(new Point(position.x, position.z + i), out nTile))
                SetTypeOnTile(nTile, settings.riverPrefab, gridManager);
            else
                stopPos = true;

            if (tiles.TryGetValue(new Point(position.x, position.z - i), out nTile))
                SetTypeOnTile(nTile, settings.riverPrefab, gridManager);
            else
                stopNeg = true;

            i++;
            yield return new WaitForSeconds(settings.timeBetweenWaterTiles);
            
        }


        
    }

    public static void CheckBanks(Tile tileToCheck, GridManager gridManager)
    {
        var tiles = gridManager.Tiles;
        Tile nTile;
        RiverBanks banks = tileToCheck.GetComponent<RiverBanks>();

        if (banks != null && !tileToCheck.isInMoveList)
        {
            banks.SetBankActive("top", !tiles.TryGetValue(new Point(tileToCheck.position.x, tileToCheck.position.z + 1), out nTile));
            banks.SetBankActive("bottom", !tiles.TryGetValue(new Point(tileToCheck.position.x, tileToCheck.position.z - 1), out nTile));
        }


    }
}
