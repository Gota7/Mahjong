// A wall of tiles.
public class Wall
{

    // Contained tiles.
    private List<Tile> m_Tiles;

    // Get the number of tiles left.
    public int Count => m_Tiles.Count;

    // Build a wall with all standard tiles.
    public Wall(bool allowUpsideDown = false)
    {
        m_Tiles = new List<Tile>();
        for (int i = 0; i < (int)TileSuite.Count; i++)
        {
            for (byte j = 1; j <= Tile.MAX_NUM_PER_SUITE[(TileSuite)i]; j++)
            {
                for (byte k = 0; k < Tile.DUPLICATE_TILES_PER_SET; k++)
                {
                    m_Tiles.Add(new Tile((TileSuite)i, j, allowUpsideDown ? (Random.Shared.Next() % 2 == 0) : false));
                }
            }
        }
        m_Tiles.Shuffle();
    }

    // Peek a tile. If tile is out of bounds, returns null. A negative index is from the back with -1 being the back most.
    public Tile Peek(int index = -1) => m_Tiles.Peek(index);

    // Peek a tile from the back.
    public Tile PopBack() => m_Tiles.PopBack();

    // Get tiles from the end. First element of the list is the back most of the wall.
    public List<Tile> Pop(int count = 1) => m_Tiles.Pop(count);

}