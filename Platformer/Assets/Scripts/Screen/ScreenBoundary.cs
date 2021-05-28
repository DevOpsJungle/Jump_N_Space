using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ScreenBoundary : MonoBehaviour
{
    public float width;
    public float height;

    public static float edgeleft;
    public static float edgeright;
    public static float edgetop;
    public static float edgebottom;
    
    public EdgeCollider2D edge;
    public Camera cam;

    
    public Vector3 pos;
    
    void FindBoundary()
    {
        width = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0) + pos).x - 0.5f);
        height = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0) + pos).y - 0.5f);
    }

    void SetEdges(int inx, int iny)       // posx und posy, entweder 0|1, ob in diese Richtung Transformiert wird
    {
        pos.x = inx * pos.x;
        pos.y = iny * pos.y;
            
        edgeleft = (-width/ 2) + pos.x;
        edgeright = (width/ 2) + pos.x;
        
        edgetop = (height / 2) + pos.y;
        edgebottom = (-height / 2) + pos.y;
    }
    
    void SetBoundary()
    {
        Vector2 point_1 = new Vector2(edgeright, edgetop);
        Vector2 point_2 = new Vector2(edgeright, edgebottom);
        Vector2 point_3 = new Vector2(edgeleft , edgebottom);
        Vector2 point_4 = new Vector2(edgeleft, edgetop);
        Vector2 [] pointArray = new Vector2[] {point_1,point_2,point_3,point_4,point_1};

        edge.points = pointArray;
    }


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        edge = GetComponent<EdgeCollider2D>();
        pos = CameraView.player_worldspace_pos;
    }

    // Update is called once per frame
    void Update()
    {
        pos = CameraView.player_worldspace_pos;
        
        FindBoundary();
        
        SetEdges(1,0);

        SetBoundary();
        
    }
}

