using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class userSelect : MonoBehaviour
{
    //Guarda o dominio da API
    string urlUser = APIDomain.Domain("userSelect.php");
    string urlCharacter = APIDomain.Domain("characterSelect.php");
    string urlSkill = APIDomain.Domain("skillSelect.php");



    //Lista que guarda todos os valores da API
    public string[] userData;
    public string[] characterData;
    public string[] skillData;



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
        StartCoroutine(GetFromURLUser());
    }

    #region Login
    //Metedo chamado quando o utilizador carrega no butão
    public void Login()
    {
        //le mais uma vez a data na API
        StartCoroutine(GetFromURLUser());

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
                    ClassUser.idUser = idUser;
                    Debug.Log(idUser);
                    Animation();

                    StartCoroutine("GetFromURLCharcter");
                    StartCoroutine("GetFromURLSkill");

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
    #region GetFromURLUser
    //Le toda a data na API
    IEnumerator GetFromURLUser()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(urlUser))
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

    #region GetFromURLCharacter
    // Lê todas as informações da API
    IEnumerator GetFromURLCharcter()
    {
        // Cria um formulário com o ID do usuário
        WWWForm form = new WWWForm();
        form.AddField("userId", ClassUser.idUser);

        // Faz uma requisição POST para a URL especificada
        using (UnityWebRequest Web = UnityWebRequest.Post(urlCharacter, form))
        {
            // Envia a requisição e aguarda a resposta
            yield return Web.SendWebRequest();

            // Verifica se houve erro na requisição
            if (Web.isNetworkError)
            {
                // Imprime o erro no console
                Debug.Log("Error: " + Web.error);
            }
            else
            {

                // Recebe todos os dados da resposta
                string characterDataString = Web.downloadHandler.text;

                if (!String.IsNullOrEmpty(characterDataString))
                {
                    characterDataString = characterDataString.Remove(Web.downloadHandler.text.Length - 1);

                    // Separa os dados em uma lista
                    characterData = characterDataString.Split(";");

                    // Obtém o número de itens na lista
                    int index = characterData.Length - 1;

                    Debug.Log("Data received successfully.");


                    List<ClassCharacter> characterList = new List<ClassCharacter>();

                    foreach (string charData in characterData)
                    {
                        ClassCharacter character = new ClassCharacter();

                        #region Class
                        character.characterId = int.Parse(GetValueData(charData, "ID:"));
                        character.nameCharacter = GetValueData(charData, "NameCharacter:");
                        character.avatarCharacter = GetValueData(charData, "Avatar:");
                        character.backgroundCharacter = GetValueData(charData, "Backgroud:");
                        character.raceCharcter = GetValueData(charData, "Race:");
                        character.healthCharacter = int.Parse(GetValueData(charData, "Health:"));
                        character.strCharacter = int.Parse(GetValueData(charData, "Strength:"));
                        character.dexCharacter = int.Parse(GetValueData(charData, "Dexterity:"));
                        character.constCharacter = int.Parse(GetValueData(charData, "Constitution:"));
                        character.intCharacter = int.Parse(GetValueData(charData, "Intelligence:"));
                        character.manaCharacter = int.Parse(GetValueData(charData, "Mana:"));
                        #endregion

                        characterList.Add(character);
                    }

                    ClassUser.CharactersList = characterList; 
                }
            }
        }
    }
    #endregion

    #region GetFromURLSkill
    // Lê todas as informações da API
    IEnumerator GetFromURLSkill()
    {
        // Cria um formulário com o ID do usuário
        WWWForm form = new WWWForm();
        form.AddField("userId", ClassUser.idUser);

        // Faz uma requisição POST para a URL especificada
        using (UnityWebRequest web = UnityWebRequest.Post(urlSkill, form))
        {
            // Envia a requisição e aguarda a resposta
            yield return web.SendWebRequest();

            // Verifica se houve erro na requisição
            if (web.isNetworkError)
            {
                // Imprime o erro no console
                Debug.Log("Error: " + web.error);
            }
            else
            {

                // Recebe todos os dados da resposta
                string skillDataString = web.downloadHandler.text;

                if (!String.IsNullOrEmpty(skillDataString))
                {
                    skillDataString =  skillDataString.Remove(web.downloadHandler.text.Length - 1);

                    // Separa os dados em uma lista
                    skillData = skillDataString.Split(';');

                    Debug.Log("Data received successfully.");


                    List<ClassSkill> SkillList = new List<ClassSkill>();

                    foreach (string skillData in skillData)
                    {
                        ClassSkill skillClass = new ClassSkill();

                        #region Class
                        skillClass.skillId = int.Parse(GetValueData(skillData, "ID:"));
                        skillClass.nameSkill = GetValueData(skillData, "NameSkill:");
                        skillClass.minLevel = int.Parse(GetValueData(skillData, "MinLevel:"));
                        skillClass.descSkill = GetValueData(skillData, "Description:");
                        skillClass.damageSkill = int.Parse(GetValueData(skillData, "Damage:"));
                        skillClass.isMagicSkill = int.Parse(GetValueData(skillData, "IsMagic:"));
                        skillClass.minHealthSkill = int.Parse(GetValueData(skillData, "MinHealth:"));
                        skillClass.minStrSkill = int.Parse(GetValueData(skillData, "MinStrength:"));
                        skillClass.minDexSkill = int.Parse(GetValueData(skillData, "MinDex:"));
                        skillClass.minConstSkill = int.Parse(GetValueData(skillData, "MinConst:"));
                        skillClass.minIntSkill = int.Parse(GetValueData(skillData, "MinInt:"));
                        skillClass.minManaSkill = int.Parse(GetValueData(skillData, "MinMana:"));

                        if (skillClass.isMagicSkill == 1)
                        {
                            skillClass.costSkill = int.Parse(GetValueData(skillData, "Cost:"));
                            skillClass.effectSkill = GetValueData(skillData, "Effect:");
                            skillClass.effectValueSkill = int.Parse(GetValueData(skillData, "EffectValue:"));
                        }
                        #endregion

                        SkillList.Add(skillClass);
                    }

                    ClassUser.SkillsList = SkillList;
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

    #region Animation
    //Muda de janela
    public void Animation()
    {
        Animator anim = cam.GetComponent<Animator>();


        anim.enabled = !anim.enabled;

    }
    #endregion

}
