Use master
go
Create Database Test
go
USE [Test] 
go

CREATE TABLE [dbo].[TipoPermisos](
	[Id] [int] NOT NULL,
	[Descripcion] [varchar](125) NOT NULL,
 CONSTRAINT [PK_TipoPermiso] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
) 
go

CREATE TABLE [dbo].[Permisos](
	[Id] [int] NOT NULL identity (1,1),
	[NombreEmpleado] [varchar](30) NOT NULL,
	[ApellidosEmpleado] [varchar](45) NOT NULL,
	[TipoPermiso] [int] NOT NULL,
	[FechaPermiso] [date] NOT NULL,
	 CONSTRAINT [PK_Permisos] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
) ON [PRIMARY]
go
ALTER TABLE [dbo].[Permisos]  WITH CHECK ADD  CONSTRAINT [FK_Permisos_TipoPermiso] FOREIGN KEY([TipoPermiso])
REFERENCES [dbo].[TipoPermisos] ([Id])
go
ALTER TABLE [dbo].[Permisos] CHECK CONSTRAINT [FK_Permisos_TipoPermiso]