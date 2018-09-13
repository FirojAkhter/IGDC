using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    [System.Serializable]
    struct GridAssister {
        public Vector3 pos;
       public  bool bla;
    }

    [SerializeField]
     Grid grid;
    [SerializeField]
    GridAssister[] gd;


    
    public static Transform box = null;
 
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float box_x_snap;
    [SerializeField]
    private float box_z_snap;

    public enum Directions { still,up,left,right,down};
    [SerializeField]
    private Directions dir;

    

	// Use this for initialization
	void Start () {
        grid = new Grid();
		for(int j =0;j < gd.Length;j++)
        {
            grid.AddElement(gd[j].pos,gd[j].bla);
        }
     //   for (int j = 0; j < gd.Length; j++)
      //  {
   //       Debug.Log(grid.Check(gd[j].pos));
     //  }

      //  grid.Display();
        dir = Directions.still;
	}
	
	// Update is called once per frame
	void Update () {

        DirectionCheck();
		if(Input.GetKeyDown(KeyCode.E) && box)
        {
            Debug.Log("Pressing E");
            switch (dir)
            {
                case Directions.still:
                    
                    break;
                case Directions.up:
                    MoveBox(0, box_z_snap);
                    break;
                case Directions.left:
                    MoveBox(-box_x_snap, 0);
                    break;
                case Directions.right:
                    MoveBox(box_x_snap, 0);
                    break;
                case Directions.down:
                    MoveBox(0, -box_z_snap);
                    break;
            }

        }
	}

    void DirectionCheck()
    {
        Vector3 angle = Vector3.Cross(Vector3.forward, player.forward);
        if (Vector3.Angle(Vector3.forward, player.forward) < 15)
            dir = Directions.up;
        else if (Vector3.Angle(Vector3.forward, player.forward) > 60 && Vector3.Angle(Vector3.forward, player.forward) < 165 && angle.y > 0)
            dir = Directions.right;
        else if (Vector3.Angle(Vector3.forward, player.forward) > 60&& Vector3.Angle(Vector3.forward, player.forward) < 165 && angle.y < 0)
            dir = Directions.left;
        else if (Vector3.Angle(Vector3.forward, player.forward) > 165)
            dir = Directions.down;
        else
            dir = Directions.still;
    }

    void MoveBox(float x_sp , float z_sp)
    {
        Vector3 post = new Vector3(box.position.x + x_sp, box.position.y, box.position.z + z_sp);
        Debug.Log(post);
      
        if (grid.Check(post))
        {
            Debug.Log("Entering if");
            grid.UnBlockGrid(box.position);
            box.position = post;
            grid.BlockGrid(post);

        }
        else
            return;
    }
}
[System.Serializable]
class GridNode
{
    public bool empty;
    public bool pres;
    public float x_pos;
    public float z_pos;

    public GridNode next;
   public  GridNode()
    {
        empty = true;
        x_pos = 0.2f;
        z_pos = 0.2f;
        pres = false;
        
        next = null;
        Debug.Log("GridNode constructor called");
    }
    
 }


[System.Serializable]
class Grid
{
    public GridNode[] g;

   public Grid()
    {
        g = new GridNode[50];
        for (int i = 0; i < 50; i++)
        {
            g[i] = new GridNode();

        }
    }

    public int HashFunction(Vector3 coord)
    {
        return Mathf.RoundToInt((Mathf.Abs(coord.x) + Mathf.Abs(coord.z)) % 50);
    }

    public void AddElement(Vector3 coord, bool bla)
    {
        int i = HashFunction(coord);
        if (!g[i].pres)
        {
            g[i].x_pos = coord.x;
            g[i].z_pos = coord.z;
            g[i].pres = true;
            g[i].empty = bla;
            g[i].next = null;
        }
        else
        {
            GridNode temp;
            temp = g[i];
            while (temp.next != null)
            {
                temp = temp.next;
            }
            GridNode put = new GridNode();
            put.pres = true;
            put.x_pos = coord.x;
            put.z_pos = coord.z;
            put.empty = bla;
            put.next = null;
            temp.next = put;
        }


    }
    public bool Check(Vector3 coord)
    {
        int i = HashFunction(coord);
        if (!g[i].pres)
            return false;
        else if (g[i].pres && g[i].next == null)
        {
            if (g[i].x_pos == coord.x && g[i].z_pos == coord.z && g[i].empty)
                return true;
            else
                return false;
        }
        else
        {
            GridNode temp = g[i];
            while (temp.next != null)
            {

               
                if (temp.x_pos == coord.x && temp.z_pos == coord.z && temp.empty )
                    return true;
                temp = temp.next;


            }
            if (temp.x_pos == coord.x && temp.z_pos == coord.z && temp.empty)
                return true;
            else
            return false;
        }
    }

   public void BlockGrid(Vector3 coord)
    {
        int i = HashFunction(coord);
        if(g[i].pres && g[i].next == null)
        {
            if(g[i].x_pos == coord.x && g[i].z_pos == coord.z)
            {
                g[i].empty = false;
                return;
            }
        }
        else
        {
            GridNode temp = g[i];
            while(temp.next != null)
            {
                if (temp.x_pos == coord.x && temp.z_pos == coord.z)
                {
                    temp.empty = false;
                    return;
                }
                temp = temp.next;
            }
            if (temp.x_pos == coord.x && temp.z_pos == coord.z)
            {
                temp.empty = false;
                return;
            }
        }
    }

   public void UnBlockGrid(Vector3 coord)
    {
        int i = HashFunction(coord);
        if (g[i].pres && g[i].next == null)
        {
            if (g[i].x_pos == coord.x && g[i].z_pos == coord.z)
            {
                g[i].empty = true;
                return;
            }
        }
        else
        {
            GridNode temp = g[i];
            while (temp.next != null)
            {
                if (temp.x_pos == coord.x && temp.z_pos == coord.z)
                {
                    temp.empty = true;
                    return;
                }
                temp = temp.next;
            }

            if (temp.x_pos == coord.x && temp.z_pos == coord.z)
            {
                temp.empty = true;
                return;
            }
        }

    }

    public void Display()
    {
        for(int i =0;i<50;i++)
        {
            if (!g[i].pres)
                continue;
            else if(g[i].pres)
            {
               if(g[i].next == null)
                {
                    Debug.Log(g[i].x_pos);
                    Debug.Log(g[i].z_pos);
                }
                GridNode temp = g[i];
                while(temp.next!=null)
                {
                    Debug.Log(temp.x_pos );
                    Debug.Log(temp.z_pos);
                    temp = temp.next;
                }
            }
        }
    }


}
