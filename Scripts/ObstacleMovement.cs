﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {
    public float rotation;
	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        
    }
}