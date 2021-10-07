using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonusManager : MonoBehaviour
{
    [SerializeField]
    private GridManager gridManager;
    
    public SettingsSO settings;
    public GameObject bonusImagePrefab;

    public List<BonusType> debugBonusList;

    public GameObject particlesPrefab;

    public AudioSource bonusAudio;

    private Bonus[] activeBonuses;
    [SerializeField]
    private GameObject bonusImages;
    private Vector3 imageOffset = new Vector3(160, 0, 0);

    private List<(Tile, BonusType)> bonusesAwarded;
    
    private void Awake()
    {
        activeBonuses = new Bonus[settings.numActiveBonuses];
        bonusesAwarded = new List<(Tile, BonusType)>();
        bonusAudio = GetComponent<AudioSource>();
    }

    public int GetBonusScores()
    {
        int totalBonusScore = 0;
        foreach (var bonus in bonusesAwarded)
        {
            totalBonusScore += BonusProcessor.GetScore(bonus.Item2);
        }
        return totalBonusScore;
    }

    public void GenerateBonuses()
    {
        //clear the internal list
        bonusesAwarded.Clear();
        activeBonuses = new Bonus[settings.numActiveBonuses];
        
        // populate the list
        for (int i = 0; i < settings.numActiveBonuses; i++)
        {
            if (debugBonusList.Count != 0)
            {
                AddBonus(i, debugBonusList[0]);
                debugBonusList.RemoveAt(0);
            }
            else
            {
                AddBonus(i, null);
            }
        }     
    }

    private void AddBonus(int bonusPosition, BonusType? type)
    {
        Bonus bonus;
        if (type == null)
            bonus = BonusProcessor.GetRandomBonus();
        else
            bonus = BonusProcessor.GetBonus((BonusType)type);

        bonus.tiles = gridManager.tiles;
        activeBonuses[bonusPosition] = bonus;
        var bonusImagetransform = bonusImages.transform.Find("BonusImage" + bonusPosition);
        GameObject bonusImage;
        bool firstLoad = false;
        if (bonusImagetransform == null)
        {
            firstLoad = true;
            bonusImage = Instantiate(bonusImagePrefab, bonusImages.transform);
            bonusImage.name = "BonusImage" + bonusPosition;
        }
        else
            bonusImage = bonusImagetransform.gameObject;
        var spriteToLoad = Resources.Load<Sprite>(bonus.SpriteName);

        if (firstLoad)
        {
            // just set the image
            bonusImage.GetComponent<Image>().sprite = spriteToLoad;
        }
        else
        {
            bonusImage.GetComponent<ParticleSystem>().Play();
            //fade it out
            bonusImage.GetComponent<Image>().DOFade(0, settings.bonusFadeTime)
                .SetDelay(1f)
                .OnComplete(() =>
            {
                bonusImage.GetComponent<Image>().sprite = spriteToLoad;
                //fade back in
                bonusImage.GetComponent<Image>().DOFade(1, settings.bonusFadeTime);
            }
            );
        }
    }

    public void CheckBonuses(Tile tile)
    {
        for (int i = 0; i < activeBonuses.Length; i++)
        {
            var bonus = activeBonuses.ElementAt<Bonus>(i);
            if (!bonusesAwarded.Contains((tile, bonus.BonusType)) && bonus.CheckBonus(tile))
            {
                // Yay! You got the bonus
                ShowParticles(bonus.GetBoundsFromStartTile(tile));
                bonusAudio.Play();

                bonusesAwarded.Add((tile, bonus.BonusType));
                tile.bonusesAwarded.Add(bonus.BonusType);

                if (debugBonusList.Count > 0)
                {
                    AddBonus(i, debugBonusList[0]);
                    debugBonusList.RemoveAt(0);
                } 
                else
                    AddBonus(i, null);

            }
        }
        
    }

    private void ShowParticles(Bounds bounds)
    {
        var particles = Instantiate(particlesPrefab, bounds.center, Quaternion.identity, this.transform);
        var particleSystem = particles.GetComponent<ParticleSystem>();
        var shape = particleSystem.shape;
        var flatBounds = bounds.size;
        flatBounds.y = 1;
        shape.scale = flatBounds;
        particleSystem.Play();
    }
}
