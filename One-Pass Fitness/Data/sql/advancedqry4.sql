SELECT p.Name, p.Lastname, m.Status
FROM Members m
JOIN Personalinfo p ON m.Personid = p.Personid
WHERE m.Status = 'Active';