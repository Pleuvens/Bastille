using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphScript : MonoBehaviour {

    [System.Serializable]
	public class Graph
    {
        int degree;
        LinkedList<MapGenerationScript.Room> nodeList;
        Dictionary<MapGenerationScript.Room, LinkedList<MapGenerationScript.Room>> dico;

        public Graph (int degree)
        {
            this.degree = degree;
            nodeList = new LinkedList<MapGenerationScript.Room>();
            dico = new Dictionary<MapGenerationScript.Room, LinkedList<MapGenerationScript.Room>>();
        }

        public void addNode(MapGenerationScript.Room room, LinkedList<MapGenerationScript.Room> neighboors)
        {
            nodeList.AddLast(room);
            dico[room] = neighboors;
            degree += 1;
        }

        public LinkedList<MapGenerationScript.Room> NodeList
        {
            get
            {
                return nodeList;
            }
        }

        public Dictionary<MapGenerationScript.Room, LinkedList<MapGenerationScript.Room>> Dico
        {
            get
            {
                return dico;
            }
        }

        public void DepthRec(MapGenerationScript.Room src, ref Dictionary<MapGenerationScript.Room, bool> m, int offset)
        {
            m[src] = true;
            src.Coordinates = new Vector2(src.Width / 6.5f, src.Height / 6.5f) * offset;
            Debug.Log(src.Coordinates.x + " " + src.Coordinates.y + " " + dico[src].Count);
            foreach (MapGenerationScript.Room dst in dico[src])
            {
                if (!m[dst])
                {
                    DepthRec(dst, ref m, offset + 1);
                }
            }
        }

        public void Depth(int offset)
        {
            Dictionary<MapGenerationScript.Room, bool> m = new Dictionary<MapGenerationScript.Room, bool>();
            foreach (MapGenerationScript.Room r in nodeList)
                m[r] = false;
            DepthRec(nodeList.First.Value, ref m, offset);
        }
    }
}
