using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool move;
    public Vector2 position1;
    public Vector2 position2;
    public float speed;
    bool movingTowardsPosition1 = false;
    // Start is called before the first frame update
    void Start()
    {
        if(move)
        {
            Debug.Log(position1);
            Debug.Log(position2);
            transform.position = position1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            if (movingTowardsPosition1)
            {
                Debug.Log("test1");
                if (MoveTo(position1))
                {
                    movingTowardsPosition1 = false;
                }
            }
            else
            {
                Debug.Log("test1");
                if (MoveTo(position2))
                {
                    movingTowardsPosition1 = true;
                }
            }
        }
    }

    bool MoveTo(Vector2 position)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, speed);

        if (transform.position == new Vector3(position.x, position.y, transform.position.z))
        {
            return true;
        }
        return false;
    }
}
