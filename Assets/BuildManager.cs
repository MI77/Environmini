using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public List<GameObject> webGLObjectsToDisable;

    void Start()
    {
#if UNITY_WEBGL
        foreach (var obj in webGLObjectsToDisable)
        {
            obj.SetActive(false);
        }
#endif
    }


}
