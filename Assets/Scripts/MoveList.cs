using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

public class MoveList : MonoBehaviour
{
    [SerializeField] public List<Tile> moveList;
    
    public SettingsSO settings;
    public int movesLeft { get { return moveList.Count; } }

    private readonly System.Random random;
    public List<GameObject> debugMoveList;

    private void Awake()
    {
        //GenerateMoveList();
    }
    public void GenerateMoveList()
    {
        // clear the internal list
        moveList.Clear();
        // destory any gameobjects
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        if (debugMoveList.Count == 0)
        { // generate random moves
            for (int y = 0; y < settings.startingNumberOfMoves; y++)
            {
                GenerateRandomMove(false);
            }
        }
        else
        { // generate moves based on the debug list
            for (int y = 0; y < debugMoveList.Count; y++)
            {
                GenerateFixedMove(debugMoveList[y]);
            }
        }
    }

    public Tile GetNextMove()
    {
        var nextMove = moveList[0];
        //Destroy(moveList[0]);
        moveList.RemoveAt(0);
        RefreshMoveList();
        return nextMove;
    }

    public void RefreshMoveList()
    {
        Sequence moveTiles = DOTween.Sequence();
        moveTiles.Pause();

        for (int i = 0; i < movesLeft; i++)
        {
            moveTiles.Insert(0.1f * i, moveList[i].gameObject.transform
                .DOLocalMove(Vector3.down * i * 10, 0.2f));
        }
        moveTiles.Play();

    }

    public void GenerateRandomMove([Optional] bool withWater)
    {
        var r = UnityEngine.Random.Range(1, 100);
        GameObject spawnedTile;

        if (r <= 10 && withWater)
        {
            spawnedTile = Instantiate(settings.riverPrefab, this.transform);
        }
        else if (r <= 40)
        {
            spawnedTile = Instantiate(settings.grassPrefab, this.transform);
        }
        else if (r <= 60)
        {
            spawnedTile = Instantiate(settings.wetlandPrefab, this.transform);
        }
        else
        {
            spawnedTile = Instantiate(settings.forestPrefab, this.transform);
        }

        SpawnTile(spawnedTile);
    }

    private void SpawnTile(GameObject spawnedTile)
    {
        var tile = spawnedTile.GetComponent<Tile>();
        //Add animals to grass tiles
        if (tile.TileType == TileType.Grass || tile.TileType == TileType.Wetland)
        {
            if (UnityEngine.Random.value < settings.animalChance)
                tile.EnableXAnimals();
        }

        // set the location etc.
        spawnedTile.transform.localPosition = new Vector3(0, -moveList.Count * 10, 0);
        spawnedTile.name = $"Tile {moveList.Count}";
        spawnedTile.GetComponent<Tile>().isInMoveList = true;
        Utils.SetGameLayerRecursive(spawnedTile.gameObject, LayerMask.NameToLayer("MoveList"));
        moveList.Add(spawnedTile.GetComponent<Tile>());
    }

    public void GenerateFixedMove(GameObject prefab)
    {
        GameObject spawnedTile;
        spawnedTile = Instantiate(prefab, this.transform);
        SpawnTile(spawnedTile);
    }

}
