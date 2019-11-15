using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform pos;
    public int turnSpeed;

    void Update()
    {
        if (Input.GetKey("a"))
        {
            transform.RotateAround(pos.position, Vector3.forward, turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey("d"))
        {
            transform.RotateAround(pos.position, Vector3.forward, -turnSpeed * Time.deltaTime);
        }
    }
}
