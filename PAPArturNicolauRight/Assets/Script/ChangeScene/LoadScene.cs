using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Services.Authentication;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Vari�vel que indica se o usu�rio � um administrador
    public static bool isAdmin = false;

    // Vari�veis para armazenar o c�digo e nome
    public static string code;
    public static string name;

    // M�todo para carregar a pr�xima cena como administrador
    public void LoadNextSceneAsAdmin(TMP_Text text)
    {
        // Define que o usu�rio � um administrador
        isAdmin = true;

        // Carrega a cena 1
        SceneManager.LoadScene(1);

        // Obt�m o nome do texto fornecido e o armazena na vari�vel "name"
        name = text.text;
    }

    // M�todo para carregar a pr�xima cena como jogador
    public void LoadNextSceneAsPlayer(TMP_InputField inputCode)
    {
        // Verifica se o c�digo n�o est� vazio ou nulo
        if (!string.IsNullOrEmpty(inputCode.text))
        {
            // Define que o usu�rio n�o � um administrador
            isAdmin = false;

            // Armazena o c�digo fornecido na vari�vel "code"
            code = inputCode.text;

            // Carrega a cena 1
            SceneManager.LoadScene(1);
        }
        else
        {
            // Imprime uma mensagem de erro no console
            Debug.Log("aaaaaaaaa");
        }
    }

    // M�todo para carregar a p�gina principal
    public void LoadMainPage()
    {
        // Carrega a cena 0
        SceneManager.LoadScene(0);
    }

    // M�todo est�tico para carregar a cena de erro
    public static void LoadError()
    {
        // Carrega a cena 2
        SceneManager.LoadScene(2);
    }

    public void LoadMainPageNonError()
    {
        SceneManager.LoadScene(0);
        NetworkManager.Singleton.Shutdown();
        AuthenticationService.Instance.SignOut();
    }
}
