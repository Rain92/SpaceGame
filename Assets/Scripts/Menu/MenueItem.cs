using UnityEngine;
using System.Collections;

public class MenueItem : MonoBehaviour
{
    public int MenuId = 1;

    static int activemenuid = 0;

    GameObject g;
    void Start()
    {
        g = GameObject.Find("menutext");
        g.renderer.enabled = false;
    }
    void LateUpdate()
    {
        if (MenuId != activemenuid)
            return;
        g.transform.position = transform.position + new Vector3(-7.7f, 7.6f, 0f);
    }

    void OnMouseEnter()
    {
        activemenuid = MenuId;
        g.renderer.enabled = true;
    }

    void OnMouseExit()
    {
        //g.renderer.enabled = false;
        //active = true;
    }
}