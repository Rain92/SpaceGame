using UnityEngine;
using System.Collections;
using System;

public class Rocket : MonoBehaviour
{

    GameObject rocket;
    Attributes attributes;
    public double Thrust = 10;

    Animator thrustanimation;
    GameObject thrustfireobject;

    GameObject explosionobject;

    // Use this for initialization
    void Start()
    {
        rocket = GameObject.Find("Rocket");
        attributes = rocket.GetComponent<Attributes>();
        thrustfireobject = GameObject.Find("ThrustFire");
        thrustanimation = thrustfireobject.GetComponent<Animator>();
        thrustanimation.enabled = true;

        explosionobject = GameObject.Find("Explosion");
    }

    // Update is called once per frame
    void Update()
    {

        rocket.transform.Rotate(new Vector3(0, 0, 1), Input.GetAxis("Horizontal") * -5);


        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!thrustfireobject.renderer.enabled)
                thrustfireobject.renderer.enabled = true;

            attributes.movementdirection.x += Math.Cos(transform.rotation.eulerAngles.z / 360 * 2 * Math.PI) * Thrust;
            attributes.movementdirection.y += Math.Sin(transform.rotation.eulerAngles.z / 360 * 2 * Math.PI) * Thrust;
        }
        else
        {
            if (thrustfireobject.renderer.enabled)
                thrustfireobject.renderer.enabled = false;
        }

        //if (explosionframe != 1)
        //{
        //    if (explosionframe == 5)
        //        rocket.renderer.enabled = false;
        //    explosionframe++;
        //}

    }

    int explosionframe = 0;
    public void Explode()
    {
        explosionframe = 1;
        rocket.renderer.enabled = false;
        attributes.IgnoreGravity = true;
        attributes.movementdirection = new Vector3d();
        explosionobject.GetComponent<SpriteRenderer>().enabled = true;
        explosionobject.GetComponent<Animator>().enabled = true;
    }
}
