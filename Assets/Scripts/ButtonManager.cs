using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public UnityEngine.UI.Button firstButton;

    private void Start()
    {
        firstButton.Select();
    }
}
