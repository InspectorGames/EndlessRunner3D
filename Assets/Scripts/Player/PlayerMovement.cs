using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;

    [Space]
    public float verticalSpeed;
    public float verticalSpeedIncrementPerSecond;
    public float maxVerticalSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (GameManager.gameOver)
        {
            rb.velocity = Vector3.zero;
            return;
        }
        rb.velocity = transform.right * verticalSpeed * Time.fixedDeltaTime;
    }

    private void Update()
    {
        if (GameManager.gameOver) return;
        if (verticalSpeed < maxVerticalSpeed)
        {
            verticalSpeed += Time.deltaTime * verticalSpeedIncrementPerSecond;
        }
    }
}
