SELECT m.Memberid, p.Name, p.Lastname, m.Datejoined, m.Status
FROM Members m
JOIN Personalinfo p ON m.Personid = p.Personid;