/*
 * Script: Planet
 * Author: Felix Schneider
 * Last Change: 01.06.21
 * ...I am a description...
 */

using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private Transform planet;
    private Transform cam_trans;
    private Vector3 last_cam_pos;

    [SerializeField] private float parallax;
    

    void Awake()
    {
        Instantiate(planet, Vector3.zero, Quaternion.identity, transform);
        cam_trans = CameraView.GetCamera().transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        last_cam_pos = cam_trans.position - Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 delta_move = cam_trans.position - last_cam_pos;
        
        transform.position += (delta_move * parallax);
        last_cam_pos = cam_trans.position;
    }
}
