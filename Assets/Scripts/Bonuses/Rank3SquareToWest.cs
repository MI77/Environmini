using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rank3SquareToWest : Bonus
{
    public override string SpriteName { get => this.GetType().Name; }
    public override BonusType BonusType { get => BonusType.Rank3SquareToWest; }
    public override int BonusAmount { get => 4; }
    public override bool CheckBonus(Tile tile)
    {
        bool bonusValid = false;

        // only check if rank 3
        if (tile.Score == 3)
        {
            List<(Point, int)> WestPoints = new List<(Point, int)>();
            WestPoints.Add((new Point(tile.position.x, tile.position.z - 1), 3));
            WestPoints.Add((new Point(tile.position.x - 1, tile.position.z), 3));
            WestPoints.Add((new Point(tile.position.x - 1, tile.position.z - 1), 3));

            bonusValid = CheckPointsAndRanks(WestPoints);

        }

        return bonusValid;
    }

    public override Bounds GetBoundsFromStartTile(Tile tile)
    {
        List<Point> points = new List<Point>();
        points.Add(new Point(tile.position.x, tile.position.z - 1));
        points.Add(new Point(tile.position.x - 1, tile.position.z));
        points.Add(new Point(tile.position.x - 1, tile.position.z - 1));
        return GetBoundsFromPoints(tile, points);
    }
}
