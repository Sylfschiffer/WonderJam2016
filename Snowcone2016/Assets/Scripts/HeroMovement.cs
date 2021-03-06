﻿using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {

    Rigidbody2D heroRidigBody2d;
    public float speed = 4;
    private Vector3 ActualVecteur;
    private string lastTriggerName;
    private Animator heroAnimator;
    public bool Ending;


	public Sprite backSprite;
	private Sprite frontSprite;
	// Use this for initialization
	void Start () {
        heroAnimator = gameObject.GetComponent<Animator>();
        heroRidigBody2d = gameObject.GetComponent<Rigidbody2D>();
        ActualVecteur = gameObject.transform.localScale;
        lastTriggerName = "LookLeft";
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            heroAnimator.SetBool("Moving", false);
            heroRidigBody2d.velocity = new Vector2(0, 0);
        }

        if (!heroAnimator.GetBool("Dead"))
        {

            #region Diagonnales
            /*if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetAxisRaw("Vertical") == 1)
            {
                heroRidigBody2d.velocity = new Vector2(-1 * speed * Time.deltaTime, 0);
                translateMainCameraOnAxis(new Vector3(-0.5f * speed * Time.deltaTime, -0.25f * speed * Time.deltaTime));
            }

            else if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetAxisRaw("Vertical") == -1)
            {
                heroRidigBody2d.velocity = new Vector2(0, -1 * speed * Time.deltaTime);
               // translateMainCameraOnAxis(new Vector3(0, -1 * speed * Time.deltaTime));
            }
            else if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == -1)
            {
                heroRidigBody2d.velocity = new Vector2(1 * speed * Time.deltaTime, 0);
                translateMainCameraOnAxis(new Vector3(0.5f * speed * Time.deltaTime, 0.25f * speed * Time.deltaTime));
            }

            else if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == 1)
            {
                heroRidigBody2d.velocity = new Vector2(0, 1 * speed * Time.deltaTime);
                //translateMainCameraOnAxis(new Vector3(0, 1 * speed * Time.deltaTime));
            }*/
            #endregion

        
            
            if (Input.GetAxisRaw("Vertical") == 1)
            {
                //right

                if (lastTriggerName != "LookRight")
                {
                    heroAnimator.ResetTrigger(lastTriggerName);
                }
                //En haut a droite
                GameObject.Find("Bob 1").GetComponent<Animator>().SetBool("IsFront", false);


                heroAnimator.SetTrigger("LookRight");
                lastTriggerName = "LookRight";
                heroAnimator.SetBool("Moving", true);
                gameObject.transform.localScale = new Vector3((ActualVecteur.x), ActualVecteur.y, ActualVecteur.z);
                heroRidigBody2d.velocity = new Vector2(1 * speed * Time.deltaTime, 0.5f * speed * Time.deltaTime);
                translateMainCameraOnAxis(gameObject.transform.position.x, gameObject.transform.position.y);
            }

            else if (Input.GetAxisRaw("Vertical") == -1)
            {
                if (lastTriggerName != "LookLeft")
                {
                    heroAnimator.ResetTrigger(lastTriggerName);
                }
                //left
                //En bas a gauche
                GameObject.Find("Bob 1").GetComponent<Animator>().SetBool("IsFront", true);


                heroAnimator.SetTrigger("LookLeft");
                lastTriggerName = "LookLeft";
                heroAnimator.SetBool("Moving", true);
                gameObject.transform.localScale = new Vector3(ActualVecteur.x, ActualVecteur.y, ActualVecteur.z);
                heroRidigBody2d.velocity = new Vector2(-1 * speed * Time.deltaTime, -0.5f * speed * Time.deltaTime);
                translateMainCameraOnAxis(gameObject.transform.position.x, gameObject.transform.position.y);
            }

            else if (Input.GetAxisRaw("Horizontal") == -1)
            {
                if (lastTriggerName != "LookLeft")
                {
                    heroAnimator.ResetTrigger(lastTriggerName);
                }

                //left

                //En haut a gauche
                GameObject.Find("Bob 1").GetComponent<Animator>().SetBool("IsFront", false);

                heroAnimator.SetTrigger("LookLeft");
                lastTriggerName = "LookLeft";
                heroAnimator.SetBool("Moving", true);
                gameObject.transform.localScale = new Vector3(ActualVecteur.x*-1, ActualVecteur.y, ActualVecteur.z);
                heroRidigBody2d.velocity = new Vector2(-1 * speed * Time.deltaTime, 0.5f * speed * Time.deltaTime);
                translateMainCameraOnAxis(gameObject.transform.position.x, gameObject.transform.position.y);

            }

            else if (Input.GetAxisRaw("Horizontal") == 1)
            {
                if (lastTriggerName != "LookRight")
                {
                    heroAnimator.ResetTrigger(lastTriggerName);
                }
                //right
                //En bas a droite
                GameObject.Find("Bob 1").GetComponent<Animator>().SetBool("IsFront", true);
                Debug.Log("EN HAUT DROITE");


                heroAnimator.SetTrigger("LookRight");
                lastTriggerName = "LookRight";
                heroAnimator.SetBool("Moving", true);
                gameObject.transform.localScale = new Vector3((ActualVecteur.x) * -1, ActualVecteur.y, ActualVecteur.z);
                heroRidigBody2d.velocity = new Vector2(1 * speed * Time.deltaTime, -0.5f * speed * Time.deltaTime);
                translateMainCameraOnAxis(gameObject.transform.position.x, gameObject.transform.position.y);
            }

        }
        else
        {
            heroRidigBody2d.velocity = new Vector2(0,0);
        }
    }
    void translateMainCameraOnAxis(float x,float y)
    {
        if (!Ending)
        {
            Camera.main.transform.position = new Vector3(x, y, -10);
        }
    }

    //void translateMainCameraOnAxis(Vector3 positionVecteur)
    //{
    //    Camera.main.transform.position += positionVecteur*Time.deltaTime;
    //}
}
