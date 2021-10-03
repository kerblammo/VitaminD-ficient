using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoundEnd : MonoBehaviour
{
    bool hasTouchedFinishLine = false;
    AudioSource sounds;
    SpriteRenderer sprite;
    [SerializeField] AudioClip death;
    [SerializeField] DestroyAfterStart particles;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish")
            && !hasTouchedFinishLine)
        {
            hasTouchedFinishLine = true;
            EndEventBroker.EndRound();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        EndEventBroker.EndRoundEvent += OnRoundEnd;
        EndEventBroker.GameOverEvent += OnGameOver;
    }

    void OnRoundEnd()
    {
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnGameOver()
    {
        Instantiate(particles, transform.position, Quaternion.identity);
        sounds.PlayOneShot(death);
        sprite.enabled = false;
        Destroy(gameObject, 2f);
        
    }

    private void OnDestroy()
    {
        EndEventBroker.EndRoundEvent -= OnRoundEnd;
        EndEventBroker.GameOverEvent -= OnGameOver;

        // I'm not sure why, but the z has to be really quite far back to be visible on the camera
        
    }

}
