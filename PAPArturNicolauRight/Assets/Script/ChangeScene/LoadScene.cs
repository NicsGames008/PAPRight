using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Services.Authentication;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Variável que indica se o usuário é um administrador
    public static bool isAdmin = false;

    // Variáveis para armazenar o código e nome
    public static string code;
    public static string name;

    // Método para carregar a próxima cena como administrador
    public void LoadNextSceneAsAdmin(TMP_Text text)
    {
        // Define que o usuário é um administrador
        isAdmin = true;

        // Carrega a cena 1
        SceneManager.LoadScene(1);

        // Obtém o nome do texto fornecido e o armazena na variável "name"
        name = text.text;
    }

    // Método para carregar a próxima cena como jogador
    public void LoadNextSceneAsPlayer(TMP_InputField inputCode)
    {
        // Verifica se o código não está vazio ou nulo
        if (!string.IsNullOrEmpty(inputCode.text))
        {
            // Define que o usuário não é um administrador
            isAdmin = false;

            // Armazena o código fornecido na variável "code"
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

    // Método para carregar a página principal
    public void LoadMainPage()
    {
        // Carrega a cena 0
        SceneManager.LoadScene(0);
    }

    // Método estático para carregar a cena de erro
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
