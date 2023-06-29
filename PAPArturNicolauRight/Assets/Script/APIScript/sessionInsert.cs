using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class sessionInsert : MonoBehaviour
{
    [SerializeField]
    TMP_InputField nameInput;

    [SerializeField]
    GameObject error, crtSession;

    //Guarda o local da API
    string urlSession = APIDomain.Domain("sessionInsert.php");

    //Guarda os dados na class
    private ClassSession session = new ClassSession();

    public void ShowCreate()
    {
        crtSession.SetActive(!crtSession.activeSelf);
    }


    public void AddSession()
    {
        bool valName = false;

        //Chama o metedo q esta respondavel por validar as var string
        if (ValidateString(nameInput.text))
        {
            //se tudo esta em ordem continua
            valName = true;
        }
        //Senão da erro
        else
            print("nome NAO passou");

        if (valName)
        {
            error.SetActive(false);


            DateTime curretTime = DateTime.Now;

            session.nameSession = nameInput.text;
            session.dateSession = curretTime.ToString("dd-MM-yyyy");

            StartCoroutine("AddSessionDB");

            crtSession.SetActive(false);
        }
        else
        {
            error.SetActive(true);
        }
    }

    #region Adiciona Character a BD
    //Adiciona as infos a BD
    public IEnumerator AddSessionDB()
    {
        // Variável para armazenar os dados a serem enviados na requisição POST
        WWWForm form = new WWWForm();

        //Adicionar os dados a serem enviados na requisição POST
        form.AddField("UserId", ClassUser.idUser);
        form.AddField("nameSession", session.nameSession);
        form.AddField("dateSession", session.dateSession);

        //Iniciando o uso de UnityWebRequest para fazer uma requisição POST para a URL especificada
        using (WWW www = new WWW(urlSession, form))
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

                if (ClassUser.SessionList == null)
                {
                    List<ClassSession> temSess = new List<ClassSession>();
                    temSess.Add(session);

                    ClassUser.SessionList = temSess;
                }
                else
                    ClassUser.SessionList.Add(session);
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
}
