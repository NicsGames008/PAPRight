drop table Session_Item;
drop table Character_Session;
drop table Item;
drop table User_Session;
drop table Skils_NPC;
drop table Skils_Character;
drop table Session_NPC;
drop table NPC;
drop table `Session`;
drop table `Character`;
drop table Skils;
drop table Map;
drop table `User`;

/*Criar Tabelas*/
CREATE TABLE `User` (
ID int(10) NOT NULL AUTO_INCREMENT,
 UserName varchar(255) NOT NULL,
 PassWord varbinary(255) NOT NULL,
 Email varbinary(255) NOT NULL,
 AvatarUser varchar(255),
 PRIMARY KEY (ID));

CREATE TABLE Map (
ID int(10) NOT NULL AUTO_INCREMENT,
 UserID int(10) NOT NULL,
 MapFile varchar(255) NOT NULL,
 MapName varchar(255) NOT NULL,
 PRIMARY KEY (ID));
 
CREATE TABLE NPC (
ID int(10) NOT NULL AUTO_INCREMENT,
 UserID int(10) NOT NULL,
 NPCName varchar(255),
 NPCAvatar varchar(255),
 Equipment varchar(255),
 Health int(10) NOT NULL,
 Strength int(10) NOT NULL,
 Dexterity int(10) NOT NULL,
 Constitution int(10) NOT NULL,
 Intelligence int(10) NOT NULL,
 PRIMARY KEY (ID));
 
CREATE TABLE Session_NPC (
SessionID int(10) NOT NULL,
 NPCID int(10) NOT NULL,
 Position int(50) NOT NULL,
 PRIMARY KEY (SessionID,
 NPCID));
 
CREATE TABLE Skils_Character (
SkilsID int(10) NOT NULL,
 CharacterID int(10) NOT NULL,
 Level int(10),
 PRIMARY KEY (SkilsID,
 CharacterID));
 
CREATE TABLE Skils_NPC (
SkilsID int(10) NOT NULL,
 NPCID int(10) NOT NULL,
 Level int(10) NOT NULL,
 PRIMARY KEY (SkilsID,
 NPCID));
 
CREATE TABLE User_Session (
UserID int(10) NOT NULL,
 SessionID int(10) NOT NULL,
 IsGM bit(1) DEFAULT 0 NOT NULL,
 PRIMARY KEY (UserID, SessionID));
 
CREATE TABLE `Session` (
ID int(10) NOT NULL AUTO_INCREMENT,
 NameSession varchar(255) NOT NULL,
 DateSession varchar(255) NOT NULL,
 MapID int(10) NOT NULL,
 Name varchar(255) NOT NULL,
 PRIMARY KEY (ID));
 
CREATE TABLE `Character` (
ID int(10) NOT NULL AUTO_INCREMENT,
 UserID int(10) NOT NULL,
 NameCharacter varchar(255) NOT NULL,
 AvatarCharacter varchar(255) NOT NULL,
 Backgroud varchar(255) NOT NULL,
 Race varchar(255) NOT NULL,
 Health int(10) NOT NULL,
 Strength int(10) NOT NULL,
 Dexterity int(10) NOT NULL,
 Constitution int(10) NOT NULL,
 Intelligence int(10) NOT NULL,
 Mana int(10) NOT NULL,
 PRIMARY KEY (ID));
 
CREATE TABLE Skils (
ID int(10) NOT NULL AUTO_INCREMENT,
 UserID int(10) NOT NULL,
 NameSkill varchar(255) NOT NULL,
 MinLevel int(10) NOT NULL,
 Description varchar(255) NOT NULL,
 Damage int(10) NOT NULL,
 IsMagic enum('1','0') NOT NULL,
 Cost int(10) ,
 Effect varchar(255),
 EffectValue int(10),
 MinHealth int(10) NOT NULL,
 MinStrength int(10) NOT NULL,
 MinDex int(10) NOT NULL,
 MinConst int(10) NOT NULL,
 MinInt int(10) NOT NULL,
 MinMana int(10) NOT NULL,
 Animation varchar(255) NOT NULL,
 PRIMARY KEY (ID));
 
