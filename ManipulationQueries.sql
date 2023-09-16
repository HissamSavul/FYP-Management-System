
use DBProject

--View all Projects that a specific supervisor (UserID#02) is supervising
SELECT ProjectID, CONCAT(U1.FirstName, ' ', U1.LastName) As Member_1, CONCAT(U2.FirstName, ' ', U2.LastName) As Member_2 , CONCAT(U3.FirstName, ' ', U3.LastName) As Member_3, Project.Review 
FROM Project, Users U1, Users U2, Users U3 
WHERE U1.UserID = Project.Member1_UserId AND U2.UserID = Project.Member2_UserId AND U3.UserID = Project.Member3_UserId AND Supervisor_UserId = 02

--View all Projects that a specific panel member (User#06) can grade
SELECT Project.ProjectID, CONCAT(U1.FirstName, ' ', U1.LastName) As Member_1, CONCAT(U2.FirstName, ' ', U2.LastName) As Member_2 , CONCAT(U3.FirstName, ' ', U3.LastName) As Member_3, CONCAT(Sup1.FirstName, ' ', Sup1.LastName) As Supervisor, StudentGrade As Grade 
FROM Project, Users U1, Users U2, Users U3, Users Sup1, Users Pan1, Project_PanelMembers PPM, Student 
WHERE U1.UserID = Project.Member1_UserId AND U2.UserID = Project.Member2_UserId AND U3.UserID = Project.Member3_UserId AND Sup1.UserID = Project.Supervisor_UserId AND Student.UserID = U1.UserID AND PPM.ProjectID = Project.ProjectID AND PPM.PanelMemberUserId = Pan1.UserID and Pan1.UserID = 06

--View all notifications of a specific supervisor(UserID#02)
SELECT NotificationMessage 
FROM Users U, Notifications N 
WHERE U.UserID = N.Supervisor_UserID and N.Supervisor_UserID = 02

--Show Project details of a specific student(UserID#15)
SELECT Project.ProjectID, CONCAT(U1.FirstName, ' ', U1.LastName) As Member_1, CONCAT(U2.FirstName, ' ', U2.LastName) As Member_2 , CONCAT(U3.FirstName, ' ', U3.LastName) As Member_3, CONCAT(Sup1.FirstName, ' ', Sup1.LastName) as Supervisor 
FROM Project, Users U1, Users U2, Users U3, Users Sup1 
WHERE U1.UserID = Project.Member1_UserId AND U2.UserID = Project.Member2_UserId AND U3.UserID = Project.Member3_UserId AND Sup1.UserID = Project.Supervisor_UserId AND (U1.UserID = 15 OR U2.UserID = 15 OR U3.UserID = 15)

--Display all projects with Members and Supervisors
SELECT Project.ProjectID, CONCAT(U1.FirstName, ' ', U1.LastName) As Member_1, CONCAT(U2.FirstName, ' ', U2.LastName) As Member_2 , CONCAT(U3.FirstName, ' ', U3.LastName) As Member_3, CONCAT(Sup1.FirstName, ' ', Sup1.LastName) as Supervisor 
FROM Project, Users U1, Users U2, Users U3, Users Sup1 
WHERE U1.UserID = Project.Member1_UserId AND U2.UserID = Project.Member2_UserId AND U3.UserID = Project.Member3_UserId AND Sup1.UserID = Project.Supervisor_UserId

--Display all Project Deadlines 
SELECT ProjectID, convert(varchar(10), DeadlineDate, 111) as Date, CONVERT(varchar(15),CAST(DeadlineTime AS TIME),100) as Time FROM Deadline

--Display all students
SELECT U.UserID, CONCAT(FirstName, ' ', LastName) As Name, Username As Username, UserPassword Password, StudentGrade As Grade 
FROM Users U, Student S WHERE U.UserID = S.UserID

--Display all Panel Members
SELECT U.UserID, CONCAT(FirstName, ' ', LastName) As Name, Username As Username, UserPassword Password 
FROM Users U, Panel_Member P WHERE U.UserID = P.UserID

--Display all Supervisors
SELECT U.UserID, CONCAT(FirstName, ' ', LastName) As Name, Username As Username, UserPassword Password, NumFYP As No_Of_FYPs 
FROM Users U, Supervisor S WHERE U.UserID = S.UserID

--Display which panelists are incharge of which group
SELECT PPM.ProjectID, CONCAT(FirstName, ' ', LastName) As Panel_Member, Evaluation 
FROM Project_PanelMembers PPM, Users U 
WHERE U.UserID = PPM.PanelMemberUserId ORDER BY PPM.ProjectID ASC


--query that checks if a projectid exists or not
Select count(ProjectID) FROM Project WHERE ProjectID=3

--query that checks if a project has been a deadline or not
Select count(ProjectID) FROM Deadline WHERE ProjectID=1

--query that checks if a project or panel member exist or not
select count(P.ProjectID),count(UserID) FROM Project P,Panel_Member PM WHERE P.ProjectID=3 AND PM.UserID=2

--query that checks that whether a project has a panel or not
select count(ProjectID),count(PanelMemberUserId) FROM Project_PanelMembers PM WHERE ProjectID=3 AND PanelMemberUserId=7

--query that checks for unique students; 1 student can be in only 1 project and project group
select count(su.UserID),count(s1.UserID),count(s2.UserID),count(s3.UserID) from Supervisor su, Student s1, Student s2, Student s3
WHERE su.UserID = 2 AND s1.UserID = 10 AND s2.UserID=11 AND s3.UserID = 12 AND s1.UserID != s2.UserID AND s1.UserID != s3.UserID AND s2.UserID != s3.UserID

--query to display number of fyps assigned to a certain supervisor
select count(Supervisor_UserId) FROM Project where Supervisor_UserId =3
--query to check as to whether a supervisor has a project group or not
select count(Supervisor_UserId),count(Member1_UserId),count(Member2_UserId),count(Member3_UserId) FROM Project
where Supervisor_UserId= 2 AND Member1_UserId = 13 AND Member2_UserId = 14 AND Member3_UserId = 15

--query to check whether a supervisor exists or not
Select count(Supervisor.UserID) FROM Supervisor WHERE UserID=4

--query to check as to whether a supervisor exist and if they exists, do they have project(s) assigned
Select count(s.UserID) FROM Supervisor s, Project p
WHERE s.UserID = 2 AND p.Supervisor_UserId = 2

--query to check if a panel member exists for an existing project
select count(p.ProjectID) from Project p inner join Project_PanelMembers PM on (p.ProjectID=PM.ProjectID)
where p.ProjectID = 4 AND PM.PanelMemberUserId = 19

--query to check if a project has already been evaluated by that panelist
select count(p.Evaluation) from Project_PanelMembers p where p.ProjectID = 3 AND p.PanelMemberUserId = 6

--query to find student 1 of a certain project
select s.UserID from Student s inner join Project p on (s.UserID=p.Member1_UserId)
where p.ProjectID = 1

--query check if a supervisor can suoervise the stated project or not
Select count(s.UserID) from Supervisor s inner join Project p on (s.UserID=p.Supervisor_UserId)
where p.ProjectID = 1 AND s.UserID = 2