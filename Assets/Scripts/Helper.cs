using UnityEngine;

public class Helper : MonoBehaviour
{
     LayerMask groundLayer;

    void Start()
    {
        // set the mask to be "Ground"
        groundLayer = LayerMask.GetMask("Ground");
    }



    public bool DoRayCollisionCheck()
    {
        float rayLength = 5f; // length of raycast


        //cast a ray downward 
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position, Vector2.down * rayLength, hitColor);
        return hit.collider;


    }

}
