using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLevelManager : MonoBehaviour
{
    public GameObject level2;
    public GameObject level3;
    public GameObject level1;

    public int score = 0;

    public SettingsSO settings;

    private void Awake()
    {
        // apply a bit of random rotation if level 2 or 3 exist
        level2?.transform.Rotate(this.transform.up, Random.Range(0f, 180f));
        level3?.transform.Rotate(this.transform.up, Random.Range(0f, 180f));

    }

    public int LevelUp()
    {
        switch (score)
        {
            case 0:
                ScaleUpSize();
                score++;
                break;
            case 1:
                level2.SetActive(true);
                ScaleUpSize();
                score++;
                break;
            case 2:
                level3.SetActive(true);
                ScaleUpSize();
                score++;
                break;
            case 3:
                break;
            default:
                break;
        }
        return score;
    }
    public int ResetLevel()
    {
        ResetScale();
        level2.SetActive(false);
        level3.SetActive(false);
        return 0;
    }

    public void ScaleUpSize()
    {
        transform.DOScale(
            this.transform.localScale + new Vector3(0, settings.tileYScaleAdjustment, 0),
                0.5f);

    }
    public void ResetScale()
    {
        this.transform.localScale = Vector3.one;
    }

}
