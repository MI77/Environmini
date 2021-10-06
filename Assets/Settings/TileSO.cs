using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "TileData")]
public class TileSO : ScriptableObject
{
    public GameObject prefab;
    public AudioClip levelUpNoise;
    public int maxScore;
    public TileType type;

}
