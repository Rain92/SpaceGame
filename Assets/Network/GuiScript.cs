using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuiScript : MonoBehaviour {

    
    public GameObject StartPanel;
    public GameObject ServerPanel;
    public GameObject ClientPanel;
    public GameObject ServerEntryPanel;


    public void OpenServerPanel()
    {
        StartPanel.SetActive(false);
        ServerPanel.SetActive(true);
    }
    public void OpenClientPanel()
    {
        StartPanel.SetActive(false);
        ClientPanel.SetActive(true);
    }
    public void OpenStartPanel()
    {
        ServerPanel.SetActive(false);
        ClientPanel.SetActive(false);
        StartPanel.SetActive(true);
    }

    int ecount = 0;
    public void AddPanel(HostData d)
    {
        GameObject e = (GameObject)GameObject.Instantiate(ServerEntryPanel);
        Debug.Log(e.GetComponentsInChildren<Text>().Length);
        e.SetActive(true);
        e.GetComponentsInChildren<Text>()[0].text = d.ip[0] + " | " + d.gameName + " | " + d.connectedPlayers + "/" + d.playerLimit;
        e.GetComponent<RectTransform>().parent = ClientPanel.transform;
        //e.GetComponent<RectTransform>().anchoredPosition.Set(0, 180 - 40 * ecount++);
        e.GetComponent<RectTransform>().localPosition = new Vector3(0, 180 - 40 * ecount++);
        e.GetComponentInChildren<Button>().onClick.AddListener(() => { GetComponent<NetworkScript>().ConnectToServer(d); });
            

    }
}
