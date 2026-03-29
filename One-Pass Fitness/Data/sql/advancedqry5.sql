SELECT p.Name, p.Lastname, mi.Enddate
FROM Memberships mi
JOIN Members m ON mi.Memberid = m.Memberid
JOIN Personalinfo p ON m.Personid = p.Personid
WHERE mi.Enddate < CAST(GETDATE() AS date);