-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Ven 25 Décembre 2015 à 01:58
-- Version du serveur :  5.6.17
-- Version de PHP :  5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données :  `bd_boris_starsup`
--

DELIMITER $$
--
-- Procédures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `ETOILLE`(IN `Nom_Inspecteur` VARCHAR(30))
BEGIN

      SELECT i.IDINSPECTEUR,i.NOMINSPECTEUR,i.PRENOMINSPECTEUR,NUMEROTEL,LIBSPECIALITE,h.NOMHEBERGEMENT,dv.DATEV,his.ETOILLE 
       FROM inspecteur i INNER JOIN visite v ON i.IDINSPECTEUR=v.IDINSPECTEUR 
       INNER JOIN hebergement h ON v.IDHEBERGEMENT=h.IDHEBERGEMENT 
       INNER JOIN datev dv ON v.IDDATEV=dv.IDDATEV 
       INNER JOIN historique his ON h.IDHEBERGEMENT=his.IDHEBERGEMENT 
       INNER JOIN specialite s ON i.IDSPECIALITEI=s.IDSPECIALITE 
       WHERE v.IDINSPECTEUR=(SELECT i.IDINSPECTEUR FROM inspecteur WHERE NOMINSPECTEUR=Nom_Inspecteur);
       END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `maj_ajout_etoille`(IN `IdHeb` INT(6), IN `IdSais` INT(6), IN `EtoileAj` INT(6))
    NO SQL
BEGIN
        
        DECLARE num int(6) DEFAULT 0;
            IF EXISTS (SELECT * FROM hebergement WHERE IDHEBERGEMENT=IdHeb)
            THEN
            SELECT 'Cet hébergement existe dans la table hebergement';
            IF EXISTS(SELECT * FROM saison WHERE IDSAISON=IdSais)
            THEN
            SELECT 'Cette saison existe dans la table saison';
                IF EXISTS(SELECT * FROM historique WHERE IDHEBERGEMENT=IdHeb AND IDSAISON=IdSais)
                THEN
                SELECT 'Cet identifiant d\'hébergement et cet identifiant de saison sont liés dans la table historique';
                   IF EXISTS(SELECT * FROM historique WHERE IDHEBERGEMENT=IdHeb AND IDSAISON=IdSais AND ETOILLE<6) 
                  THEN
                  SELECT ETOILLE+EtoileAj INTO num FROM historique WHERE IDHEBERGEMENT=IdHeb AND IDSAISON=IdSais;
                IF num<6
                 THEN
            UPDATE historique SET ETOILLE=ETOILLE+EtoileAj WHERE IDHEBERGEMENT=IdHeb AND IDSAISON=IdSais;
            SELECT 'Mise à jour OK--------';
                ELSE
                 UPDATE historique SET ETOILLE=ETOILLE WHERE IDHEBERGEMENT=IdHeb AND IDSAISON=IdSais;
             SELECT 'Etoille reprend sa valeur de base';
            
                END IF;
                ELSE
                SELECT 'Impossible d\'augmenter plus';
                END IF;
        ELSE
        SELECT 'Cet identifiant d\'hébergement et cet identifiant de saison ne sont pas liés dans la table historique';

       END IF;
       ELSE
       SELECT 'Cette saison n\'existe pas dans la table saison';
       END IF;
       ELSE
       SELECT 'Cet hébergement n\'existe pas dans la table hébergement';
       END IF;
       END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `maj_diminuer_etoille`(IN `IdHeb` INT(6), IN `IdSais` INT(6), IN `EtoileAj` INT(6))