CREATE TABLE Item (
ID int(10) NOT NULL AUTO_INCREMENT,
 CharacterID int(10), NPCID int(10),
 UserID int(10) NOT NULL,
 NameItem varchar(255) NOT NULL,
 AvatarItem varchar(255) NOT NULL,
 Strength int(10),
 Durability int(10),
 Effect varchar(255),
 EffectValue int(10),
 TriggerChance int(10),
 HealthBoost int(10),
 StrengthBoost int(10),
 DexterityBoost int(10),
 ConstitutionBoost int(10),
 IntelligenceBoost int(10),
 ManaBoost int(10),
 PRIMARY KEY (ID));
 
CREATE TABLE Character_Session (
CharacterID int(10) NOT NULL,
 SessionID int(10) NOT NULL,
 Health int(10) NOT NULL,
 Strength int(10) NOT NULL,
 Dexterity int(10) NOT NULL,
 Constitution int(10) NOT NULL, 
 Intelligence int(10) NOT NULL,
 Mana int(10) NOT NULL,
 CurrentHealth int(10) NOT NULL,
 CurrentMana int(10) NOT NULL,
 Position int(50) NOT NULL,
 CurrentMoney int(10) NOT NULL,
 PRIMARY KEY (CharacterID, SessionID));
 
CREATE TABLE Session_Item (
SessionID int(10) NOT NULL,
 ItemID int(10) NOT NULL,
 Position int(50) NOT NULL,
 PRIMARY KEY (SessionID, ItemID));
 
 /*Alter Table para FK*/
ALTER TABLE Session_NPC ADD CONSTRAINT FKSession_NP832784 FOREIGN KEY (SessionID) REFERENCES `Session` (ID);

ALTER TABLE User_Session ADD CONSTRAINT FKUser_Sessi870738 FOREIGN KEY (UserID) REFERENCES `User` (ID);

ALTER TABLE User_Session ADD CONSTRAINT FKUser_Sessi882303 FOREIGN KEY (SessionID) REFERENCES `Session` (ID);

ALTER TABLE Map ADD CONSTRAINT FKMap440077 FOREIGN KEY (UserID) REFERENCES `User` (ID);

ALTER TABLE `Session` ADD CONSTRAINT FKSession136535 FOREIGN KEY (MapID) REFERENCES Map (ID);

ALTER TABLE Skils_Character ADD CONSTRAINT FKSkils_Char696507 FOREIGN KEY (SkilsID) REFERENCES Skils (ID);

ALTER TABLE Session_NPC ADD CONSTRAINT FKSession_NP260520 FOREIGN KEY (NPCID) REFERENCES NPC (ID);

ALTER TABLE Skils ADD CONSTRAINT FKSkils572865 FOREIGN KEY (UserID) REFERENCES `User` (ID);

ALTER TABLE Item ADD CONSTRAINT FKItem227732 FOREIGN KEY (UserID) REFERENCES `User` (ID);

ALTER TABLE Skils_Character ADD CONSTRAINT FKSkils_Char856503 FOREIGN KEY (CharacterID) REFERENCES `Character` (ID);

ALTER TABLE `Character` ADD CONSTRAINT FKCharacter649967 FOREIGN KEY (UserID) REFERENCES `User` (ID);

ALTER TABLE Skils_NPC ADD CONSTRAINT FKSkils_NPC94168 FOREIGN KEY (SkilsID) REFERENCES Skils (ID);

ALTER TABLE Skils_NPC ADD CONSTRAINT FKSkils_NPC489128 FOREIGN KEY (NPCID) REFERENCES NPC (ID);

ALTER TABLE NPC ADD CONSTRAINT FKNPC439688 FOREIGN KEY (UserID) REFERENCES `User` (ID);

ALTER TABLE Item ADD CONSTRAINT FKItem854007 FOREIGN KEY (NPCID) REFERENCES NPC (ID);

ALTER TABLE Item ADD CONSTRAINT FKItem801979 FOREIGN KEY (CharacterID) REFERENCES `Character` (ID);

ALTER TABLE Character_Session ADD CONSTRAINT FKCharacter_62648 FOREIGN KEY (CharacterID) REFERENCES `Character` (ID);

ALTER TABLE Character_Session ADD CONSTRAINT FKCharacter_992961 FOREIGN KEY (SessionID) REFERENCES `Session` (ID);

ALTER TABLE Session_Item ADD CONSTRAINT FKSession_It245729 FOREIGN KEY (SessionID) REFERENCES `Session` (ID);

ALTER TABLE Session_Item ADD CONSTRAINT FKSession_It269319 FOREIGN KEY (ItemID) REFERENCES Item (ID);
