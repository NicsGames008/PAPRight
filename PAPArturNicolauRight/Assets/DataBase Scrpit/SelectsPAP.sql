/*Select geral*/
Select * From `User`;
select * from skils;
select * from `Character`;
select * from `Skils_Character`;

/*Select especifico*/

/*Select Login, validação*/
SELECT ID, UserName, aes_decrypt(PassWord, "shrek") as PassWord, aes_decrypt(Email, "shrek") as Email FROM user;
select count(*) from user where UserName = "Raul" and PassWord = "123" and Email  = "1@1.pt";

/*select de skill simples*/
select NameSkill, Description from skils where UserId = 1;

/*select de charcter simples*/
select NameCharacter from `Character` where UserId = 1;

/*select da skill para dar add ao Skils_Character*/
select ID from skils where NameSkill = 'skill1' and UserID = 1;
select ID from `Character` ORDER BY id DESC LIMIT 1;
