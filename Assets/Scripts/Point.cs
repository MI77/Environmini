public struct Point
{
    public int x;
    public int z;

    public Point(int x, int z) : this()
    {
        this.x = x;
        this.z = z;
    }

    public override string ToString()
    {
        return x + " " + z; 
    }

    public static bool operator ==(Point p1, Point p2)
    {
        return (p1.x == p2.x && p1.z == p2.z);
    }

    public static bool operator !=(Point p1, Point p2)
    {
        return !(p1.x == p2.x && p1.z == p2.z);
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

}
