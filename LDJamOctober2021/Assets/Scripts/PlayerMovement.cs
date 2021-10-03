using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody;
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;
    Animator animator;
    float animationFacing = 1;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Facing", animationFacing);
        animator.SetBool("IsWalking", horizontal != 0);
        
        if (horizontal > 0) // moving right
        {
            animationFacing = 1;
            if (rigidbody.velocity.x < maxSpeed)
            {
                rigidbody.AddForce(Vector2.right * speed * Time.deltaTime);
            }
        }
        if (horizontal < 0) // moving left
        {
            animationFacing = -1;
            if (rigidbody.velocity.x > -maxSpeed)
            {
                rigidbody.AddForce(Vector2.left * speed * Time.deltaTime);
            }
        }
    }
}
