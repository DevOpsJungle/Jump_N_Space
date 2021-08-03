/*
 * Script: PolygonCollider
 * Author: Felix Schneider
 * Source: https://answers.unity.com/questions/722748/refreshing-the-polygon-collider-2d-upon-sprite-cha.html
 * Last Change: 30.07.21
 * Update a PolygonCollider of a GameObject when sprite changes
 */

using System.Collections.Generic;
using UnityEngine;

public class PolygonCollider : MonoBehaviour
{
    private PolygonCollider2D polygon_collider;
    private Sprite sprite;
    
    
    // Update is called once per frame
    private void Update()
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
        
        polygon_collider = GetComponent<PolygonCollider2D>();
        sprite = GetComponent<SpriteRenderer>().sprite;
        polygon_collider.pathCount = 0;
        polygon_collider.pathCount = sprite.GetPhysicsShapeCount();
 
        List<Vector2> path = new List<Vector2>();
        for (int i = 0; i < polygon_collider.pathCount; i++) {
            path.Clear();
            sprite.GetPhysicsShape(i, path);
            polygon_collider.SetPath(i, path.ToArray());
        }
    }
}
