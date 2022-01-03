using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateManager : MonoBehaviour
{
    internal void HideTemplates()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
            Destroy(transform.GetChild(i).gameObject);
        }
    }
    internal void ShowTemplateAt(GameObject go, Point point)
    {
        HideTemplates();

        // instantiate the prefab
        GameObject templateToShow = Instantiate(go, point.WorldPosition(), Quaternion.identity, this.transform);

        // TODO: Only show points where there are actually grid tiles
        // currently showing them based on hardcoded Prefabs  

    }
}
