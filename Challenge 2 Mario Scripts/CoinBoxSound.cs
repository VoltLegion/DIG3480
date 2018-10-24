using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBoxSound : MonoBehaviour
{

    public AudioSource CoinPickUp;

    // Use this for initialization
    void Start()
    {

    }
    private void Awake()
    {
        CoinPickUp = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
           CoinPickUp.Play();
        }
    }
}