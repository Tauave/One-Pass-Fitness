SELECT mi.MembershipInfoid, p.Name, p.Lastname, mi.Startdate, mi.Enddate
FROM Memberships mi
JOIN Members m ON mi.Memberid = m.Memberid
JOIN Personalinfo p ON m.Personid = p.Personid;