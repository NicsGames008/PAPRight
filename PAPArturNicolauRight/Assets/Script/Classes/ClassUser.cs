public class ClassUser
{
    #region UserName
    //Guarda o username
    private string username;

    //recebe o valor do username
    public string usernamePub
    {
        get { return username; }
        set { username = value; }
    }
    #endregion

    #region Password
    //Guarda o password
    private string password;

    //recebe o valor do password
    public string passwordPub
    {
        get { return password; }
        set { password = value; }
    }
    #endregion

    #region Email
    //Guarda o email
    private string email;

    //recebe o valor do email
    public string emailPub
    {
        get { return email; }
        set { email = value; }
    }
    #endregion
}
