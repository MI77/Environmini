using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

[Serializable]
public abstract class Bonus
{
    public abstract bool CheckBonus(Tile tile);
    public Sprite sprite;
    public abstract string SpriteName { get;}
    public abstract BonusType BonusType { get; }
    public abstract int BonusAmount { get; }
    public abstract Bounds GetBoundsFromStartTile(Tile tile);
    [SerializeField]
    public Dictionary<Point, Tile> tiles;
    private protected bool CheckPointsAndRanks(List<(Point, int)> pointsAndRanksToCheck)
    {
        List<(Tile, int)> validTiles = new List<(Tile, int)>();

        Tile nTile;
        foreach ((Point, int) pointRank in pointsAndRanksToCheck)
        {
            if (tiles.TryGetValue(pointRank.Item1, out nTile))
            {
                validTiles.Add((nTile, pointRank.Item2));
            }
        }

        return (
            validTiles.TrueForAll(t => t.Item1.Score == t.Item2)
            && validTiles.Count == pointsAndRanksToCheck.Count
            );

    }
    private protected Bounds GetBoundsFromPoints(Tile tile, List<Point> points)
    {
        Bounds b = tile.GetComponent<Collider>().bounds;
        foreach (var point in points)
        {
            Tile nTile;
            if (tiles.TryGetValue(point, out nTile))
            {
                b.Encapsulate(nTile.GetComponent<Collider>().bounds);
            }
        }
        return b;
    }
}
public enum BonusType
{ Rank3Tile, Rank3SquareToEast, Rank3SquareToWest, LineToSE321, LineToNE321 }
public static class BonusProcessor
{
    private static Dictionary<BonusType, Bonus> _bonuses = new Dictionary<BonusType, Bonus>();
    private static bool initialized;

    public static int GetScore(BonusType type)
    {
        if (initialized == false)
            Initialize();

        return _bonuses[type].BonusAmount;
    }
    private static void Initialize()
    {
        _bonuses.Clear();

        var assembly = Assembly.GetAssembly(typeof(Bonus));

        var allBonusTypes = assembly.GetTypes()
            .Where(b => typeof(Bonus).IsAssignableFrom(b) && b.IsAbstract == false);

        foreach (var bonusType in allBonusTypes)
        {
            Bonus bonus = Activator.CreateInstance(bonusType) as Bonus;
            _bonuses.Add(bonus.BonusType, bonus);
        }

        initialized = true;
    }
    public static Bonus GetRandomBonus()
    {
        if (initialized == false)
            Initialize();

        Array values = Enum.GetValues(typeof(BonusType));
        System.Random random = new System.Random();
        return _bonuses[(BonusType)values.GetValue(random.Next(values.Length))];      

    }

    public static Bonus GetBonus(BonusType type)
    {
        if (initialized == false)
            Initialize();

        return _bonuses[type];
    }
}