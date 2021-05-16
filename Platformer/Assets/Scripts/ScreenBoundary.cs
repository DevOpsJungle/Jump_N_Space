using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundary : MonoBehaviour
{
    public float width;
    public float height;

    public float edgeleft;
    public float edgeright;
    public float edgetop;
    public float edgebottom;
    


    public EdgeCollider2D edge;
    public Camera cam;

    
    public Vector3 pos;
    
    void FindBounds()
    {
        width = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0) + pos).x - 0.5f);
        height = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0) + pos).y - 0.5f);
    }

    void SetBounds()
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
        
        edgeleft = (-width/ 2) + pos.x;
        edgeright = (width/ 2) + pos.x;
        
        edgetop = (height / 2);
        edgebottom = (-height / 2);
        
        pos = CameraView.player_worldspace_pos;
        
        FindBounds();
        SetBounds();
    }
}

