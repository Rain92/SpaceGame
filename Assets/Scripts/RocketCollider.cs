﻿using UnityEngine;
using System.Collections;

public class RocketCollider : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Earth" || col.gameObject.name == "Moon")
        {
            //this.gameObject.SetActive(false);
            this.gameObject.GetComponent<Rocket>().Explode();
            GameObject.Find("notice").GetComponent<TextMesh>().text = "You are dead!";
        }
        if (col.gameObject.name == "Spacegate")
        {
            //this.gameObject.SetActive(false);
            this.gameObject.GetComponent<Rocket>().EnterGate();
            TextMesh t = GameObject.Find("notice").GetComponent<TextMesh>();
            t.color = Color.green;
            t.text = "You win!";
        }
    }
}
