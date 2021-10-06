using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Rank3Tile : Bonus
{
    private List<(Point point, int rank)> pointsAndRanks;
    public override string SpriteName { get => this.GetType().Name; }
    public override BonusType BonusType { get => BonusType.Rank3Tile; }
    public override int BonusAmount { get => 0; }
    public override bool CheckBonus(Tile tile)
    {
        pointsAndRanks = new List<(Point point, int rank)> { (tile.position, 3) };
        return CheckPointsAndRanks(pointsAndRanks);
    }

    public override Bounds GetBoundsFromStartTile(Tile tile)
    {
        List<Point> points = new List<Point>{ tile.position };
        return GetBoundsFromPoints(tile, points);
    }

}
