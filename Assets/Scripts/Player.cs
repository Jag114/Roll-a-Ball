using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Item> itemInventory;
    private MovementController movementController;

    void Start()
    {
       movementController = GetComponent<MovementController>(); 
    }

    void Update()
    {
        movementController.GetInput();
    }

    public void AddToInventory(Item newItem)
    {
        itemInventory.Add(newItem);
    }
}
