using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Maze : MonoBehaviour
{

    public uint width;
    public uint height;
    public uint xStart;
    public uint yStart;
    private uint xEnd;
    private uint yEnd;
    private Cell[,] maze;
    private Vector2 posStart;
    public Sprite w;
    public Sprite g;
    public GameObject ennemy;
    public GameObject player;
    public GameObject end;


    // Use this for initialization
    void Start()
    {
        xEnd = (uint)Random.Range(0, width);
        yEnd = (uint)Random.Range(0, height);
        maze = new Cell[width, height];
        posStart = new Vector2(xStart, yStart);
        for (uint x = 0; x < width; x++)
            for (uint y = 0; y < height; y++)
            {
                if (x == xStart && y == yStart)
                    maze[x, y] = new Cell(Type.START);
                else if (x == xEnd && y == yEnd)
                    maze[x, y] = new Cell(Type.END);
                else
                    maze[x, y] = new Cell();
            }
        generate();
        PrintMaze();
    }

    private bool verticalWall(uint x1, uint x2, uint y)
    {
        if (x2 < width && x1 < width && x2 >= 0 && x1 >= 0 && maze[x1, y].isLinked((uint)x2, y))
            return false;

        return true;
    }

    private bool horizontalWall(uint x, uint y1, uint y2)
    {
        if (y2 < height && y1 < height && y2 >= 0 && y1 >= 0 && maze[x, y1].isLinked(x, (uint)y2))
            return false;

        return true;
    }

    private void PrintMaze()
    {
        int count = 32;
        GameObject empty = new GameObject();
        GameObject prt = (GameObject)Instantiate(empty, Vector3.zero, Quaternion.identity);
        GameObject play = (GameObject)Instantiate(player, prt.transform);
        play.transform.position = new Vector3(xStart * 4 * 2.5f / w.rect.width, yStart * 4 * 2.5f / w.rect.height);
        GameObject l_end = (GameObject)Instantiate(this.end, prt.transform);
        l_end.transform.position = new Vector3((xEnd * 4 + 2) * 2.5f / w.rect.width, (yEnd * 4 + 1) * 2.5f / w.rect.height, 0.5f);
        GameObject bound = (GameObject)Instantiate(empty, prt.transform);
        bound.transform.position = new Vector2(-1 * 2.5f / w.rect.width, -1 * 2.5f / w.rect.height);
        bound.AddComponent<SpriteRenderer>();
        bound.GetComponent<SpriteRenderer>().sprite = w;
        bound.AddComponent<BoxCollider2D>();

        for (uint x = 0; x < width * 4; x++)
        {
            GameObject wall = (GameObject)Instantiate(empty, prt.transform);
            wall.transform.position = new Vector2(x * 2.5f / w.rect.width, -1 * 2.5f / w.rect.height);
            wall.AddComponent<SpriteRenderer>();
            wall.GetComponent<SpriteRenderer>().sprite = w;
            wall.AddComponent<BoxCollider2D>();
        }

        for (uint y = 0; y < height; y++)
        {
            GameObject wall = (GameObject)Instantiate(empty, prt.transform);
            wall.transform.position = new Vector2(-1 * 2.5f / w.rect.width, y * 4 * 2.5f / w.rect.height);
            wall.AddComponent<SpriteRenderer>();
            wall.GetComponent<SpriteRenderer>().sprite = w;
            wall.AddComponent<BoxCollider2D>();
            wall = (GameObject)Instantiate(empty, prt.transform);
            wall.transform.position = new Vector2(-1 * 2.5f / w.rect.width, (y * 4 + 1) * 2.5f / w.rect.height);
            wall.AddComponent<SpriteRenderer>();
            wall.GetComponent<SpriteRenderer>().sprite = w;
            wall.AddComponent<BoxCollider2D>();
            wall = (GameObject)Instantiate(empty, prt.transform);
            wall.transform.position = new Vector2(-1 * 2.5f / w.rect.width, (y * 4 + 2) * 2.5f / w.rect.height);
            wall.AddComponent<SpriteRenderer>();
            wall.GetComponent<SpriteRenderer>().sprite = w;
            wall.AddComponent<BoxCollider2D>();
            wall = (GameObject)Instantiate(empty, prt.transform);
            wall.transform.position = new Vector2(-1 * 2.5f / w.rect.width, (y * 4 + 3) * 2.5f / w.rect.height);
            wall.AddComponent<SpriteRenderer>();
            wall.GetComponent<SpriteRenderer>().sprite = w;
            wall.AddComponent<BoxCollider2D>();
            for (uint x = 0; x < width; x++)
            {
                if (Random.Range(0, 20) == 0 && count > 0)
                {
                    count--;
                    GameObject monster = (GameObject)Instantiate(ennemy, prt.transform);
                    monster.transform.position = new Vector3(x * 4 * 2.5f / w.rect.width, y * 4 * 2.5f / w.rect.height);
                    monster.GetComponent<EnemyScript>().target = GameObject.Find("Player(Clone)");
                }
                GameObject blk = (GameObject)Instantiate(empty, prt.transform);
                blk.transform.position = new Vector3(x * 4 * 2.5f / w.rect.width, y * 4 * 2.5f / w.rect.height, 1);
                blk.AddComponent<SpriteRenderer>();
                blk.GetComponent<SpriteRenderer>().sprite = g;
                blk = (GameObject)Instantiate(empty, prt.transform);
                blk.transform.position = new Vector3((x * 4 + 1) * 2.5f / w.rect.width, (y * 4) * 2.5f / w.rect.height, 1);
                blk.AddComponent<SpriteRenderer>();
                blk.GetComponent<SpriteRenderer>().sprite = g;
                blk = (GameObject)Instantiate(empty, prt.transform);
                blk.transform.position = new Vector3((x * 4 + 2) * 2.5f / w.rect.width, (y * 4) * 2.5f / w.rect.height, 1);
                blk.AddComponent<SpriteRenderer>();
                blk.GetComponent<SpriteRenderer>().sprite = g;
                blk = (GameObject)Instantiate(empty, prt.transform);
                blk.transform.position = new Vector3((x * 4) * 2.5f / w.rect.width, (y * 4 + 1) * 2.5f / w.rect.height, 1);
                blk.AddComponent<SpriteRenderer>();
                blk.GetComponent<SpriteRenderer>().sprite = g;
                blk = (GameObject)Instantiate(empty, prt.transform);
                blk.transform.position = new Vector3((x * 4) * 2.5f / w.rect.width, (y * 4 + 2) * 2.5f / w.rect.height, 1);
                blk.AddComponent<SpriteRenderer>();
                blk.GetComponent<SpriteRenderer>().sprite = g;
                blk = (GameObject)Instantiate(empty, prt.transform);
                blk.transform.position = new Vector3((x * 4 + 1) * 2.5f / w.rect.width, (y * 4 + 1) * 2.5f / w.rect.height, 1);
                blk.AddComponent<SpriteRenderer>();
                blk.GetComponent<SpriteRenderer>().sprite = g;
                blk = (GameObject)Instantiate(empty, prt.transform);
                blk.transform.position = new Vector3((x * 4 + 2) * 2.5f / w.rect.width, (y * 4 + 1) * 2.5f / w.rect.height, 1);
                blk.AddComponent<SpriteRenderer>();
                blk.GetComponent<SpriteRenderer>().sprite = g;
                blk = (GameObject)Instantiate(empty, prt.transform);
                blk.transform.position = new Vector3((x * 4 + 1) * 2.5f / w.rect.width, (y * 4 + 2) * 2.5f / w.rect.height, 1);
                blk.AddComponent<SpriteRenderer>();
                blk.GetComponent<SpriteRenderer>().sprite = g;
                blk = (GameObject)Instantiate(empty, prt.transform);
                blk.transform.position = new Vector3((x * 4 + 2) * 2.5f / w.rect.width, (y * 4 + 2) * 2.5f / w.rect.height, 1);
                blk.AddComponent<SpriteRenderer>();
                blk.GetComponent<SpriteRenderer>().sprite = g;

                GameObject blk2 = (GameObject)Instantiate(empty, prt.transform);
                blk2.transform.position = new Vector3((x * 4 + 3) * 2.5f / w.rect.width, (y * 4) * 2.5f / w.rect.height, 1);
                blk2.AddComponent<SpriteRenderer>();
                blk2.GetComponent<SpriteRenderer>().sprite = g;
                blk = (GameObject)Instantiate(empty, prt.transform);
                blk.transform.position = new Vector3((x * 4 + 3) * 2.5f / w.rect.width, (y * 4 + 1) * 2.5f / w.rect.height, 1);
                blk.AddComponent<SpriteRenderer>();
                blk.GetComponent<SpriteRenderer>().sprite = g;
                GameObject blk3 = (GameObject)Instantiate(empty, prt.transform);
                blk3.transform.position = new Vector3((x * 4 + 3) * 2.5f / w.rect.width, (y * 4 + 2) * 2.5f / w.rect.height, 1);
                blk3.AddComponent<SpriteRenderer>();
                blk3.GetComponent<SpriteRenderer>().sprite = g;
                if (verticalWall(x, x + 1, y))
                {
                    blk.transform.position = new Vector3(blk.transform.position.x, blk.transform.position.y);
                    blk.GetComponent<SpriteRenderer>().sprite = w;
                    blk.AddComponent<BoxCollider2D>();
                    blk2.transform.position = new Vector3(blk2.transform.position.x, blk2.transform.position.y);
                    blk2.GetComponent<SpriteRenderer>().sprite = w;
                    blk2.AddComponent<BoxCollider2D>();
                    blk3.transform.position = new Vector3(blk3.transform.position.x, blk3.transform.position.y);
                    blk3.GetComponent<SpriteRenderer>().sprite = w;
                    blk3.AddComponent<BoxCollider2D>();
                }
                blk3 = (GameObject)Instantiate(empty, prt.transform);
                blk3.transform.position = new Vector3((x * 4) * 2.5f / w.rect.width, (y * 4 + 3) * 2.5f / w.rect.height, 1);
                blk3.AddComponent<SpriteRenderer>();
                blk3.GetComponent<SpriteRenderer>().sprite = g;
                blk = (GameObject)Instantiate(empty, prt.transform);
                blk.transform.position = new Vector3((x * 4 + 1) * 2.5f / w.rect.width, (y * 4 + 3) * 2.5f / w.rect.height, 1);
                blk.AddComponent<SpriteRenderer>();
                blk.GetComponent<SpriteRenderer>().sprite = g;
                blk2 = (GameObject)Instantiate(empty, prt.transform);
                blk2.transform.position = new Vector3((x * 4 + 2) * 2.5f / w.rect.width, (y * 4 + 3) * 2.5f / w.rect.height, 1);
                blk2.AddComponent<SpriteRenderer>();
                blk2.GetComponent<SpriteRenderer>().sprite = g;
                if (horizontalWall(x, y, y + 1))
                {
                    blk.transform.position = new Vector3(blk.transform.position.x, blk.transform.position.y);
                    blk.GetComponent<SpriteRenderer>().sprite = w;
                    blk.AddComponent<BoxCollider2D>();
                    blk2.transform.position = new Vector3(blk2.transform.position.x, blk2.transform.position.y);
                    blk2.GetComponent<SpriteRenderer>().sprite = w;
                    blk2.AddComponent<BoxCollider2D>();
                    blk3.transform.position = new Vector3(blk3.transform.position.x, blk3.transform.position.y);
                    blk3.GetComponent<SpriteRenderer>().sprite = w;
                    blk3.AddComponent<BoxCollider2D>();
                }
                GameObject blk4 = (GameObject)Instantiate(empty, prt.transform);
                blk4.transform.position = new Vector2((x * 4 + 3) * 2.5f / w.rect.width, (y * 4 + 3) * 2.5f / w.rect.height);
                blk4.AddComponent<SpriteRenderer>();
                blk4.GetComponent<SpriteRenderer>().sprite = w;
                blk4.AddComponent<BoxCollider2D>();

            }
        }
        Destroy(empty);
    }

    public void generate()
    {
        uint x = (uint)Random.Range(0, (int)width);
        uint y = (uint)Random.Range(0, (int)height);

        generateRec(x, y);
    }
    private void generateRec(uint x, uint y)
    {
        if (maze[x, y].getVisited())
            return;

        maze[x, y].setVisited(true);
        if (maze[x, y].getType() == Type.START || maze[x, y].getType() == Type.END)
            return;
        List<Vector2> n = getNotVisitedNeighbor(x, y);
        while (n.Count != 0)
        {
            int i = Random.Range(0, n.Count);
            Vector2 t = n.ElementAt<Vector2>(i);
            maze[x, y].addLink(t);
            maze[(uint)t.x, (uint)t.y].addLink(new Vector2(x, y));
            generateRec((uint)t.x, (uint)t.y);
            n = getNotVisitedNeighbor(x, y);
        }
    }
    private List<Vector2> getNotVisitedNeighbor(uint x, uint y)
    {
        List<Vector2> n = new List<Vector2>();
        if (x > 0 && !maze[x - 1, y].getVisited())
            n.Add(new Vector2(x - 1, y));
        if (x < width - 1 && !maze[x + 1, y].getVisited())
            n.Add(new Vector2(x + 1, y));
        if (y > 0 && !maze[x, y - 1].getVisited())
            n.Add(new Vector2(x, y - 1));
        if (y < height - 1 && !maze[x, y + 1].getVisited())
            n.Add(new Vector2(x, y + 1));
        return n;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
