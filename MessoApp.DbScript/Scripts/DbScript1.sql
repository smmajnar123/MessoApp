---------------------------------------------------
-- Admins table
---------------------------------------------------
CREATE TABLE dbo.Admins
(
    AdminId INT IDENTITY(1,1) CONSTRAINT PK_Admins PRIMARY KEY,
    AdminName NVARCHAR(200) NOT NULL,
    MobileNumber NVARCHAR(15) NOT NULL,
    EmailId NVARCHAR(100) NOT NULL,
    Gender NVARCHAR(10) CHECK (Gender IN ('Male','Female','Other')),
    Address NVARCHAR(500),
    Dob DATE,
    PasswordHash NVARCHAR(500) NOT NULL DEFAULT '',
    CONSTRAINT UQ_Admins_Email UNIQUE (EmailId),
    CONSTRAINT UQ_Admins_Mobile UNIQUE (MobileNumber)
);
GO

---------------------------------------------------
-- MemberProfiles table
---------------------------------------------------
CREATE TABLE dbo.MemberProfiles
(
    ProfileId INT IDENTITY(1,1) CONSTRAINT PK_MemberProfiles PRIMARY KEY,
    MemberName NVARCHAR(200) NOT NULL,
    MobileNumber NVARCHAR(15),
    EmailId NVARCHAR(100),
    Gender NVARCHAR(10) CHECK (Gender IN ('Male','Female','Other')),
    Address NVARCHAR(500),
    Dob DATE,
    PasswordHash NVARCHAR(500) NOT NULL DEFAULT '',
    AdminId INT NOT NULL,
    CONSTRAINT FK_MemberProfiles_Admins 
        FOREIGN KEY (AdminId) REFERENCES dbo.Admins(AdminId)
);
GO

---------------------------------------------------
-- Messes table
---------------------------------------------------
CREATE TABLE dbo.Messes
(
    MessId INT IDENTITY(1,1) CONSTRAINT PK_Messes PRIMARY KEY,
    AdminId INT NOT NULL,
    MessName NVARCHAR(100) NOT NULL,
    MessAddress NVARCHAR(200),
    MessMobile NVARCHAR(15),
    MessEmail NVARCHAR(100),
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Messes_Admins 
        FOREIGN KEY (AdminId) REFERENCES dbo.Admins(AdminId)
);
GO

---------------------------------------------------
-- MemberMessDetails table
---------------------------------------------------
CREATE TABLE dbo.MemberMessDetails
(
    MemberMessDetailId INT IDENTITY(1,1) CONSTRAINT PK_MemberMessDetails PRIMARY KEY,
    ProfileId INT NOT NULL,
    MessId INT NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    JoinedDate DATE,
    MessType NVARCHAR(50) CHECK (MessType IN ('Veg','Non-Veg')),
    MemberCategory NVARCHAR(50),
    MonthlyPrice DECIMAL(18,2) CHECK (MonthlyPrice >= 0),
    LeaveDays INT DEFAULT 0 CHECK (LeaveDays >= 0),
    TotalTiffinCount INT CHECK (TotalTiffinCount >= 0),
    RemainingTiffinDays INT CHECK (RemainingTiffinDays >= 0),
    ExtraTiffinDays INT DEFAULT 0 CHECK (ExtraTiffinDays >= 0),
    CONSTRAINT FK_MemberMessDetails_MemberProfiles 
        FOREIGN KEY (ProfileId) REFERENCES dbo.MemberProfiles(ProfileId),
    CONSTRAINT FK_MemberMessDetails_Messes 
        FOREIGN KEY (MessId) REFERENCES dbo.Messes(MessId)
);
GO

---------------------------------------------------
-- MemberTransactions table
---------------------------------------------------
CREATE TABLE dbo.MemberTransactions
(
    MemberTransactionId INT IDENTITY(1,1) CONSTRAINT PK_MemberTransactions PRIMARY KEY,
    MemberMessDetailId INT NOT NULL,
    MessId INT NOT NULL,
    TransactionDate DATETIME NOT NULL DEFAULT GETDATE(),
    Amount DECIMAL(18,2) CHECK (Amount >= 0),
    PaymentMode NVARCHAR(50),
    PaymentStatus NVARCHAR(50) CHECK (PaymentStatus IN ('Paid','Pending','Failed')),
    Remarks NVARCHAR(500),
    TotalPaidAmount DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (TotalPaidAmount >= 0),
    RemainingAmount DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (RemainingAmount >= 0),
    CONSTRAINT FK_MemberTransactions_MemberMessDetails 
        FOREIGN KEY (MemberMessDetailId) REFERENCES dbo.MemberMessDetails(MemberMessDetailId),
    CONSTRAINT FK_MemberTransactions_Messes 
        FOREIGN KEY (MessId) REFERENCES dbo.Messes(MessId)
);
GO

