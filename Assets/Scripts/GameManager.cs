using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _gridManager;

    public IGridManager gridManager;

    public MoveList moveList;
    public BonusManager bonusManager;

    public void StartNewGame()
    {
        gridManager.GenerateGrid();
        moveList.GenerateMoveList();
        bonusManager.GenerateBonuses();
    }

    private void Awake()
    {
        gridManager = _gridManager.GetComponent<IGridManager>();
    }

    private void Start()
    {
        StartNewGame();
    }
}

