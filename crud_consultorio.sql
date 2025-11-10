-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 10-11-2025 a las 22:22:05
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `crud_consultorio`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `paciente`
--

CREATE TABLE `paciente` (
  `Id_Paciente` int(11) NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `Apellido` varchar(50) NOT NULL,
  `Fecha_Nacimiento` varchar(11) NOT NULL,
  `Direccion` varchar(100) DEFAULT NULL,
  `Motivo_Consulta` varchar(255) NOT NULL,
  `Dni` int(11) NOT NULL,
  `Telefono` int(11) DEFAULT NULL,
  `Correo` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `paciente`
--

INSERT INTO `paciente` (`Id_Paciente`, `Nombre`, `Apellido`, `Fecha_Nacimiento`, `Direccion`, `Motivo_Consulta`, `Dni`, `Telefono`, `Correo`) VALUES
(1, 'JULIAN', 'CAPRILE', '10/07/98', 'ABC', 'PSICOLOGIA', 9999, 11111, 'JULIAN'),
(3, 'AAA', 'AAA', '10201998', 'AAA', 'AAA', 114123, 112211, 'AAA@'),
(4, 'AAA', 'AAA', '101010', 'AAA', 'FONIATRA', 101010, 102030, 'AAA@');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `turnos`
--

CREATE TABLE `turnos` (
  `Id_Turno` int(11) NOT NULL,
  `Id_Paciente_FK` int(11) NOT NULL,
  `Fecha` date NOT NULL,
  `Hora` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `turnos`
--

INSERT INTO `turnos` (`Id_Turno`, `Id_Paciente_FK`, `Fecha`, `Hora`) VALUES
(1, 1, '0000-00-00', '09:30:00'),
(2, 1, '0000-00-00', '08:30:00'),
(3, 1, '0000-00-00', '11:00:00');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `paciente`
--
ALTER TABLE `paciente`
  ADD PRIMARY KEY (`Id_Paciente`),
  ADD UNIQUE KEY `Dni` (`Dni`);

--
-- Indices de la tabla `turnos`
--
ALTER TABLE `turnos`
  ADD PRIMARY KEY (`Id_Turno`),
  ADD KEY `Id_Paciente_FK` (`Id_Paciente_FK`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `paciente`
--
ALTER TABLE `paciente`
  MODIFY `Id_Paciente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de la tabla `turnos`
--
ALTER TABLE `turnos`
  MODIFY `Id_Turno` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `turnos`
--
ALTER TABLE `turnos`
  ADD CONSTRAINT `turnos_ibfk_1` FOREIGN KEY (`Id_Paciente_FK`) REFERENCES `paciente` (`Id_Paciente`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
