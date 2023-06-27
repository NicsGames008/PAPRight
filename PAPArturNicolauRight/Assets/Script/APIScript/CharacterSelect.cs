using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities.UniversalDelegates;
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

    [Header("Sprits")]
    public Sprite Mage;
    public Sprite Goblin;
    //public Sprite Human;
    //public Sprite Knight;

    public void ExecutSelect()
    {
        if (ClassUser.CharactersList.Count == 0)
            return;


        foreach (Transform child in characterInfoContainer.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (ClassCharacter character in ClassUser.CharactersList)
        {
            GameObject gobj = (GameObject)Instantiate(characterInfoTemplate);

            gobj.transform.SetParent(characterInfoContainer.transform);

            gobj.GetComponent<characterInfo>().transform.localPosition = new Vector3(0f, 0f, 0f);


            switch (character.avatarCharacter)
            {
                case "M":
                    gobj.GetComponent<characterInfo>().characterAvatar.sprite = Mage;
                    break;
                case "G":
                    gobj.GetComponent<characterInfo>().characterAvatar.sprite = Goblin;
                    break;
                //case "H":
                //    gobj.GetComponent<characterInfo>().characterAvatar.sprite = Human;
                //    break;
                //case "K":
                //    gobj.GetComponent<characterInfo>().characterAvatar.sprite = Knight;
                //    break;
            }

            gobj.GetComponent<characterInfo>().characterName.text = character.nameCharacter;


            gobj.GetComponent<characterInfo>().transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
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
