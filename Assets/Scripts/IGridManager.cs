using System.Collections.Generic;

public interface IGridManager
{
    int CalculateScore();
    void ExtendGrid();
    void GenerateGrid();
    void SetTile(Tile targetTile, Tile sourceTile, bool fromMoveList);

    Dictionary<Point, Tile> Tiles { get; set; }


}