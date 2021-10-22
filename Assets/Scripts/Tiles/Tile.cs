using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public Tile()
    { }
    public MeshRenderer block;

    public abstract TileType TileType { get; }
    public abstract GameObject GetPrefab();
    public int Score { get => tileLevelManager.score;}
    public virtual bool CanSetTile { get => true; }
    
    public List<BonusType> bonusesAwarded;

    public MeshRenderer highlight;
    [SerializeField]
    public Point position;
    public List<AudioClip> levelUpClips;
    [SerializeField]
    protected AudioSource levelUpNoise;
    public TileLevelManager tileLevelManager;
    public TextMeshPro scoreText;

    public SettingsSO settings;

    public bool hasXAnimals;
    public AnimalAnimation xAnimals;

    public delegate void OnTileSelected(Tile tile);
    public event OnTileSelected tileSelectedDelegate;

    public delegate void OnScoreChanged(int score);
    public event OnScoreChanged scoreChangedDelegate;

    public bool isInMoveList;
    private Coroutine showingScoreOnHover;

    private void Start()
    {
        if(block != null)
            RandomizeColor(block);
        
        RandomizeDecorationRotationAndPosition(gameObject);
        levelUpNoise = this.gameObject.AddComponent<AudioSource>();
    }

    public abstract void LevelUpSelf();
    public abstract IEnumerator LevelUpSurroundingTiles(IGridManager gridManager);

    public void PlayLevelUpNoise()
    {
        var noiseToPlay = levelUpClips[UnityEngine.Random.Range(0, levelUpClips.Count - 1)];
        levelUpNoise.PlayOneShot(noiseToPlay);
    }

    public void OnMouseUpAsButton()
    {
        tileSelectedDelegate(this);
    }
    
    public void SelectTile()
    {
        FindObjectOfType<SelectionManager>().SetSelectedPoint(position);
        highlight.enabled = true;
        if (!isInMoveList && Score != 0)
            showingScoreOnHover = StartCoroutine(ShowScore());
    }
    public void DeselectTile()
    {
        highlight.enabled = false; 
        scoreText.enabled = false;
        if (!isInMoveList && Score != 0 && showingScoreOnHover != null)
            StopCoroutine(showingScoreOnHover);
    }

    public IEnumerator ShowScore()
    {
        scoreText.text = Score.ToString();
        scoreText.enabled = true;
        yield return new WaitForSeconds(2f);
        // sometimes the GO has been destroyed by the time WaitForSeconds completes
        if(scoreText)
            scoreText.enabled = false;
    }

    protected void RaiseScoreChangedEvent()
    {
        StartCoroutine(ShowScore());
        scoreChangedDelegate(Score);
    }

    internal void EnableXAnimals()
    {
        hasXAnimals = true;
        xAnimals?.gameObject.SetActive(true);
    }

    internal IEnumerator LevelUpAnimalTiles(IGridManager gridManager)
    {
        if (hasXAnimals)
        {

            Tile nTile;
            GameObject prefab = GetPrefab();
            // level up tiles along the x axis

            // Swapping to have a fixed number of tiles to run
            //var maxTilesToCheck = Math.Max(tilesAway, tilesToward);
            var maxTilesToCheck = settings.animalTilesToRun;

            // work out how far to run
            // TODO : How can I do this recursively to deal with odd-sized boards?
            // See also: River.LevelUpSurroundingTiles
            bool stopPos = false, stopNeg = false;
            int i = 0, posTiles = 0, negTiles = 0;

            while ((!stopPos && !stopNeg) || i == maxTilesToCheck)
            {
                if (gridManager.Tiles.TryGetValue(new Point(position.x + i, position.z), out nTile))
                    posTiles = i;
                else
                    stopPos = true;

                if (gridManager.Tiles.TryGetValue(new Point(position.x - i, position.z), out nTile))
                    negTiles = i;
                else
                    stopNeg = true;

                i++;
            }

            int tilesToward = Math.Min(maxTilesToCheck, posTiles);
            int tilesAway = Math.Min(maxTilesToCheck, negTiles);



            StartCoroutine(xAnimals.AnimalRun(tilesToward, tilesAway));

            for (int j = 1; j <= maxTilesToCheck; j++)
            {
                if (gridManager.Tiles.TryGetValue(new Point(position.x + j, position.z), out nTile))
                    SetTypeOnTile(nTile, prefab, gridManager);
                if (gridManager.Tiles.TryGetValue(new Point(position.x - j, position.z), out nTile))
                    SetTypeOnTile(nTile, prefab, gridManager);
                yield return new WaitForSeconds(settings.timeBetweenAnimalTiles);
            }
            // turn them off so we don't fire this path again
            hasXAnimals = false;
        }
        else
            yield return null;

    }

    public virtual void SetTypeOnTile(Tile selectedTile, GameObject prefab, IGridManager gridManager)
    {
        if (selectedTile.CanSetTile)
        {
            GameObject newTile =
                                Instantiate(
                                    prefab,
                                    selectedTile.transform.position,
                                    Quaternion.identity);
            Tile newTileTile = newTile.GetComponent<Tile>();

            newTile.transform
                .DOMove(selectedTile.transform.position, 0.1f)
                .OnComplete(() => gridManager.SetTile(selectedTile, newTileTile, false));
        }
    }

    private void RandomizeDecorationRotationAndPosition(GameObject go)
    {
        for (int i = 0; i < go.transform.childCount; i++)
        {
            GameObject childGO = go.transform.GetChild(i).gameObject;
            if (childGO.CompareTag("RandomizeRotation"))
            {
                float rotAngle = UnityEngine.Random.Range(0, 180);
                float positionAdjust = UnityEngine.Random.Range(-1f, 1f);
                // Space.World rotation/translation handles prefabs that were imported at 90deg
                childGO.transform.Rotate(Vector3.up, rotAngle, Space.World);
                childGO.transform.Translate(new Vector3(positionAdjust, 0, positionAdjust), Space.World);
            }
            RandomizeDecorationRotationAndPosition(childGO);

        }
    }

    protected void RandomizeColor(MeshRenderer mesh)
    {
        Material mat = mesh.materials[0];

        Color color = mat.color;
        int r = UnityEngine.Random.Range(-8, 8);
        int d = 400;

        color.r += (float)r / d;
        color.g += (float)r / d;
        color.b += (float)r / d;

        mat.color = color;
    }
}
