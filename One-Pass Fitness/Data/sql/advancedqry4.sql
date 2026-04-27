SELECT c.ClassesId, c.Classname, c.Date, c.Starttime, c.Endtime, c.Availability, r.Role
FROM Classes c
JOIN Roles r ON c.RoleId = r.Rolesid;