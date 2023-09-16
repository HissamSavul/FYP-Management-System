
use DBProject

/* DISPLAY TABLES */
SELECT * FROM users
select * from Student
select * from Supervisor
select * from Panel_Member
select * from Committee_Member
select * from Project
select * from Project_PanelMembers
select * from Audit_Records
select * from Deadline
select * from Notifications


/* Committee Member	*/
insert into Users values(01, 'admin', '1234', 'Database', 'Tester');
insert into Committee_Member values(01);

/* Supervisors	*/
INSERT INTO Users VALUES(02, 'sup1', 'pass', 'Diane', 'Wood')
INSERT INTO Supervisor VALUES(02, 6)
INSERT INTO Users VALUES(03, 'sup2', 'pass', 'Eleanor', 'Carlson')
INSERT INTO Supervisor VALUES(03, 0)
INSERT INTO Users VALUES(04, 'sup3', 'pass', 'Gordon', 'Jessie')
INSERT INTO Supervisor VALUES(04, 1)
INSERT INTO Users VALUES(05, 'sup4', 'pass', 'Kevin', 'Montgomery')
INSERT INTO Supervisor VALUES(05, 0)

/* Panel Member	*/
INSERT INTO Users VALUES(06, 'pan1', 'pass', 'Arthur', 'Burke')
INSERT INTO Panel_Member VALUES(06)
INSERT INTO Users VALUES(07, 'pan2', 'pass', 'Glenda', 'Morgan')
INSERT INTO Panel_Member VALUES(07)
INSERT INTO Users VALUES(08, 'pan3', 'pass', 'Zachary', 'Perry')
INSERT INTO Panel_Member VALUES(08) 
INSERT INTO Users VALUES(09, 'pan4', 'pass', 'Barry', 'Patterson')
INSERT INTO Panel_Member VALUES(09)

/* Student	*/
INSERT INTO Users VALUES(10, 'han', '1234', 'Hanan', 'Jahangiri');
INSERT INTO Student VALUES(10, 'A')
INSERT INTO Users VALUES(11, 'usm', '1234', 'Muhammad', 'Usman');
INSERT INTO Student VALUES(11, 'A')
INSERT INTO Users VALUES(12, 'his', '1234', 'Hissam', 'Savul');
INSERT INTO Student VALUES(12, 'A')

INSERT INTO Users VALUES(13, 'stud1', '1234', 'John', 'Cena');
INSERT INTO Student VALUES(13, 'B')
INSERT INTO Users VALUES(14, 'stud2', '1234', 'David', 'Bautista');
INSERT INTO Student VALUES(14, 'B')
INSERT INTO Users VALUES(15, 'stud3', '1234', 'Shawn', 'Micheals');
INSERT INTO Student VALUES(15, 'B')

INSERT INTO Users VALUES(16, 'stud4', '1234', 'Erin', 'Washington');
INSERT INTO Student VALUES(16, 'C')
INSERT INTO Users VALUES(17, 'stud5', '1234', 'Ida', 'Ramos');
INSERT INTO Student VALUES(17, 'C')
INSERT INTO Users VALUES(18, 'stud6', '1234', 'Jon', 'Williams');
INSERT INTO Student VALUES(18, 'C')

INSERT INTO Users VALUES(19, 'stud7', '1234', 'Stephanie', 'Alma');
INSERT INTO Student VALUES(19, 'B')
INSERT INTO Users VALUES(20, 'stud8', '1234', 'Tylor', 'Currie');
INSERT INTO Student VALUES(20, 'B')
INSERT INTO Users VALUES(21, 'stud9', '1234', 'Claude', 'Macgregor');
INSERT INTO Student VALUES(21, 'B')

INSERT INTO Users VALUES(22, 'stud10', '1234', 'Taylor', 'Mcarthur');
INSERT INTO Student VALUES(22, 'C+')
INSERT INTO Users VALUES(23, 'stud11', '1234', 'Marshall', 'Guthrie');
INSERT INTO Student VALUES(23, 'C+')
INSERT INTO Users VALUES(24, 'stud12', '1234', 'Mohammad', 'Sinclair');
INSERT INTO Student VALUES(24, 'C+')

