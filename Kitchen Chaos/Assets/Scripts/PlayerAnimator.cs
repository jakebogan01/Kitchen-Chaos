using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Player player; //references Player script *
    private Animator animtor;
    private const string IS_PLAYER_WALKING = "IsWalking"; //value based of animator parameter *

    private void Awake() {
        animtor = GetComponent<Animator>();
    }

    private void Update() {
        animtor.SetBool(IS_PLAYER_WALKING, player.IsWalking()); //changes the animator parameter value based on players movement in Player script *
    }
}
