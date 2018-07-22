CREATE DATABASE  IF NOT EXISTS `blockchain_certificates` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `blockchain_certificates`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: blockchain_certificates
-- ------------------------------------------------------
-- Server version	8.0.11

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `completion`
--

DROP TABLE IF EXISTS `completion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `completion` (
  `studentId` varchar(45) NOT NULL,
  `courseId` varchar(45) NOT NULL,
  `grade` int(11) NOT NULL,
  `semester` varchar(45) NOT NULL,
  `year` varchar(45) NOT NULL,
  PRIMARY KEY (`studentId`,`courseId`),
  KEY `courseId_idx` (`courseId`),
  CONSTRAINT `courseId` FOREIGN KEY (`courseId`) REFERENCES `course` (`id`),
  CONSTRAINT `studentId` FOREIGN KEY (`studentId`) REFERENCES `student` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `completion`
--

LOCK TABLES `completion` WRITE;
/*!40000 ALTER TABLE `completion` DISABLE KEYS */;
/*!40000 ALTER TABLE `completion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `course`
--

DROP TABLE IF EXISTS `course`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `course` (
  `id` varchar(45) NOT NULL,
  `name` varchar(45) NOT NULL,
  `program` varchar(45) NOT NULL,
  `room` varchar(45) NOT NULL,
  `capacity` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `course`
--

LOCK TABLES `course` WRITE;
/*!40000 ALTER TABLE `course` DISABLE KEYS */;
/*!40000 ALTER TABLE `course` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `student` (
  `id` varchar(45) NOT NULL,
  `firstname` varchar(45) NOT NULL,
  `lastname` varchar(45) NOT NULL,
  `imageUrl` varchar(500) NOT NULL,
  `program` varchar(45) NOT NULL,
  `avgGrade` int(11) NOT NULL,
  `certIssued` tinyint(1) NOT NULL DEFAULT '0',
  `certIssueDate` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student`
--

LOCK TABLES `student` WRITE;
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` VALUES ('09a52661-9f65-4e8c-b81b-68318dd819be','Gabriel','Bottari','https://media.licdn.com/dms/image/C5603AQFrkBvhVGp5Sg/profile-displayphoto-shrink_200_200/0?e=1534377600&v=beta&t=EqqVkZLbiJLxTGaXhekh5vnrzrD5p3P6GlTgV9GpJJQ','Software Engineering',78,0,''),('0b2db115-7f2c-40e2-b68e-6584e8f29c17','Martin','Grogan','https://media.licdn.com/dms/image/C4E03AQHN1TETLDA2Cw/profile-displayphoto-shrink_800_800/0?e=1534377600&v=beta&t=k58fV-QKQV8ZsSCQhtl6F0nLF8FmZtNPtplrSMV7CCI','Computer Science',89,0,''),('2f87412e-30a4-4ecb-ba74-2acabe5d087d','Pascal','Leblanc','https://media.licdn.com/dms/image/C5603AQF72cLe2sQVLg/profile-displayphoto-shrink_800_800/0?e=1534377600&v=beta&t=rYalvNur7p8E5IZgNGUJXyyv-AE93IIOxInVMY1brXY','Computer Science',76,0,''),('afbc50b2-0827-4125-abf2-0b05f0d402ff','Simon','Lacoursiere','https://media.licdn.com/dms/image/C5603AQGaXE74aPfyZg/profile-displayphoto-shrink_800_800/0?e=1534377600&v=beta&t=PUPuoFTfwZkRvaMXNYv8kP4sPvpB5nIuDI1KSAQ1-X8','Computer Science',56,0,''),('d056dd3d-d1cb-444b-a4b4-57f652e998aa','Arnaud','Gorain','https://media.licdn.com/dms/image/C4E03AQGxjS1fV1z5zg/profile-displayphoto-shrink_800_800/0?e=1534377600&v=beta&t=5hoPXTLvk73VuYWc1lbC0XY7Enowu-0rSaDgS7GjFIY','Software Engineering',92,0,''),('f557c42a-3e17-4498-bdbe-2663f3092099','Yann','Thibodeau','https://media.licdn.com/dms/image/C4E03AQFtS6wNRrC3bg/profile-displayphoto-shrink_800_800/0?e=1534377600&v=beta&t=7Jr2wfBxCvTR0Y4YCNK4DTcyIaSM9VGNLFPjq9z1Y7M','Computer Science',100,0,'');
/*!40000 ALTER TABLE `student` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-07-22 16:36:05
