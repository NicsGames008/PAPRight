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


    //800 - 0
    //0 - 233
    //-800 - 466
    //-1600 - 699
    
    public void OpenRegister()
    {
        background.transform.LeanMoveLocal(new Vector3(1600, 0, 0), 0.89f).setEaseInBack().setIgnoreTimeScale(true);
    }

    public void BackLogin()
    {
        cam.transform.LeanMoveLocal(new Vector3(0, 0, 0), 0.89f).setEaseInBack().setIgnoreTimeScale(true);
    }

    public void BackMapSelect()
    {
        cam.transform.LeanMoveLocal(new Vector3(233, 0, 0), 0.89f).setEaseInBack().setIgnoreTimeScale(true);
    }

    public void BackCharacterSelect()
    {
        cam.transform.LeanMoveLocal(new Vector3(466, 0, 0), 0.89f).setEaseInBack().setIgnoreTimeScale(true);
    }

    public void OpenCharacterCreat()
    {
        cam.transform.LeanMoveLocal(new Vector3(699, 0, 0), 0.89f).setEaseInBack().setIgnoreTimeScale(true);
    }


    
}
