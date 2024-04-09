using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public List<string> inventory;

    private void Start()
    {
        inventory = new List<string>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("coin"))
        {
           
            string itemType = collision.gameObject.GetComponent<CollectableScript>().itemType;
            print("We Have collected a:" + " " + itemType);
            inventory.Add(itemType);
            print("Inventory Length:" + " " + inventory.Count);
            Destroy(collision.gameObject);
        } 
    }
}
