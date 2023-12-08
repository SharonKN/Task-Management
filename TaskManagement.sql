USE master

create database TaskManagement

use TaskManagement

CREATE TABLE Priority
(
PriorityID int identity(1,1) Primary key,
PriorityName varchar(255)
)

CREATE TABLE Status
(
StatusID int identity(1,1) Primary Key,
StatusType varchar(255)
)

CREATE TABLE Task
(
TaskID int identity(1,1) Primary Key,
[Description] varchar(255) not null,
StatusType int references Status(StatusID),
StartDate date,
DueDate date,
PriorityID int references Priority(PriorityID)
)

INSERT into [Priority] values
('Important'),
('Semi-important'),
('Not important')

insert into Status values
('To be done'),
('In progress'),
('Completed')

insert into Task values
('sleep', 1, '2023-12-12', '2023-12-13', 1),
('eat', 2, '2023-11-11', '2023-11-12', 2),
('study', 3, '2023-10-10', '2023-10-11', 3)

