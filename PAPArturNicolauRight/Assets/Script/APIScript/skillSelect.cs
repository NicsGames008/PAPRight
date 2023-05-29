using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class skillSelect : MonoBehaviour
{
    //Guarda o dominio da API
    string url = APIDomain.Domain("skillSelect.php");

    //Lista que guarda todos os valores da API
    public string[] skillData;

    [SerializeField]
    GameObject skillInfoContainer, skillInfoTemplate;

    public void ExecutSelect()
    {

        foreach (Transform child in skillInfoContainer.transform)
        {
            Destroy(child.gameObject);
        }

        StartCoroutine(GetFromURL());

    }

    #region API
    #region GetFromURL
    // Lê todas as informações da API
    IEnumerator GetFromURL()
    {
        // Cria um formulário com o ID do usuário
        WWWForm form = new WWWForm();
        form.AddField("userId", ClassSkill.UserIdPub);

        // Faz uma requisição POST para a URL especificada
        using (UnityWebRequest skill = UnityWebRequest.Post(url, form))
        {
            // Envia a requisição e aguarda a resposta
            yield return skill.SendWebRequest();

            // Verifica se houve erro na requisição
            if (skill.isNetworkError)
            {
                // Imprime o erro no console
                Debug.Log("Error: " + skill.error);
            }
            else
            {
                // Recebe todos os dados da resposta
                string skillDataString = skill.downloadHandler.text;

                // Separa os dados em uma lista
                skillData = skillDataString.Split(';');

                // Obtém o número de itens na lista
                int index = skillData.Length - 1;

                Debug.Log("Data received successfully.");

                // Itera por todos os itens na lista
                for (int i = 0; i < index; i++)
                {
                    GameObject gobj = (GameObject)Instantiate(skillInfoTemplate);

                    gobj.transform.SetParent(skillInfoContainer.transform);

                    gobj.GetComponent<skillInfo>().skillName.text = GetValueData(skillData[i], "SkillName:");
                    gobj.GetComponent<skillInfo>().skillDesc.text = GetValueData(skillData[i], "Desc:");

                    gobj.GetComponent<skillInfo>().transform.localScale = new Vector3(1.086957f, 1.428571f, 1);
                    gobj.GetComponent<skillInfo>().transform.localPosition = new Vector3(165.1413f, -29.8942f, 7);
                }
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
        //retira o traço de difição adicionada na API
        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }
        //devolve o valor singular
        return value;
    }
    #endregion
    #endregion
}
