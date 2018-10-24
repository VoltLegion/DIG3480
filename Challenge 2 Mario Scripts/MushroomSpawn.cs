using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawn : MonoBehaviour
{
    private Rigidbody2D rdb2D;
    private void Start()
    {
        rdb2D = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);


        }
    }
}
