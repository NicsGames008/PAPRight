using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrasitionSky : MonoBehaviour
{
    public GameObject background;

    public void OpenRegister()
    {
        background.transform.LeanMoveLocal(new Vector3(400, 0, 0), 0.89f).setEaseInBack().setIgnoreTimeScale(true);
    }
    public void OpenLogin()
    {
        background.transform.LeanMoveLocal(new Vector3(-400, 0, 0), 0.89f).setEaseInBack().setIgnoreTimeScale(true);
    }
}
