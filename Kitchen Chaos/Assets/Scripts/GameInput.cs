using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private void Awake() {
        /*****
        * enables new input system
        * refrences PlayerInputActions input actions in Unity
        *****/
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    /*****
    * Access for Player script
    * returns normailized Vector2
    *****/
    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>(); //playerInputActions.Player.Move.ReadValue<Vector2>() returns a Vector2 (0,0) *

        /*****
        * normalized makes the player move diagenally at the same speed as WASD directions
        * commented out because I have it enabled in the input actions Processors
        *****/
        //inputVector = inputVector.normalized;

        return inputVector;
    }
}
