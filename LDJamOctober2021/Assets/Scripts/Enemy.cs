using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private void Start()
    {
        EndEventBroker.EndRoundEvent += OnRoundEnd;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EndEventBroker.GameOver();
        }
    }

    void OnRoundEnd()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EndEventBroker.EndRoundEvent -= OnRoundEnd;
    }
}
