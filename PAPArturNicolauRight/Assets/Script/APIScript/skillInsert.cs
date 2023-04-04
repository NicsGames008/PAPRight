using System;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class skillInsert : MonoBehaviour
{
     //Guarda o local da API
    string url = APIDomain.Domain("skillInsert.php");

    public string[] skillData;

    //Recebe os inputs do user
    public TMP_InputField inputNameSkill, inputMinLevel, inputDesc, inputDamage, inputMinHealth, inputMinStr, inputMinDex, inputMinConst, inputMinInt, inputMinMana, inputCost, inputEffect, inputEffectValue;

    //////////////////////////////////////////////////////
    //temp vars
    private string animation = "animação";
    //////////////////////////////////////////////////////

    //saber se é magia 
    private int isMagic;
    public GameObject magic;
    public ToggleGroup toggleGroup;

    //Chama a class
    ClassSkill skill = new ClassSkill();

    //Backgrounds
    public GameObject skillBackground;

    //Erro
    public GameObject ErrorMsg;


    public ScrollRect myScrollRect;

    public void AddSkill()
    {

        //vares de validação
        bool valName = false, valMinLevel = false, valDamage = false, valMinHealth = false, valMinStr = false, valMinDex = false, valMinConst = false, valMinInt = false, valMinMana = false, valDesc = false, valCost = false, valEffect = false, valEffectValue = false;

        #region Validações
        #region Name
        //Chama o metedo q esta respondavel por validar as var string
        if (ValidateString(inputNameSkill.text))
        {
            //se tudo esta em ordem continua
            valName = true;
        }
        //Senão da erro
        else
            print("nome NAO passou");
        #endregion

        #region MinLevel
        //Chama o metedo q esta respondavel por validar as var int
        if (ValidateInt(inputMinLevel.text))
        {
            //se tudo esta em ordem continua
            valMinLevel = true;
        }
        //Senão da erro
        else
            print("minLevel NAO passou");
        #endregion

        #region Dano
        //Chama o metedo q esta respondavel por validar as var int
        if (ValidateInt(inputDamage.text))
        {
            //se tudo esta em ordem continua
            valDamage = true;
        }
        //Senão da erro
        else
            print("Dano NAO passou");
        #endregion

        #region Stats

        #region MinHealth
        //Chama o metedo q esta respondavel por validar as var int
        if (ValidateInt(inputMinHealth.text))
        {
            //se tudo esta em ordem continua
            valMinHealth = true;
        }
        //Senão da erro
        else
            print("MinHealth NAO passou");
        #endregion

        #region MinStreght
        //Chama o metedo q esta respondavel por validar as var int
        if (ValidateInt(inputMinStr.text))
        {
            //se tudo esta em ordem continua
            valMinStr = true;
        }
        //Senão da erro
        else
            print("MinStr NAO passou");
        #endregion

        #region MinDex
        //Chama o metedo q esta respondavel por validar as var int
        if (ValidateInt(inputMinDex.text))
        {
            //se tudo esta em ordem continua
            valMinDex = true;
        }
        //Senão da erro
        else
            print("MinDex NAO passou");
        #endregion

        #region MinConst
        //Chama o metedo q esta respondavel por validar as var int
        if (ValidateInt(inputMinConst.text))
        {
            //se tudo esta em ordem continua
            valMinConst = true;
        }
        //Senão da erro
        else
            print("MinConst NAO passou");
        #endregion

        #region MinInt
        //Chama o metedo q esta respondavel por validar as var int
        if (ValidateInt(inputMinInt.text))
        {
            //se tudo esta em ordem continua
            valMinInt = true;
        }
        //Senão da erro
        else
            print("MinInt NAO passou");
        #endregion

        #region MinMana
        //Chama o metedo q esta respondavel por validar as var int
        if (ValidateInt(inputMinMana.text))
        {
            //se tudo esta em ordem continua
            valMinMana = true;
        }
        //Senão da erro
        else
            print("MinMana NAO passou");
        #endregion


        #endregion

        #region isMagicValues
        if (isMagic == 1)
        {
            #region Custo
            //Chama o metedo q esta respondavel por validar as var int
            if (ValidateInt(inputCost.text))
            {
                //se tudo esta em ordem continua
                valCost = true;
            }
            //Senão da erro
            else
                print("Cost NAO passou");
            #endregion

            #region Effect
            //Chama o metedo q esta respondavel por validar as var int
            if (ValidateString(inputEffect.text))
            {
                //se tudo esta em ordem continua
                valEffect = true;
            }
            //Senão da erro
            else
                print("Effect NAO passou");
            #endregion

            #region EffectValue
            //Chama o metedo q esta respondavel por validar as var int
            if (ValidateInt(inputEffectValue.text))
            {
                //se tudo esta em ordem continua
                valEffectValue = true;
            }
            //Senão da erro
            else
                print("EffectValue NAO passou");
            #endregion
        }
        else if (isMagic == 0)
        {
            valCost = true;
            valEffect = true;
            valEffectValue = true;

            inputCost.text = "0";
            inputEffect.text = "vazio";
            inputEffectValue.text = "0";
        }

        #endregion

        #region Discrição
        //Chama o metedo q esta respondavel por validar as var int
        if (ValidateString(inputDesc.text))
        {
            //se tudo esta em ordem continua
            valDesc = true;
        }
        //Senão da erro
        else
            print("descrição NAO passou");
        #endregion

        #endregion

        if (valName && valMinLevel && valDamage && valMinHealth && valMinStr && valMinDex && valMinConst && valMinInt && valMinMana && valDesc && valCost && valEffect && valEffectValue)
        {
            #region Classes
            skill.NameSkillPub = inputNameSkill.text;
            skill.MinLevelPub = int.Parse(inputMinLevel.text);
            skill.DescPub = inputDesc.text;
            skill.DamagePub = int.Parse(inputDamage.text);
            skill.MinHealthPub = int.Parse(inputMinHealth.text);
            skill.MinStrPub = int.Parse(inputMinStr.text);
            skill.MinDexPub = int.Parse(inputMinDex.text);
            skill.MinConstPub = int.Parse(inputMinConst.text);
            skill.MinIntPub = int.Parse(inputMinInt.text);
            skill.MinManaPub = int.Parse(inputMinMana.text);
            skill.AnimationPub = animation;
            skill.IsMagicPub = isMagic;
            skill.CostPub = int.Parse(inputCost.text);
            skill.EffectPub = inputEffect.text;
            skill.EffectValuePub = int.Parse(inputEffectValue.text);
            #endregion

            StartCoroutine(AddSkillDB());

            ErrorMsg.SetActive(false);
        }
        else
        {
            print("NAO passou");
            ErrorMsg.SetActive(true);
        }
    }

    #region Adiciona a BD
    //Adiciona as infos a BD
    public IEnumerator AddSkillDB()
    {

        // Variável para armazenar os dados a serem enviados na requisição POST
        WWWForm form = new WWWForm();

        //Adicionar os dados a serem enviados na requisição POST
        form.AddField("userId", ClassSkill.UserIdPub);
        form.AddField("nameSkill", skill.NameSkillPub);
        form.AddField("minLevel", skill.MinLevelPub);
        form.AddField("desc", skill.DescPub);
        form.AddField("damage", skill.DamagePub);
        form.AddField("minHealth", skill.MinLevelPub);
        form.AddField("minStr", skill.MinStrPub);
        form.AddField("minDex", skill.MinDexPub);
        form.AddField("minConst", skill.MinConstPub);
        form.AddField("minInt", skill.MinIntPub);
        form.AddField("minMana", skill.MinManaPub);
        form.AddField("animation", skill.AnimationPub);
        form.AddField("isMagic", skill.IsMagicPub);
        form.AddField("cost", skill.CostPub);
        form.AddField("effect", skill.EffectPub);
        form.AddField("effectValue", skill.EffectValuePub);

        //Iniciando o uso de UnityWebRequest para fazer uma requisição POST para a URL especificada
        using (WWW www = new WWW(url, form))
        {
            //Enviando a requisição e aguardando a resposta
            yield return www;

            //Verificando se houve erro na rede ou no HTTP
            if (!www.isDone)
            {
                //Imprimindo o erro no console
                Debug.Log(www.error);
            }
            else
            {
                //Imprimindo uma mensagem de sucesso no console
                Debug.Log("Data sent successfully.");

                ResetInputs();


                skillBackground.SetActive(false);

            }
        }

    }
    #endregion

    #region Reset inputs
    /// <summary>
    /// Poe os valores ao normal
    /// </summary>
    void ResetInputs()
    {
        inputNameSkill.text = null;
        inputMinLevel.text = null;
        inputDesc.text = null;
        inputDamage.text = null;
        inputMinHealth.text = null;
        inputMinStr.text = null;
        inputMinDex.text = null;
        inputMinConst.text = null;
        inputMinInt.text = null;
        inputMinMana.text = null;
        inputCost.text = null;
        inputEffect.text = null;
        inputEffectValue.text = null;
        myScrollRect.verticalNormalizedPosition = 1f;
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

    #region RadioButton
    //Sabe se o radiobutton foi selecionado e informa de tal
    void LateUpdate()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();

        if (toggle.name == "isNotMagic")
        {
            isMagic = 0;
            magic.SetActive(false);
        }
        else if (toggle.name == "isMagic")
        {
            isMagic = 1;
            magic.SetActive(true);
        }
    }
    #endregion
}

