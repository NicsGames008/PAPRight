using System;
using System.Collections;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class userInsert : MonoBehaviour
{
    //Guarda o local da API
    string url = APIDomain.Domain("userInsert.php");
    //Recebe os valores das caixas
    public TMP_InputField insertUsername, insertPassword, insertEmail, confirmPassword;
    public GameObject background, erroUser, erroPass, erroConfPass, erroEmail, passDiferente;

    //chama a class
    private ClassUser user = new ClassUser();

    //Loading
    private bool isLoading = false;

    public void AddUser()
    {
        //sabe se as infos estam certas
        bool valUsername = false, valEmail = false, valPass = false;

        //guarda os valores nal class
        user.usernamePub = insertUsername.text;
        user.passwordPub = insertPassword.text;
        user.emailPub = insertEmail.text;

        #region Username
        if (ValidateUsername(user.usernamePub))
        {
            valUsername = true;
            print("Username passou");
            erroUser.SetActive(false);
        }
        else
        {
            print("Username erro");
            erroUser.SetActive(true);
        }
        #endregion

        #region Email
        //Valida de o email esta de acordo com o pedido
        if (ValidateEmail(user.emailPub))
        {
            valEmail = true;
            print("email passou");
            erroEmail.SetActive(false);

        }
        else
        {
            print("email erro");
            erroEmail.SetActive(true);
        }
        #endregion

        #region PassWord
        //Valida de o email esta de acordo com o pedido
        if (ValidatePassword(user.passwordPub))
        {
            //valida se o confirmar a pass
            if (ValidatePassword(confirmPassword.text))
            {
                //escoal a mensg de erro
                erroConfPass.SetActive(false);
                //Ve se a pass e cofirmar pass são iguais
                if (confirmPassword.text == insertPassword.text)
                {
                    //se tudo estiver certo passa
                    valPass = true;
                    print("pass passou");
                    passDiferente.SetActive(false);
                }
                //se for diferente manda uma mnsg de erro
                else
                    passDiferente.SetActive(true);
            }
            //SE não manda uma mesng de erro
            else
                erroConfPass.SetActive(true);
        }
        //SE nãoi der manda uma msng de erro
        else
        {
            print("pass erro");
            erroPass.SetActive(true);
        }
        #endregion

        //ve se esta tudo certo, se sim manda tudo para a BD
        if (valEmail && valPass && valUsername)
        {
            StartCoroutine(AddUserDB());
            if (isLoading)
            {
                BackLogin();
                ResetInputs();
            }
            else
            {
                Debug.Log("Loading");
            }
        }
    }

    //Metedo que muda de ecrã
    public void BackLogin()
    {
        background.transform.LeanMoveLocal(new Vector3(-400, 0, 0), 0.7f).setEaseInBack().setIgnoreTimeScale(true);
    }

    #region Adiciona a BD
    //Adiciona as infos a BD
    public IEnumerator AddUserDB()
    {
        isLoading = true;

        //Var que vair ter os POST's para a API
        WWWForm form = new WWWForm();

        //da os valores aos post's da API
        form.AddField("addUsername", user.usernamePub);
        form.AddField("addEmail", user.emailPub);
        form.AddField("addPassword", user.passwordPub);

        //Iniciando o uso de UnityWebRequest para fazer uma requisição POST para a URL especificada
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            //Enviando a requisição e aguardando a resposta
            yield return www.SendWebRequest();

            //Verificando se houve erro na rede ou no HTTP
            if (www.isNetworkError || www.isHttpError)
            {
                //Imprimindo o erro no console
                Debug.Log(www.error);
            }
            else
            {
                //Imprimindo uma mensagem de sucesso no console
                Debug.Log("Data sent successfully.");
            }

        }

        isLoading = false;
    }
    #endregion

    #region Reset Inputs
    //da reset as textbox's
    private void ResetInputs()
    {
        insertUsername.text = null;
        insertPassword.text = null;
        insertEmail.text = null;
        confirmPassword.text = null;
    }
    #endregion

    #region Username
    // Valida se o nome esta certo
    public bool ValidateUsername(string username)
    {
        //Verifica se exete o limite e é null
        if (String.IsNullOrEmpty(username))
        {
            //Retorna um Erro
            return false;
        }

        //Se estver tudo certo deica passar
        return true;
    }
    #endregion

    #region Email
    // Valida se o nome esta certo
    public bool ValidateEmail(string email)
    {
        //Ve se tem o que é preciso
        Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);

        //Verifica se exete o limite e é null
        if (String.IsNullOrEmpty(email) || !emailRegex.IsMatch(email))
        {
            //Retorna um Erro
            return false;
        }

        //Se estver tudo certo deica passar
        return true;
    }
    #endregion

    #region Palavra Passe
    // Valida se a palavra passe esta certo
    public bool ValidatePassword(string Password)
    {
        //Verifica se exete o limite e é null
        if (String.IsNullOrEmpty(Password) || Password.Length > 25)
        {
            //Retorna um Erro
            return false;
        }
        //Se estver tudo certo deica passar
        return true;
    }
    #endregion
}
