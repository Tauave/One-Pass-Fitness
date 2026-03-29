SELECT c.Classname, COUNT(b.BookingClassesId) AS TotalBookings
FROM Classes c
LEFT JOIN BookingClasses b ON c.ClassesId = b.Classid
GROUP BY c.Classname;