using UnityEngine;

public class SelectServer : MonoBehaviour
{
    // Refer�ncia ao objeto do servidor
    public GameObject server;

    // Refer�ncia ao objeto de erro
    public GameObject error;

    // M�todo chamado para selecionar uma sess�o
    public void SelectSession()
    {
        // Verifica se o nome do personagem n�o est� vazio ou nulo
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

    // M�todo chamado para fechar uma sess�o
    public void CloseSession()
    {
        // Ativa ou desativa o objeto do servidor
        server.SetActive(!server.activeSelf);
    }

}
