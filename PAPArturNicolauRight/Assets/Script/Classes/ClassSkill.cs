public class ClassSkill
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

    #region NameSkill
    //Guarda o NameSkill
    private string NameSkill;

    //recebe o valor do NameSkill
    public string NameSkillPub
    {
        get { return NameSkill; }
        set { NameSkill = value; }
    }
    #endregion

    #region MinLevel
    //Guarda o NameSkill
    private int MinLevel;

    //recebe o valor do NameSkill
    public int MinLevelPub
    {
        get { return MinLevel; }
        set { MinLevel = value; }
    }
    #endregion

    #region Desc
    //Guarda o Desc
    private string Desc;

    //recebe o valor do Desc
    public string DescPub
    {
        get { return Desc; }
        set { Desc = value; }
    }
    #endregion

    #region Damage
    //Guarda o Damage
    private int Damage;

    //recebe o valor do Damage
    public int DamagePub
    {
        get { return Damage; }
        set { Damage = value; }
    }
    #endregion

    #region MinHealth               <---------------------
    //Guarda o MinHealth
    private int MinHealth;

    //recebe o valor do MinHealth
    public int MinHealthPub
    {
        get { return MinHealth; }
        set { MinHealth = value; }
    }
    #endregion

    #region MinStr
    //Guarda o MinStr
    private int MinStr;

    //recebe o valor do Damage
    public int MinStrPub
    {
        get { return MinStr; }
        set { MinStr = value; }
    }
    #endregion

    #region MinDex
    //Guarda o MinDex
    private int MinDex;

    //recebe o valor do MinDex
    public int MinDexPub
    {
        get { return MinDex; }
        set { MinDex = value; }
    }
    #endregion

    #region MinConst
    //Guarda o MinConst
    private int MinConst;

    //recebe o valor do MinConst
    public int MinConstPub
    {
        get { return MinConst; }
        set { MinConst = value; }
    }
    #endregion

    #region MinInt
    //Guarda o MinInt
    private int MinInt;

    //recebe o valor do MinInt
    public int MinIntPub
    {
        get { return MinInt; }
        set { MinInt = value; }
    }
    #endregion

    #region MinMana                 <---------------------
    //Guarda o MinMana
    private int MinMana;

    //recebe o valor do MinMana
    public int MinManaPub
    {
        get { return MinMana; }
        set { MinMana = value; }
    }
    #endregion

    #region Animation
    //Guarda o Animation
    private string Animation;

    //recebe o valor do MinConst
    public string AnimationPub
    {
        get { return Animation; }
        set { Animation = value; }
    }
    #endregion

    #region IsMagic
    //Guarda o IsMagic
    private int IsMagic;

    //recebe o valor do IsMagic
    public int IsMagicPub
    {
        get { return IsMagic; }
        set { IsMagic = value; }
    }
    #endregion

    #region Cost
    //Guarda o Cost
    private int Cost;

    //recebe o valor do Cost
    public int CostPub
    {
        get { return Cost; }
        set { Cost = value; }
    }
    #endregion

    #region Effect
    //Guarda o Effect
    private string Effect;

    //recebe o valor do Effect
    public string EffectPub
    {
        get { return Effect; }
        set { Effect = value; }
    }
    #endregion

    #region EffectValue
    //Guarda o EffectValue
    private int EffectValue;

    //recebe o valor do Effect
    public int EffectValuePub
    {
        get { return EffectValue; }
        set { EffectValue = value; }
    }
    #endregion


}
