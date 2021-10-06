using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnHover : MonoBehaviour
{
    public MeshRenderer highlight;
    private void Awake()
    {
        if(highlight != null)
            highlight.enabled = false;
    }
    private void OnMouseEnter()
    {
        highlight.enabled = true;
    }
    private void OnMouseExit()
    {
        highlight.enabled = false;
    }
}
