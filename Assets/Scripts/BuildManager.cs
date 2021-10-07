using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public List<GameObject> objectsToDisable;

    void Start()
    {
#if UNITY_WEBGL
        foreach (var obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
#endif
    }


}
