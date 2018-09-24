using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text penaltyText;

    private Rigidbody rb;
    private int count;
    private int penalty;
    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        penalty = 0;
        SetCountText ();
        winText.text = "";
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        PlayerColorChange();

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText ();
        }
        if (other.gameObject.CompareTag("Red Pick Up"))
        {
            other.gameObject.SetActive(false);
            penalty = penalty + 1;
            SetCountText();
        }
    }
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        penaltyText.text = "Penalty: " + penalty.ToString();
        score = count - penalty;
        if (count == 12)
        {
            Vector3 Position = transform.position;
            Position.x = 58;
            transform.position = Position;
            
        }
        if (count == 24)
        {
            winText.text = "You Finished with a score of: " + score.ToString();
            rb.constraints = RigidbodyConstraints.FreezePosition;
            
        }
            

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall Penalty"))
        {
            penalty++;
            SetCountText();
        }
    }
    void PlayerColorChange ()
    {
        Color Random;
        MeshRenderer Render;

        Random = new Color(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        Render = GetComponent<MeshRenderer>();
        Render.material.color = Random;
    }
}