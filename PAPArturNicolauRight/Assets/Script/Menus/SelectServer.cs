using UnityEngine;

public class SelectServer : MonoBehaviour
{
    // Referência ao objeto do servidor
    public GameObject server;

    // Referência ao objeto de erro
    public GameObject error;

    // Método chamado para selecionar uma sessão
    public void SelectSession()
    {
        // Verifica se o nome do personagem não está vazio ou nulo
        if (!string.IsNullOrEmpty(EnterServer.character.nameCharacter))
        {
            // Ativa ou desativa o objeto do servidor
            server.SetActive(!server.activeSelf);

            // Desativa o objeto de erro
            error.SetActive(false);
        }
        else
        {
            // Ativa o objeto de erro
            error.SetActive(true);
        }
    }

    // Método chamado para fechar uma sessão
    public void CloseSession()
    {
        // Ativa ou desativa o objeto do servidor
        server.SetActive(!server.activeSelf);
    }

}
