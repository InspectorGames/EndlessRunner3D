using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    public Transform target;

    public bool followX;
    public bool followY;

    private void Update()
    {
        Vector3 position = transform.position;
        if (followX)
        {
            position.x = target.position.x;
        }

        if(followY)
        {
            position.y = target.position.y;
        }

        transform.position = position;
    }
}
