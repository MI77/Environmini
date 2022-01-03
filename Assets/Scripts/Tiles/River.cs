using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class River : Tile
{
    public override TileType TileType => TileType.River;
    //public override GameObject GetPrefab() => Resources.Load("River") as GameObject;
    //public override GameObject GetTemplate() => Resources.Load("RiverTemplate") as GameObject;
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
        gridManager = FindObjectOfType<GridManager>();
        levelUpNoise = this.gameObject.AddComponent<AudioSource>();
    }
    public override IEnumerator LevelUpSurroundingTiles(GridManager gridManager)
    {
        var tiles = gridManager.tiles;
        
        Tile nTile;
        for (int i = 1; i < gridManager.gridSize; i++)
        {
            if (tiles.TryGetValue(new Point(position.x, position.z + i), out nTile))
            {
                SetTypeOnTile(gridManager, nTile, settings.riverPrefab);
            }

            if (tiles.TryGetValue(new Point(position.x, position.z - i), out nTile))
            {
                SetTypeOnTile(gridManager, nTile, settings.riverPrefab);
            }
            yield return new WaitForSeconds(settings.timeBetweenWaterTiles);
            
        }
        
    }

    public static void CheckBanks(Tile tileToCheck, GridManager gridManager)
    {
        RiverBanks banks = tileToCheck.GetComponent<RiverBanks>();

        if (banks != null && !tileToCheck.isInMoveList)
        {
            banks.SetBankActive("top", tileToCheck.position.z == gridManager.gridMax);
            banks.SetBankActive("bottom", tileToCheck.position.z == gridManager.gridMin);
        }


    }
}
