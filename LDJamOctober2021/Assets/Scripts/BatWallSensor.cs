using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatWallSensor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BatWall"))
        {
            GetComponentInParent<Bat>().FlipDirection();
        }
    }
}
