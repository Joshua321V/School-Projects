-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: cafebillingsystem
-- ------------------------------------------------------
-- Server version	8.0.42

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
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customers` (
  `CustomerID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Phone` varchar(20) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`CustomerID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (1,'John Lyoid','newemail@email.com','09739374856','Manila'),(2,'Justine','justine94@gmail.com','09369273658','Pasig City'),(3,'Renz','Renz48@gmail.com','09654567424','Manila'),(4,'Jane','Jane383@gmail.com','09478255','Pasig City'),(5,'Benzil','','0956456466','Calloocan'),(6,'Rose','rose32@gmail.com','09453525252','Manila'),(9,'Roa','rpoa@gmail.com','0095673463245','Pasig City'),(10,'kika','kikafas','0946437472434','Rizal');
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `discounts`
--

DROP TABLE IF EXISTS `discounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `discounts` (
  `DiscountID` int NOT NULL AUTO_INCREMENT,
  `DiscountName` varchar(100) DEFAULT NULL,
  `DiscountValue` decimal(5,2) DEFAULT NULL,
  PRIMARY KEY (`DiscountID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `discounts`
--

LOCK TABLES `discounts` WRITE;
/*!40000 ALTER TABLE `discounts` DISABLE KEYS */;
INSERT INTO `discounts` VALUES (1,'Senior Citizen',0.20),(2,'Promo Code',0.10),(3,'Holiday Sale',0.10),(4,'Loyalty Discount',0.05),(5,'Student Promo',0.15);
/*!40000 ALTER TABLE `discounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoicedetails`
--

DROP TABLE IF EXISTS `invoicedetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `invoicedetails` (
  `DetailID` int NOT NULL AUTO_INCREMENT,
  `InvoiceID` int DEFAULT NULL,
  `ProductID` int DEFAULT NULL,
  `Quantity` int DEFAULT NULL,
  `LineTotal` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`DetailID`),
  KEY `idx_product_id` (`ProductID`),
  KEY `idx_invoiceid` (`InvoiceID`),
  KEY `idx_productid` (`ProductID`),
  CONSTRAINT `invoicedetails_ibfk_1` FOREIGN KEY (`InvoiceID`) REFERENCES `invoices` (`InvoiceID`),
  CONSTRAINT `invoicedetails_ibfk_2` FOREIGN KEY (`ProductID`) REFERENCES `products` (`ProductID`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoicedetails`
--

LOCK TABLES `invoicedetails` WRITE;
/*!40000 ALTER TABLE `invoicedetails` DISABLE KEYS */;
INSERT INTO `invoicedetails` VALUES (1,1,1,2,160.00),(2,1,2,1,120.00),(3,2,3,1,110.00),(17,18,3,5,550.00),(18,19,1,4,320.00),(19,20,3,4,440.00),(20,21,3,4,440.00),(21,21,6,6,480.00),(22,21,8,2,150.00),(25,23,3,1,110.00),(26,23,17,2,190.00),(27,23,5,1,50.00),(28,23,6,3,240.00),(31,25,3,1,110.00);
/*!40000 ALTER TABLE `invoicedetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoices`
--

DROP TABLE IF EXISTS `invoices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `invoices` (
  `InvoiceID` int NOT NULL AUTO_INCREMENT,
  `CustomerID` int DEFAULT NULL,
  `InvoiceDate` date DEFAULT NULL,
  `DueDate` date DEFAULT NULL,
  `TotalAmount` decimal(10,2) DEFAULT NULL,
  `Subtotal` decimal(10,2) DEFAULT NULL,
  `ServiceCharge` decimal(10,2) DEFAULT NULL,
  `DiscountAmount` decimal(10,2) DEFAULT NULL,
  `PaymentReceived` decimal(10,2) DEFAULT NULL,
  `ChangeDue` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`InvoiceID`),
  KEY `idx_customer_id` (`CustomerID`),
  KEY `idx_invoice_date` (`InvoiceDate`),
  KEY `idx_customerid` (`CustomerID`),
  CONSTRAINT `invoices_ibfk_1` FOREIGN KEY (`CustomerID`) REFERENCES `customers` (`CustomerID`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoices`
--

LOCK TABLES `invoices` WRITE;
/*!40000 ALTER TABLE `invoices` DISABLE KEYS */;
INSERT INTO `invoices` VALUES (1,1,'2025-06-01','2025-06-02',200.00,NULL,NULL,NULL,NULL,NULL),(2,2,'2025-06-02','2025-06-02',110.00,NULL,NULL,NULL,NULL,NULL),(18,3,'2025-06-16',NULL,577.50,NULL,27.50,0.00,1000.00,422.50),(19,4,'2025-06-16',NULL,336.00,NULL,16.00,0.00,500.00,164.00),(20,5,'2025-06-17',NULL,396.00,NULL,22.00,66.00,500.00,60.00),(21,6,'2025-06-18',NULL,963.00,NULL,53.50,160.50,1000.00,37.00),(23,9,'2025-06-19',NULL,531.00,NULL,29.50,88.50,1000.00,469.00),(25,10,'2025-06-28',NULL,93.50,NULL,5.50,22.00,200.00,106.50);
/*!40000 ALTER TABLE `invoices` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payments`
--

DROP TABLE IF EXISTS `payments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payments` (
  `PaymentID` int NOT NULL AUTO_INCREMENT,
  `InvoiceID` int DEFAULT NULL,
  `AmountPaid` decimal(10,2) DEFAULT NULL,
  `PaymentDate` date DEFAULT NULL,
  `PaymentMethod` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`PaymentID`),
  KEY `InvoiceID` (`InvoiceID`),
  KEY `idx_paymentmethod` (`PaymentMethod`),
  CONSTRAINT `payments_ibfk_1` FOREIGN KEY (`InvoiceID`) REFERENCES `invoices` (`InvoiceID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payments`
--

LOCK TABLES `payments` WRITE;
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
INSERT INTO `payments` VALUES (1,1,200.00,'2025-06-01','Cash'),(2,2,110.00,'2025-06-02','GCash');
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `ProductID` int NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(100) NOT NULL,
  `Description` text,
  `Price` decimal(10,2) NOT NULL,
  PRIMARY KEY (`ProductID`),
  KEY `idx_productname` (`ProductName`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'Brewed Coffee','Freshly brewed hot coffee',80.00),(2,'Cappuccino','Espresso with steamed milk',120.00),(3,'Iced Latte','Cold espresso with milk',110.00),(4,'Latte','Creamy milk and espresso',85.00),(5,'Espresso','Strong coffee shot',50.00),(6,'Mocha','Chocolate coffee blend',80.00),(7,'ValeCoffee','House special coffee',100.00),(8,'Cappuccino','Frothy espresso-based drink',75.00),(9,'Almond Mocha Joy','Hand-made Classics, Hot',105.00),(10,'Milk Tea','Tea with milk and sugar',55.00),(17,'Americano',' espresso and hot water',95.00);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(266) NOT NULL,
  `Role` enum('Admin','Cashier') NOT NULL,
  PRIMARY KEY (`UserID`),
  UNIQUE KEY `Username` (`Username`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (2,'Cashier01','Cashierpass','Cashier'),(4,'Joshua','12345','Admin'),(5,'Ben','123456','Cashier'),(8,'renxo','1234567','Cashier');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-29 15:53:04
