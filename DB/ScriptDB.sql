-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: guardiadb
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `miembro`
--

DROP TABLE IF EXISTS `miembro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `miembro` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) COLLATE utf8mb4_general_ci NOT NULL,
  `Email` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Phone` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Street` varchar(200) COLLATE utf8mb4_general_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=86 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `miembro`
--

LOCK TABLES `miembro` WRITE;
/*!40000 ALTER TABLE `miembro` DISABLE KEYS */;
INSERT INTO `miembro` VALUES (2,'Juan Perez','juan.perez@gmail.com','993265873','Los Frutales 259'),(3,'Maria Gomez','maria.gomez@example.com','993112233','Avenida Siempre Viva 123'),(4,'Luis Martinez','luis.martinez@example.com','993445566','Calle Falsa 456'),(5,'Ana Torres','ana.torres@example.com','993778899','Boulevard de los Sueños 789'),(6,'Carlos Ruiz','carlos.ruiz@example.com','993991122','Camino Real 1011'),(7,'Elena Fernandez','elena.fernandez@example.com','993223344','Ruta 66, km 21'),(8,'Pedro Sanchez','pedro.sanchez@example.com','993556677','Parque Central 1515'),(9,'Lucia Ramirez','lucia.ramirez@example.com','993889900','Plaza Mayor 2020'),(10,'Roberto Diaz','roberto.diaz@example.com','993334455','Callejón del Beso 5'),(11,'Isabel Herrera','isabel.herrera@example.com','993667788','Calle del Prado 303'),(12,'Javier Lopez','javier.lopez@example.com','993223311','Vía Láctea 404'),(13,'Laura Mendoza','laura.mendoza@example.com','994123456','Avenida Las Flores 125'),(14,'Fernando Silva','fernando.silva@example.com','994234567','Calle La Paz 789'),(15,'Patricia Lopez','patricia.lopez@example.com','994345678','Jardines del Valle 56'),(16,'Ricardo Diaz','ricardo.diaz@example.com','994456789','Avenida del Sol 321'),(17,'Sandra Rojas','sandra.rojas@example.com','994567890','Boulevard del Mar 102'),(18,'Miguel Torres','miguel.torres@example.com','994678901','Parque de los Pinos 88'),(19,'Diana Fernandez','diana.fernandez@example.com','994789012','Plaza de Armas 455'),(20,'Jorge Ramirez','jorge.ramirez@example.com','994890123','Callejón del Arco 99'),(21,'Monica Chavez','monica.chavez@example.com','994901234','Avenida Los Robles 222'),(22,'Alejandro Reyes','alejandro.reyes@example.com','995012345','Calle del Comercio 150'),(23,'Gabriela Castillo','gabriela.castillo@example.com','995123456','Avenida Los Sauces 197'),(24,'Jose Ortiz','jose.ortiz@example.com','995234567','Camino de la Sierra 298'),(25,'Beatriz Herrera','beatriz.herrera@example.com','995345678','Boulevard de los Poetas 133'),(26,'Francisco Mendez','francisco.mendez@example.com','995456789','Avenida de la Juventud 467'),(27,'Paula Guzman','paula.guzman@example.com','995567890','Calle de las Artes 312'),(28,'Luis Garcia','luis.garcia@example.com','995678901','Parque Industrial 507'),(29,'Angela Alvarez','angela.alvarez@example.com','995789012','Plaza de los Heroes 245'),(30,'Andres Flores','andres.flores@example.com','995890123','Calle de los Naranjos 365'),(31,'Rosa Morales','rosa.morales@example.com','995901234','Avenida de la Libertad 178'),(32,'Victor Gutierrez','victor.gutierrez@example.com','996012345','Calle de los Tilos 421'),(33,'Veronica Pena','veronica.pena@example.com','996123456','Boulevard del Bosque 299'),(34,'Javier Sosa','javier.sosa@example.com','996234567','Avenida del Maestro 148'),(35,'Marcela Romero','marcela.romero@example.com','996345678','Camino del Rey 512'),(36,'Hugo Navarro','hugo.navarro@example.com','996456789','Calle de las Palmeras 335'),(37,'Alicia Vega','alicia.vega@example.com','996567890','Parque del Sol 478'),(38,'Rodrigo Campos','rodrigo.campos@example.com','996678901','Avenida de las Acacias 209'),(39,'Claudia Fernandez','claudia.fernandez@example.com','996789012','Calle de la Luna 192'),(40,'Martin Rivas','martin.rivas@example.com','996890123','Boulevard del Rio 367'),(41,'Lorena Diaz','lorena.diaz@example.com','996901234','Avenida de la Esperanza 503'),(42,'Felipe Aguilar','felipe.aguilar@example.com','997012345','Calle del Rosario 451'),(43,'Valeria Soto','valeria.soto@example.com','997123456','Plaza de la Estrella 102'),(44,'Ricardo Alvarez','ricardo.alvarez@example.com','997234567','Avenida del Cielo 354'),(45,'Elena Castro','elena.castro@example.com','997345678','Calle de las Camelias 217'),(46,'Carlos Marquez','carlos.marquez@example.com','997456789','Boulevard de la Paz 191'),(47,'Lucia Fernandez','lucia.fernandez@example.com','997567890','Avenida del Libertador 385'),(48,'Julian Vargas','julian.vargas@example.com','997678901','Calle de los Pinos 123'),(49,'Carmen Soto','carmen.soto@example.com','997789012','Parque de las Flores 402'),(50,'Esteban Morales','esteban.morales@example.com','997890123','Avenida de la Luz 241'),(51,'Silvia Rios','silvia.rios@example.com','997901234','Calle de los Laureles 306'),(52,'Diego Lopez Ramirez','diego.lopez123@example.com','998123456','Avenida Las Rosas 321'),(53,'Ana Martinez Torres','ana.martinez456@example.com','998234567','Calle La Esperanza 654'),(54,'Marcos Rodriguez Gomez','marcos.rodriguez789@example.com','998345678','Jardin del Edén 23'),(55,'Lucia Gomez Fernandez','lucia.gomez101@example.com','998456789','Calle Los Aromos 87'),(56,'Roberto Sanchez Diaz','roberto.sanchez202@example.com','998567890','Boulevard Central 405'),(57,'Elena Perez Ruiz','elena.perez303@example.com','998678901','Parque del Norte 19'),(58,'Javier Fernandez Castro','javier.fernandez404@example.com','998789012','Plaza Mayor 112'),(59,'Carmen Ruiz Martinez','carmen.ruiz505@example.com','998890123','Callejón del Sol 76'),(60,'Mario Castro Hernandez','mario.castro606@example.com','998901234','Avenida Libertad 231'),(61,'Valeria Diaz Sanchez','valeria.diaz707@example.com','999012345','Calle de las Flores 456'),(62,'Raul Ramirez Lopez','raul.ramirez808@example.com','999123456','Avenida Siempre Viva 789'),(63,'Andrea Morales Perez','andrea.morales909@example.com','999234567','Jardines del Prado 321'),(64,'Luis Jimenez Torres','luis.jimenez1010@example.com','999345678','Calle Principal 654'),(65,'Beatriz Herrera Gomez','beatriz.herrera1111@example.com','999456789','Avenida de los Pinos 987'),(66,'Carlos Medina Sanchez','carlos.medina1212@example.com','999567890','Calle del Sol 321'),(67,'Patricia Ruiz Diaz','patricia.ruiz1313@example.com','999678901','Boulevard del Mar 654'),(68,'Fernando Gonzalez Lopez','fernando.gonzalez1414@example.com','999789012','Calle La Paz 456'),(69,'Lorena Martinez Gomez','lorena.martinez1515@example.com','999890123','Avenida Central 789'),(70,'Jose Luis Ramirez','jose.luis1616@example.com','999901234','Calle del Arco 321'),(71,'Sofia Torres Fernandez','sofia.torres1717@example.com','991012345','Plaza del Sol 654'),(72,'Ricardo Morales Diaz','ricardo.morales1818@example.com','991123456','Calle La Paz 987'),(73,'Laura Hernandez Ruiz','laura.hernandez1919@example.com','991234567','Avenida del Mar 123'),(74,'Miguel Gomez Sanchez','miguel.gomez2020@example.com','991345678','Calle del Prado 456'),(75,'Elisa Jimenez Martinez','elisa.jimenez2121@example.com','991456789','Parque del Norte 789'),(76,'Antonio Lopez Perez','antonio.lopez2222@example.com','991567890','Calle Principal 321'),(77,'Claudia Ramirez Torres','claudia.ramirez2323@example.com','991678901','Avenida Las Rosas 654'),(78,'Pablo Fernandez Ruiz','pablo.fernandez2424@example.com','991789012','Boulevard Central 987'),(79,'Monica Torres Gomez','monica.torres2525@example.com','991890123','Calle La Esperanza 123'),(80,'Hector Perez Sanchez','hector.perez2626@example.com','991901234','Parque del Prado 456'),(82,'Kasandra Reategui Romero','kasandra.rea.romero@gmail.com','963225588',NULL),(83,'string','string','string','string');
/*!40000 ALTER TABLE `miembro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rol`
--

DROP TABLE IF EXISTS `rol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rol` (
  `RolId` int NOT NULL,
  `Description` varchar(100) NOT NULL,
  `State` tinyint(1) NOT NULL,
  PRIMARY KEY (`RolId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rol`
--

LOCK TABLES `rol` WRITE;
/*!40000 ALTER TABLE `rol` DISABLE KEYS */;
INSERT INTO `rol` VALUES (1,'ADMINISTRADOR',1),(2,'MIEMBRO',0),(3,'VISITANTE',1);
/*!40000 ALTER TABLE `rol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sede`
--

DROP TABLE IF EXISTS `sede`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sede` (
  `SedeId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `Adress` varchar(200) DEFAULT NULL,
  `City` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`SedeId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sede`
--

LOCK TABLES `sede` WRITE;
/*!40000 ALTER TABLE `sede` DISABLE KEYS */;
INSERT INTO `sede` VALUES (1,'ACROPOLIS LIMA','JAVIER PRADO ESTE 974','LIMA'),(2,'ACROPOLIS CHINCHA','AVENIDA CHINCHA 966','CHINCHA'),(3,'ACROPOLIS IQUITOS','AVENIDA QUIÑONES 2388','IQUITOS');
/*!40000 ALTER TABLE `sede` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `UserId` int NOT NULL AUTO_INCREMENT,
  `UserName` varchar(100) NOT NULL,
  `UserPass` varchar(100) NOT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `RolId` int NOT NULL,
  `SedeId` int NOT NULL,
  `State` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`UserId`),
  KEY `Rol_FK` (`RolId`),
  KEY `Sede_FK` (`SedeId`),
  CONSTRAINT `Rol_FK` FOREIGN KEY (`RolId`) REFERENCES `rol` (`RolId`),
  CONSTRAINT `Sede_FK` FOREIGN KEY (`SedeId`) REFERENCES `sede` (`SedeId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Cristian Pérez','Casa12345','cristian@cris.com',1,3,1),(2,'Juan Ortiz','acropolis123','juan@juan.com',2,1,0);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-22 12:57:24