BEGIN
        
        DECLARE num int(6) DEFAULT 0;
            IF EXISTS (SELECT * FROM hebergement WHERE IDHEBERGEMENT=IdHeb)
            THEN
            SELECT 'Cet hébergement existe dans la table hebergement';
            IF EXISTS(SELECT * FROM saison WHERE IDSAISON=IdSais)
            THEN
            SELECT 'Cette saison existe dans la table saison';
                IF EXISTS(SELECT * FROM historique WHERE IDHEBERGEMENT=IdHeb AND IDSAISON=IdSais)
                THEN
                SELECT 'Cet identifiant d\'hébergement et cet identifiant de saison sont liés dans la table historique';
                   IF EXISTS(SELECT * FROM historique WHERE IDHEBERGEMENT=IdHeb AND IDSAISON=IdSais AND ETOILLE > 1) 
                  THEN
                  SELECT ETOILLE-EtoileAj INTO num FROM historique WHERE IDHEBERGEMENT=IdHeb AND IDSAISON=IdSais;
                IF num >= 1
                 THEN
            UPDATE historique SET ETOILLE=ETOILLE-EtoileAj WHERE IDHEBERGEMENT=IdHeb AND IDSAISON=IdSais;
            SELECT 'Mise à jour OK--------';
                ELSE
                 UPDATE historique SET ETOILLE=ETOILLE WHERE IDHEBERGEMENT=IdHeb AND IDSAISON=IdSais;
             SELECT 'Etoille reprend sa valeur de base';
            
                END IF;
                ELSE
                SELECT 'Impossible de diminuer plus';
                END IF;
        ELSE
        SELECT 'Cet identifiant d\'hébergement et cet identifiant de saison ne sont pas liés dans la table historique';

       END IF;
       ELSE
       SELECT 'Cette saison n\'existe pas dans la table saison';
       END IF;
       ELSE
       SELECT 'Cet hébergement n\'existe pas dans la table hébergement';
       END IF;
       END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `maj_vm_visites`()
BEGIN
TRUNCATE vm_visites;
INSERT INTO vm_visites
select v.IDVISITE as Identifiant_Visite, v.IDINSPECTEUR as Identifiant_Inspecteur,NOMINSPECTEUR as Nom_Inspecteur,PRENOMINSPECTEUR 
as Prenom_Inspecteur, h.NOMHEBERGEMENT as Nom_Hebergement,ADRESSEHEBERGEMENT as Adresse_Hebergement, DATEV as Date_de_visite,s.IDSAISON as Identifiant_Saison,d.IDDEPARTEMENT 
as Identifiant_Departement, LIBDEPARTEMENT as Nom_Departement from visite v inner join hebergement h on v.IDHEBERGEMENT=h.IDHEBERGEMENT 
inner join historique his on h.IDHEBERGEMENT=his.IDHEBERGEMENT inner join saison s on his.IDSAISON=s.IDSAISON 
inner join datev dv on s.IDSAISON=dv.IDSAISON inner join departement d on h.IDDEPARTEMENT=d.IDDEPARTEMENT 
inner join inspecteur i on v.IDINSPECTEUR=i.IDINSPECTEUR ;
SELECT 'La table a été mise à jour';
end$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `attribuer`
--

