using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GridManager gridManager;
    public MoveList moveList;
    public BonusManager bonusManager;
    public SelectionManager selectionManager;
    public SettingsSO settings;
    public SceneAsset nextLevel;

    private void Awake()
    {
        if (gridManager == null)
        {
            gridManager = FindObjectOfType<GridManager>();
        }

        if (bonusManager == null)
        {
            bonusManager = FindObjectOfType<BonusManager>();
        }
        if (bonusManager.GridManager == null)
            bonusManager.GridManager = gridManager;

        if (selectionManager == null)
        {
            selectionManager = FindObjectOfType<SelectionManager>();
        }
        if (selectionManager.GridManager == null)
            selectionManager.GridManager = gridManager;

        gridManager.settings = settings;
        FindObjectOfType<ScoreManager>().settings = settings;
        bonusManager.settings = settings;
        moveList.settings = settings;


    }

    private void Start()
    {
        StartNewGame();
    }
    public void StartNewGame()
    {
        gridManager.GenerateGrid();
        moveList.GenerateMoveList();
        bonusManager.GenerateBonuses();
    }

    public void LoadNextLevel()
    {
        // TODO: How do we store a reference to the nextLevel in the Scene, or the SettingsSO?
        SceneManager.LoadScene(nextLevel.name);
    }

}

