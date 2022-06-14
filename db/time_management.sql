-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : lun. 13 juin 2022 à 21:46
-- Version du serveur : 10.4.24-MariaDB
-- Version de PHP : 8.1.6

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

CREATE TABLE `cours` (
  `IdCours` int(11) NOT NULL,
  `Heures` varchar(10) NOT NULL,
  `Dates` varchar(50) NOT NULL,
  `IdSemC` int(11) NOT NULL,
  `IdEnsC` varchar(10) NOT NULL,
  `CodeMatC` varchar(10) NOT NULL,
  `CodeSalC` varchar(10) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `cours`
--

INSERT INTO `cours` (`IdCours`, `Heures`, `Dates`, `IdSemC`, `IdEnsC`, `CodeMatC`, `CodeSalC`) VALUES
(7, '16h-19h', 'vendredi 17 juin 2022', 20, '12k0000', 'ICT2022', '250'),
(11, '12h-14h', 'vendredi 17 juin 2022', 2, '00F000', 'info104', '250'),
(10, '12h-14h', 'lundi 13 juin 2022', 1, '11p0000', 'info104', '250');

-- --------------------------------------------------------

--
-- Structure de la table `enseignant`
--

CREATE TABLE `enseignant` (
  `IdEns` varchar(10) NOT NULL,
  `NomEns` varchar(25) NOT NULL,
  `PrenomEns` varchar(25) NOT NULL,
  `SexeEns` varchar(10) NOT NULL,
  `AgeEns` int(3) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `enseignant`
--

INSERT INTO `enseignant` (`IdEns`, `NomEns`, `PrenomEns`, `SexeEns`, `AgeEns`) VALUES
('00p0000', 'db', 'dollars', 'masculin', 16),
('00v0000', 'db22', 'dollars', 'masculin', 24),
('12k0000', 'fr', 'fanta', 'feminine', 45),
('11p0000', 'db3', 'danielle', 'feminine', 32),
('00F000', 'Franck', 'judes', 'Masculin', 36);

-- --------------------------------------------------------

--
-- Structure de la table `matiere`
--

CREATE TABLE `matiere` (
  `CodeMat` varchar(10) NOT NULL,
  `LibMat` varchar(25) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `matiere`
--

INSERT INTO `matiere` (`CodeMat`, `LibMat`) VALUES
('info210', 'Base de Donnee'),
('info104', 'architecture'),
('info211', 'systeme'),
('ICT2022', 'Dev Mobile');

-- --------------------------------------------------------

--
-- Structure de la table `salle`
--

CREATE TABLE `salle` (
  `CodeSal` int(10) NOT NULL,
  `NomSalle` varchar(25) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `salle`
--

INSERT INTO `salle` (`CodeSal`, `NomSalle`) VALUES
(350, 'Amphi'),
(250, 'Amphi1020');

-- --------------------------------------------------------

--
-- Structure de la table `semaine`
--

CREATE TABLE `semaine` (
  `NumSem` int(11) NOT NULL,
  `IdSem` int(11) NOT NULL,
  `IdJour` varchar(10) NOT NULL,
  `Heures` varchar(10) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `semaine`
--

INSERT INTO `semaine` (`NumSem`, `IdSem`, `IdJour`, `Heures`) VALUES
(1, 1, 'Lundi', '11H-13H'),
(20, 6, 'samedi', '12h-14h'),
(11, 10, '22', '12h'),
(2, 20, '2', '12h-14h');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `cours`
--
ALTER TABLE `cours`
  ADD PRIMARY KEY (`IdCours`),
  ADD KEY `IdSemC` (`IdSemC`),
  ADD KEY `IdEnsC` (`IdEnsC`),
  ADD KEY `CodeMatC` (`CodeMatC`),
  ADD KEY `CodeSalC` (`CodeSalC`);

--
-- Index pour la table `enseignant`
--
ALTER TABLE `enseignant`
  ADD PRIMARY KEY (`IdEns`);

--
-- Index pour la table `matiere`
--
ALTER TABLE `matiere`
  ADD PRIMARY KEY (`CodeMat`);

--
-- Index pour la table `salle`
--
ALTER TABLE `salle`
  ADD PRIMARY KEY (`CodeSal`);

--
-- Index pour la table `semaine`
--
ALTER TABLE `semaine`
  ADD PRIMARY KEY (`NumSem`),
  ADD KEY `IdJour` (`IdJour`),
  ADD KEY `Heures` (`Heures`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `cours`
--
ALTER TABLE `cours`
  MODIFY `IdCours` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT pour la table `semaine`
--
ALTER TABLE `semaine`
  MODIFY `NumSem` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
