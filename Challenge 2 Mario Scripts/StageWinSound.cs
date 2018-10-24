using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageWinSound : MonoBehaviour {

    public AudioSource StageWin;


    void Awake()
    {
        StageWin = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            GetComponent<AudioSource>().Play();
        }

    }
}
