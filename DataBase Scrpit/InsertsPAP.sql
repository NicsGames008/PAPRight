delete from Skils_Character;
delete from `Character`;
delete from Skils;
delete from `User`;

insert into `User`(UserName, PassWord, Email) values("artur", aes_encrypt('a', "shrek"), aes_encrypt('a', "shrek"));
insert into `User`(UserName, PassWord, Email) values("lucas", aes_encrypt('123', "shrek"), aes_encrypt('lucas@gmail.com', "shrek"));

insert into Skils(UserID, NameSkill, MinLevel, Description, Damage, MinHealth, MinStrength, MinDex, MinConst, MinInt,MinMana , Animation, IsMagic) values(1, "skill1", 1, "1º Skill de teste", 1 ,1 , 1, 1, 1, 1, 1, "Animação toda bocks bocks", '0');
insert into Skils(UserID, NameSkill, MinLevel, Description, Damage, MinHealth, MinStrength, MinDex, MinConst, MinInt,MinMana , Animation, IsMagic, Cost, Effect, EffectValue) values(1, "skill2", 2, "2º Skill de teste", 2 ,2 , 2, 2, 2, 2, 2, "Animação toda bocks bocks", '1', 2, "magia2", 2);

insert into `Character`(UserID, NameCharacter, AvatarCharacter, Backgroud, Race, Health, Strength, Dexterity, Constitution, Intelligence, Mana) values(1, "character1", "M", "good", "that one", 1, 1, 1, 1, 1, 1);

insert into Skils_Character(SkilsID, CharacterID) values(1, 1);