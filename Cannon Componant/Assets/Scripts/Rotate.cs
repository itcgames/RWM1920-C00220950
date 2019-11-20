using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform transform;
    public float turnSpeed;
    public int InitialAngle;

    private float angle;

    void Start()
    {
        angle = InitialAngle;
    }

    void Update()
    {
        if (Input.GetKey("a"))
        {
            angle += turnSpeed;
            //transform.RotateAround(pos.position, Vector3.forward, turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey("d"))
        {
            angle -= turnSpeed;
            //transform.RotateAround(pos.position, Vector3.forward, -turnSpeed * Time.deltaTime);
        }

        transform.localEulerAngles = new Vector3(0, 0, angle);
    }
}