CREATE TABLE IF NOT EXISTS `attribuer` (
  `IDHEBERGEMENT` smallint(6) NOT NULL,
  `IDEQUIPEMENT` smallint(6) NOT NULL,
  PRIMARY KEY (`IDHEBERGEMENT`,`IDEQUIPEMENT`),
  KEY `I_FK_ATTRIBUER_CAMPING` (`IDHEBERGEMENT`),
  KEY `I_FK_ATTRIBUER_EQUIPEMENTS` (`IDEQUIPEMENT`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `avoir_gerant`
--

CREATE TABLE IF NOT EXISTS `avoir_gerant` (
  `IDHEBERGEMENT` smallint(6) NOT NULL,
  `IDGERANT` smallint(6) NOT NULL,
  PRIMARY KEY (`IDHEBERGEMENT`,`IDGERANT`),
  KEY `I_FK_AVOIR_GERANT_HEBERGEMENT` (`IDHEBERGEMENT`),
  KEY `I_FK_AVOIR_GERANT_GERANT` (`IDGERANT`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `camping`
--

CREATE TABLE IF NOT EXISTS `camping` (
  `IDHEBERGEMENT` smallint(6) NOT NULL,
  PRIMARY KEY (`IDHEBERGEMENT`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déclencheurs `camping`
--
DROP TRIGGER IF EXISTS `avant_insertion_camping`;
DELIMITER //
CREATE TRIGGER `avant_insertion_camping` BEFORE INSERT ON `camping`
 FOR EACH ROW BEGIN
	  IF EXISTS(SELECT * FROM chambre_hotte WHERE IDHEBERGEMENT=NEW.IDHEBERGEMENT)
	     THEN
	     signal sqlstate '16440' set message_text='Cet hébergement est une chambre_hôte';
	     ELSE
	     IF EXISTS(SELECT * FROM hotel WHERE IDHEBERGEMENT=NEW.IDHEBERGEMENT)
	     THEN
	     signal sqlstate '16440' set message_text='Cet hébergement est un hotel ';
	     END IF;
	     END IF;
         END
//
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `chambre_hotte`
--

CREATE TABLE IF NOT EXISTS `chambre_hotte` (
  `IDHEBERGEMENT` smallint(6) NOT NULL,
  `NBCHAMBRE` int(11) DEFAULT NULL,
  `CUISINE` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`IDHEBERGEMENT`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déclencheurs `chambre_hotte`
--
DROP TRIGGER IF EXISTS `avant_insertion_chambre_hotte`;
DELIMITER //
CREATE TRIGGER `avant_insertion_chambre_hotte` BEFORE INSERT ON `chambre_hotte`
 FOR EACH ROW BEGIN
    IF EXISTS(SELECT * FROM hotel WHERE IDHEBERGEMENT=NEW.IDHEBERGEMENT)
       THEN
       signal sqlstate '16440' set message_text='Cet hébergement est un hotel';
       ELSE
       IF EXISTS(SELECT * FROM camping WHERE IDHEBERGEMENT=NEW.IDHEBERGEMENT)
       THEN
       signal sqlstate '16440' set message_text='Cet hébergement est un camping ';
       END IF;
       END IF;
         END
//
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `contrevisite`
--

CREATE TABLE IF NOT EXISTS `contrevisite` (
  `IDCONTREVISITE` smallint(6) NOT NULL AUTO_INCREMENT,
  `IDINSPECTEUR` smallint(6) NOT NULL,
  `IDDATEV` smallint(6) NOT NULL,
  `IDVISITE` smallint(6) NOT NULL,
  `COMMENTAIRECV` text,
  `NBETOILEMOINS` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`IDCONTREVISITE`),
  KEY `I_FK_CONTREVISITE_INSPECTEUR` (`IDINSPECTEUR`),
  KEY `I_FK_CONTREVISITE_DATEV` (`IDDATEV`),
  KEY `I_FK_CONTREVISITE_VISITE` (`IDVISITE`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Déclencheurs `contrevisite`
--
DROP TRIGGER IF EXISTS `avant_insertion_contre_visite`;
DELIMITER //
CREATE TRIGGER `avant_insertion_contre_visite` BEFORE INSERT ON `contrevisite`
 FOR EACH ROW BEGIN
      DECLARE var int(6) DEFAULT 0;
      SELECT count(*) into var FROM visite WHERE IDVISITE=NEW.IDVISITE AND IDINSPECTEUR=NEW.IDINSPECTEUR  AND IDDATEV=NEW.IDDATEV;

      IF var > 0
      THEN
          signal sqlstate '16440' set message_text='Vous ne pouvez pas insérer cette contre visite: il existe une visite similaire' ;

END IF;
END
//
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `datev`
--

CREATE TABLE IF NOT EXISTS `datev` (
  `IDDATEV` smallint(6) NOT NULL AUTO_INCREMENT,
  `IDSAISON` smallint(6) NOT NULL,
  `DATEV` date DEFAULT NULL,
  PRIMARY KEY (`IDDATEV`),
  KEY `I_FK_DATEV_SAISON` (`IDSAISON`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Contenu de la table `datev`
--

INSERT INTO `datev` (`IDDATEV`, `IDSAISON`, `DATEV`) VALUES
(1, 1, '2015-12-08');

--
-- Déclencheurs `datev`
--
DROP TRIGGER IF EXISTS `avant_insertion_date_visite`;
DELIMITER //
CREATE TRIGGER `avant_insertion_date_visite` BEFORE INSERT ON `datev`
 FOR EACH ROW BEGIN
	  if not exists(SELECT * FROM saison s WHERE s.IDSAISON=NEW.IDSAISON AND YEAR(NEW.DATEV)=ANNEESAISON)
	  THEN

	     signal sqlstate '16440' set message_text='Lannée de la date de visite n est pas la même que celle de la saison' ;
	     END IF;
	     END
//
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `departement`
--

CREATE TABLE IF NOT EXISTS `departement` (
  `IDDEPARTEMENT` smallint(6) NOT NULL AUTO_INCREMENT,
  `NUMDEPARTEMENT` smallint(6) DEFAULT NULL,
  `LIBDEPARTEMENT` char(32) DEFAULT NULL,
  PRIMARY KEY (`IDDEPARTEMENT`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Contenu de la table `departement`
--

INSERT INTO `departement` (`IDDEPARTEMENT`, `NUMDEPARTEMENT`, `LIBDEPARTEMENT`) VALUES
(1, 49, 'Maine-Et-Loire'),
(2, 44, ' Loire-Atlantique');

-- --------------------------------------------------------

--
-- Structure de la table `equipements`
--

CREATE TABLE IF NOT EXISTS `equipements` (
  `IDEQUIPEMENT` smallint(6) NOT NULL AUTO_INCREMENT,
  `NOMEQUIPEMENT` char(32) DEFAULT NULL,
  PRIMARY KEY (`IDEQUIPEMENT`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `gerant`
--

CREATE TABLE IF NOT EXISTS `gerant` (
  `IDGERANT` smallint(6) NOT NULL AUTO_INCREMENT,
  `NOMGERANT` char(32) DEFAULT NULL,
  `PRENOMGERANT` char(32) DEFAULT NULL,
  `TELGERANT` bigint(20) DEFAULT NULL,
  `ADRESSEGERANT` char(32) DEFAULT NULL,
  PRIMARY KEY (`IDGERANT`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `hebergement`
--

CREATE TABLE IF NOT EXISTS `hebergement` (
  `IDHEBERGEMENT` smallint(6) NOT NULL AUTO_INCREMENT,
  `NOMHEBERGEMENT` varchar(30) NOT NULL,
  `IDDEPARTEMENT` smallint(6) NOT NULL,
  `ADRESSEHEBERGEMENT` char(32) DEFAULT NULL,
  `VILLE` char(32) DEFAULT NULL,
  PRIMARY KEY (`IDHEBERGEMENT`),
  KEY `I_FK_HEBERGEMENT_DEPARTEMENT` (`IDDEPARTEMENT`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Contenu de la table `hebergement`
--

INSERT INTO `hebergement` (`IDHEBERGEMENT`, `NOMHEBERGEMENT`, `IDDEPARTEMENT`, `ADRESSEHEBERGEMENT`, `VILLE`) VALUES
(1, 'LES FLINGUETTES', 1, '19 Rue Des Capucins', 'Angers');

--
-- Déclencheurs `hebergement`
--
DROP TRIGGER IF EXISTS `avant_insertion_hebergement`;
DELIMITER //
CREATE TRIGGER `avant_insertion_hebergement` BEFORE INSERT ON `hebergement`
 FOR EACH ROW BEGIN
	       IF EXISTS(SELECT * FROM hebergement WHERE LOWER(ADRESSEHEBERGEMENT)=LOWER(NEW.ADRESSEHEBERGEMENT))
	       THEN
	        signal sqlstate '16440' set message_text='Un hébergement à déjà cette adresse' ;
	        ELSE
	        INSERT INTO hebergement(IDHEBERGEMENT,IDDEPARTEMENT,ADRESSEHEBERGEMENT,VILLE)VALUES(NULL,NEW.IDDEPARTEMENT,NEW.ADRESSEHEBERGEMENT,NEW.VILLE);
	        END IF;
	        END
//
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `historique`
--

CREATE TABLE IF NOT EXISTS `historique` (
  `IDHEBERGEMENT` smallint(6) NOT NULL,
  `IDSAISON` smallint(6) NOT NULL,
  `ETOILLE` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`IDHEBERGEMENT`,`IDSAISON`),
  KEY `I_FK_HISTORIQUE_HEBERGEMENT` (`IDHEBERGEMENT`),
  KEY `I_FK_HISTORIQUE_SAISON` (`IDSAISON`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `historique`
--

INSERT INTO `historique` (`IDHEBERGEMENT`, `IDSAISON`, `ETOILLE`) VALUES
(1, 1, 1);

-- --------------------------------------------------------

--
-- Structure de la table `hotel`
--

CREATE TABLE IF NOT EXISTS `hotel` (
  `IDHEBERGEMENT` smallint(6) NOT NULL,
  PRIMARY KEY (`IDHEBERGEMENT`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `hotel`
--

INSERT INTO `hotel` (`IDHEBERGEMENT`) VALUES
(1);

--
-- Déclencheurs `hotel`
--
DROP TRIGGER IF EXISTS `avant_insertion_hotel`;
DELIMITER //
CREATE TRIGGER `avant_insertion_hotel` BEFORE INSERT ON `hotel`
 FOR EACH ROW BEGIN
    IF EXISTS(SELECT * FROM chambre_hotte WHERE IDHEBERGEMENT=NEW.IDHEBERGEMENT)
       THEN
       signal sqlstate '16440' set message_text='Cet hébergement est une chambre_hôte';
       ELSE
       IF EXISTS(SELECT * FROM camping WHERE IDHEBERGEMENT=NEW.IDHEBERGEMENT)
       THEN
       signal sqlstate '16440' set message_text='Cet hébergement est un camping ';
       END IF;
       END IF;
         END
//
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `inspecteur`
--

CREATE TABLE IF NOT EXISTS `inspecteur` (
  `IDINSPECTEUR` smallint(6) NOT NULL AUTO_INCREMENT,
  `IDSPECIALITEI` smallint(6) NOT NULL,
  `NOMINSPECTEUR` char(32) DEFAULT NULL,
  `PRENOMINSPECTEUR` char(32) DEFAULT NULL,
  `IDDEPARTEMENT` smallint(6) NOT NULL,
  `NUMEROTEL` int(10) unsigned zerofill DEFAULT NULL,
  `MDPINSPECTEUR` varchar(30) NOT NULL,
  PRIMARY KEY (`IDINSPECTEUR`),
  KEY `I_FK_INSPECTEUR_SPECIALITE` (`IDSPECIALITEI`),
  KEY `IDDATEV` (`IDDEPARTEMENT`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Contenu de la table `inspecteur`
--

INSERT INTO `inspecteur` (`IDINSPECTEUR`, `IDSPECIALITEI`, `NOMINSPECTEUR`, `PRENOMINSPECTEUR`, `IDDEPARTEMENT`, `NUMEROTEL`, `MDPINSPECTEUR`) VALUES
(1, 1, 'Flemming', 'David', 1, 0623298517, 'linch'),
(2, 2, 'Minea', 'Douglas', 2, 0623521485, 'douglas');

-- --------------------------------------------------------

--
-- Structure de la table `restaurant`
--

CREATE TABLE IF NOT EXISTS `restaurant` (
  `IDRESTAURANT` char(32) NOT NULL,
  `IDTC` smallint(6) NOT NULL,
  `IDHEBERGEMENT` smallint(6) NOT NULL,
  `CHEF` char(32) DEFAULT NULL,
  PRIMARY KEY (`IDRESTAURANT`),
  KEY `I_FK_RESTAURANT_HOTEL` (`IDHEBERGEMENT`),
  KEY `I_FK_RESTAURANT_TYPE_CUISINE` (`IDTC`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `saison`
--

CREATE TABLE IF NOT EXISTS `saison` (
  `IDSAISON` smallint(6) NOT NULL AUTO_INCREMENT,
  `LIBSAISON` char(32) DEFAULT NULL,
  `ANNEESAISON` year(4) DEFAULT NULL,
  PRIMARY KEY (`IDSAISON`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Contenu de la table `saison`
--

INSERT INTO `saison` (`IDSAISON`, `LIBSAISON`, `ANNEESAISON`) VALUES
(1, 'Les Bleus', 2015);

-- --------------------------------------------------------

--
-- Structure de la table `semaine`
--

CREATE TABLE IF NOT EXISTS `semaine` (
  `IDSEMAINE` smallint(6) NOT NULL AUTO_INCREMENT,
  `DATEDEBUT` date NOT NULL,
  `DATEFIN` date NOT NULL,
  PRIMARY KEY (`IDSEMAINE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

--
-- Déclencheurs `semaine`
--
DROP TRIGGER IF EXISTS `avant_insertion_semaine`;
DELIMITER //
CREATE TRIGGER `avant_insertion_semaine` BEFORE INSERT ON `semaine`
 FOR EACH ROW BEGIN 
   IF NOT EXISTS(SELECT DAYNAME(NEW.DATEDEBUT) = 'Monday' AND DAYNAME(NEW.DATEFIN) = 'Sunday')
   	THEN
   	signal sqlstate'16440' SET message_text='Ajout semaine Impossible: Vérifiez que l'interval est de 7 jours et qu'elle débute un Lundi pour finir un Dimanche';
       END IF;
       END
//
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `specialite`
--

CREATE TABLE IF NOT EXISTS `specialite` (
  `IDSPECIALITE` smallint(6) NOT NULL AUTO_INCREMENT,
  `LIBSPECIALITE` char(32) DEFAULT NULL,
  PRIMARY KEY (`IDSPECIALITE`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Contenu de la table `specialite`
--

INSERT INTO `specialite` (`IDSPECIALITE`, `LIBSPECIALITE`) VALUES
(1, 'Hotel'),
(2, 'Camping'),
(3, 'Chambre hôte');

-- --------------------------------------------------------

--
-- Structure de la table `type_cuisine`
--

CREATE TABLE IF NOT EXISTS `type_cuisine` (
  `IDTC` smallint(6) NOT NULL AUTO_INCREMENT,
  `LIBELLETC` char(32) DEFAULT NULL,
  PRIMARY KEY (`IDTC`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `visite`
--

CREATE TABLE IF NOT EXISTS `visite` (
  `IDVISITE` smallint(6) NOT NULL AUTO_INCREMENT,
  `IDINSPECTEUR` smallint(6) DEFAULT NULL,
  `IDHEBERGEMENT` smallint(6) NOT NULL,
  `IDDATEV` smallint(6) DEFAULT NULL,
  `COMMENTAIREV` text,
  `CONTREVISITE` tinyint(4) DEFAULT NULL,
  `NBETOILEPLUS` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`IDVISITE`),
  KEY `I_FK_VISITE_INSPECTEUR` (`IDINSPECTEUR`),
  KEY `I_FK_VISITE_HEBERGEMENT` (`IDHEBERGEMENT`),
  KEY `I_FK_VISITE_DATEV` (`IDDATEV`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Contenu de la table `visite`
--

INSERT INTO `visite` (`IDVISITE`, `IDINSPECTEUR`, `IDHEBERGEMENT`, `IDDATEV`, `COMMENTAIREV`, `CONTREVISITE`, `NBETOILEPLUS`) VALUES
(1, 1, 1, 1, 'DETHJQETYHJQRYJSRYJSHY', NULL, NULL);

--
-- Déclencheurs `visite`
--
DROP TRIGGER IF EXISTS `avant_insertion_inspecteur`;
DELIMITER //
CREATE TRIGGER `avant_insertion_inspecteur` BEFORE INSERT ON `visite`
 FOR EACH ROW BEGIN
   IF NOT EXISTS( SELECT * FROM inspecteur i inner join hebergement h where i.IDINSPECTEUR=NEW.IDINSPECTEUR AND h.IDHEBERGEMENT=NEW.IDHEBERGEMENT AND  h.IDDEPARTEMENT=i.IDDEPARTEMENT)
      THEN
         signal sqlstate'16440' SET message_text='Visite Impossible: le département de l'inspecteur et de l'hébergement sont différents';
         call maj_vm_visites();
         END IF;
         END
//
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `vm_visites`
--

CREATE TABLE IF NOT EXISTS `vm_visites` (
  `Identifiant_Visite` smallint(6) NOT NULL,
  `Identifiant_Inspecteur` smallint(6) DEFAULT NULL,
  `Nom_Inspecteur` char(32) CHARACTER SET latin1 DEFAULT NULL,
  `Prenom_Inspecteur` char(32) CHARACTER SET latin1 DEFAULT NULL,
  `Nom_Hebergement` varchar(30) CHARACTER SET latin1 NOT NULL,
  `Adresse_Hebergement` varchar(30) NOT NULL,
  `Date_de_visite` date DEFAULT NULL,
  `Identifiant_Saison` smallint(6) NOT NULL DEFAULT '0',
  `Identifiant_Departement` smallint(6) NOT NULL DEFAULT '0',
  `Nom_Departement` char(32) CHARACTER SET latin1 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `vm_visites`
--

INSERT INTO `vm_visites` (`Identifiant_Visite`, `Identifiant_Inspecteur`, `Nom_Inspecteur`, `Prenom_Inspecteur`, `Nom_Hebergement`, `Adresse_Hebergement`, `Date_de_visite`, `Identifiant_Saison`, `Identifiant_Departement`, `Nom_Departement`) VALUES
(1, 1, 'Flemming', 'David', 'LES FLINGUETTES', '19 Rue Des Capucins', '2015-12-08', 1, 1, 'Maine-Et-Loire');

--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `attribuer`
--
ALTER TABLE `attribuer`
  ADD CONSTRAINT `attribuer_ibfk_1` FOREIGN KEY (`IDHEBERGEMENT`) REFERENCES `hebergement` (`IDHEBERGEMENT`),
  ADD CONSTRAINT `attribuer_ibfk_2` FOREIGN KEY (`IDEQUIPEMENT`) REFERENCES `equipements` (`IDEQUIPEMENT`);

--
-- Contraintes pour la table `avoir_gerant`
--
ALTER TABLE `avoir_gerant`
  ADD CONSTRAINT `avoir_gerant_ibfk_1` FOREIGN KEY (`IDHEBERGEMENT`) REFERENCES `hebergement` (`IDHEBERGEMENT`),
  ADD CONSTRAINT `avoir_gerant_ibfk_2` FOREIGN KEY (`IDGERANT`) REFERENCES `gerant` (`IDGERANT`);

--
-- Contraintes pour la table `camping`
--
ALTER TABLE `camping`
  ADD CONSTRAINT `camping_ibfk_1` FOREIGN KEY (`IDHEBERGEMENT`) REFERENCES `hebergement` (`IDHEBERGEMENT`);

--
-- Contraintes pour la table `chambre_hotte`
--
ALTER TABLE `chambre_hotte`
  ADD CONSTRAINT `chambre_hotte_ibfk_1` FOREIGN KEY (`IDHEBERGEMENT`) REFERENCES `hebergement` (`IDHEBERGEMENT`);

--
-- Contraintes pour la table `contrevisite`
--
ALTER TABLE `contrevisite`
  ADD CONSTRAINT `contrevisite_ibfk_1` FOREIGN KEY (`IDINSPECTEUR`) REFERENCES `inspecteur` (`IDINSPECTEUR`),
  ADD CONSTRAINT `contrevisite_ibfk_2` FOREIGN KEY (`IDDATEV`) REFERENCES `datev` (`IDDATEV`),
  ADD CONSTRAINT `contrevisite_ibfk_3` FOREIGN KEY (`IDVISITE`) REFERENCES `visite` (`IDVISITE`);

--
-- Contraintes pour la table `datev`
--
ALTER TABLE `datev`
  ADD CONSTRAINT `datev_ibfk_1` FOREIGN KEY (`IDSAISON`) REFERENCES `saison` (`IDSAISON`);

--
-- Contraintes pour la table `hebergement`
--
ALTER TABLE `hebergement`
  ADD CONSTRAINT `hebergement_ibfk_2` FOREIGN KEY (`IDDEPARTEMENT`) REFERENCES `departement` (`IDDEPARTEMENT`);

--
-- Contraintes pour la table `historique`
--
ALTER TABLE `historique`
  ADD CONSTRAINT `historique_ibfk_1` FOREIGN KEY (`IDHEBERGEMENT`) REFERENCES `hebergement` (`IDHEBERGEMENT`),
  ADD CONSTRAINT `historique_ibfk_2` FOREIGN KEY (`IDSAISON`) REFERENCES `saison` (`IDSAISON`);

--
-- Contraintes pour la table `hotel`
--
ALTER TABLE `hotel`
  ADD CONSTRAINT `hotel_ibfk_1` FOREIGN KEY (`IDHEBERGEMENT`) REFERENCES `hebergement` (`IDHEBERGEMENT`);

--
-- Contraintes pour la table `inspecteur`
--
ALTER TABLE `inspecteur`
  ADD CONSTRAINT `inspecteur_ibfk_1` FOREIGN KEY (`IDSPECIALITEI`) REFERENCES `specialite` (`IDSPECIALITE`),
  ADD CONSTRAINT `inspecteur_ibfk_2` FOREIGN KEY (`IDDEPARTEMENT`) REFERENCES `departement` (`IDDEPARTEMENT`);

--
-- Contraintes pour la table `restaurant`
--
ALTER TABLE `restaurant`
  ADD CONSTRAINT `restaurant_ibfk_1` FOREIGN KEY (`IDTC`) REFERENCES `type_cuisine` (`IDTC`),
  ADD CONSTRAINT `restaurant_ibfk_2` FOREIGN KEY (`IDHEBERGEMENT`) REFERENCES `hebergement` (`IDHEBERGEMENT`);

--
-- Contraintes pour la table `visite`
--
ALTER TABLE `visite`
  ADD CONSTRAINT `visite_ibfk_1` FOREIGN KEY (`IDINSPECTEUR`) REFERENCES `inspecteur` (`IDINSPECTEUR`),
  ADD CONSTRAINT `visite_ibfk_2` FOREIGN KEY (`IDHEBERGEMENT`) REFERENCES `hebergement` (`IDHEBERGEMENT`),
  ADD CONSTRAINT `visite_ibfk_3` FOREIGN KEY (`IDDATEV`) REFERENCES `datev` (`IDDATEV`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
