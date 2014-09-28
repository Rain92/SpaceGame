using UnityEngine;
using System.Collections;

public class RocketCollider : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(123);
        //if (col.gameObject.name == "Earth")
        //{
            this.gameObject.SetActive(false);
            GameObject.Find("deadnotice").SetActive(true);
        //}
    }
    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        Debug.Log(123);
    }

    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        Debug.Log(123);
    }
}
