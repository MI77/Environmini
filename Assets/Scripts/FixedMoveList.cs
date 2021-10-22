using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMoveList : MoveList
{
    public List<bool> animals;

    public override void GenerateMoveList()
    {
        // clear the internal list
        moveList.Clear();
        // destory any gameobjects
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        for (int y = 0; y < debugMoveList.Count; y++)
        {
            GenerateFixedMove(debugMoveList[y], animals[y]);
        }
        
    }
    public void GenerateFixedMove(GameObject prefab, bool withAnimals)
    {
        GameObject spawnedTile;
        spawnedTile = Instantiate(prefab, this.transform);
        SpawnTile(spawnedTile, withAnimals);
    }
}
