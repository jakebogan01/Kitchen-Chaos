using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    /*****
        * letting this script aware of player gameobject
    *****/
    [SerializeField] private Player player;

    private Animator animtor;

    /*****
        * value based of animator parameter IsWalking
    *****/
    private const string IS_PLAYER_WALKING = "IsWalking";

    private void Awake() {
        animtor = GetComponent<Animator>();
    }

    private void Update() {
        /*****
            * changing the animator parameter value based on players vector movement in Player script
        *****/
        animtor.SetBool(IS_PLAYER_WALKING, player.IsWalking());
    }
}
