using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public GameObject p1Wins;
    public GameObject p2Wins;
    public GameObject menu;

    public bool isMenuOn;

    //public AudioSource gameOverSound;
    public AudioSource hurtSound;

    public GameObject[] p1Sticks;
    public GameObject[] p2Sticks;
        
    public int p1Life;
    public int p2Life;

	void Start () 
	{
		
	}
	
	void Update () 
	{
        CheckForMenu();
        CheckPlayerLIfes();
	}
    void CheckPlayerLIfes()
    {
        if(p1Life <= 0)
        {
           // gameOverSound.Play();
            player1.SetActive(false);
            p2Wins.SetActive(true);
        }
        else if (p2Life <= 0)
        {
           // gameOverSound.Play();
            player2.SetActive(false);
            p1Wins.SetActive(true);
        }
    }
    public void HurtP1()
    {
        p1Life -= 1;
        if(p1Life <= 0)
        {
            p1Life = 0;
        }

        for (int i = 0; i < p1Sticks.Length; i++)
        {
            if (p1Life > i)
            {
                p1Sticks[i].SetActive(true);
            }
            else
            { 
                p1Sticks[i].SetActive(false);
            }
        }
        hurtSound.Play();

    }

    public void HurtP2()
    {
        p2Life -= 1;
        if (p2Life <= 0)
        {
            p2Life = 0;
        }

        for (int i = 0; i < p2Sticks.Length; i++)
        {
            if (p2Life > i)
            {
                p2Sticks[i].SetActive(true);
            }
            else
            {
                p2Sticks[i].SetActive(false);
            }
            
        }
        hurtSound.Play();
    }
	void SetInit()
	{

	}

    void CheckForMenu()
    {
        if (isMenuOn)
        {
            menu.SetActive(true);
        }
        else if (!isMenuOn)
        {
            menu.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuOn = !isMenuOn;
        }
    }
}
