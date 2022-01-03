using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class SelectionManager : MonoBehaviour
{
    public GridManager gridManager;
    public Canvas canvas;
    
    public Point selectedPoint;

    private void Awake()
    {
        selectedPoint = new Point(0, 0);
    }
    public void SetSelectedPoint(Point point)
    {
        DeselectCurrentTile();
        selectedPoint = point;
        if(gridManager.isReadyForTurn)
            gridManager.moveList.ShowNextTemplateAt(point);
    }
    public void MoveSelection(CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        // == zero means it's gone back to the original position
        if (input == Vector2.zero ||
            // context.performed means the input is completed
            !(context.performed)
            ) return;

        Point pointToSelect;
        // if nothing's been selected yet, start at 1,1
        if (selectedPoint == new Point(0, 0))
        {
            pointToSelect = new Point(1, 1);
        }
        else
        {
            pointToSelect = new Point(selectedPoint.x + Mathf.RoundToInt(input.x),
                                      selectedPoint.z + Mathf.RoundToInt(input.y));
        }

        
        Tile tileToSelect;
        gridManager.tiles.TryGetValue(pointToSelect, out tileToSelect);
        if (tileToSelect != null)
        {
            DeselectCurrentTile();
            tileToSelect.SelectTile();
        }
    }

    public void DeselectCurrentTile()
    {
        Tile selectedTile;
        gridManager.tiles.TryGetValue(selectedPoint, out selectedTile);
        if (selectedTile != null)
        {
            gridManager.moveList.HideTemplate();
            selectedTile.DeselectTile();
        }
    }

    public void SetTile(CallbackContext context)
    {
        Tile tileToSet;
        gridManager.tiles.TryGetValue(selectedPoint, out tileToSet);
        if (tileToSet != null)
        {
            tileToSet.OnMouseUpAsButton();
        }

    }



}
