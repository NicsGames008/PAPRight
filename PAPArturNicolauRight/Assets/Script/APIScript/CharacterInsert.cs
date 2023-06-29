using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TMPro;
using Unity.Entities.UniversalDelegates;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CharacterInsert : MonoBehaviour
{
    //Guarda o local da API
    string urlCharacterInsert = APIDomain.Domain("characterInsert.php");
    string urlCharacterSkillSelect = APIDomain.Domain("characterSkillSelect.php");
    string urlCharacterSkillInsert = APIDomain.Domain("characterSkillInsert.php");

    //Recebe os inputs do user
    public TMP_InputField inputNameCharacter, inputBackground, inputHealth, inputStr, inputDex, inputConst, inputInt, inputMana;
    public TMP_Dropdown inputRace;

    //Guarda os dados na class
    private ClassCharacter character = new ClassCharacter();
    private ClassSkillCharacter skillCharacter = new ClassSkillCharacter();

    //recebe o cam para poder mover o ecrã
    public GameObject cam;

    // Referência ao objeto do grupo de ToggleButtons
    public GameObject toggleGroupObj;

    public ScrollRect myScrollRect;

    private List<string> nameSkill = new List<string>();

    public List<string> characterSkillData = new List<string>();

    /// <summary>
    /// Metedo que é chamado quando o utilizador carrega no butão
    /// </summary>
    public void AddCharacter()
    {
        //vares de validação
        bool valName = false, valBackground = false, valRace = false, valHealth = false, valStr = false, valDex = false, valConst = false, valInt = false, valMana = false;

        SkillIsActive();

        #region Validações
        #region Name
        //Chama o metedo q esta respondavel por validar as var string
        if (ValidateString(inputNameCharacter.text))
        {
            //se tudo esta em ordem continua
            valName = true;
        }
        //Senão da erro
        else
            print("nome NAO passou");
        #endregion

        #region Background
        //Chama o metedo q esta respondavel por validar as var string
        if (ValidateString(inputBackground.text))
        {
            //se tudo esta em ordem continua
            valBackground = true;
        }
        //Senão da erro
        else
            print("background NAO passou");
        #endregion 

        #region Race
        //Chama o metedo q esta respondavel por validar as var string
        if (inputRace.value != 0)
        {
            //se tudo esta em ordem continua
            valRace = true;
        }
        //Senão da erro
        else
            print("race NAO passou");
        #endregion 

        #region Health
        //Chama o metedo q esta respondavel por validar as var string
        if (ValidateInt(inputHealth.text))
        {
            //se tudo esta em ordem continua
            valHealth = true;
        }
        //Senão da erro
        else
            print("health NAO passou");
        #endregion 

        #region Str
        //Chama o metedo q esta respondavel por validar as var string
        if (ValidateInt(inputStr.text))
        {
            //se tudo esta em ordem continua
            valStr = true;
        }
        //Senão da erro
        else
            print("str NAO passou");
        #endregion 

        #region Dex
        //Chama o metedo q esta respondavel por validar as var string
        if (ValidateInt(inputDex.text))
        {
            //se tudo esta em ordem continua
            valDex = true;
        }
        //Senão da erro
        else
            print("dex NAO passou");
        #endregion 

        #region Const
        //Chama o metedo q esta respondavel por validar as var string
        if (ValidateInt(inputConst.text))
        {
            //se tudo esta em ordem continua
            valConst = true;
        }
        //Senão da erro
        else
            print("const NAO passou");
        #endregion 

        #region Int
        //Chama o metedo q esta respondavel por validar as var string
        if (ValidateInt(inputInt.text))
        {
            //se tudo esta em ordem continua
            valInt = true;
        }
        //Senão da erro
        else
            print("int NAO passou");
        #endregion 

        #region Mana
        //Chama o metedo q esta respondavel por validar as var string
        if (ValidateInt(inputMana.text))
        {
            //se tudo esta em ordem continua
            valMana = true;
        }
        //Senão da erro
        else
            print("mana NAO passou");
        #endregion
        #endregion

        if (valName && valBackground && valRace && valHealth && valStr && valDex && valConst && valInt && valMana)
        {
            character = new ClassCharacter();
            skillCharacter = new ClassSkillCharacter();

            #region Classes
            if (ClassUser.CharactersList == null)
                character.intCharacter = 1;
            else            
                character.characterId = ClassUser.CharactersList[ClassUser.CharactersList.Count - 1].characterId + 1;

            skillCharacter.CharacterId =  character.characterId;
            character.nameCharacter = inputNameCharacter.text;
            character.backgroundCharacter = inputBackground.text;
            switch (inputRace.value)
            {
                case 1:
                    character.raceCharcter = "M";
                    break;
                case 2:
                    character.raceCharcter = "G";
                    break;
                case 3:
                    character.raceCharcter = "H";
                    break;
                case 4:
                    character.raceCharcter = "k";
                    break;
            }
            character.healthCharacter = int.Parse(inputHealth.text);
            character.strCharacter = int.Parse(inputStr.text);
            character.dexCharacter = int.Parse(inputDex.text);
            character.constCharacter = int.Parse(inputConst.text);
            character.intCharacter = int.Parse(inputInt.text);
            character.manaCharacter = int.Parse(inputMana.text);
            #endregion

            //metedo de BD
            StartCoroutine(AddCharacterDB());

            //for (int i = 0; i < nameSkill.Count; i++)
            //{
            //    Debug.Log(nameSkill[i]);

            //    foreach (ClassSkill skill in ClassUser.SkillsList)
            //    {
            //        if (skill.nameSkill == nameSkill[i])
            //        {
            //            skillCharacter.skillId = skill.skillId;
            //            StartCoroutine(AddSkillCharacterDB(skill.skillId));

            //            Debug.Log(skillCharacter.skillId);
            //            Debug.Log(skillCharacter.CharacterId);


            //            //ClassUser.SkillsCharacterList.Add(skillCharacter);
            //        }
            //    }

            //}


            ResetValues();
            cam.transform.LeanMoveLocal(new Vector3(466, 0, 0), 0.7f).setEaseInBack().setIgnoreTimeScale(true);
        }
    }


    #region Adiciona Character a BD
    //Adiciona as infos a BD
    public IEnumerator AddCharacterDB()
    {
        // Variável para armazenar os dados a serem enviados na requisição POST
        WWWForm form = new WWWForm();

        //Adicionar os dados a serem enviados na requisição POST
        form.AddField("userId", ClassUser.idUser);
        form.AddField("nameCharacter", character.nameCharacter);
        form.AddField("background", character.backgroundCharacter);
        form.AddField("race", character.raceCharcter);
        form.AddField("health", character.healthCharacter);
        form.AddField("str", character.strCharacter);
        form.AddField("dex", character.dexCharacter);
        form.AddField("const", character.constCharacter);
        form.AddField("int", character.intCharacter);
        form.AddField("mana", character.manaCharacter);

        //Iniciando o uso de UnityWebRequest para fazer uma requisição POST para a URL especificada
        using (WWW www = new WWW(urlCharacterInsert, form))
        {
            //Enviando a requisição e aguardando a resposta
            yield return www;

            //Verificando se houve erro na rede ou no HTTP
            if (!www.isDone)
            {
                //Imprido o erro no console
                Debug.Log(www.error);
            }
            else
            {
                //Imprido uma mensagem de sucesso no console
                Debug.Log("Data sent successfully.");

                if (ClassUser.CharactersList == null)
                {
                    List<ClassCharacter> temChar = new List<ClassCharacter>();
                    temChar.Add(character);

                    ClassUser.CharactersList = temChar;
                }
                else
                    ClassUser.CharactersList.Add(character);
            }
        }

    }
    #endregion

    #region Adicionar Skill_Character a BD
    public IEnumerator AddSkillCharacterDB(int skillId)
    {
        /*Ver op skillId user para n dar erro como o jonny disse*/

        // Variável para armazenar os dados a serem enviados na requisição POST
        WWWForm form = new WWWForm();

        //Adicionar os dados a serem enviados na requisição POST
        form.AddField("idSkill", skillId);
        form.AddField("idCharacter", character.characterId);
        form.AddField("idUser", ClassUser.idUser);

        //Iniciando o uso de UnityWebRequest para fazer uma requisição POST para a URL especificada
        using (WWW www = new WWW(urlCharacterSkillInsert, form))
        {
            //Enviando a requisição e aguardando a resposta
            yield return www;

            //Verificando se houve erro na rede ou no HTTP
            if (!www.isDone)
            {
                //Imprido o erro no console
                Debug.Log(www.error);
            }
            else
            {
                //Imprido uma mensagem de sucesso no console
                Debug.Log("Data sent successfully.");
            }
        }
    }

    #endregion

    #region Validar String
    // Valida se o nome esta certo
    public bool ValidateString(string text)
    {
        //Verifica se exete o limite e é null
        if (String.IsNullOrEmpty(text))
        {
            //Retorna um Erro
            return false;
        }

        //Se estver tudo certo deica passar
        return true;
    }
    #endregion

    #region Reset TextBox
    private void ResetValues()
    {
        inputNameCharacter.text = null;
        inputBackground.text = null;
        inputRace.value = 0;
        inputHealth.text = null;
        inputStr.text = null;
        inputDex.text = null;
        inputConst.text = null;
        inputInt.text = null;
        inputMana.text = null;
        myScrollRect.verticalNormalizedPosition = 1f;
    }
    #endregion

    #region Validar Int
    // Valida se o nome esta certo
    public bool ValidateInt(string text)
    {
        //Verifica se exete o limite e é null
        if (String.IsNullOrEmpty(text) || !Regex.IsMatch(text, @"^\d+$"))
        {
            //Retorna um Erro
            return false;
        }

        //Se estver tudo certo deica passar
        return true;
    }
    #endregion

    #region Skill Is Active
    private void SkillIsActive()
    {

        nameSkill.Clear();

        // Obtém todos os componentes Toggle no grupo de ToggleButtons
        var toggleGroup = toggleGroupObj.GetComponentsInChildren<Toggle>();

        // Obtém todas as informações de habilidade (script "skillInfo") no grupo de ToggleButtons
        skillInfo[] skillInfos = toggleGroupObj.GetComponentsInChildren<skillInfo>();

        // Itera por todos os ToggleButtons no grupo
        for (int i = 0; i < toggleGroup.Length; i++)
        {
            if (toggleGroup[i].isOn)
            {
                // Imprime o nome da habilidade associado ao ToggleButton atual
                //Debug.Log(skillInfos[i].skillName.text);

                nameSkill.Add(skillInfos[i].skillName.text);
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
}
