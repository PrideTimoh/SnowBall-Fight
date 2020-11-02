using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour {

    public float ballSpeed;
    Rigidbody2D myRigidbody;

   

    public GameObject snowballEffect;
	

	void Start () 
	{
        SetInit();
	}
	
	void Update () 
	{
        MoveSnowball();
	}

    void MoveSnowball()
    {
        myRigidbody.velocity = new Vector2(ballSpeed * transform.localScale.x, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.CompareTag("Player 1"))
        {
            FindObjectOfType<GameManager>().HurtP1();
        }

        if (collision.CompareTag("Player 2"))
        {
            FindObjectOfType<GameManager>().HurtP2();
        }

        Instantiate(snowballEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        //Destroy(snowballEffect, 2f);
    }

    void SetInit()
	{
        myRigidbody = GetComponent<Rigidbody2D>();
        
	}
}
