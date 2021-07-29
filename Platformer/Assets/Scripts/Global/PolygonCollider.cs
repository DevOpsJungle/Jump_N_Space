using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonCollider : MonoBehaviour
{
    public PolygonCollider2D polygonCollider;
    public Sprite sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*new_sprite = GetComponent<SpriteRenderer>().sprite;          Inefficient but working

        if (new_sprite.Equals(old_sprite))
        {
            
        }
        else
        {
            Destroy(GetComponent<PolygonCollider2D>());
            gameObject.AddComponent<PolygonCollider2D>();
        }
        old_sprite = new_sprite;*/
        
        polygonCollider = GetComponent<PolygonCollider2D>();
        sprite = GetComponent<SpriteRenderer>().sprite;
        polygonCollider.pathCount = 0;
        polygonCollider.pathCount = sprite.GetPhysicsShapeCount();
 
        List<Vector2> path = new List<Vector2>();
        for (int i = 0; i < polygonCollider.pathCount; i++) {
            path.Clear();
            sprite.GetPhysicsShape(i, path);
            polygonCollider.SetPath(i, path.ToArray());
        }
    }
}
