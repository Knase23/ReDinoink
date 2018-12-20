using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(DinoController))]
public class DinoMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private DinoController dino;
    private DinoSettings settings;

    private float direction;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        dino = GetComponent<DinoController>();
        settings = FindObjectOfType<DinoSettings>();

    }
    public bool Move(float direction)
    {
        this.direction = direction;

        if(direction != 0)
        {
            return true;
        }

        return false;
    }
    private void FixedUpdate()
    {
        Vector2 velocity = rb2D.velocity;
        float acceleration = 0;
        float drag = 0;

        if (!dino.IsOnGround)
        {
            acceleration = settings.accelerationAir;
            drag = settings.dragAir;
        }
        else
        {
            acceleration = settings.accelerationGround;
            drag = settings.dragGround;
        }

        //Calculate velocity
        velocity.x += (acceleration * direction - drag * velocity.x) * Time.fixedDeltaTime;
        
        // Limiting Velocity
        velocity.x = Mathf.Clamp(velocity.x, -settings.movmentVelocityMax, settings.movmentVelocityMax);
        dino.AnimateMove(Mathf.Abs(velocity.x));
        // Apply changes
        rb2D.velocity = new Vector2(velocity.x, velocity.y);
    }
}