INSERT INTO Users VALUES(25, 'stud13', '1234', 'Aayush', 'Ryder');
INSERT INTO Student VALUES(25, NULL)
INSERT INTO Users VALUES(26, 'stud14', '1234', 'Savannah', 'Drake');
INSERT INTO Student VALUES(26, NULL)
INSERT INTO Users VALUES(27, 'stud15', '1234', 'Tracy', 'Mackenzie');
INSERT INTO Student VALUES(27, NULL)

INSERT INTO Users VALUES(28, 'stud16', '1234', 'Domas', 'Mcgill');
INSERT INTO Student VALUES(28, NULL)
INSERT INTO Users VALUES(29, 'stud17', '1234', 'Barnaby', 'Morton');
INSERT INTO Student VALUES(29, NULL)
INSERT INTO Users VALUES(30, 'stud18', '1234', 'Wright', 'Cantrell');
INSERT INTO Student VALUES(30, NULL)

/* Projects	*/
INSERT INTO Project VALUES(01, 02, 10, 11, 12, 'There is a fault between the connection of your database');
INSERT INTO Project VALUES(02, 02, 13, 14, 15, 'You need to improve the third part of your project');
INSERT INTO Project VALUES(03, 02, 16, 17, 18, NULL);
INSERT INTO Project VALUES(04, 02, 19, 20, 21, 'Redo everything from scratch, this does not work well');
INSERT INTO Project VALUES(05, 02, 22, 23, 24, NULL);
INSERT INTO Project VALUES(06, 04, 25, 26, 27, NULL);
INSERT INTO Project VALUES(07, 02, 28, 29, 30, NULL);

/* Add panel members to project */
INSERT INTO Project_PanelMembers VALUES(01, 06, 'Excellent work');
INSERT INTO Project_PanelMembers VALUES(01, 07, 'I am glad that you guys put in all that effort');
INSERT INTO Project_PanelMembers VALUES(01, 08, 'Could have been better but its not bad');
INSERT INTO Project_PanelMembers VALUES(02, 07, 'There is room for improvement but i see effort');
INSERT INTO Project_PanelMembers VALUES(02, 08, 'Did you even try');
INSERT INTO Project_PanelMembers VALUES(02, 09, NULL);
INSERT INTO Project_PanelMembers VALUES(03, 06, NULL);
INSERT INTO Project_PanelMembers VALUES(03, 08, NULL);
INSERT INTO Project_PanelMembers VALUES(03, 09, NULL);
INSERT INTO Project_PanelMembers VALUES(04, 06, NULL);
INSERT INTO Project_PanelMembers VALUES(04, 08, NULL);
INSERT INTO Project_PanelMembers VALUES(04, 09, NULL);
INSERT INTO Project_PanelMembers VALUES(05, 06, NULL);
INSERT INTO Project_PanelMembers VALUES(05, 08, NULL);
INSERT INTO Project_PanelMembers VALUES(05, 09, NULL);

/*Deadline*/
INSERT INTO Deadline VALUES(01, '22-june-2022','11:59 pm');
INSERT INTO Deadline VALUES(02, '23-june-2022','12:00 pm');
INSERT INTO Deadline VALUES(03, '30-july-2022','10:00 pm');
INSERT INTO Deadline VALUES(04, '25-june-2022','01:30 am');
INSERT INTO Deadline VALUES(05, '26-june-2022','11:59 pm');
INSERT INTO Deadline VALUES(06, '26-june-2022','9:00 am');

/*Notification*/
INSERT INTO Notifications VALUES(02, 'You will be undertaking Students with UserID 10, 11 and 12.');
INSERT INTO Notifications VALUES(02, 'You will be undertaking Students with UserID 13, 14 and 15.');
INSERT INTO Notifications VALUES(02, 'You will be undertaking Students with UserID 16, 17 and 18.');
INSERT INTO Notifications VALUES(02, 'You will be undertaking Students with UserID 19, 20 and 21.');
INSERT INTO Notifications VALUES(02, 'You will be undertaking Students with UserID 22, 23 and 24.');
INSERT INTO Notifications VALUES(04, 'You will be undertaking Students with UserID 25, 26 and 27.');
INSERT INTO Notifications VALUES(02, 'You will be undertaking Students with UserID 28, 29 and 30');
