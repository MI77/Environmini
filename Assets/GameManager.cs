using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GridManager grid;
    public MoveList moveList;
    public BonusManager bonusManager;

    public void StartNewGame()
    {
        grid.GenerateGrid();
        moveList.GenerateMoveList();
        bonusManager.GenerateBonuses();
    }

    private void Start()
    {
        StartNewGame();
    }
}

