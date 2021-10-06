using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "SettingsData")]
public class SettingsSO : ScriptableObject
{
    public float timeBetweenAnimalTiles = 0.4f;
    public float timeBetweenWaterTiles = 0.2f;
    public float animalChance = 0.5f;
    public int animalTilesToRun = 3;


    public float tileYScaleAdjustment = 1.05f;
    public float timeBetweenForestTiles = 0.1f;
    public float tileMoveDuration = 0.5f;
    public int startingNumberOfMoves = 12;
    public int startingGridSize = 4;
    public int movesToAddOnExtend = 10;
    public int startingTargetScore = 32;
    public int targetScoreMultiplier = 8;
    public int numActiveBonuses = 3;
    
    public int highScore = 0;
    public List<int> Scores;

    public GameObject grassPrefab;
    public GameObject dirtPrefab;
    public GameObject wetlandPrefab;
    public GameObject riverPrefab;
    public GameObject forestPrefab;

    public List<Bonus> bonuses;
    public float bonusFadeTime = 0.5f;
}
