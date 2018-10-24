using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaController : MonoBehaviour {

    private Animator anim;
    public float speed;
    public LayerMask isPlayer;
    public LayerMask isGround;
    public Transform wallHitBox;
    public Transform playerHitBox;
    private bool wallHit;
    private bool playerHit;
    public float wallHitHeight;
    public float wallHitWidth;
    public float playerHitHeight;
    public float playerHitWidth;



	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    private void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        wallHit = Physics2D.OverlapBox(wallHitBox.position, new Vector2(wallHitWidth, wallHitHeight), 0, isGround);
        wallHit = Physics2D.OverlapBox(wallHitBox.position, new Vector2(wallHitWidth, wallHitHeight), 0, isPlayer);
        if (wallHit == true)
        {
            speed = speed * -1;
        }
        Debug.Log(wallHit);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && playerHit==true)
        {
            
            Debug.Log("I loved living");
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(wallHitBox.position, new Vector3(wallHitWidth, wallHitHeight, 1));
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(playerHitBox.position, new Vector3(playerHitWidth, playerHitHeight, 1));
    }

}
