using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateData : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Sprite sprite;
    public Collider2D[] colliders;

    public StateData (float speed, float jumpForce, Sprite sprite, Collider2D[] colliders)
    {
        this.speed = speed;
        this.jumpForce = jumpForce;
        this.sprite = sprite;
        this.colliders = colliders;
    }
}
