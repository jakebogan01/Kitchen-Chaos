using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    private PlayerInputActions playerInputActions;

    private void Awake() {
        /*****
        * enables new input system
        * refrences PlayerInputActions input actions in Unity
        *****/
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        //fires Interact_performed function when player hits the interactive button (E) *
        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        //fires the event listener for subscribers who are listeners of the event *
        OnInteractAction?.Invoke(this, EventArgs.Empty); //?.Invoke is the ternary operator for null *
    }

    /*****
    * Access for Player script
    * returns normailized Vector2
    *****/
    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>(); //playerInputActions.Player.Move.ReadValue<Vector2>() returns a Vector2 (0,0) *

        /*****
        * normalized makes the player move diagenally at the same speed as WASD directions
        *****/
        inputVector = inputVector.normalized;

        return inputVector;
    }
}
