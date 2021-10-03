using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    bool hasBeenJumpedOn = false;
    Animator animator;
    PlatformSounds sounds;

    private void Start()
    {
        sounds = FindObjectOfType<PlatformSounds>();
        EndEventBroker.EndRoundEvent += OnRoundEnd;
        animator = GetComponent<Animator>();
    }

    public void JumpOnPlatform()
    {
        if (!hasBeenJumpedOn)
        {
            hasBeenJumpedOn = true;
            animator.SetTrigger("Cracked");
            sounds.PlayCrackle();
        }
        
    }

    void OnRoundEnd()
    {
        if (hasBeenJumpedOn)
        { 
            sounds.PlayDestruction();
            animator.SetTrigger("Destroyed");
            Destroy(gameObject, 2f);
        }
    }

    private void OnDestroy()
    {
        EndEventBroker.EndRoundEvent -= OnRoundEnd;
    }
}
