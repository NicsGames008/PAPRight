drop table `Session`;
drop table `Character`;
drop table `User`;

CREATE TABLE `User` (
ID int(10) NOT NULL AUTO_INCREMENT,
 UserName varchar(255) NOT NULL,
 PassWord varbinary(255) NOT NULL,
 Email varbinary(255) NOT NULL,
 AvatarUser varchar(255),
 PRIMARY KEY (ID));
 
CREATE TABLE `Session` (
ID int(10) NOT NULL AUTO_INCREMENT,
 UserID int(10) NOT NULL,
 NameSession varchar(255) NOT NULL,
 DateSession varchar(255) NOT NULL, 
 PRIMARY KEY (ID));
 
CREATE TABLE `Character` (
ID int(10) NOT NULL AUTO_INCREMENT,
 UserID int(10) NOT NULL,
 NameCharacter varchar(255) NOT NULL,
 Backgroud varchar(255) NOT NULL,
 Race enum('M','G', 'H', 'k') NOT NULL,
 Health int(10) NOT NULL,
 Strength int(10) NOT NULL,
 Dexterity int(10) NOT NULL,
 Constitution int(10) NOT NULL,
 Intelligence int(10) NOT NULL,
 Mana int(10) NOT NULL,
 PRIMARY KEY (ID));
 
ALTER TABLE `Character` ADD CONSTRAINT FKCharacter649967 FOREIGN KEY (UserID) REFERENCES `User` (ID);
ALTER TABLE `Session` ADD CONSTRAINT FKSession821011 FOREIGN KEY (UserID) REFERENCES `User` (ID);
