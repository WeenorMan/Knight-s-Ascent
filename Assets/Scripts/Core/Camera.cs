using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 2, -10);
    public float smoothTime = 0.25f;

    Vector3 currentVelocity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + offset, ref currentVelocity, smoothTime);
    }
}
