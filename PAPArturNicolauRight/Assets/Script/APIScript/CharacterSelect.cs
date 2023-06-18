using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterSelect : MonoBehaviour
{
    //Guarda o dominio da API
    string url = APIDomain.Domain("characterSelect.php");

    //Lista que guarda todos os valores da API
    public string[] characterData;

    [SerializeField]
    GameObject characterInfoContainer, characterInfoTemplate;

    [Header("APAGAR")]
    public Sprite temp;

    public List<ClassCharacter> characterList = new List<ClassCharacter>();

    private ClassCharacter characterClass = new ClassCharacter();

    public void ExecutSelect()
    {

        foreach (Transform child in characterInfoContainer.transform)
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
        using (UnityWebRequest character = UnityWebRequest.Post(url, form))
        {
            // Envia a requisição e aguarda a resposta
            yield return character.SendWebRequest();

            // Verifica se houve erro na requisição
            if (character.isNetworkError)
            {
                // Imprime o erro no console
                Debug.Log("Error: " + character.error);
            }
            else
            {
                // Recebe todos os dados da resposta
                string characterDataString = character.downloadHandler.text;

                // Separa os dados em uma lista
                characterData = characterDataString.Split(';');

                // Obtém o número de itens na lista
                int index = characterData.Length - 1;

                Debug.Log("Data received successfully.");

                // Itera por todos os itens na lista
                for (int i = 0; i < index; i++)
                {
                    GameObject gobj = (GameObject)Instantiate(characterInfoTemplate);

                    gobj.transform.SetParent(characterInfoContainer.transform);

                    gobj.GetComponent<characterInfo>().transform.localPosition = new Vector3(0f, 0f, 0f);

                    gobj.GetComponent<characterInfo>().characterAvatar.sprite = temp;
                    gobj.GetComponent<characterInfo>().characterName.text = GetValueData(characterData[i], "NameCharacter:");


                    gobj.GetComponent<characterInfo>().transform.localScale = new Vector3(1f, 1f, 1f);

                    #region Class
                    characterClass.CharacterIdPub = int.Parse(GetValueData(characterData[i], "ID:"));
                    characterClass.NameCharacterPub = GetValueData(characterData[i], "NameCharacter:");
                    characterClass.AvatarPub = GetValueData(characterData[i], "AvatarCharacter:");
                    characterClass.BackgroundPub = GetValueData(characterData[i], "Backgroud:");
                    characterClass.RacePub = GetValueData(characterData[i], "Race:");
                    characterClass.HealthPub = int.Parse(GetValueData(characterData[i], "Health:"));
                    characterClass.StrPub = int.Parse(GetValueData(characterData[i], "Strength:"));
                    characterClass.DexPub = int.Parse(GetValueData(characterData[i], "Dexterity:"));
                    characterClass.ConstPub = int.Parse(GetValueData(characterData[i], "Constitution:"));
                    characterClass.IntPub = int.Parse(GetValueData(characterData[i], "Intelligence:"));
                    characterClass.ManaPub = int.Parse(GetValueData(characterData[i], "Mana:")); 
                    #endregion

                    characterList.Add(characterClass);
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
}
