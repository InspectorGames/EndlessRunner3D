using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionMover : MonoBehaviour
{
    public enum Position
    {
        Up,
        Down
    }

    private Rigidbody rb;

    public float switchingSpeed;
    public float upY;
    public float downY;
    
    [Space]
    public float queueSwitchTime;
    private float queueSwitchTimer;
    private bool queueSwitch;

    private bool isChangingPosition = false;
    private float desiredY;
    private Position actualPosition = Position.Down;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        InputManager.OnActionStarted += ChangePosition;
        GameManager.OnRestartGame += RestartGame;
    }

    private void Update()
    {
        if (GameManager.gameOver) return;
        if (queueSwitch)
        {
            queueSwitchTimer += Time.deltaTime;
            if(queueSwitchTimer > queueSwitchTime)
            {
                queueSwitchTimer = 0;
                queueSwitch = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.gameOver) return;
        if (isChangingPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, desiredY, 0), switchingSpeed / 10);
            

            isChangingPosition = !(actualPosition.Equals(Position.Down) && transform.position.y <= desiredY) && !(actualPosition.Equals(Position.Up) && transform.position.y >= desiredY);
            if (!isChangingPosition && queueSwitch) ChangePosition();
        }

    }

    private void ChangePosition()
    {
        if (isChangingPosition)
        {
            queueSwitch = true;
            return;
        }
        switch (actualPosition)
        {
            case Position.Up: //Switching to Down
                desiredY = downY;
                actualPosition = Position.Down;
                break;

            case Position.Down: //Switching to Up
                desiredY = upY;
                actualPosition = Position.Up;
                break;
        }
        isChangingPosition = true;
    }

    private void RestartGame()
    {
        InputManager.OnActionStarted -= ChangePosition;
        GameManager.OnRestartGame -= RestartGame;
    }
}
