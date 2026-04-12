SELECT c.ClassesId, c.Classname, c.Date, c.Starttime, c.Endtime,
       p.Name, p.Lastname
FROM Classes c
JOIN Trainers t ON c.Trainerid = t.Trainersid
JOIN Personalinfo p ON t.Personid = p.Personid;