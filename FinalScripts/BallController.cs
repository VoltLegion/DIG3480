using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    private Rigidbody rgbd;
    public float speed;
    public float jumpforce;

    private float timer;
    private int wholetime;

    public Text CollectText;
    public Text endText;
    private float count;


    // Use this for initialization
    void Start () {
        rgbd = GetComponent<Rigidbody>();
        //Initialize count to zero.
        count = 0;

        //Initialze winText to a blank string since we haven't won yet at beginning.
        //  winText.text = "";
        endText.text = "";

        CollectText.text = "";

        //Call our SetCountText function which will update the text with the current value for count.
        SetCountText();

    }

    void FixedUpdate()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(movementHorizontal, movementVertical);
        rgbd.AddForce(movement * speed);

        timer = timer + Time.deltaTime;
        if (timer >= 10)
        {
            endText.text = "You Lose! :(";
            StartCoroutine(ByeAfterDelay(2));

        }

    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {


            if (Input.GetKey(KeyCode.J))
            {
                rgbd.velocity = Vector2.up * jumpforce;


            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            //Add one to the current value of our count variable.
            count = count + 1;

            // add a point to the game
            GameLoader.AddScore(1);

            //Update the currently displayed count by calling the SetCountText function.
            SetCountText();
        }
    }

    //This function updates the text displaying the number of objects we've collected and displays our victory message if we've collected all of them.
    void SetCountText()
    {
        //Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
        //  countText.text = "Count: " + count.ToString();

        //Check if we've collected all 12 pickups. If we have...
        if (count == 1)
        {
            //... then set the text property of our winText object to "You win!"
            //  winText.text = "You win!";
            endText.text = "You win!";
            StartCoroutine(ByeAfterDelay(2));



        }
    }

    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        GameLoader.gameOn = false;
    }
}
