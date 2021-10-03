using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Layers
{
    public static int Player = 6;
    public static int Platform = 7;
}
public class PlayerJump : MonoBehaviour
{
    enum JumpState
    {
        NotJumping,
        Rising,
        Falling
    }
    JumpState state = JumpState.NotJumping;
    Rigidbody2D rigidbody;
    [SerializeField] float jumpStrength;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case JumpState.NotJumping:
                if (Input.GetKeyDown(KeyCode.W))
                {
                    state = JumpState.Rising;
                    Physics2D.IgnoreLayerCollision(Layers.Platform, Layers.Player, true);
                    rigidbody.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
                }
                break;
            case JumpState.Rising:
                if (rigidbody.velocity.y < 0)
                {
                    state = JumpState.Falling;
                    Physics2D.IgnoreLayerCollision(Layers.Platform, Layers.Player, false);
                }
                break;
            case JumpState.Falling:
                if (rigidbody.velocity.y == 0)
                {
                    state = JumpState.NotJumping;
                }
                break;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            // I want to fall through the floor
            Physics2D.IgnoreLayerCollision(Layers.Platform, Layers.Player, true);
        } else if (   Input.GetKeyUp(KeyCode.S) 
                   && state != JumpState.Rising)
        {
            Physics2D.IgnoreLayerCollision(Layers.Platform, Layers.Player, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (state == JumpState.Falling)
        {
            if (collision.collider.CompareTag("Platform"))
            {
                PlatformBehaviour platform = collision.collider.GetComponent<PlatformBehaviour>();
                platform.JumpOnPlatform();
            }
        }
        
    }
}
