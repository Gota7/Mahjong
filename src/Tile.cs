// Suites of tiles.
public enum TileSuite
{
    Number,
    Bamboo,
    Dot,
    Wind,
    Dragon,
    Count
}

// Standard mahjong tile.
public class Tile
{
    public const byte DUPLICATE_TILES_PER_SET = 4;
    public static readonly Dictionary<TileSuite, byte> MAX_NUM_PER_SUITE = new Dictionary<TileSuite, byte>()
    {
        { TileSuite.Number, 9 },
        { TileSuite.Bamboo, 9 },
        { TileSuite.Dot, 9 },
        { TileSuite.Wind, 4 },
        { TileSuite.Dragon, 3 }
    };

    // Internal type.
    private byte m_Type;

    // Suite of a tile.
    public TileSuite Suite => (TileSuite)((m_Type & 0x7F) / 10);

    // Number of a tile.
    public byte Number => (byte)((m_Type & 0x7F) % 10);

    // If tile is upside down.
    public bool UpsideDown => (m_Type & 0x80) > 0;

    // Create a tile.
    public Tile(TileSuite suite, byte number, bool upsideDown = false)
    {
        if ((int)suite > (int)TileSuite.Count
            || number < 1
            || number > MAX_NUM_PER_SUITE[suite]
        ) throw new System.ArgumentOutOfRangeException();
        m_Type = (byte)((int)suite * 10 + number);
        if (upsideDown) m_Type |= 0x80;
    }

}