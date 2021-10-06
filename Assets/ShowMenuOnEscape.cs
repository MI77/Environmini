using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowMenuOnEscape : MonoBehaviour, ICancelHandler
{
    public void OnCancel(BaseEventData eventData)
    {
        Debug.Log("ShowMenuOnEscape received: " + eventData);
    }
}
