-- 1. Script para realizar creación de la base de datos de prueba

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'CamilestDB')
BEGIN
	CREATE DATABASE CamilestDB;
END