---------------------------------------------------
-- AdminSubscriptionDetails table
---------------------------------------------------
CREATE TABLE dbo.AdminSubscriptionDetails
(
    SubscriptionPaymentId INT IDENTITY(1,1) CONSTRAINT PK_AdminSubscriptionDetails PRIMARY KEY,
    AdminId INT NOT NULL,
    PaymentDate DATETIME NOT NULL DEFAULT GETDATE(),
    Amount DECIMAL(10,2) NOT NULL CHECK (Amount > 0),
    SubscriptionPlan NVARCHAR(50) NOT NULL DEFAULT 'Monthly',
    PlanDurationDays INT NOT NULL DEFAULT 30 CHECK (PlanDurationDays > 0),
    PaymentMode NVARCHAR(20) NOT NULL DEFAULT 'UPI',
    PaymentStatus NVARCHAR(20) NOT NULL DEFAULT 'Paid',
    StartDate DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    EndDate DATE NOT NULL DEFAULT CAST(DATEADD(DAY, 30, GETDATE()) AS DATE),
    Remarks NVARCHAR(200),
    CONSTRAINT FK_AdminSubscriptionDetails_Admins 
        FOREIGN KEY (AdminId) REFERENCES dbo.Admins(AdminId)
);
GO

---------------------------------------------------
PRINT '✅ Database created successfully';
PRINT '🚀 All tables, constraints, and checks applied';

---------------------------------------------------
-- Insert Admins
---------------------------------------------------
INSERT INTO dbo.Admins
(AdminName, MobileNumber, EmailId, Gender, Address, Dob, PasswordHash)
VALUES
('Neha Sharma', '9876543210', 'neha.sharma@example.com', 'Female', '123 Main Street, City', '1990-05-10', 'HASHED_PASSWORD_1'),
('Ravi Kumar', '9123456780', 'ravi.kumar@example.com', 'Male', '456 Elm Street, City', '1985-11-22', 'HASHED_PASSWORD_2');
GO

---------------------------------------------------
-- Insert Messes
---------------------------------------------------
INSERT INTO dbo.Messes
(AdminId, MessName, MessAddress, MessMobile, MessEmail, IsActive)
VALUES
(1, 'City Center Mess', '101 City Plaza, City', '9998887776', 'citycenter@example.com', 1),
(2, 'Green Garden Mess', '202 Green Lane, City', '8887776665', 'greengarden@example.com', 1);
GO

---------------------------------------------------
-- Insert MemberProfiles
---------------------------------------------------
INSERT INTO dbo.MemberProfiles
(MemberName, MobileNumber, EmailId, Gender, Address, Dob, AdminId)
VALUES
('John Doe', '9001122334', 'john.doe@example.com', 'Male', '12 Baker Street, City', '1995-03-15', 1),
('Priya Singh', '9011223344', 'priya.singh@example.com', 'Female', '34 Rose Avenue, City', '1998-07-20', 1),
('Amit Patel', '9022334455', 'amit.patel@example.com', 'Male', '56 Lake Road, City', '1992-12-10', 2);
GO

---------------------------------------------------
-- Insert MemberMessDetails
---------------------------------------------------
INSERT INTO dbo.MemberMessDetails
(ProfileId, MessId, IsActive, JoinedDate, MessType, MemberCategory,
 MonthlyPrice, LeaveDays, TotalTiffinCount, RemainingTiffinDays, ExtraTiffinDays)
VALUES
(1, 1, 1, '2026-01-01', 'Veg', 'Regular', 1500.00, 2, 30, 28, 0),
(2, 1, 1, '2026-01-05', 'Non-Veg', 'Premium', 2000.00, 0, 30, 30, 0),
(3, 2, 1, '2026-01-10', 'Veg', 'Regular', 1500.00, 1, 30, 29, 1);
GO

---------------------------------------------------
-- Insert MemberTransactions
---------------------------------------------------
INSERT INTO dbo.MemberTransactions
(MemberMessDetailId, MessId, Amount, PaymentMode, PaymentStatus,
 Remarks, TotalPaidAmount, RemainingAmount)
VALUES
(1, 1, 1500.00, 'UPI', 'Paid', 'January payment', 1500.00, 0),
(2, 1, 2000.00, 'Cash', 'Paid', 'January payment', 2000.00, 0),
(3, 2, 1500.00, 'UPI', 'Pending', 'January payment', 0, 1500.00);
GO

---------------------------------------------------
-- Insert AdminSubscriptionDetails
---------------------------------------------------
INSERT INTO dbo.AdminSubscriptionDetails
(AdminId, Amount, SubscriptionPlan, PlanDurationDays,
 PaymentMode, PaymentStatus, Remarks)
VALUES
(1, 5000.00, 'Monthly', 30, 'UPI', 'Paid', 'January subscription'),
(2, 10000.00, 'Monthly', 30, 'Cash', 'Paid', 'January subscription');
GO

---------------------------------------------------
PRINT '✅ Dummy data inserted successfully';
