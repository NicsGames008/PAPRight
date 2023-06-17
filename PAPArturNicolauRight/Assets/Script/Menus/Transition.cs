using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField]
    private GameObject background;
    [SerializeField]
    private GameObject cam;

    private void Start()
    {
        if (string.IsNullOrEmpty(ClassUser.idPub.ToString()) || ClassUser.idPub == 0)
        {
            cam.transform.Rotate(-90, 0, 0);
        }
    }

    public void OpenRegister()
    {
        background.transform.LeanMoveLocal(new Vector3(1600, 0, 0), 0.89f).setEaseInBack().setIgnoreTimeScale(true);
    }

    public void BackLogin()
    {
        background.transform.LeanMoveLocal(new Vector3(800, 0, 0), 0.89f).setEaseInBack().setIgnoreTimeScale(true);
    }

    public void BackMapSelect()
    {
        background.transform.LeanMoveLocal(new Vector3(0, 0, 0), 0.89f).setEaseInBack().setIgnoreTimeScale(true);
    }

    public void BackCharacterSelect()
    {
        background.transform.LeanMoveLocal(new Vector3(-800, 0, 0), 0.89f).setEaseInBack().setIgnoreTimeScale(true);
    }

    public void OpenCharacterCreat()
    {
        background.transform.LeanMoveLocal(new Vector3(-1600, 0, 0), 0.89f).setEaseInBack().setIgnoreTimeScale(true);
    }


    
}
