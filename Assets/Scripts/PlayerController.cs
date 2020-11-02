using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D myRigidbody;
    Animator myAnimator;
    public AudioSource throwSound;

    public GameObject snowBall;
    public Transform throwPoint;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode throwSnow;

    public float moveSpeed;
    public float jumpForce;

    public bool isGrounded;



	void Start () 
	{
        SetInit();

	}
	
	void Update () 
	{
        CheckForInput();
	}

    void CheckForInput()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (Input.GetKey(left))
        {
            myRigidbody.velocity = new Vector2(-moveSpeed, myRigidbody.velocity.y);

        }
        else if (Input.GetKey(right))
        {
            myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
        }
        else
        {
            myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
        }
        if (Input.GetKeyDown(jump) && isGrounded)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);

        }

        myAnimator.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
        myAnimator.SetBool("Grounded", isGrounded);


        if(Input.GetKeyDown(throwSnow))
        {
            throwSound.Play();
            GameObject snowballClone = (GameObject)Instantiate(snowBall, throwPoint.position, throwPoint.rotation) as GameObject;
            if (transform.localScale == new Vector3(1.5f, 1.5f, 1.5f))
            {
                snowballClone.transform.localScale = transform.localScale - new Vector3(.5f, .5f, .5f);
            }
            else if (transform.localScale == new Vector3(-1.5f, 1.5f, 1.5f))
            {
                snowballClone.transform.localScale = transform.localScale - new Vector3(-0.5f, .5f, .5f);
            }


            //snowballClone.transform.localScale = transform.localScale - new Vector3(.5f, .5f, .5f);
            myAnimator.SetTrigger("Throw");
        }

        if(myRigidbody.velocity.x < 0f)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
        else if(myRigidbody.velocity.x > 0f)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }

	void SetInit()
	{
        myAnimator = GetComponent<Animator>();
        
        myRigidbody = GetComponent<Rigidbody2D>();
	}
}
