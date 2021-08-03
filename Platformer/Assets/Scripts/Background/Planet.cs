/*
 * Script: Planet
 * Author: Felix Schneider
 * Last Change: 01.06.21
 * Moves the Planet with a parallax effect
 */

using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private Transform planet;
    private Transform cam_trans;
    private Vector3 last_cam_pos;
    public Vector3 pos;

    [SerializeField] private float parallax;
    

    void Awake()
    {
        cam_trans = CameraView.GetCamera().transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(planet, Vector3.zero, Quaternion.identity, transform);
        last_cam_pos = cam_trans.position - GameController.GetStartPos() - pos;
    }

    // Update is called once per frame
    void Update()
    {
        Parallax(5.0f);
    }

    private void Parallax(float t)
    {
        new WaitForSeconds(t);      /* parallex starts after 5 sec, because player has to settle on plattform */
        
        ScreenViewport.OutBoundary(transform);
        
        Vector3 delta_move = cam_trans.position - last_cam_pos;
        
        transform.position += (delta_move * parallax);
        last_cam_pos = cam_trans.position;
    } 
}
