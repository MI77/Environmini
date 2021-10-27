using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]
    private GridManager _gridManager;

    public Canvas canvas;
    
    public Point selectedPoint;

    public GridManager GridManager { get => _gridManager; set => _gridManager = value; }

    private void Awake()
    {
        selectedPoint = new Point(0, 0);
    }

    public void SelectTileUnderCursor(CallbackContext context)
    {

    }
    public void SetSelectedPoint(Point point)
    {
        DeselectCurrentTile();
        selectedPoint = point;
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
        GridManager.Tiles.TryGetValue(pointToSelect, out tileToSelect);
        if (tileToSelect != null)
        {
            DeselectCurrentTile();
            tileToSelect.SelectTile();
        }
    }

    private void DeselectCurrentTile()
    {
        Tile selectedTile;
        GridManager.Tiles.TryGetValue(selectedPoint, out selectedTile);
        if (selectedTile != null)
            selectedTile.DeselectTile();
    }

    public void SetTile(CallbackContext context)
    {
        Tile tileToSet;
        GridManager.Tiles.TryGetValue(selectedPoint, out tileToSet);
        if (tileToSet != null)
        {
            tileToSet.OnMouseUpAsButton();
        }

    }



}
