using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectServer : MonoBehaviour
{
    public GameObject server;

    public void SelectSession()
    {
        server.SetActive(!server.activeSelf);
    }
}
