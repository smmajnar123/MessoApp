-- Add DOB to Members if not exists
IF COL_LENGTH('Members', 'Dob') IS NULL
BEGIN
    ALTER TABLE Members
    ADD Dob DATE NULL;
END
GO

-- Add DOB to Admins if not exists
IF COL_LENGTH('Admins', 'Dob') IS NULL
BEGIN
    ALTER TABLE Admins
    ADD Dob DATE NULL;
END
GO
