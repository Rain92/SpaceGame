using UnityEngine;
using System.Collections;
using System;

public class Rocket : MonoBehaviour
{

    GameObject rocket;
    Attributes attributes;
    public double Thrust = 10;

    Animator anim;
    GameObject thrustfire;

    // Use this for initialization
    void Start()
    {
        rocket = GameObject.Find("Rocket");
        attributes = rocket.GetComponent<Attributes>();
        thrustfire = GameObject.Find("ThrustFire");
        anim = thrustfire.GetComponent<Animator>();
        anim.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        rocket.transform.Rotate(new Vector3(0, 0, 1), Input.GetAxis("Horizontal") * -5);


        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!thrustfire.renderer.enabled)
                thrustfire.renderer.enabled = true;

            attributes.movementdirection.x += Math.Cos(transform.rotation.eulerAngles.z / 360 * 2 * Math.PI) * Thrust;
            attributes.movementdirection.y += Math.Sin(transform.rotation.eulerAngles.z / 360 * 2 * Math.PI) * Thrust;
        }
        else
        {
            if (thrustfire.renderer.enabled)
                thrustfire.renderer.enabled = false;
        }

    }
}
