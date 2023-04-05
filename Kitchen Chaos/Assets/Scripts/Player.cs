using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed = 7f;

    private bool isPlayerWalking;

    private void Update() {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W)) {
            inputVector.y += 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector.y -= 1;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector.x -= 1;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector.x += 1;
        }

        /*****
         * normalized evens the movement speed of character at an angle
        *****/
        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * playerMovementSpeed * Time.deltaTime;

        /*****
         * ternary operator setting isPlayerWalking true or false
         * comparing if moveDir vector is not (0,0,0)
        *****/
        isPlayerWalking = moveDir != Vector3.zero;

        /*****
         * allows characters to rotate direction smoothly
         * Slerp spherical interpolations
         * Slerp(a, b, t) t returns the difference between point a (starting point vector) and b (target point vector)
        *****/
        float playerRotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * playerRotateSpeed);
    }

    /*****
        * public function for PlayerAnimator script
        * returns true or false for isPlayerWalking
    *****/
    public bool IsWalking() {
        return isPlayerWalking;
    }
}
