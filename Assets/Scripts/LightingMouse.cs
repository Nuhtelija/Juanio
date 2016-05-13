using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class LightingMouse : MonoBehaviour
{
    public List<LineRenderer> line = new List<LineRenderer>();
    BoxCollider2D[] colliders;
    public LayerMask mask;
    public List<Vector2> cornerPoints = new List<Vector2>();


    private GameObject myObject;
    public List<Vector3> nodePositions;
    public List<Vector3> interPositions;
    public List<Vector3> sortedPos;
    private Vector2 mousePos;
    public Material myMaterial;
    // Use this for initialization
    void Start()
    {
        myObject = new GameObject();
        myObject.AddComponent<MeshFilter>();
        myObject.AddComponent<MeshRenderer>();

        colliders = FindObjectsOfType<BoxCollider2D>();

        updateColliders();

        for (int i = 0; i < cornerPoints.Count; i++)
        {
            line.Add(new GameObject("Line" + i).AddComponent<LineRenderer>());
        }



    }

    void Update()
    {

        /*  for(int i = 0; i < line.Count; i++)
          {
              createLine(cornerPoints[i], i);
          }
          */
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        updateColliders();
        shootRays(mousePos);
        updatePolygon();



    }


    private void updateColliders()
    {
        cornerPoints.Clear();
        foreach (BoxCollider2D i in colliders)
        {
            if (1 << i.gameObject.layer == mask.value)
            {
                Vector2 size = i.GetComponent<Transform>().lossyScale;
                Vector3 centerpoint = new Vector3(i.GetComponent<Collider2D>().offset.x,
                                                     i.GetComponent<Collider2D>().offset.y,
                                                     0f);
                Vector3 worldPos = i.transform.TransformPoint(i.GetComponent<Collider2D>().offset);

                float top = worldPos.y + (size.y / 2f);
                float btm = worldPos.y - (size.y / 2f);
                float left = worldPos.x - (size.x / 2f);
                float right = worldPos.x + (size.x / 2f);


                cornerPoints.Add(new Vector3(left, btm, worldPos.z));
                cornerPoints.Add(new Vector3(right, btm, worldPos.z));
                cornerPoints.Add(new Vector3(right, top, worldPos.z));
                cornerPoints.Add(new Vector3(left, top, worldPos.z));

            }
        }
    }

    private void createLine(Vector2 pos1, Vector2 pos2, int i)
    {
        //create a new empty gameobject and line renderer component
        line[i].SetPosition(0, pos1);
        line[i].SetPosition(1, pos2);

        //assign the material to the line
        line[i].material.color = Color.red;

        //set the number of points to the line
        line[i].SetVertexCount(2);
        //set the width
        line[i].SetWidth(0.15f, 0.15f);
        line[i].sortingOrder = 20;
        //render line to the world origin and not to the object's position
        //line.useWorldSpace = true;

    }


    private void shootRays(Vector3 pos)
    {
        nodePositions.Clear();
       
        for (int i = 0; i < cornerPoints.Count; i++)
        {
            RaycastHit2D hit = Physics2D.Linecast(mousePos, cornerPoints[i], 1 << LayerMask.NameToLayer("Light"));


            RaycastHit2D hit2 = Physics2D.Linecast(mousePos, cornerPoints[i] + new Vector2(0.1f, 0.1f), 1 << LayerMask.NameToLayer("Light"));
            RaycastHit2D hit3 = Physics2D.Linecast(mousePos, cornerPoints[i] - new Vector2(0.1f, 0.1f), 1 << LayerMask.NameToLayer("Light"));

            if (hit == true)
            {
                //createLine(pos, hit.point, i);
                nodePositions.Add(hit.point);
            }
            if (hit2 == true)
            {
                nodePositions.Add(hit2.point);
            }
            if (hit3 == true)
            {
                nodePositions.Add(hit3.point);
            }
        }

    }
    /*
    private Vector2 getDirection(Vector2 a, Vector2 b)
    {
        float dx = b.x - a.x;
        float dy = b.y - a.y;

        return new Vector2(dx, dy);
    }

    private void interSections(Vector2 ray, Vector2 source)
    {
        interPositions.Clear();
        float currentT1 = -1, T1 = -1, T2 = -1;

        Vector2 segDir;
        Vector2 rayDir = getDirection(source, ray);


        for (int i = 0; i < cornerPoints.Count-1; i++)
        {
            Vector2 segA = cornerPoints[i];
            Vector2 segB = cornerPoints[i + 1];

            segDir = getDirection(segA, segB);
            // Straight parametrised is = segA + segDir * T2
            // Line is source + rayDir * T1
            T1 = -1;
            T2 = (rayDir.x * (segA.y - source.y)) + rayDir.y * (source.x - segA.x) / (segDir.x * rayDir.y - segDir.y * rayDir.x);
            if (T2 > 0 && T2 < 1)
            {
                T1 = (segA.x + segDir.x * T2 - source.x) / rayDir.x;
            }

            if (T1 > 0)
            {
                currentT1 = T1;
            }

           
        }
        if(currentT1 > 0)
            interPositions.Add(new Vector2(source.x + rayDir.x * currentT1, source.y + rayDir.y * currentT1));

        Debug.Log("T1: " + T1 + " T2: " + T2);
    }
    */

    public void updatePolygon()
    {
        //Destroy old game object
        myObject.GetComponent<MeshFilter>().mesh.Clear();



        //New mesh and game object
        myObject.name = "MousePolygon";
        Mesh mesh = new Mesh();

        //Components
        MeshFilter MF = myObject.GetComponent<MeshFilter>();
        MeshRenderer MR = myObject.GetComponent<MeshRenderer>();
        //myObject[x].AddComponent();

        //Create mesh
        mesh = CreateMesh(0);

        //Assign materials
        MR.material = myMaterial;

        //Assign mesh to game object
        MF.mesh = mesh;
        myObject.GetComponent<Transform>().Translate(new Vector3(0, 0, 1f));
    }



    private Mesh CreateMesh(int num)
    {

        int x; //Counter

        //Create a new mesh
        Mesh mesh = new Mesh();

        //Vertices

        // Remove duplicate vectors
        List<Vector3> noDupes = nodePositions.Distinct().ToList<Vector3>();
        nodePositions = noDupes;
        var vertex = new Vector3[nodePositions.Count];

        for (x = 0; x < nodePositions.Count; x++)
        {
            vertex[x] = nodePositions[x];
        }

        // Sort vectors to be rendered in a clockwise order
        Vector2Sort sorter = new Vector2Sort(mousePos);
        Array.Sort(vertex, sorter.Compare);
        // Put them in a temporary list
        sortedPos.Clear();
        for (x = 0; x < vertex.Length; x++)
        {
            sortedPos.Add(vertex[x]);
        }
        // Insert the mouse location as the first vector
        sortedPos.Insert(0, mousePos);
        // add the updated list back into the array
        for (x = 0; x < nodePositions.Count; x++)
        {
            vertex[x] = sortedPos[x];
        }

        //UVs
        var uvs = new Vector2[vertex.Length];

        for (x = 0; x < vertex.Length; x++)
        {
            if ((x % 2) == 0)
            {
                uvs[x] = new Vector2(0, 0);
            }
            else
            {
                uvs[x] = new Vector2(1, 1);
            }
        }

        //Triangles
        var tris = new int[3 * (vertex.Length - 2) + 3];    //3 verts per triangle * num triangles, plus we need additional polygon to tie them up
        int C1;
        int C2;
        int C3;


        C1 = 0;
        C2 = 1;
        C3 = 2;
        // everything except the last polygon that will tie first and last nodes
        for (x = 0; x < tris.Length - 3; x += 3) 
        {
            tris[x] = C1;
            tris[x + 1] = C2;
            tris[x + 2] = C3;

            C2++;
            C3++;
        }
        // tie up the last and first node if the polygon is larger than 3
        if (tris.Length > 3)        
        {
            tris[tris.Length - 3] = 0;
            tris[tris.Length - 2] = vertex.Length - 1;
            tris[tris.Length - 1] = 1;
        }



        //Assign data to mesh
        mesh.vertices = vertex;
        mesh.uv = uvs;
        mesh.triangles = tris;

        //Recalculations
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();

        //Name the mesh
        mesh.name = "MyMesh";

        //Return the mesh
        return mesh;
    }

}