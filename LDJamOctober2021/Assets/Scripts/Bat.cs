using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [SerializeField] float amplitude;
    [SerializeField] float frequency;
    [SerializeField] float step;
    Vector2 lastLocation;
    float initial_y;
    float initial_z;
    public bool isMovingRight;

    private void Start()
    {
        lastLocation = transform.position;
        initial_y = transform.position.y;
        initial_z = transform.position.z;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float y = (Mathf.Sin(Time.time) * amplitude) + frequency + initial_y;
        if (isMovingRight)
        {
            transform.position = new Vector3(lastLocation.x + step, y, initial_z);
        } else
        {
            transform.position = new Vector3(lastLocation.x - step, y, initial_z);
        }
        
        lastLocation = transform.position;
    }

    public void FlipDirection()
    {
        isMovingRight = !isMovingRight;
    }


}
