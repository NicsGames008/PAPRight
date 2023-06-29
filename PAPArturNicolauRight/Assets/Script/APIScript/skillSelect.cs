using System;
using System.Collections;
using System.Collections.Generic;
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

    public static List<ClassSkill> skillList = new List<ClassSkill>();

    public void ExecutSelect()
    {
        foreach (Transform child in skillInfoContainer.transform)
        {
            Destroy(child.gameObject);
        }

        if (ClassUser.SkillsList == null || ClassUser.SkillsList.Count == 0)
            return;

        // Itera por todos os itens na lista
        foreach (ClassSkill skill in ClassUser.SkillsList)
        {
            GameObject gobj = (GameObject)Instantiate(skillInfoTemplate);

            gobj.transform.SetParent(skillInfoContainer.transform);

            gobj.GetComponent<skillInfo>().skillName.text = skill.nameSkill;
            gobj.GetComponent<skillInfo>().skillDesc.text = skill.descSkill;

            gobj.GetComponent<skillInfo>().transform.localScale = new Vector3(1.086957f, 1.428571f, 1);
            gobj.GetComponent<skillInfo>().transform.localPosition = new Vector3(165.1413f, -29.8942f, 7);
        }
    }
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
}
