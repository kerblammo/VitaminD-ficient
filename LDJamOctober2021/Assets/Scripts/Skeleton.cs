using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    Animator animator;
    bool isMovingRight;
    Rigidbody2D rigidbody;
    [SerializeField] float speed;
    [SerializeField] float jitterStrength;
    [SerializeField] DestroyAfterStart particles;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Time.timeScale > 0f)
        {
            // only move if game is not paused
            transform.Translate(Vector2.up * jitterStrength * Time.deltaTime);
        }
        
        if (isMovingRight)
        {
            rigidbody.AddForce(Vector2.right * speed * Time.deltaTime);
        } else
        {
            rigidbody.AddForce(Vector2.left * speed * Time.deltaTime);
        }
    }

    public void CollideWithWall()
    {
        isMovingRight = !isMovingRight;
        animator.SetBool("WalkRight", isMovingRight);
    }

    void OnDestroy()
    {
        Instantiate(particles, transform.position, Quaternion.identity);
    }


}
