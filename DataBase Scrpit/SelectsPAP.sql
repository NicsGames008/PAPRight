/*Select geral*/
Select * From `User`;
select * from `Character`;
select * from `Session`;


SELECT ID, UserName, aes_decrypt(PassWord, "shrek") as PassWord, aes_decrypt(Email, "shrek") as Email FROM user;
select count(*) from user where UserName = "Raul" and PassWord = "123" and Email  = "1@1.pt";

select NameSession, DateSession from `Session` where UserID = 1;

select NameCharacter from `Character` where UserId = 1;

/*
select NameSkill, Description from skils where UserId = 1;



select ID from skils where NameSkill = 'skill1' and UserID = 1;
select ID from `Character` ORDER BY id DESC LIMIT 1;



select SkilsID, CharacterID from `Skils_Character` where UserID = 1;
*/