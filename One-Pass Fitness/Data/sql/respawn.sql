DELETE FROM BookingClasses;
DELETE FROM Memberships;
DELETE FROM Admin;
DELETE FROM Classes;
DELETE FROM Trainers;
DELETE FROM Members;
DELETE FROM Personalinfo;

DBCC CHECKIDENT ('BookingClasses', RESEED, 0);
DBCC CHECKIDENT ('Memberships', RESEED, 0);
DBCC CHECKIDENT ('Admin', RESEED, 0);
DBCC CHECKIDENT ('Classes', RESEED, 0);
DBCC CHECKIDENT ('Trainers', RESEED, 0);
DBCC CHECKIDENT ('Members', RESEED, 0);
DBCC CHECKIDENT ('Personalinfo', RESEED, 0);

SELECT * FROM Personalinfo;
SELECT * FROM Members;
SELECT * FROM Trainers;
SELECT * FROM Classes;
SELECT * FROM BookingClasses;
SELECT * FROM Admin;
SELECT * FROM Memberships;