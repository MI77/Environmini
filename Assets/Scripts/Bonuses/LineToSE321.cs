using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineToSE321 : Bonus
{
    public override string SpriteName { get => this.GetType().Name; }
    public override BonusType BonusType { get => BonusType.LineToSE321; }
    public override int BonusAmount { get => 3; }

    public override bool CheckBonus(Tile tile)
    {
        List<(Point, int)> OtherPoints = new List<(Point, int)>();

        switch (tile.Score)
        {
            // Actually only going to award it if the tile played this turn was 3
            //case 1:
            //    OtherPoints.Add((new Point(tile.position.x-1, tile.position.z), 2));
            //    OtherPoints.Add((new Point(tile.position.x-2, tile.position.z), 3));
            //    return CheckPointsAndRanks(OtherPoints);
            //case 2:
            //    OtherPoints.Add((new Point(tile.position.x-1, tile.position.z), 3));
            //    OtherPoints.Add((new Point(tile.position.x+1, tile.position.z), 1));
            //    return CheckPointsAndRanks(OtherPoints);
            case 3:
                OtherPoints.Add((new Point(tile.position.x+1, tile.position.z), 2));
                OtherPoints.Add((new Point(tile.position.x+2, tile.position.z), 1));
                return CheckPointsAndRanks(OtherPoints);
            default:
                return false;
        }

    }

    public override Bounds GetBoundsFromStartTile(Tile tile)
    {
        List<Point> points = new List<Point>();
        points.Add(new Point(tile.position.x, tile.position.z));
        points.Add(new Point(tile.position.x + 1, tile.position.z));
        points.Add(new Point(tile.position.x + 2, tile.position.z));
        return GetBoundsFromPoints(tile, points);
    }
}
