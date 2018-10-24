using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour {

    public AudioSource CoinPickUp;


    void Awake()
    {
        CoinPickUp = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            GetComponent<AudioSource>().Play();
        }
        
    }
}
