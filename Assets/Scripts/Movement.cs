using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{

    public int speedfactor = 1;
    public int granularity = 1;

    private const double distancescale = 1e7;

    private const double G = 6.67384e-11;

    public class MovableOblect
    {
        public Component gameobject;
        public Attributes attributes;
        public MovableOblect(Component c, Attributes a)
        {
            gameobject = c;
            attributes = a;
        }

    }
    List<MovableOblect> objects;


    // Use this for initialization
    void Start()
    {
        Component[] comps = gameObject.GetComponentsInChildren(typeof(Transform));


        objects = new List<MovableOblect>();


        for (int i = 0; i < comps.Length - 1; i++)
        {
            Attributes a = comps[i + 1].GetComponent<Attributes>();
            if (a == null)
                continue;
            MovableOblect mo = new MovableOblect(comps[i + 1], comps[i + 1].GetComponent<Attributes>());
            mo.attributes.position = new Vector3d(comps[i + 1].transform.position.x, comps[i + 1].transform.position.y, comps[i + 1].transform.position.z);
            mo.attributes.movementdirection = new Vector3d(mo.attributes.StartspeedDirection.x * mo.attributes.Startspeed, mo.attributes.StartspeedDirection.y * mo.attributes.Startspeed, mo.attributes.StartspeedDirection.z * mo.attributes.Startspeed);

            objects.Add(mo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3d imp= new Vector3d();        
        //for (int i = 0; i < objects.Length; i++)
        //    imp+= objects[i].attributes.movementdirection*objects[i].attributes.mass;
        //Debug.Log("Gesamtimpuls: " + imp.z);

        for (int sp = 0; sp < speedfactor; sp++)
        {
            for (int a = 0; a < objects.Count - 1; a++)
                for (int b = a + 1; b < objects.Count; b++)
                    ApplyGForce(objects[a], objects[b], granularity);

            for (int i = 0; i < objects.Count; i++)
                objects[i].attributes.position += objects[i].attributes.movementdirection / distancescale * granularity;

        }

        for (int i = 0; i < objects.Count; i++)
            objects[i].gameobject.transform.position = objects[i].attributes.position.ToVector3();
    }

    private void ApplyGForce(MovableOblect a, MovableOblect b, int time = 1)
    {
        double distancesqr = (a.attributes.position - b.attributes.position).LengthSquared() * distancescale * distancescale;
        Vector3d dir = (b.attributes.position - a.attributes.position).Normalize();

        int sgn = 1;

        if ((a.attributes.Antigravity && !b.attributes.Antigravity) || (!a.attributes.Antigravity && b.attributes.Antigravity))
            sgn = -1;

        if (!b.attributes.SmallObject && !a.attributes.IgnoreGravity)
            a.attributes.movementdirection += dir * ((G * b.attributes.Mass / distancesqr) * time) * sgn;
        if (!a.attributes.SmallObject && !b.attributes.IgnoreGravity)
            b.attributes.movementdirection -= dir * ((G * a.attributes.Mass / distancesqr) * time) * sgn;
    }
}
