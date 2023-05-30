using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSelectServer : MonoBehaviour
{
    public GameObject server;

    public void ClickSkill()
    {
        server.SetActive(!server.activeSelf);
    }
}
