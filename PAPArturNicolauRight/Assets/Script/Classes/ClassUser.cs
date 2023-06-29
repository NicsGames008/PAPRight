using System.Collections.Generic;

public class ClassUser
{
    //Guarda o username
    public static int idUser { get; set; }

    //Guarda o username
    public string usernameUser { get; set; }

    //Guarda o password
    public string passwordUser { get; set; }

    //Guarda o email
    public string emaiUser { get; set; }

    //Guarda a Lista dos Character
    public static List<ClassCharacter> CharactersList { get; set; }

    //Guarda a Lista dos Skills
    public static List<ClassSkill> SkillsList { get; set; }

    //Guarda a Lista dos SkillCharacter
    public static List<ClassSkillCharacter> SkillsCharacterList { get; set; }

    //Guarda a Lista dos SessionList
    public static List<ClassSession> SessionList { get; set; }
}
