using UnityEngine;
using System.Collections;

public class RocketCollider : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Earth")
        {
            Debug.Log(123);
            this.gameObject.SetActive(false);
            GameObject.Find("deadnotice").GetComponent<TextMesh>().text = "You are dead!";
        }
    }
}
