using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimalAnimation : MonoBehaviour
{
    public GameObject xTowardAnimal;
    public GameObject xAwayAnimal;
    public GameObject xTowardRaycast;
    public GameObject xAwayRaycast;
    public SettingsSO settings;

    public AudioSource runNoise;
    private int runningAnimals = 0;

    private void Start()
    {
        xTowardAnimal.GetComponent<Animator>().SetFloat("IdleOffset", Random.Range(0.0f, 0.5f));
        xAwayAnimal.GetComponent<Animator>().SetFloat("IdleOffset", Random.Range(0.0f, 0.5f));

    }
    ///<summary>
    /// Run animals (positive/towards, negative/away) units 
    ///</summary>
    public IEnumerator AnimalRun(int posUnits, int negUnits)
    {
        StartCoroutine(Run(xTowardAnimal, posUnits, true));
        StartCoroutine(Run(xAwayAnimal, negUnits, false));
        yield return null;
    }
    IEnumerator Run(GameObject go, int units, bool positive)
    {
        runningAnimals++;

        go.SetActive(true);
        var startPos = go.transform.position;
        var distance = (positive ? 1 : -1) * units;

        runNoise.Play();

        go.GetComponent<Animator>().Play("Gallop", -1, UnityEngine.Random.Range(0.0f, 0.5f));

        Tween runAnimalTween =
        go.transform
            .DOMove(go.transform.position + new Vector3(distance * 10, 0, 0),
            units * settings.timeBetweenAnimalTiles)
            .SetEase(Ease.Linear)
            .OnComplete(()=>HideAndReturnAnimal(go, startPos));
        yield return null;    
    }

    private void HideAndReturnAnimal(GameObject go, Vector3 startPos)
    {
        // hide it and bring them back to the start position
        runningAnimals--;
        if (runningAnimals == 0) runNoise.Stop();
        go.SetActive(false);
        go.transform.position = startPos;
    }

    private void Update()
    {
        if(runningAnimals > 0)
        {
            if (Physics.Raycast(xTowardRaycast.transform.position,
                Vector3.down, out RaycastHit towardHit, 5f))
            {
                if (towardHit.collider.gameObject.name == "water")
                {
                    xTowardAnimal.GetComponent<Animator>().SetTrigger("GallopJump");
                }
            }
            if (Physics.Raycast(xAwayRaycast.transform.position, 
                Vector3.down, out RaycastHit awayHit, 5f))
            {
                if (awayHit.collider.gameObject.name == "water")
                {
                    xAwayAnimal.GetComponent<Animator>().SetTrigger("GallopJump");
                }
            }
        }
    }
}
