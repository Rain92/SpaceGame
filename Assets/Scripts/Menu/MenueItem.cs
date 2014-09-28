using UnityEngine;
using System.Collections;

public class MenueItem : MonoBehaviour
{
    public int MenuId = 1;

    static int activemenuid = 0;

    GameObject g;
    void Start()
    {
        g = GameObject.Find("menutext" + MenuId.ToString());
        g.renderer.enabled = false;
    }
    void LateUpdate()
    {
        if (MenuId != activemenuid)
        {
            g.renderer.enabled = false;
            return;
        }
        g.transform.position = transform.position + new Vector3(-6.25f, 6.25f, 0f);
    }

    void OnMouseEnter()
    {
        if (MenuId == activemenuid)
            return;
        activemenuid = MenuId;
        g.renderer.enabled = true;
    }

    void OnMouseDown()
    {
        switch (MenuId)
        {
            case 1:
                Application.LoadLevel("Level 1");
                break;
            case 2:
                Application.Quit();
                break;
            case 3:
                Application.LoadLevel("Level 1");
                break;
            default:
                break;
        }
    }
}