insert into `User`(UserName, PassWord, Email) values("artur", aes_encrypt('a', "shrek"), aes_encrypt('a', "shrek"));
insert into `User`(UserName, PassWord, Email) values("lucas", aes_encrypt('b', "shrek"), aes_encrypt('b', "shrek"));

insert into `Character`(UserID, NameCharacter, Backgroud, Race, Health, Strength, Dexterity, Constitution, Intelligence, Mana) values(1, "character1",  "good", "M", 1, 1, 1, 1, 1, 1);

insert into`Session`(UserID, NameSession, DateSession) values(1, "Sessios 1", "29-06-2023");
/*
insert into Item(UserID, NameItem, TypeItem, DescriptionItem) values(1, "Some Book", "B", "Some stuff as exemplo for the book");


insert into Skils(UserID, NameSkill, MinLevel, Description, Damage, MinHealth, MinStrength, MinDex, MinConst, MinInt,MinMana , IsMagic) values(1, "skill1", 1, "1º Skill de teste", 1 ,1 , 1, 1, 1, 1, 1, '0');
insert into Skils(UserID, NameSkill, MinLevel, Description, Damage, MinHealth, MinStrength, MinDex, MinConst, MinInt,MinMana , IsMagic, Cost, Effect, EffectValue) values(1, "skill2", 2, "2º Skill de teste", 2 ,2 , 2, 2, 2, 2, 2, '1', 2, "magia2", 2);

insert into Skils_Character(SkilsID, CharacterID, UserID) values(1, 1, 1);
*/
