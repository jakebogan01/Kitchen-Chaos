using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed = 7f;
    [SerializeField] private GameInput gameInput; //references GameInput script *
    private bool isPlayerWalking;

    private void Update() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        /*****
        * START COLLISION DETECTION
        *****/
        float moveDistance = playerMovementSpeed * Time.deltaTime;
        float playerRadius = 0.7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove) {
            //cannot move towards moveDir *
            //move only on the x axis *
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove) {
                //can only move on the x axis *
                moveDir = moveDirX;
            }
            else {
                //cannot move on the x axis *
                //move only on the z axis *
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove) {
                    //can only move on the z axis *
                    moveDir = moveDirZ;
                }
                else {
                    //cannot move in any direction *
                }
            }
        }
        /*****
        * END COLLISION DETECTION
        *****/

        if (canMove) {
            transform.position += moveDir * moveDistance;
        }

        /*****
        * ternary operator
        * sets isPlayerWalking true or false
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
    * Access for PlayerAnimator script
    * returns true or false
    *****/
    public bool IsWalking() {
        return isPlayerWalking;
    }
}
