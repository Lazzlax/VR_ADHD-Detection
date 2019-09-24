-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 24, 2019 at 03:48 PM
-- Server version: 10.1.26-MariaDB
-- PHP Version: 7.1.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `datacenter`
--

-- --------------------------------------------------------

--
-- Table structure for table `playerdata`
--

CREATE TABLE `playerdata` (
  `id` int(11) NOT NULL,
  `total_Time` float NOT NULL,
  `total_BookCorrRight` int(11) NOT NULL,
  `total_BookCorrLeft` int(11) NOT NULL,
  `total_BookCorrFront` int(11) NOT NULL,
  `total_BookInCorr` int(11) NOT NULL,
  `total_TimeHoldBook` float NOT NULL,
  `total_TimeLookDesk` float NOT NULL,
  `total_TimeLookNonDesk` float NOT NULL,
  `total_InstructionRepeat` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `playerdata`
--

INSERT INTO `playerdata` (`id`, `total_Time`, `total_BookCorrRight`, `total_BookCorrLeft`, `total_BookCorrFront`, `total_BookInCorr`, `total_TimeHoldBook`, `total_TimeLookDesk`, `total_TimeLookNonDesk`, `total_InstructionRepeat`) VALUES
(7334, 141, 6, 5, 26, 2, 80, 64, 77, 2),
(7335, 234, 5, 12, 27, 4, 85, 182, 51, 2),
(7336, 128, 5, 9, 21, 14, 64, 28, 100, 3),
(7337, 181, 9, 5, 40, 0, 45, 6, 175, 2),
(7338, 259, 5, 7, 22, 12, 119, 67, 191, 3),
(7339, 96, 6, 5, 20, 3, 39, 68, 28, 1),
(7340, 91, 7, 5, 24, 1, 45, 37, 53, 0),
(7341, 86, 5, 9, 17, 1, 28, 6, 0, 1),
(7342, 94, 5, 5, 29, 2, 35, 73, 0, 0),
(7343, 147, 7, 5, 18, 1, 44, 103, 2, 1),
(7344, 130, 5, 5, 16, 4, 56, 20, 0, 1),
(7345, 98, 5, 3, 48, 26, 26, 23, 0, 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `playerdata`
--
ALTER TABLE `playerdata`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `playerdata`
--
ALTER TABLE `playerdata`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7346;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
