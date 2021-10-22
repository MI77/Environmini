using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class River : Tile
{
    public override TileType TileType => TileType.Water;
    public override GameObject GetPrefab() => Resources.Load("River") as GameObject;
    public override bool CanSetTile => false;
    public IGridManager gridManager;

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
        gridManager = FindObjectOfType<GridManager>();
        if(gridManager == null)
            gridManager = FindObjectOfType<IrregularGridManager>();
        levelUpNoise = this.gameObject.AddComponent<AudioSource>();
    }
    public override IEnumerator LevelUpSurroundingTiles(IGridManager gridManager)
    {
        var tiles = gridManager.Tiles;
        Tile nTile;

        bool stopNeg = false, stopPos = false;
        int i = 0;
        // TODO : how can I do this incrementally / recursively to deal with arbitrary-sized grids?
        // (See also Tile.LevelUpAnimalTiles)
        while (!stopPos && !stopNeg)
        {
            if (tiles.TryGetValue(new Point(position.x, position.z + i), out nTile))
            {
                SetTypeOnTile(nTile, settings.riverPrefab, gridManager);
            }
            else
                stopPos = true;

            if (tiles.TryGetValue(new Point(position.x, position.z - i), out nTile))
            {
                SetTypeOnTile(nTile, settings.riverPrefab, gridManager);
            }
            else
                stopNeg = true;

            i++;
            yield return new WaitForSeconds(settings.timeBetweenWaterTiles);
            
        }


        
    }

    public static void CheckBanks(Tile tileToCheck, IGridManager gridManager)
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
