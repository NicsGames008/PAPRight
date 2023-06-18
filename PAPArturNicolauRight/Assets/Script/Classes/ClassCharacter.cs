using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassCharacter
{

    
    #region UserId

    //Guarda o userId
    private static int userId;

    //recebe o valor do userId
    public static int UserIdPub
    {
        get { return userId; }
        set { userId = value; }
    }
    #endregion

    #region CharacterId
    //Guarda o CharacterId
    private int CharacterId;

    //recebe o valor do CharacterId
    public int CharacterIdPub
    {
        get { return CharacterId; }
        set { CharacterId = value; }
    }
    #endregion

    #region NameCharacter
    //Guarda o NameCharacter
    private string NameCharacter;

    //recebe o valor do NameCharacter
    public string NameCharacterPub
    {
        get { return NameCharacter; }
        set { NameCharacter = value; }
    }
    #endregion

    #region Avatar
    //Guarda o Avatar
    private string Avatar;

    //recebe o valor do Avatar
    public string AvatarPub
    {
        get { return Avatar; }
        set { Avatar = value; }
    }
    #endregion

    #region Background
    //Guarda o Background
    private string Background;

    //recebe o valor do Background
    public string BackgroundPub
    {
        get { return Background; }
        set { Background = value; }
    }
    #endregion

    #region Race
    //Guarda o Race
    private string Race;

    //recebe o valor do Race
    public string RacePub
    {
        get { return Race; }
        set { Race = value; }
    }
    #endregion

    #region Health
    //Guarda o Health
    private int Health;

    //recebe o valor do Health
    public int HealthPub
    {
        get { return Health; }
        set { Health = value; }
    }
    #endregion

    #region Str
    //Guarda o Str
    private int Str;

    //recebe o valor do Str
    public int StrPub
    {
        get { return Str; }
        set { Str = value; }
    }
    #endregion

    #region Dex
    //Guarda o Dex
    private int Dex;

    //recebe o valor do Dex
    public int DexPub
    {
        get { return Dex; }
        set { Dex = value; }
    }
    #endregion

    #region Const
    //Guarda o Const
    private int Const;

    //recebe o valor do Const
    public int ConstPub
    {
        get { return Const; }
        set { Const = value; }
    }
    #endregion

    #region Int
    //Guarda o Int
    private int Int;

    //recebe o valor do Int
    public int IntPub
    {
        get { return Int; }
        set { Int = value; }
    }
    #endregion

    #region Mana
    //Guarda o Mana
    private int Mana;

    //recebe o valor do Mana
    public int ManaPub
    {
        get { return Mana; }
        set { Mana = value; }
    }
    #endregion
}
