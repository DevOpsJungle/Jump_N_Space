/*
 * Script: ScreenViewport
 * Author: Felix Schneider
 * Last Change: 10.06.21
 * ...I am a description...
 */

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ScreenViewport : MonoBehaviour
{
    
    public static Vector3 screenpos;            //screenpos => x, y - middle of every Viewport Axis to Worldspace
    
    public static float width;       //show private attribute in inspector
    public static float height;
    
    public static float edgeleft;
    public static float edgeright;
    public static float edgetop;
    public static float edgebottom;
    
    public EdgeCollider2D edge;
    public Camera camera_viewport;
    [SerializeField] private Vector3 pos;       //Player Position
   
    void Awake()
    {
        edge = GetComponent<EdgeCollider2D>();
        
        FindDimensions();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        camera_viewport = CameraView.camera_player;
        pos = PlayerController.player_pos;
        FindScreenpos();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        pos = PlayerController.player_pos;
        FindScreenpos();

        FindDimensions();
        SetEdges();
        SetBoundary();
    }

    private void FindScreenpos()
    {
        screenpos = camera_viewport.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, - camera_viewport.transform.position.z));
    }
    
    public void FindDimensions()
    {
        width = 1 / (camera_viewport.WorldToViewportPoint(new Vector3(1, 1, 0) + pos).x - 0.5f);        //Viewport Transformation
        height = 1 / (camera_viewport.WorldToViewportPoint(new Vector3(1, 1, 0) + pos).y - 0.5f);
    }

    private void SetEdges()                         //set edges with camera pos --> Camera Viewport defines edges
    {
        edgeleft = (-width/ 2) + pos.x;
        edgeright = (width/ 2) + pos.x;
        
        edgetop = (height / 2) + pos.y;
        edgebottom = (-height / 2) + pos.y;
    }
    
    private void SetBoundary()                      //with edgepoints boundary can be set
    {
        Vector2 point_1 = new Vector2(edgeright, edgetop);
        Vector2 point_2 = new Vector2(edgeright, edgebottom);
        Vector2 point_3 = new Vector2(edgeleft , edgebottom);
        Vector2 point_4 = new Vector2(edgeleft, edgetop);
        Vector2 [] pointArray = new Vector2[] {point_1,point_2,point_3,point_4,point_1};

        edge.points = pointArray;
    }
}

