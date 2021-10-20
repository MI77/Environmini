using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

public class GridManager : MonoBehaviour, IGridManager
{
    [SerializeField] public int gridSize;
    public Dictionary<Point, Tile> tiles;
    public int gridMin = 1;
    public int gridMax;

    public SettingsSO settings;

    public MoveList moveList;

    public int totalScore = 0;
    public int targetScoreForExtend;
    public ScoreManager scoreManager;
    public GameObject restartButton;

    public BonusManager bonusManager;
    public MainMenuBehaviour menuManager;

    public Camera gridCamera;

    public Texture2D timerCursor;
    public Texture2D pointerCursor;

    private bool turnIsProcessed = false;
    private bool irregularGrid = false;

    private void Update()
    {
        if (DOTween.TotalPlayingTweens() != 0)
            Cursor.SetCursor(timerCursor, Vector2.zero, CursorMode.Auto);
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            if (!turnIsProcessed)
                ProcessEndOfTurn();
        }
    }
    public void GenerateGrid()
    {
        scoreManager.ResetUILabels();
        gridSize = settings.startingGridSize;
        gridMin = 1;
        gridMax = gridSize;
        targetScoreForExtend = settings.startingTargetScore;
        scoreManager.UpdateTarget(targetScoreForExtend);
        //restartButton.SetActive(false);
        // TODO : this should re-center on the tiles
        ZoomCamera(28.6f);

        // Create a new tile dictionary if this is the first game
        if (tiles == null)
            tiles = new Dictionary<Point, Tile>();
        else
        // Clear the dict, destroy any tiles on the grid, reset the score
        {
            tiles.Clear();
            for (int i = 0; i < this.transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            scoreManager.ResetUILabels();
        }

        // Create the board
        // from child gameobjects
        if (transform.childCount != 0)
            CreateBoardFromPlacedTiles();
        else // from nothing
            CreateDefaultBoard();

    }

    private void CreateDefaultBoard()
    {
        // Create the blank board
        for (int x = 1; x <= gridSize; x++)
        {
            for (int z = 1; z <= gridSize; z++)
            {
                SpawnTile(x, z, TileType.Dirt);
            }
        }
    }

    private void SpawnTile(int x, int z, TileType type)
    {
        GameObject prefabToSpawn;
        switch (type)
        {
            case TileType.Dirt:
                prefabToSpawn = settings.dirtPrefab;
                break;
            case TileType.Grass:
                prefabToSpawn = settings.grassPrefab;
                break;
            case TileType.Water:
                prefabToSpawn = settings.riverPrefab;
                break;
            case TileType.Wetland:
                prefabToSpawn = settings.wetlandPrefab;
                break;
            case TileType.Forest:
                prefabToSpawn = settings.forestPrefab;
                break;
            default:
                prefabToSpawn = settings.dirtPrefab;
                break;
        }
        Tile spawnedTile = Instantiate(prefabToSpawn, new Vector3(x * 10, 0, z * 10), Quaternion.identity, this.transform).GetComponent<Tile>();
        AddTileToGrid(x, z, spawnedTile);
        if (spawnedTile.TileType != TileType.Dirt)
        {
            spawnedTile.LevelUpSelf();
        }

    }

    private void AddTileToGrid(int x, int z, Tile spawnedTile)
    {
        spawnedTile.name = $"Tile {x} {z}";
        // MainGrid layer is only rendered by the main camera
        Utils.SetGameLayerRecursive(spawnedTile.gameObject, LayerMask.NameToLayer("MainGrid"));
        spawnedTile.tileSelectedDelegate += HandleTileSelected;
        spawnedTile.scoreChangedDelegate += HandleScoreChanged;
        spawnedTile.position = new Point(x, z);
        try
        {
            tiles.Add(spawnedTile.position, spawnedTile);
        }
        catch (ArgumentException ae)
        {
            Debug.LogError("ArgException trying to insert: " + spawnedTile.position);
            Debug.LogError(ae);
        }
    }

    public void ExtendGrid()
    {
        AddMovesOnExtend();
        //targetScoreForExtend = gridSize * 3 * settings.targetScoreMultiplier;
        targetScoreForExtend += (gridSize * gridSize);
        scoreManager.UpdateTarget(targetScoreForExtend);

        ZoomCamera(gridCamera.orthographicSize + 10);

        //1 left edge [gridMin-1,            gridMin-1 -> gridMax+1]
        for (int i = gridMin - 1; i <= gridMax + 1; i++)
        {
            // can't be water
            SpawnTile(gridMin - 1, i, TileType.Dirt);
        }

        //2 top edge [gridMin -> gridMax+1, gridMax+1]
        for (int i = gridMin; i <= gridMax; i++)
        {
            // check if water
            Tile nTile;
            tiles.TryGetValue(new Point(i, gridMax), out nTile);
            if (nTile.TileType == TileType.Water)
            {   //spawn another water
                SpawnTile(i, gridMax + 1, TileType.Water);
            }
            else
                SpawnTile(i, gridMax + 1, TileType.Dirt);
        }

        //3 right edge [gridMax+1,            gridMax -> gridMin-1]
        for (int i = gridMax + 1; i >= gridMin - 1; --i)
        {
            SpawnTile(gridMax + 1, i, TileType.Dirt);
        }
        //4 bottom edge [gridMin+1 -> gridMin, gridMin-1]
        for (int i = gridMax; i >= gridMin; --i)
        {
            // check if water
            Tile nTile;
            tiles.TryGetValue(new Point(i, gridMin), out nTile);
            if (nTile.TileType == TileType.Water)
            {
                //spawn another water
                SpawnTile(i, gridMin - 1, TileType.Water);
            }
            else
                SpawnTile(i, gridMin - 1, TileType.Dirt);
        }

        gridMin--;
        gridMax++;
        gridSize += 2;


    }

    private void ZoomCamera(float newSize)
    {
        DOTween.To(
                    () => gridCamera.orthographicSize,
                    x => gridCamera.orthographicSize = x,
                    newSize,
                    0.5f
                    );
    }

    private void AddMovesOnExtend()
    {
        for (int i = 0; i < settings.movesToAddOnExtend; i++)
        {
            // pass in true so we might generate water tiles too
            moveList.GenerateRandomMove(true);
        }
    }

    public void ExtendIrregularGrid()
    {
        AddMovesOnExtend();
        // TODO: update targetScoreForExtend

        //// Add tiles around the grid
        // create a temp set of tiles so we do'nt extend infinitely
        var tilesToExtend = new List<Tile>(tiles.Values);
        foreach (var tile in tilesToExtend)
        {
            // does this tile have an empty space around it?
            var pointsToCheck = new List<Point>();
            pointsToCheck.Add(new Point(tile.position.x + 1, tile.position.z));
            pointsToCheck.Add(new Point(tile.position.x - 1, tile.position.z));
            pointsToCheck.Add(new Point(tile.position.x, tile.position.z + 1));
            pointsToCheck.Add(new Point(tile.position.x, tile.position.z - 1));

            foreach (var pointToCheck in pointsToCheck)
            {
                if (!tiles.TryGetValue(pointToCheck, out _))
                {
                    // TODO: check if this needs to be river?
                    SpawnTile(pointToCheck.x, pointToCheck.z, TileType.Dirt);
                }
            }

        }

        // TODO: re-center camera on new set of tiles 
        ZoomCamera(gridCamera.orthographicSize + 10);

        // TODO: update gridMin/gridMax?
    }

    private void CreateBoardFromPlacedTiles()
    {
        irregularGrid = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            var go = transform.GetChild(i);
            AddTileToGrid(
                (int)go.transform.position.x / 10,
                (int)go.transform.position.z / 10,
                go.GetComponent<Tile>());
        }
    }



    private void HandleScoreChanged(int score)
    {
        CalculateScore();
    }

    private void HandleTileSelected(Tile tile)
    {
        if (moveList.movesLeft != 0 && DOTween.TotalPlayingTweens() == 0)
        {
            Tile nextMove = moveList.GetNextMove();
            nextMove.transform
                .DOMove(tile.transform.position, settings.tileMoveDuration)
                .OnComplete(() => SetTile(tile, nextMove, true));
            Utils.SetGameLayerRecursive(nextMove.gameObject, LayerMask.NameToLayer("MainGrid"));
            turnIsProcessed = false;
        }
    }

    public void SetTile(Tile targetTile, Tile sourceTile, bool fromMoveList)
    {
        GameObject sourceTileGO = sourceTile.gameObject;

        sourceTile.isInMoveList = false;

        // is the new tile the same type as the old one?
        if (targetTile.TileType == sourceTile.TileType)
        // it is, so we'll level it up
        {
            // check if the new one has animals, enable on the other if it does
            if (sourceTile.hasXAnimals)
                targetTile.EnableXAnimals();

            // we'll keep the existing tile, so destroy the new one
            Destroy(sourceTileGO);
        }
        else if (targetTile.TileType == TileType.Water)
        // water tiles can't be changed
        {
            Destroy(sourceTileGO);
        }
        else
        // replace the tile with the new one
        {
            // reparent under Grid
            sourceTileGO.transform.parent = this.transform;

            // hide the target
            targetTile.enabled = false;

            // swap the tile reference in the Grid
            tiles.Remove(targetTile.position);
            // set up the name etc.
            AddTileToGrid(targetTile.position.x, targetTile.position.z, sourceTile);

            // get rid of the selected tile
            Destroy(targetTile.gameObject);

            // will use selectedTile from now on
            targetTile = sourceTile;
        }

        // level up the selected tile
        targetTile.LevelUpSelf();

        if (fromMoveList)
        {
            // change any surrounding tiles
            StartCoroutine(targetTile.LevelUpSurroundingTiles(this));
            // deal with it if it has animals
            StartCoroutine(targetTile.LevelUpAnimalTiles(this));
        }

        bonusManager.CheckBonuses(targetTile);

    }

    private void ProcessEndOfTurn()
    {
        if (CalculateScore() >= targetScoreForExtend)
        {
            if (irregularGrid)
                ExtendIrregularGrid();
            else
                ExtendGrid();

        }

        if (moveList.movesLeft == 0)
        {
            scoreManager.UpdateHighScore(CalculateScore());
            menuManager.ShowGameOverMenu();
        }
        turnIsProcessed = true;
    }

    public int CalculateScore()
    {
        //regular tiles
        var thisScore = 0;
        foreach (var tile in tiles)
        {
            thisScore += tile.Value.Score;
        }

        // bonuses
        var bonusScores = bonusManager.GetBonusScores();
        scoreManager.UpdateBonusScore(bonusScores);
        thisScore += bonusScores;

        scoreManager.UpdateScore(thisScore);
        return thisScore;
    }

    // public void SaveScore() => settings.Scores.Add(totalScore);

}
public struct Point
{
    public int x;
    public int z;

    public Point(int x, int z) : this()
    {
        this.x = x;
        this.z = z;
    }

    public override string ToString()
    {
        return x + " " + z; 
    }

    public static bool operator ==(Point p1, Point p2)
    {
        return (p1.x == p2.x && p1.z == p2.z);
    }

    public static bool operator !=(Point p1, Point p2)
    {
        return !(p1.x == p2.x && p1.z == p2.z);
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

}
