using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverBanks : MonoBehaviour
{
    public GameObject leftBank;
    public GameObject rightBank;
    public GameObject topBank;
    public GameObject bottomBank;

    public void SetBankActive(string bank, bool active)
    {
        switch (bank)
        {
            case "left":
                leftBank.SetActive(active);
                break;
            case "right":
                rightBank.SetActive(active);
                break;
            case "top":
                topBank.SetActive(active);
                break;
            case "bottom":
                bottomBank.SetActive(active);
                break;
            default:
                break;
        }
    }    

}
