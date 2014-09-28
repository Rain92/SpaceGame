using UnityEngine;
using System.Collections;

public class RocketCollider : MonoBehaviour {


    void OnCollisionEnter(Collision col)
    {
        Debug.Log(123);
        //if (col.gameObject.name == "Earth")
        //{
            this.gameObject.SetActive(false);
            GameObject.Find("deadnotice").SetActive(true);
        //}
    }
    void OnCollisionStay(Collision collisionInfo)
    {
        Debug.Log(123);
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        Debug.Log(123);
    }
}
