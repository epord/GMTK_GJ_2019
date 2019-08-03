using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateData : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public StateData (float speed, float jumpForce)
    {
        this.speed = speed;
        this.jumpForce = jumpForce;
    }
}
