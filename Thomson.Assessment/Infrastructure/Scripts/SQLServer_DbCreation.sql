CREATE DATABASE ThomsonAssessment;
GO
USE ThomsonAssessment;
CREATE TABLE Cases (
    [Number] VARCHAR(25) NOT NULL PRIMARY KEY,
    CourtName VARCHAR(1000) NOT NULL,
    ResponsibleName VARCHAR(1000) NOT NULL,
    RegistrationDate DATETIME NOT NULL DEFAULT(GETDATE())
);