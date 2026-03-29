SELECT p.Name, p.Lastname, COUNT(c.ClassesId) AS TotalClasses
FROM Trainers t
JOIN Personalinfo p ON t.Personid = p.Personid
LEFT JOIN Classes c ON t.Trainersid = c.Trainerid
GROUP BY p.Name, p.Lastname;