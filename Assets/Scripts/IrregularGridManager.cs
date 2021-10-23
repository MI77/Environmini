using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class IrregularGridManager : GridManager
{
    private List<Tile> outerTiles;
    private List<Tile> tilesToExtend;

    private List<Point> startingPoints = new List<Point>();

    protected override void CreateBoard()
    {
        if (startingPoints.Count == 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var go = transform.GetChild(i).gameObject;
                startingPoints.Add(new Point((int)go.transform.position.x / 10, (int)go.transform.position.z / 10));
                Destroy(go);
            }
        }

        foreach (Point point in startingPoints)
        {
            SpawnTile(point.x, point.z, TileType.Dirt);
        }

    }

    public override void ExtendGrid()
    {
        AddMovesOnExtend();
        targetScoreForExtend += Tiles.Count;
        scoreManager.UpdateTarget(targetScoreForExtend);

        //// Add tiles around the grid

        if (tilesToExtend == null)
        {
            // first time around, tilesToExtend needs to be new List from the current Tiles.Values);
            tilesToExtend = new List<Tile>(Tiles.Values);
            // at the end of the first time, outerTiles will contain the ones we added
            outerTiles = new List<Tile>();
        }
        else
        {
            // on subsequent extends, tilesToExtend needs to be a new List from the current outerTiles;
            tilesToExtend = new List<Tile>(outerTiles);
            // and we need to clear outerTiles
            outerTiles.Clear();
        }

        foreach (var tile in tilesToExtend)
        {
            // does this tile have an empty space around it?
            var pointsToCheck = new List<Point>();
            pointsToCheck.Add(new Point(tile.position.x + 1, tile.position.z));
            pointsToCheck.Add(new Point(tile.position.x - 1, tile.position.z));
            pointsToCheck.Add(new Point(tile.position.x, tile.position.z + 1));
            pointsToCheck.Add(new Point(tile.position.x, tile.position.z - 1));

            foreach (var pointToCheck in pointsToCheck)
            {
                if (!Tiles.TryGetValue(pointToCheck, out _))
                {
                    // check if this needs to be river
                    Tile northTile, southTile;
                    Tiles.TryGetValue(new Point(pointToCheck.x, pointToCheck.z - 1), out northTile);
                    Tiles.TryGetValue(new Point(pointToCheck.x, pointToCheck.z + 1), out southTile);

                    if (northTile != null && northTile.TileType == TileType.Water)
                        outerTiles.Add(SpawnTile(pointToCheck.x, pointToCheck.z, TileType.Water));
                    else if (southTile != null && southTile.TileType == TileType.Water)
                        outerTiles.Add(SpawnTile(pointToCheck.x, pointToCheck.z, TileType.Water));
                    else
                        outerTiles.Add(SpawnTile(pointToCheck.x, pointToCheck.z, TileType.Dirt));
                }
            }

        }

        // TODO: re-center camera on new set of tiles 
        ZoomCamera(gridCamera.orthographicSize + 10);
    }




}