using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(DinoController))]
public class DinoJump : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private DinoController dino;
    private DinoSettings settings;

    private bool jumpOnce;
    private float groundY;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        dino = GetComponent<DinoController>();
        settings = FindObjectOfType<DinoSettings>();
    }

    internal void Jump(bool jump)
    {
        if(jump && dino.IsOnGround)
        {
            jumpOnce = false;
            rb2D.velocity = new Vector2(rb2D.velocity.x, settings.jumpSpeed);
            groundY = transform.position.y;
            dino.AnimateJump(true);
            
        }
        else if(jump && !jumpOnce && rb2D.velocity.y > 0 && transform.position.y - groundY < settings.jumpHeight)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, settings.jumpSpeed);
            
        }
        else
        {
            jumpOnce = true;
        }
    }

    private void FixedUpdate()
    {
        if (dino.IsInAir)
        {
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (settings.fallMultiplier - 1) * Time.fixedDeltaTime;
            }
            else if (rb2D.velocity.y > 0 && (!Input.GetButton("Jump") || transform.position.y - groundY > settings.jumpHeight))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (settings.lowJumpMultiplier - 1) * Time.fixedDeltaTime;
            }
        }
    }
    
}
