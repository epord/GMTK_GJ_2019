using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    //public Animator animator;

    float movingDirection = 0f;
    bool jump = false;

	private float movingSpeed;

    public void onLanding()
    {
        //animator.SetBool("jumping", false);
    }

    // Update is called once per frame
    void Update()
    {
        movingDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            //animator.SetBool("jumping", true);
        }

        //float lookingDirection = Input.GetAxisRaw("Vertical");
        //animator.SetFloat("lookingY", lookingDirection);

        //animator.SetFloat("speed", Mathf.Abs(movingDirection));
    }

    public void SetSpeed(float speed)
    {
        movingSpeed = speed;
    }

    private void FixedUpdate()
    {
        controller.Move(movingDirection * movingSpeed * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
