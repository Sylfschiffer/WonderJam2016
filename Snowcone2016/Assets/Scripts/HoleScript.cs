﻿using UnityEngine;
using System.Collections;

public class HoleScript : MonoBehaviour {

	private bool isFilled;
    public Sprite filled;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!isFilled) {
            if (other.gameObject.tag == "block")
            {
                isFilled = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = filled;
                gameObject.transform.localScale = new Vector3(0.07170061f, 0.07170061f, 0);
                Destroy(other.gameObject);
            }

            if(other.gameObject.tag == "metalBlock")
            {
                isFilled = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = filled;
                gameObject.transform.localScale = new Vector3(0.1364248f, 0.1364248f, 0);
                Destroy(other.gameObject);
            }

            if (other.tag == "character")
            {
                GameObject.Find("Bob 1").GetComponent<Animator>().SetTrigger("Dying");
                GameObject.Find("Bob 1").GetComponent<Animator>().SetBool("Dead", true);
            }
            //Destroy (other.gameObject);
        }
	}
}
