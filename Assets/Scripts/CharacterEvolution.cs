using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState {
    UNBORN = 0,
    BABY,
    ADULT,
    OLD,
    DEAD
};

public class CharacterEvolution : MonoBehaviour
{
    public CharacterController2D controller;
    public PlayerMovement playerMovement;

    public float babySpeed = 40;
    public float adultSpeed = 60;
    public float oldSpeed = 20;

    public float babyJumpForce = 0;
    public float adultJumpForce = 550;
    public float oldJumpForce = 400;

    public Sprite unbornSprite;
    public Sprite babySprite;
    public Sprite adultSprite;
    public Sprite oldSprite;
    public Sprite deadSprite;

    public Collider2D[] unbornColliders;
    public Collider2D[] babyColliders;
    public Collider2D[] adultColliders;
    public Collider2D[] oldColliders;
    public Collider2D[] deadColliders;

    public CharacterState currentState;

    private Dictionary<CharacterState, StateData> stateMap = new Dictionary<CharacterState, StateData>();

    void Start()
    {
        stateMap.Add(CharacterState.UNBORN, new StateData(0, 0, unbornSprite, unbornColliders));
        stateMap.Add(CharacterState.BABY, new StateData(babySpeed, babyJumpForce, babySprite, babyColliders));
        stateMap.Add(CharacterState.ADULT, new StateData(adultSpeed, adultJumpForce, adultSprite, adultColliders));
        stateMap.Add(CharacterState.OLD, new StateData(oldSpeed, oldJumpForce, oldSprite, oldColliders));
        stateMap.Add(CharacterState.DEAD, new StateData(0, 0, deadSprite, deadColliders));

        EvolveState(CharacterState.UNBORN);
    }

    public void Evolve ()
    {
        if (currentState == CharacterState.DEAD)
        {
            return; // No next state
        }

        switch (currentState) {
            case CharacterState.UNBORN:
                EvolveState(CharacterState.BABY);
                break;
            case CharacterState.BABY:
                EvolveState(CharacterState.ADULT);
                break;
            case CharacterState.ADULT:
                EvolveState(CharacterState.OLD);
                break;
            case CharacterState.OLD:
                EvolveState(CharacterState.DEAD);
                break;

        }
    }

    private void EvolveState(CharacterState nextState) {
        StateData currentStateData = stateMap[currentState];
        StateData nextStateData = stateMap[nextState];

        // Set new jumpForce
        controller.SetJumpForce(nextStateData.jumpForce);

        // Set new speed
        playerMovement.SetSpeed(nextStateData.speed);

        // Set new Sprite
        GetComponent<SpriteRenderer>().sprite = nextStateData.sprite;

        // Disable actual colliders
        foreach (Collider2D collider in currentStateData.colliders)
        {
            collider.enabled = false;
        }

        // Enable new colliders
        foreach (Collider2D collider in nextStateData.colliders)
        {
            collider.enabled = true;
        }

        // Change state
        currentState = nextState;
    }
}
