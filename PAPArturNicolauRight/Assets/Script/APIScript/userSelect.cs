using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class userSelect : MonoBehaviour
{
    //Guarda o dominio da API
    string url = APIDomain.Domain("userSelect.php");
    //Lista que guarda todos os valores da API
    public string[] userData;
    //Caixa de email e passaword que o utilizador pos
    public TMP_InputField insertPassword, insertEmail;
    public GameObject background, errorUser, errorPassword;

    //Guarda o id do user q fez Login para user dps
    [HideInInspector]
    public int idUser;

    [SerializeField]
    GameObject cam;

    private void Start()
    {
        StartCoroutine(GetFromURL());
    }

    #region Login
    //Metedo chamado quando o utilizador carrega no butão
    public void Login()
    {
        //le mais uma vez a data na API
        StartCoroutine(GetFromURL());

        //tira 1 valor ao tamanhao do arrai para bater certo
        int index = userData.Length - 1;

        //passa por todo o tamanho do array para...
        for (int i = 0; i < index; i++)
        {
            //ver se ha algum email com o input que o utilizador pos
            if (GetValueData(userData[i], "email:") == insertEmail.text)
            {
                //e ve se a passe esta certa
                if (GetValueData(userData[i], "password:") == insertPassword.text)
                {
                    //passa para a proxima fasse e acaba com a procura
                    print("passou");
                    errorUser.SetActive(false);
                    errorPassword.SetActive(false);

                    //Guardar o Id do User aq
                    idUser = int.Parse(GetValueData(userData[i], "Id:"));
                    //Guarda o valor do idUser na class para uso futuro
                    ClassSkill.UserIdPub = idUser;
                    ClassCharacter.UserIdPub = idUser;
                    Debug.Log(idUser);
                    Animation();
                    return;
                }
                //se a passe n estiver certa acaba com a procura e manda um mnsg de erro
                else
                {
                    errorPassword.SetActive(true);
                    print("pass n esta certa");
                    return;
                }
            }
        }
        //Se nada foi encontrado manda uma mensaguem de erro
        print("não ha conta");
        errorUser.SetActive(true);
    }
    #endregion

    #region API
    #region GetFromURL
    //Le toda a data na API
    IEnumerator GetFromURL()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Envia a requisição
            yield return webRequest.SendWebRequest();

            // Verifica se houve erro na requisição
            if (webRequest.isNetworkError)
            {
                Debug.Log("Error: " + webRequest.error);
            }
            else
            {
                //recebe todos os dados
                string userDataString = webRequest.downloadHandler.text;

                //Guarda na lista
                userData = userDataString.Split(';');
            }

        }
    }
    #endregion

    #region GetValueData
    //Pega um valor especifico da API
    string GetValueData(string data, string index)
    {
        //Le o index pedido quando é chamado o metedo e vai ler ate onde etsa o index pedido
        string value = data.Substring(data.IndexOf(index) + index.Length);
        //retira o trço de difição adicionada na API
        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }
        //devolve o valor singular
        return value;
    }
    #endregion
    #endregion




    //Muda de janela
    public void Animation()
    {
        Animator anim = cam.GetComponent<Animator>();


        anim.enabled = !anim.enabled;

    }

}
