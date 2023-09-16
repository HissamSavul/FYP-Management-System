create database DBProject
use DBProject

------------------------------DROPPING TABLES----------------------------
DROP TABLE Deadline
DROP TABLE Project_PanelMembers
DROP TABLE Project
DROP TABLE Notifications
DROP TABLE Audit_Records
DROP TABLE Student
DROP TABLE Committee_Member
DROP TABLE Supervisor
DROP TABLE Panel_Member
DROP TABLE Users

drop trigger Insert_Audit1
DROP trigger Insert_Audit2
DROP trigger Insert_Audit3
DROP trigger Insert_Audit4

------------------------------TABLE CREATION----------------------------
CREATE TABLE Users(
	UserID numeric(5) NOT NULL,
	UserName varchar(20) UNIQUE NOT NULL,
	UserPassWord varchar(20) NOT NULL,
	FirstName varchar(10) NOT NULL,
	LastName varchar(10) NOT NULL,
	PRIMARY KEY (UserID),
);

CREATE TABLE Panel_Member(
	UserID numeric(5) NOT NULL,
	PRIMARY KEY (UserID),
	FOREIGN KEY (UserID) REFERENCES Users(UserID),
);

CREATE TABLE Supervisor(
	UserID numeric(5) NOT NULL,
	NumFYP numeric(2) DEFAULT 0 NOT NULL,
	PRIMARY KEY (UserID),
	FOREIGN KEY (UserID) REFERENCES Users(UserID),
);

CREATE TABLE Committee_Member(
	UserID numeric(5) NOT NULL,
	PRIMARY KEY (UserID),
	FOREIGN KEY (UserID) REFERENCES Users(UserID),	
);

CREATE TABLE Student(
	UserID numeric(5) NOT NULL,
	StudentGrade varchar(2),
	PRIMARY KEY (UserID),
	FOREIGN KEY (UserID) REFERENCES Users(UserID),
);

CREATE TABLE Audit_Records(
	RecordAction varchar(50) NOT NULL,
	RecordDate date NOT NULL
);

CREATE TABLE Notifications(
	Supervisor_UserID numeric(5) NOT NULL,
	NotificationMessage varchar(100)
	PRIMARY KEY(Supervisor_UserID, NotificationMessage),
	FOREIGN KEY(Supervisor_UserID) REFERENCES Supervisor(UserID),
);

CREATE TABLE Project(
	ProjectID numeric(5) NOT NULL,
	Supervisor_UserId numeric(5) NOT NULL,
	Member1_UserId numeric(5) NOT NULL,
	Member2_UserId numeric(5) NOT NULL,
	Member3_UserId numeric(5) NOT NULL,
	Review varchar(100),
	PRIMARY KEY(ProjectId),
	FOREIGN KEY (Supervisor_UserId) REFERENCES Supervisor(UserID),
	FOREIGN KEY (Member1_UserId) REFERENCES Student(UserID),
	FOREIGN KEY (Member2_UserId) REFERENCES Student(UserID),
	FOREIGN KEY (Member3_UserId) REFERENCES Student(UserID),
);

--TABLE FOR MULTIVALUED ATTRIBUE-->PANELMEMBERS OF THE ENTITY PROJECT
CREATE TABLE Project_PanelMembers(
	ProjectID numeric(5) NOT NULL,
	PanelMemberUserId numeric(5) NOT NULL,
	Evaluation VARCHAR(100),
	PRIMARY KEY (ProjectID, PanelMemberUserId),
	FOREIGN KEY (ProjectID) REFERENCES Project(ProjectID),
	FOREIGN KEY (PanelMemberUserId) REFERENCES Panel_Member(UserID),
);
CREATE TABLE Deadline(
	ProjectID numeric(5) NOT NULL,
	DeadlineDate date,
	DeadlineTime time,
	PRIMARY KEY(ProjectID),
	FOREIGN KEY (ProjectID) REFERENCES Project(ProjectID),
);


----------------------------- TRIGGERS -----------------------------------
GO
CREATE TRIGGER Insert_Audit1 ON Users AFTER INSERT
AS
BEGIN
	
	DECLARE @UserID varchar(10)
	SELECT @UserID = UserID FROM INSERTED

	INSERT INTO Audit_Records VALUES('New User ID#' + @UserID +' was created',getdate());

END


GO
CREATE TRIGGER Insert_Audit2 ON Notifications AFTER INSERT
AS
BEGIN
	
	DECLARE @UserID varchar
	SELECT @UserID = Supervisor_UserID FROM INSERTED

	INSERT INTO Audit_Records VALUES('New Notification for supervisor#'+@UserID+' was added',getdate());
END


GO
CREATE TRIGGER Insert_Audit3 ON Deadline AFTER INSERT
AS
BEGIN
	
	DECLARE @projId varchar
	SELECT @projId = ProjectID FROM INSERTED

	INSERT INTO Audit_Records VALUES('Deadline for project#'+@projId+' was added',getdate());
END



GO
CREATE TRIGGER Insert_Audit4 ON Project AFTER INSERT
AS
BEGIN
	
	DECLARE @projId varchar
	SELECT @projId = ProjectID FROM INSERTED

	INSERT INTO Audit_Records VALUES('Project #'+@projId+' was added',getdate());

END