using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoAnCameraController : MonoBehaviour {

    public Transform player;
    public Vector3 offset;
    public float smoothSpeed;

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }

}
