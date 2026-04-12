SELECT mi.Membershipid, mi.MembershipType, p.Name, p.Lastname, mi.Startdate, mi.Enddate, mi.Price
FROM Membership mi
JOIN Members m ON mi.Memberid = m.Memberid
JOIN Personalinfo p ON m.Personid = p.Personalinfoid;
