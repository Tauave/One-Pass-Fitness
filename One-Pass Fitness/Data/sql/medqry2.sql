SELECT t.Trainersid, p.Name, p.Lastname, t.Trainedfield, t.Datehired
FROM Trainers t
JOIN Personalinfo p ON t.Personid = p.Personid;