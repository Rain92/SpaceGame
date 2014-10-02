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
    GameObject entergateobject;

    // Use this for initialization
    void Start()
    {
        rocket = GameObject.Find("Rocket");
        attributes = rocket.GetComponent<Attributes>();
        thrustfireobject = GameObject.Find("ThrustFire");
        thrustanimation = thrustfireobject.GetComponent<Animator>();
        thrustanimation.enabled = true;

        explosionobject = GameObject.Find("Explosion");
        entergateobject = GameObject.Find("EnterGate");

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

        if (explosionframe != 0)
        {
            if (explosionframe == 27)
                this.gameObject.SetActive(false);
            explosionframe++;
        }

        if (egateframe != 0)
        {
            if (egateframe == 44)
            {
                entergateobject.GetComponent<SpriteRenderer>().enabled = false;
                this.gameObject.SetActive(false);
            }
            egateframe++;
        }
    }

    int explosionframe = 0;
    public void Explode()
    {
        explosionframe = 1;
        rocket.renderer.enabled = false;
        attributes.IgnoreGravity = true;
        attributes.movementdirection = new Vector3d();
        this.GetComponent<PolygonCollider2D>().enabled = false;
        explosionobject.GetComponent<SpriteRenderer>().enabled = true;
        explosionobject.GetComponent<Animator>().enabled = true;
    }

    int egateframe = 0;
    public void EnterGate()
    {
        egateframe = 1;
        rocket.renderer.enabled = false;
        attributes.IgnoreGravity = true;
        attributes.movementdirection = new Vector3d();
        this.GetComponent<PolygonCollider2D>().enabled = false;
        entergateobject.GetComponent<SpriteRenderer>().enabled = true;
        entergateobject.GetComponent<Animator>().enabled = true;
    }
}
