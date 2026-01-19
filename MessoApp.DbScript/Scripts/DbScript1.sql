-- ========================================
-- DATABASE : MessManagementDB
-- ========================================

-- ========================
-- Admins Table
-- ========================
IF OBJECT_ID('Admins', 'U') IS NULL
BEGIN
    CREATE TABLE Admins (
        AdminId INT IDENTITY(1,1) PRIMARY KEY,

        AdminName VARCHAR(100) NOT NULL,
        MobileNumber VARCHAR(15),
        EmailId VARCHAR(100),
        Gender VARCHAR(10) DEFAULT 'Male',
        Address VARCHAR(200),

        TotalMemberCount INT DEFAULT 0,
        TotalActiveMemberCount INT DEFAULT 0,
        TotalInActiveMemberCount INT DEFAULT 0,

        Subscription VARCHAR(50) DEFAULT '1 Month Free',
        SubscriptionPrice DECIMAL(10,2) DEFAULT 0.00,
        SubscriptionStartDate DATE DEFAULT GETDATE(),
        SubscriptionRemainingDays INT DEFAULT 30
    );
END
GO

-- ========================
-- Messes Table
-- ========================
IF OBJECT_ID('Messes', 'U') IS NULL
BEGIN
    CREATE TABLE Messes (
        MessId INT IDENTITY(1,1) PRIMARY KEY,
        AdminId INT NOT NULL,

        MessName VARCHAR(100) NOT NULL,
        MessAddress VARCHAR(200),
        MessGender VARCHAR(10) DEFAULT 'Mixed',

        MembersCount INT DEFAULT 0,
        ActiveMemberCount INT DEFAULT 0,
        InActiveMemberCount INT DEFAULT 0,

        IsActive BIT DEFAULT 1,

        CONSTRAINT FK_Messes_Admins
            FOREIGN KEY (AdminId) REFERENCES Admins(AdminId)
    );
END
GO

-- ========================
-- Members Table
-- ========================
IF OBJECT_ID('Members', 'U') IS NULL
BEGIN
    CREATE TABLE Members (
        MemberId INT IDENTITY(1,1) PRIMARY KEY,
        MessId INT NOT NULL,

        MemberName VARCHAR(100) NOT NULL,
        MobileNumber VARCHAR(15),
        EmailId VARCHAR(100),
        Gender VARCHAR(10) DEFAULT 'Male',
        Address VARCHAR(200),

        IsActive BIT DEFAULT 1,
        JoinedDate DATETIME DEFAULT GETDATE(),

        MessType VARCHAR(20) DEFAULT 'Monthly',
        MemberCategory VARCHAR(20) DEFAULT 'Student',
        MonthlyPrice DECIMAL(10,2) DEFAULT 0.00,

        LeaveDays INT DEFAULT 0,
        TotalTiffinCount INT DEFAULT 0,
        RemainingLunchDays INT DEFAULT 0,
        ExtraLunchDays INT DEFAULT 0,

        CONSTRAINT FK_Members_Messes
            FOREIGN KEY (MessId) REFERENCES Messes(MessId)
    );
END
GO

-- ========================
-- MemberTransactions Table
-- ========================
IF OBJECT_ID('MemberTransactions', 'U') IS NULL
BEGIN
    CREATE TABLE MemberTransactions (
        MemberTransactionId INT IDENTITY(1,1) PRIMARY KEY,

        MemberId INT NOT NULL,
        TransactionDate DATETIME DEFAULT GETDATE(),
        Amount DECIMAL(10,2) NOT NULL,

        PaymentMode VARCHAR(20) DEFAULT 'Cash',
        PaymentStatus VARCHAR(20) DEFAULT 'Paid',

        Remarks VARCHAR(200),

        CONSTRAINT FK_MemberTransactions_Members 
            FOREIGN KEY (MemberId) REFERENCES Members(MemberId),
    );
END
GO

-- ========================
-- Admin Subscription Payments Table
-- ========================
IF OBJECT_ID('AdminSubscriptionPayments', 'U') IS NULL
BEGIN
    CREATE TABLE AdminSubscriptionPayments (
        SubscriptionPaymentId INT IDENTITY(1,1) PRIMARY KEY,

        AdminId INT NOT NULL,

        PaymentDate DATETIME DEFAULT GETDATE(),
        Amount DECIMAL(10,2) NOT NULL,

        SubscriptionPlan VARCHAR(50) DEFAULT 'Monthly',
        PlanDurationDays INT DEFAULT 30,

        PaymentMode VARCHAR(20) DEFAULT 'UPI',
        PaymentStatus VARCHAR(20) DEFAULT 'Paid',

        StartDate DATE DEFAULT GETDATE(),
        EndDate DATE DEFAULT DATEADD(DAY, 30, GETDATE()),

        Remarks VARCHAR(200),

        CONSTRAINT FK_AdminSubscriptionPayments_Admins
            FOREIGN KEY (AdminId) REFERENCES Admins(AdminId)
    );
END
GO

-- ========================================
-- SAMPLE DATA INSERTS
-- ========================================

-- Admins
INSERT INTO Admins (AdminName, MobileNumber, EmailId, Address)
VALUES
('Sachin Manjanar', '9876543210', 'sachin@gmail.com', 'Pune'),
('Rahul Patil', '9822334455', 'rahul@gmail.com', 'Mumbai');

-- Messes
INSERT INTO Messes (AdminId, MessName, MessAddress, MessGender)
VALUES
(1, 'Sai Mess', 'Shivaji Nagar Pune', 'Boys'),
(1, 'Krishna Mess', 'Hadapsar Pune', 'Mixed'),
(2, 'Patil Mess', 'Andheri Mumbai', 'Boys');

-- Members
INSERT INTO Members
(MessId, MemberName, MobileNumber, EmailId, Gender, Address, MonthlyPrice)
VALUES
(1, 'Amit Sharma', '9000011111', 'amit@gmail.com', 'Male', 'Pune', 2500),
(1, 'Rohit Verma', '9000022222', 'rohit@gmail.com', 'Male', 'Pune', 3000),
(2, 'Priya Singh', '9000033333', 'priya@gmail.com', 'Female', 'Pune', 2800),
(3, 'Neha Patil', '9000044444', 'neha@gmail.com', 'Female', 'Mumbai', 2700);

-- Member Transactions
INSERT INTO MemberTransactions
(MemberId, Amount, PaymentMode, Remarks)
VALUES
(1, 2500, 'UPI', 'January Fees'),
(2, 3000, 'Cash', 'January Fees'),
(3, 2800, 'UPI', 'January Fees'),
(4, 2700, 'Card', 'January Fees');

-- Admin Subscription Payments
INSERT INTO AdminSubscriptionPayments
(AdminId, Amount, SubscriptionPlan, PlanDurationDays, PaymentMode, StartDate, EndDate, Remarks)
VALUES
(1, 0, 'Free Trial', 30, 'Free', GETDATE(), DATEADD(DAY,30,GETDATE()), 'Free Trial'),
(1, 499, 'Monthly', 30, 'UPI', DATEADD(DAY,31,GETDATE()), DATEADD(DAY,61,GETDATE()), 'Monthly Renewal'),
(2, 999, 'Quarterly', 90, 'Card', GETDATE(), DATEADD(DAY,90,GETDATE()), '3 Month Plan');
