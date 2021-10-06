using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BonusTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Bonus bonus;

    private void Awake()
    {
        //tile = GetComponent<Tile>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //tile.SelectTile();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //tile.DeselectTile();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //tile.OnMouseUpAsButton();
    }


}