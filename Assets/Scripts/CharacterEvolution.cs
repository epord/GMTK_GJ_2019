using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState {
    BABY = 0,
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

    public CharacterState currentState;

    private Dictionary<CharacterState, StateData> stateMap = new Dictionary<CharacterState, StateData>();

    void Start()
    {
        stateMap.Add(CharacterState.BABY, new StateData(babySpeed, babyJumpForce));
        stateMap.Add(CharacterState.ADULT, new StateData(adultSpeed, adultJumpForce));
        stateMap.Add(CharacterState.OLD, new StateData(oldSpeed, oldJumpForce));
        stateMap.Add(CharacterState.DEAD, new StateData(0, 0));

        EvolveState(CharacterState.BABY);
    }

    public void Evolve ()
    {
        if (currentState == CharacterState.DEAD)
        {
            return; // No next state
        }

        switch (currentState) {
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
        currentState = nextState;
        Debug.Log(nextState);
        Debug.Log(stateMap[nextState].jumpForce);
        controller.SetJumpForce(stateMap[nextState].jumpForce);
        playerMovement.SetSpeed(stateMap[nextState].speed);
    }
}
