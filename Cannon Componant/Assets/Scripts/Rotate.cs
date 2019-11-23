using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool autoRotate;
    public float autoAngle1;
    public float autoAngle2;
    public bool startMovingClockwise;

    public Transform transform;
    public float turnSpeed;
    public int InitialAngle;

    private float angle;
    private bool automaticMovingClockwise;

    void Start()
    {
        angle = InitialAngle;
        automaticMovingClockwise = startMovingClockwise;
    }

    void Update()
    {

        if (autoRotate)
        {
            handleAutomatic();
        }
        else
        {
            handleManuel();
        }
    }

    public void handleAutomatic()
    {
        if(automaticMovingClockwise)
        {
            changeAngle(-turnSpeed);
        }
        else
        {
            changeAngle(turnSpeed);
        }

        float distanceToAngle = angle - autoAngle1;
        if (distanceToAngle < 0) { distanceToAngle *= -1; }
        if (distanceToAngle < turnSpeed) { automaticMovingClockwise = !automaticMovingClockwise; }

        distanceToAngle = angle - autoAngle2;
        if (distanceToAngle < 0) { distanceToAngle *= -1; }
        if (distanceToAngle < turnSpeed * 1) { automaticMovingClockwise = !automaticMovingClockwise; }

        updateRotation();
    }

    public void handleManuel()
    {
        if (Input.GetKey("a"))
        {
            changeAngle(turnSpeed);
        }

        if (Input.GetKey("d"))
        {
            changeAngle(-turnSpeed);
        }

        updateRotation();
    }

    public void changeAngle(float val)
    {
        angle += val;
        
        if (angle >= 360)
        {
            angle -= 360;
        }
        if (angle < 0)
        {
            angle += 360;
        }
    }

    public void updateRotation()
    {
        transform.localEulerAngles = new Vector3(0, 0, angle);
    }
}
