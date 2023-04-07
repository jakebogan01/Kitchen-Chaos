using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObject;

    public KitchenObjectSO GetKitchenObjectSO() {
        return kitchenObject;
    }
}
