namespace Swaplay.Db;

public sealed class GraphicsConfig
{
    public required string Id { get; set; } 
    public int Width { get; set; }
    public int Height { get; set; }

    public GraphicsMode Mode { get; set; }

}
