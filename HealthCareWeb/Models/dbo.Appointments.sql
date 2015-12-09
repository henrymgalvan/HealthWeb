CREATE TABLE [dbo].[Appointments] (
    [AppointID]   INT            IDENTITY (1, 1) NOT NULL,
    [PatientName] NVARCHAR (MAX) NULL,
    [DoctorName]  NVARCHAR (MAX) NULL,
    [UserId]      NVARCHAR (MAX) NULL,
    [description] NVARCHAR (MAX) NULL,
    [Time]        DATETIME       DEFAULT ('1900-01-01T00:00:00.000') NOT NULL,
    CONSTRAINT [PK_dbo.Appointments] PRIMARY KEY CLUSTERED ([AppointID] ASC)
);

