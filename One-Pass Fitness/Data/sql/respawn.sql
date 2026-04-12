DELETE FROM BookingClasses;
DELETE FROM Membership;
DELETE FROM Classes;
DELETE FROM Members;
DELETE FROM Manager;
DELETE FROM Trainers;
DELETE FROM Personalinfo;

DBCC CHECKIDENT ('BookingClasses', RESEED, 0);
DBCC CHECKIDENT ('Membership', RESEED, 0);
DBCC CHECKIDENT ('Classes', RESEED, 0);
DBCC CHECKIDENT ('Members', RESEED, 0);
DBCC CHECKIDENT ('Manager', RESEED, 0);
DBCC CHECKIDENT ('Trainers', RESEED, 0);
DBCC CHECKIDENT ('Personalinfo', RESEED, 0);

SELECT * FROM Personalinfo;
SELECT * FROM Members;
SELECT * FROM Trainers;
SELECT * FROM Manager;
SELECT * FROM Classes;
SELECT * FROM BookingClasses;
SELECT * FROM Membership;
