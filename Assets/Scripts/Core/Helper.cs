using UnityEngine;

public class Helper : MonoBehaviour
{
    LayerMask groundLayer;
    LayerMask wallLayer;
    SpriteRenderer spriteRenderer;

    public void Start()
    {
        wallLayer = LayerMask.GetMask("Wall");
        groundLayer = LayerMask.GetMask("Ground");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void FlipObject(bool flip)
    {
        if(flip == true)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }


    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs, Vector2 dir, float rayLength, LayerMask layer )
    {
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward 
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, dir, rayLength, layer);


        Color hitColor = Color.red;


        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, dir * rayLength, hitColor);

        return hitSomething;

    }



}
