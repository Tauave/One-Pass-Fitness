SELECT b.BookingClassesId, p.Name, p.Lastname, c.Classname, b.Bookingdate, b.Attendancestatus
FROM BookingClasses b
JOIN Members m ON b.Memberid = m.Memberid
JOIN Personalinfo p ON m.Personid = p.Personid
JOIN Classes c ON b.Classid = c.ClassesId;