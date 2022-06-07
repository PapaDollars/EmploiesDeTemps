-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : mar. 07 juin 2022 à 18:15
-- Version du serveur : 5.7.36
-- Version de PHP : 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `time_management`
--

-- --------------------------------------------------------

--
-- Structure de la table `cours`
--

DROP TABLE IF EXISTS `cours`;
CREATE TABLE IF NOT EXISTS `cours` (
  `IdCours` int(11) NOT NULL AUTO_INCREMENT,
  `Heures` varchar(10) NOT NULL,
  `Dates` date NOT NULL,
  `IdSemC` int(11) NOT NULL,
  `IdJourC` varchar(10) NOT NULL,
  `IdEnsC` varchar(10) NOT NULL,
  `CodeMatC` varchar(10) NOT NULL,
  `CodeSalC` varchar(10) NOT NULL,
  PRIMARY KEY (`IdCours`),
  KEY `IdSemC` (`IdSemC`),
  KEY `IdJourC` (`IdJourC`),
  KEY `IdEnsC` (`IdEnsC`),
  KEY `CodeMatC` (`CodeMatC`),
  KEY `CodeSalC` (`CodeSalC`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `cours`
--

INSERT INTO `cours` (`IdCours`, `Heures`, `Dates`, `IdSemC`, `IdJourC`, `IdEnsC`, `CodeMatC`, `CodeSalC`) VALUES
(1, '11H-13H', '2022-06-01', 1, 'Lundi', '00v0000', 'info310', '250'),
(2, '09H-11H', '2022-06-30', 1, 'Jeudi', '00v0000', 'info104', '350'),
(3, '16H-20H', '2022-06-20', 1, 'Vendredi', '00p0000', 'info211', '250');

-- --------------------------------------------------------

--
-- Structure de la table `enseignant`
--

DROP TABLE IF EXISTS `enseignant`;
CREATE TABLE IF NOT EXISTS `enseignant` (
  `IdEns` varchar(10) NOT NULL,
  `NomEns` varchar(25) NOT NULL,
  `PrenomEns` varchar(25) NOT NULL,
  `SexeEns` varchar(10) NOT NULL,
  `AgeEns` int(3) NOT NULL,
  PRIMARY KEY (`IdEns`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `enseignant`
--

INSERT INTO `enseignant` (`IdEns`, `NomEns`, `PrenomEns`, `SexeEns`, `AgeEns`) VALUES
('00p0000', 'db', 'dollars', 'masculin', 16),
('00v0000', 'db22', 'dollars', 'masculin', 24),
('12k0000', 'fr', 'fanta', 'feminine', 45),
('11p0000', 'db3', 'danielle', 'feminine', 32);

-- --------------------------------------------------------

--
-- Structure de la table `jour`
--

DROP TABLE IF EXISTS `jour`;
CREATE TABLE IF NOT EXISTS `jour` (
  `NumJour` int(10) NOT NULL AUTO_INCREMENT,
  `IdJour` varchar(10) NOT NULL,
  PRIMARY KEY (`NumJour`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `jour`
--

INSERT INTO `jour` (`NumJour`, `IdJour`) VALUES
(1, 'Lundi'),
(2, 'Jeudi');

-- --------------------------------------------------------

--
-- Structure de la table `matiere`
--

DROP TABLE IF EXISTS `matiere`;
CREATE TABLE IF NOT EXISTS `matiere` (
  `CodeMat` varchar(10) NOT NULL,
  `LibMat` varchar(25) NOT NULL,
  PRIMARY KEY (`CodeMat`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `matiere`
--

INSERT INTO `matiere` (`CodeMat`, `LibMat`) VALUES
('info210', 'Base de Donnee'),
('info104', 'architecture'),
('info211', 'systeme');

-- --------------------------------------------------------

--
-- Structure de la table `salle`
--

DROP TABLE IF EXISTS `salle`;
CREATE TABLE IF NOT EXISTS `salle` (
  `CodeSal` int(10) NOT NULL,
  `NomSalle` varchar(25) NOT NULL,
  PRIMARY KEY (`CodeSal`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `salle`
--

INSERT INTO `salle` (`CodeSal`, `NomSalle`) VALUES
(350, 'Amphi'),
(250, 'Amphi');

-- --------------------------------------------------------

--
-- Structure de la table `semaine`
--

DROP TABLE IF EXISTS `semaine`;
CREATE TABLE IF NOT EXISTS `semaine` (
  `NumSem` int(11) NOT NULL AUTO_INCREMENT,
  `IdSem` int(11) NOT NULL,
  `IdJour` varchar(10) NOT NULL,
  `Heures` varchar(10) NOT NULL,
  PRIMARY KEY (`NumSem`),
  KEY `IdJour` (`IdJour`),
  KEY `Heures` (`Heures`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `semaine`
--

INSERT INTO `semaine` (`NumSem`, `IdSem`, `IdJour`, `Heures`) VALUES
(1, 1, 'Lundi', '11H-13H'),
(2, 1, 'Jeudi', '09H-11H'),
(3, 2, 'Lundi', '16H-20H'),
(4, 2, 'Lundi', '11H-13H');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
