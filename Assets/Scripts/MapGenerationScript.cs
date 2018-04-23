using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerationScript : MonoBehaviour {

    public Sprite w;
    public Sprite g;
    

    void Start()
    {
        Room[] map = GenerateRandomRoom(16, 16, 100, 256, 12);
        Debug.Log("GenerateRandom done");

        int offset = 0;
        GraphScript.Graph G = new GraphScript.Graph(0);
        ConnectRooms(ref G, map, 10);
        G.Depth(offset);

        foreach (Room r in map)
        {
            r.PrintRoom(w, g);
        }
        Debug.Log("Print done");
    }

    float RoundRoom(float n, float m)
    {
        return Mathf.Floor((n + m - 1) / m) * m;
    }

    Vector2 GetRandomPointInCircle(int radius, int tileSize)
    {
        Vector2 coords = Vector2.zero;
        float t = 2 * Mathf.PI * Random.Range(0f, 1f);
        float u = Random.Range(0f, 1f) + Random.Range(0f, 1f);
        float r = 0f;
        if (u > 1)
            r = 2 - u;
        else
            r = u;
        coords.x = RoundRoom(radius * r * Mathf.Cos(t), tileSize);
        coords.y = RoundRoom(radius * r * Mathf.Sin(t), tileSize);
        return coords;
    }

    bool RoomsTouches(Room a, Room b, int padding)
    {
        return a.Left() < b.Right() && a.Right() > b.Left() && a.Top() > b.Bottom() && a.Bottom() < b.Top();
    }

    public void ConnectRooms(ref GraphScript.Graph G, Room[] map, int mapSize)
    {
        Room a, b, c;
        float abDist, acDist, bcDist;
        bool skip;
        for (int i = 0; i < mapSize; ++i)
        {
            a = map[i];
            for (int j = i + 1; j < mapSize; ++j)
            {
                skip = false;
                b = map[j];

                abDist = Mathf.Pow(a.CenterX() - b.CenterX(), 2) + Mathf.Pow(a.CenterY() - b.CenterY(), 2);
                for (int k = 0; k < mapSize; ++k)
                {
                    if (k == i || k == j)
                        continue;
                    c = map[k];

                    acDist = Mathf.Pow(a.CenterX() - c.CenterX(), 2) + Mathf.Pow(a.CenterY() - c.CenterY(), 2);
                    bcDist = Mathf.Pow(b.CenterX() - c.CenterX(), 2) + Mathf.Pow(b.CenterY() - c.CenterY(), 2);

                    if (acDist < abDist && bcDist < abDist)
                        skip = true;
                    if (skip)
                        break;
                }
                if (!skip)
                {
                    if (G.NodeList.Find(a) == null)
                    {
                        G.addNode(a, new LinkedList<Room>());
                    }
                    if (G.NodeList.Find(b) == null)
                    {
                        G.addNode(b, new LinkedList<Room>());
                    }
                    G.Dico[G.NodeList.Find(a).Value].AddLast(b);
                    G.Dico[G.NodeList.Find(b).Value].AddLast(a);
                }
            }
        }
    }

    Room[] GenerateRandomRoom(int width, int height, int radius, int tileSize, int mapSize)
    {
        Room[] map = new Room[mapSize];
        for (int i = 0; i < mapSize; ++i)
        {
            map[i] = new Room(width, height, RoomType.BASIC, GetRandomPointInCircle(radius, tileSize));
        }
        return map;
    }

    [System.Serializable]
    public enum RoomType
    {
        BASIC,
        START,
        DOWNSTAIRS
    }

    [System.Serializable]
    public class Room
    {
        private RoomType type;
        private int width;
        private int height;
        Vector2 coordinates;

        public Room(int width, int height, RoomType type, Vector2 coordinates)
        {
            this.width = width;
            this.height = height;
            this.type = type;
            this.coordinates = coordinates;
        }

        public int Width
        {
            get
            {
                return this.width;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
        }

        public Vector2 Coordinates
        {
            get
            {
                return this.coordinates;
            }
            set
            {
                this.coordinates = value;
            }
        }

        public float Right()
        {
            return this.coordinates.x + this.width;
        }

        public float Left()
        {
            return this.coordinates.x;
        }

        public float Bottom()
        {
            return this.coordinates.y;
        }

        public float Top()
        {
            return this.coordinates.y + this.height;
        }

        public void Shift(float x, float y)
        {
            this.coordinates.x += x;
            this.coordinates.y += y;
        }

        public float CenterX()
        {
            return this.coordinates.x + this.width / 2;
        }

        public float CenterY()
        {
            return this.coordinates.y + this.height / 2;
        }

        public void PrintRoom(Sprite wall, Sprite ground)
        {
            GameObject empty = new GameObject();
            GameObject prt = (GameObject)Instantiate(empty, Vector3.zero, Quaternion.identity);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Debug.Log(this.coordinates.x + " " + this.coordinates.y);
                    GameObject blk = (GameObject)Instantiate(empty, prt.transform);
                    blk.transform.position = new Vector2(this.coordinates.x + i * 2.5f / wall.rect.width, this.coordinates.y + j * 2.5f / wall.rect.height);
                    blk.AddComponent<SpriteRenderer>();
                    if ((i > 0 && i < width - 1 && j > 0 && j < height - 1) || Mathf.Abs(i - width / 2) < 2 || Mathf.Abs(j - height / 2) < 2)
                        blk.GetComponent<SpriteRenderer>().sprite = ground;
                    else
                    {
                        blk.GetComponent<SpriteRenderer>().sprite = wall;
                        blk.AddComponent<BoxCollider2D>();
                    }
                }
            }
            Destroy(empty);
        }
    }
}
