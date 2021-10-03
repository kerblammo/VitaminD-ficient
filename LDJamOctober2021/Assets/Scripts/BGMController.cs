using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        EndEventBroker.GameOverEvent += OnGameOver;
    }
    void OnGameOver()
    {
        source.Stop();
    }

    void OnDestroy()
    {
        EndEventBroker.GameOverEvent -= OnGameOver;
    }
}
