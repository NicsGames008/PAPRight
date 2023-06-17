using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public static bool isAdmin = false;
    public static string code;

    public void LoadNextSceneAsAdmin()
    {
        isAdmin = true;
        SceneManager.LoadScene(1);
    }

    public void LoadNextSceneAsPlayer(TMP_InputField inputCode)
    {
        if (!string.IsNullOrEmpty(inputCode.text))
        {
            isAdmin = false;
            code = inputCode.text;
            SceneManager.LoadScene(1); 
        }
        else
        {
            Debug.Log("aaaaaaaaa");
        }
    }
}
