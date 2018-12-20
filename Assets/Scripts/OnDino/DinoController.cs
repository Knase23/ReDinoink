using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
[DisallowMultipleComponent]
public class DinoController : MonoBehaviour
{
    internal bool IsOnGround { get; private set; }
    internal bool IsInAir { get; private set; }

    private DinoJump dinoJump;
    private DinoMovement dinoMovement;
    private CapsuleCollider2D boxCollider2;
    private Animator animator;
    [SerializeField]
    private LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    public bool stunned;

    // Start is called before the first frame update
    private void Start()
    {
        dinoJump = GetComponent<DinoJump>();
        dinoMovement = GetComponent<DinoMovement>();
        boxCollider2 = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        SetIsOnGround(false);

        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, whatIsGround);
        for (int i = 0; i < collider2Ds.Length; i++)
        {
            if(collider2Ds[i].gameObject != gameObject)
            {
                SetIsOnGround(true);
                AnimateJump(false);
            }
        }

    }

    public void SetIsOnGround(bool boolean)
    {
        IsOnGround = boolean;
        IsInAir = !boolean;
    }
    public void Jump(bool state)
    {
        dinoJump.Jump(state);
    }
    public void Move(float direction)
    {
        dinoMovement.Move(direction);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
    }

    public void Stunned()
    {
        stunned = true;
    }
    public void UnStun()
    {
        stunned = false;
    }

    public void AnimateJump(bool state)
    {
        animator.SetBool("IsJumping", state);
    }
    public void AnimateMove(float velocity)
    {
        animator.SetFloat("Walking", velocity);
    }
    public void AnimateStunned()
    {
        animator.SetTrigger("Stunned");
    }

}
