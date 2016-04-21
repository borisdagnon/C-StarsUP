-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Lun 18 Avril 2016 à 16:35
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
CREATE DEFINER=`root`@`localhost` PROCEDURE `maj_ajout_etoille`(IN `IdVisite` INT(6), IN `EtoileAj` INT(6))
BEGIN
            IF EXISTS (SELECT * FROM visite WHERE IDVISITE=IdVisite)
            THEN
           
                   IF EXISTS(SELECT * FROM historique WHERE IDVISITE=IdVisite AND ETOILLE<6) 
                  THEN
                  
                IF EXISTS(SELECT * FROM historique WHERE IDVISITE=IdVisite AND ETOILLE+EtoileAj<6)

                 THEN
            UPDATE historique SET ETOILLE=ETOILLE+EtoileAj WHERE IDVISITE=IdVisite ;
            
                ELSE
                 UPDATE historique SET ETOILLE=ETOILLE WHERE IDVISITE=IdVisite;
            
       END IF;      
       END IF;
       END IF;
       END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `maj_diminuer_etoille`(IN IdVisite smallint(6), IN EtoileAj smallint(6))
BEGIN
        
        DECLARE num int(6) DEFAULT 0;
            IF EXISTS (SELECT * FROM visite WHERE IDVISITE=IdVisite)
            THEN
    
                   IF EXISTS(SELECT * FROM historique WHERE IDVISITE=IdVisite AND ETOILLE > 1) 
                  THEN
                IF EXISTS(SELECT * FROM historique WHERE IDVISITE=IdVisite AND ETOILLE-EtoileAj>= 1)
                 THEN
            UPDATE historique SET ETOILLE=ETOILLE-EtoileAj WHERE IDVISITE=IdVisite;
                ELSE
                 UPDATE historique SET ETOILLE=ETOILLE WHERE IDVISITE=IdVisite;
       END IF;
                  
       END IF;
        END IF;
       END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `maj_vm_contrevisite`()
    NO SQL
BEGIN
TRUNCATE vm_contrevisite;
INSERT INTO vm_contrevisite
SELECT IDCONTREVISITE AS Identifiant_Contrevisite, i.IDINSPECTEUR AS Identifiant_Inspecteur, 
NOMINSPECTEUR AS Nom_Inspecteur, PRENOMINSPECTEUR AS Prenom_Inspecteur, NOMHEBERGEMENT AS Nom_Hebergement, 
ADRESSEHEBERGEMENT AS Adress_Hebergement, DATEV AS Date_de_visite, s.IDSAISON AS Identifiant_Saison,
 d.IDDEPARTEMENT AS Identifiant_Departement, LIBDEPARTEMENT AS Nom_Departement, LIBSAISON AS Nom_Saison, 
 YEAR(DATEV) AS Annee_Date_Visite FROM contrevisite c INNER JOIN inspecteur i ON c.IDINSPECTEUR=i.IDINSPECTEUR
INNER JOIN saison s ON c.IDSAISON=s.IDSAISON
INNER JOIN visite v ON v.IDVISITE=c.IDVISITE
INNER JOIN hebergement h ON h.IDHEBERGEMENT=v.IDHEBERGEMENT
INNER JOIN datev dv ON v.IDDATEV=dv.IDDATEV
INNER JOIN departement d ON d.IDDEPARTEMENT=h.IDDEPARTEMENT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `maj_vm_saison`()
BEGIN
TRUNCATE vm_saison;
INSERT INTO vm_saison
SELECT s.IDSAISON AS Identifiant_Saison,s.LIBSAISON AS Nom_Saison,s_a.ANNEE AS Annee_Saison, NOMINSPECTEUR AS Nom_Inspecteur
FROM inspecteur i INNER JOIN visite v ON v.IDINSPECTEUR = i.IDINSPECTEUR 
INNER JOIN hebergement h ON h.IDHEBERGEMENT = v.IDHEBERGEMENT 
INNER JOIN datev d_v ON v.IDDATEV = d_v.IDDATEV 
INNER JOIN saison s ON s.IDSAISON = v.IDSAISON 
INNER JOIN saison_annee s_a ON s_a.IDSAISON = v.IDSAISON 
WHERE ANNEE = YEAR(DATEV);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `maj_vm_visites`()
BEGIN
TRUNCATE vm_visites;
INSERT INTO vm_visites
select IDVISITE AS Identifiant_Visite,v.IDINSPECTEUR AS Identifiant_Inspecteur,NOMINSPECTEUR 
AS Nom_Inspecteur,PRENOMINSPECTEUR AS Prenom_Inspecteur,NOMHEBERGEMENT 
AS Nom_Hebergement,ADRESSEHEBERGEMENT 
AS Adresse_Hebergement,DATEV 
AS Date_de_visite,s.IDSAISON 
AS Identifiant_Saison,h.IDDEPARTEMENT 
AS Identifiant_Departement,LIBDEPARTEMENT 
AS Nom_Departement, LIBSAISON AS Nom_Saison,YEAR(DATEV) AS Annee_Date_Visite
FROM visite v INNER JOIN datev dv ON v.IDDATEV=dv.IDDATEV 
INNER JOIN inspecteur i ON i.IDINSPECTEUR=v.IDINSPECTEUR 
INNER JOIN saison_annee s_a ON v.IDSAISON=s_a.IDSAISON 
INNER JOIN saison s ON s.IDSAISON=v.IDSAISON 
INNER JOIN hebergement h ON h.IDHEBERGEMENT=v.IDHEBERGEMENT 
INNER JOIN departement d ON d.IDDEPARTEMENT=h.IDDEPARTEMENT WHERE ANNEE=YEAR(DATEV);
SELECT 'La table a été mise à jour';
end$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `annee`
--

CREATE TABLE IF NOT EXISTS `annee` (
  `ANNEE` year(4) NOT NULL,
  PRIMARY KEY (`ANNEE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `annee`
--

INSERT INTO `annee` (`ANNEE`) VALUES
(2015),
(2016),
(2017),
(2018);

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

--
-- Contenu de la table `attribuer`
--

INSERT INTO `attribuer` (`IDHEBERGEMENT`, `IDEQUIPEMENT`) VALUES
(2, 1);

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

--
-- Contenu de la table `avoir_gerant`
--

INSERT INTO `avoir_gerant` (`IDHEBERGEMENT`, `IDGERANT`) VALUES
(2, 1);

-- --------------------------------------------------------

--
-- Structure de la table `camping`
--

CREATE TABLE IF NOT EXISTS `camping` (
  `IDHEBERGEMENT` smallint(6) NOT NULL,
  PRIMARY KEY (`IDHEBERGEMENT`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `camping`
--

INSERT INTO `camping` (`IDHEBERGEMENT`) VALUES
(2),
(5);

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
-- Contenu de la table `chambre_hotte`
--

INSERT INTO `chambre_hotte` (`IDHEBERGEMENT`, `NBCHAMBRE`, `CUISINE`) VALUES
(3, 4, NULL);

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
  `IDSAISON` smallint(6) NOT NULL,
  `IDVISITE` smallint(6) NOT NULL,
  `COMMENTAIRECV` text,
  `NBETOILEMOINS` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`IDCONTREVISITE`),
  KEY `I_FK_CONTREVISITE_INSPECTEUR` (`IDINSPECTEUR`),
  KEY `I_FK_CONTREVISITE_DATEV` (`IDSAISON`),
  KEY `I_FK_CONTREVISITE_VISITE` (`IDVISITE`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Déclencheurs `contrevisite`
--
DROP TRIGGER IF EXISTS `avant_insertion_contre_visite`;
DELIMITER //
CREATE TRIGGER `avant_insertion_contre_visite` BEFORE INSERT ON `contrevisite`
 FOR EACH ROW BEGIN
     DECLARE var smallint(6) DEFAULT 0;
     DECLARE var2 smallint(6) DEFAULT 0;
     DECLARE nom_spe varchar(30) DEFAULT '';
      SELECT IDDEPARTEMENT INTO var FROM inspecteur WHERE IDINSPECTEUR=NEW.IDINSPECTEUR;
      SELECT IDHEBERGEMENT INTO var2 FROM visite WHERE IDVISITE=NEW.IDVISITE;
      SELECT (LIBSPECIALITE) INTO nom_spe FROM inspecteur i INNER JOIN specialite s ON i.IDSPECIALITEI=s.IDSPECIALITE WHERE i.IDINSPECTEUR=NEW.IDINSPECTEUR;


IF EXISTS(SELECT * FROM visite WHERE IDVISITE=NEW.IDVISITE AND IDINSPECTEUR=NEW.IDINSPECTEUR  AND IDSAISON=NEW.IDSAISON AND CONTREVISITE=0)
     
      THEN
      
          signal sqlstate '16440' SET message_text='Soit il existe une visite similaire soit l\'option CONTREVISITE=0';

             END IF;

             IF NOT EXISTS(SELECT * FROM hebergement h INNER JOIN visite v ON v.IDHEBERGEMENT=h.IDHEBERGEMENT WHERE v.IDVISITE=NEW.IDVISITE AND IDDEPARTEMENT=var)

             THEN 
             signal sqlstate'16440' SET message_text='Visite Impossible: le département de l\'inspecteur et de l\'hébergement sont différents';
              END IF;

          IF nom_spe='Hotel'
          THEN
                                         IF NOT EXISTS(SELECT * FROM hotel WHERE IDHEBERGEMENT=var2) 
                                         THEN
                                                  
                                                       signal sqlstate '16440' SET message_text='L\'hébergement ne correspond pas à la specialité de l\'inspecteur' ;
                                          END IF;

            ELSE
            IF nom_spe='Camping'
                          THEN
                                         IF NOT EXISTS(SELECT * FROM camping WHERE IDHEBERGEMENT=var2)
                                        THEN
                                           signal sqlstate '16440' SET message_text='L\'hébergement ne correspond pas à la specialité de l\'inspecteur' ;
                                          END IF;                
            ELSE
            IF nom_spe='Chambre hôte'
                           THEN
                                          IF NOT EXISTS(SELECT * FROM chambre_hotte WHERE IDHEBERGEMENT=var2)
                                          THEN
                                           signal sqlstate '16440' SET message_text='L\'hébergement ne correspond pas à la specialité de l\'inspecteur' ;
                                         END IF;
                       END IF;


 END IF;
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
  `DATEV` date DEFAULT NULL,
  PRIMARY KEY (`IDDATEV`),
  UNIQUE KEY `DATEV` (`DATEV`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Contenu de la table `datev`
--

INSERT INTO `datev` (`IDDATEV`, `DATEV`) VALUES
(1, '2015-12-08'),
(2, '2016-03-11'),
(3, '2016-04-18'),
(4, '2016-04-19'),
(5, '2016-04-20'),
(6, '2016-04-21'),
(7, '2016-04-22');

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Contenu de la table `equipements`
--

INSERT INTO `equipements` (`IDEQUIPEMENT`, `NOMEQUIPEMENT`) VALUES
(1, 'Chauffage Mobile'),
(2, 'Poste Radio'),
(3, 'Télévision 4k');

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Contenu de la table `gerant`
--

INSERT INTO `gerant` (`IDGERANT`, `NOMGERANT`, `PRENOMGERANT`, `TELGERANT`, `ADRESSEGERANT`) VALUES
(1, 'Callou', 'Roger', 623958474, '12 Rue Des Philippines'),
(2, 'Diams', 'Greg', 623258414, '45 Rue Des Molières');

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=9 ;

--
-- Contenu de la table `hebergement`
--

INSERT INTO `hebergement` (`IDHEBERGEMENT`, `NOMHEBERGEMENT`, `IDDEPARTEMENT`, `ADRESSEHEBERGEMENT`, `VILLE`) VALUES
(1, 'LES FLINGUETTES', 1, '19 Rue Des Capucins', 'Angers'),
(2, 'Les Callanques', 1, '18 Rue De Oliveras', '  Le May-sur-Èvre'),
(3, 'Les Dammières', 2, '1 Avenue Brasières', 'Vertou'),
(4, 'La Passadona', 1, '5 Rue Des Collines', '  Saumur'),
(5, 'La Gullerma', 2, '6 Rue Rémal', ' Bouguenais'),
(6, 'L''Everton', 1, '10 Avenue Symbale', '   Doué-la-Fontaine'),
(7, 'L''Iliade', 1, 'La Rue Des Florandes', 'Chemillé'),
(8, 'Dial', 2, 'Rue Tassigni', 'Carquefou');

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
          
          END IF;
          END
//
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `historique`
--

CREATE TABLE IF NOT EXISTS `historique` (
  `IDVISITE` smallint(6) NOT NULL,
  `ETOILLE` smallint(6) NOT NULL,
  PRIMARY KEY (`IDVISITE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `historique`
--

INSERT INTO `historique` (`IDVISITE`, `ETOILLE`) VALUES
(1, 5),
(2, 1),
(3, 4);

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
(1),
(4),
(6),
(7);

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
-- Structure de la table `image`
--

CREATE TABLE IF NOT EXISTS `image` (
  `idImage` int(11) NOT NULL AUTO_INCREMENT,
  `nomImage` varchar(40) DEFAULT NULL,
  `pathImage` varchar(100) NOT NULL,
  `IDINSPECTEUR` smallint(6) NOT NULL,
  PRIMARY KEY (`idImage`),
  KEY `IDINSPECTEUR` (`IDINSPECTEUR`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=8 ;

--
-- Contenu de la table `image`
--

INSERT INTO `image` (`idImage`, `nomImage`, `pathImage`, `IDINSPECTEUR`) VALUES
(7, 'Grey2.jpg', 'C:\\StarsUP\\Images\\', 1);

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
  UNIQUE KEY `IDINSPECTEUR` (`IDINSPECTEUR`,`IDDEPARTEMENT`),
  KEY `I_FK_INSPECTEUR_SPECIALITE` (`IDSPECIALITEI`),
  KEY `IDDATEV` (`IDDEPARTEMENT`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Contenu de la table `inspecteur`
--

INSERT INTO `inspecteur` (`IDINSPECTEUR`, `IDSPECIALITEI`, `NOMINSPECTEUR`, `PRENOMINSPECTEUR`, `IDDEPARTEMENT`, `NUMEROTEL`, `MDPINSPECTEUR`) VALUES
(1, 1, 'Flemming', 'Bob', 1, 0623298541, 'linch'),
(2, 2, 'Minea', 'Douglas', 2, 0623521485, 'douglas'),
(3, 3, 'Prince', 'Jacob', 2, 0745126325, 'gladiator'),
(4, 1, 'Mauriah', 'Alexandre', 1, 0745851265, 'uquino'),
(5, 1, 'Lham', 'Freddy', 2, 0652147852, 'lham');

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
  PRIMARY KEY (`IDSAISON`),
  UNIQUE KEY `LIBSAISON` (`LIBSAISON`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Contenu de la table `saison`
--

INSERT INTO `saison` (`IDSAISON`, `LIBSAISON`) VALUES
(4, 'Automne'),
(2, 'Été'),
(3, 'Hiver'),
(1, 'Printemps');

-- --------------------------------------------------------

--
-- Structure de la table `saison_annee`
--

CREATE TABLE IF NOT EXISTS `saison_annee` (
  `IDSAISON` smallint(6) NOT NULL,
  `ANNEE` year(4) NOT NULL,
  PRIMARY KEY (`IDSAISON`,`ANNEE`),
  KEY `ANNEE` (`ANNEE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `saison_annee`
--

INSERT INTO `saison_annee` (`IDSAISON`, `ANNEE`) VALUES
(1, 2015),
(2, 2015),
(3, 2015),
(4, 2015),
(1, 2016),
(2, 2016),
(3, 2016),
(4, 2016);

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Contenu de la table `type_cuisine`
--

INSERT INTO `type_cuisine` (`IDTC`, `LIBELLETC`) VALUES
(1, 'Chinoise'),
(2, 'Allemande');

-- --------------------------------------------------------

--
-- Structure de la table `visite`
--

CREATE TABLE IF NOT EXISTS `visite` (
  `IDVISITE` smallint(6) NOT NULL AUTO_INCREMENT,
  `IDINSPECTEUR` smallint(6) DEFAULT NULL,
  `IDHEBERGEMENT` smallint(6) NOT NULL,
  `IDDATEV` smallint(6) DEFAULT NULL,
  `IDSAISON` smallint(6) DEFAULT NULL,
  `COMMENTAIREV` text CHARACTER SET utf8,
  `CONTREVISITE` tinyint(1) DEFAULT NULL,
  `NBETOILEPLUS` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`IDVISITE`),
  KEY `I_FK_VISITE_INSPECTEUR` (`IDINSPECTEUR`),
  KEY `I_FK_VISITE_HEBERGEMENT` (`IDHEBERGEMENT`),
  KEY `I_FK_VISITE_DATEV` (`IDDATEV`),
  KEY `IDSAISON` (`IDSAISON`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Contenu de la table `visite`
--

INSERT INTO `visite` (`IDVISITE`, `IDINSPECTEUR`, `IDHEBERGEMENT`, `IDDATEV`, `IDSAISON`, `COMMENTAIREV`, `CONTREVISITE`, `NBETOILEPLUS`) VALUES
(1, 1, 1, 1, 1, 'Blblblblblblbllbl', 1, NULL),
(2, 2, 5, 2, 2, 'jgcfjgfghfydb', 1, 4),
(3, 1, 6, 2, 3, 'Boris', 0, NULL),
(4, 1, 7, 7, 4, NULL, NULL, NULL);

--
-- Déclencheurs `visite`
--
DROP TRIGGER IF EXISTS `avant_insertion_visite`;
DELIMITER //
CREATE TRIGGER `avant_insertion_visite` BEFORE INSERT ON `visite`
 FOR EACH ROW BEGIN


          DECLARE nom_spe varchar(30) DEFAULT '';
          SELECT (LIBSPECIALITE) INTO nom_spe FROM inspecteur i INNER JOIN specialite s ON i.IDSPECIALITEI=s.IDSPECIALITE WHERE i.IDINSPECTEUR=NEW.IDINSPECTEUR;
          
           IF NOT EXISTS( SELECT * FROM inspecteur i inner join hebergement h where i.IDINSPECTEUR=NEW.IDINSPECTEUR AND h.IDHEBERGEMENT=NEW.IDHEBERGEMENT AND h.IDDEPARTEMENT=i.IDDEPARTEMENT)
             THEN 
             signal sqlstate'16440' SET message_text='Visite Impossible: le département de l\'inspecteur et de l\'hébergement sont différents';
             ELSE

          IF nom_spe='Hotel'
          THEN
                                         IF NOT EXISTS(SELECT * FROM hotel WHERE IDHEBERGEMENT=NEW.IDHEBERGEMENT) 
                                         THEN
                                                  
                                                       signal sqlstate '16440' SET message_text='L\'hébergement ne correspond pas à la specialité de l\'inspecteur' ;
                                          END IF;

            ELSE
            IF nom_spe='Camping'
                          THEN
                                         IF NOT EXISTS(SELECT * FROM camping WHERE IDHEBERGEMENT=NEW.IDHEBERGEMENT)
                                        THEN
                                           signal sqlstate '16440' SET message_text='L\'hébergement ne correspond pas à la specialité de l\'inspecteur' ;
                                          END IF;                
            ELSE
            IF nom_spe='Chambre hôte'
                           THEN
                                          IF NOT EXISTS(SELECT * FROM chambre_hotte WHERE IDHEBERGEMENT=NEW.IDHEBERGEMENT)
                                          THEN
                                           signal sqlstate '16440' SET message_text='L\'hébergement ne correspond pas à la specialité de l\'inspecteur' ;
                                         END IF;
                       END IF;
 END IF;

 END IF;
 END IF;
 IF EXISTS(SELECT * FROM visite WHERE IDINSPECTEUR=NEW.IDINSPECTEUR AND IDHEBERGEMENT=NEW.IDHEBERGEMENT AND IDSAISON=NEW.IDSAISON)
 THEN
 
     signal sqlstate '16440' SET message_text='Cette cobinaison existe déjà' ;
 
           END IF;
  END
//
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `vm_contrevisite`
--

CREATE TABLE IF NOT EXISTS `vm_contrevisite` (
  `Identifiant_Contrevisite` smallint(6) DEFAULT NULL,
  `Identifiant_Inspecteur` smallint(6) DEFAULT NULL,
  `Nom_Inspecteur` char(32) DEFAULT NULL,
  `Prenom_Inspecteur` char(32) DEFAULT NULL,
  `Nom_Hebergement` varchar(30) DEFAULT NULL,
  `Adresse_Hebergement` varchar(30) DEFAULT NULL,
  `Date_de_visite` date DEFAULT NULL,
  `Identifiant_Saison` smallint(6) DEFAULT NULL,
  `Identifiant_Departement` smallint(6) DEFAULT NULL,
  `Nom_Departement` char(32) DEFAULT NULL,
  `Nom_Saison` char(32) DEFAULT NULL,
  `Annee_Date_Visite` year(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `vm_saison`
--

CREATE TABLE IF NOT EXISTS `vm_saison` (
  `Identifiant_Saison` int(11) NOT NULL,
  `Nom_Saison` char(32) DEFAULT NULL,
  `Annee_Saison` year(4) NOT NULL,
  `Nom_Inspecteur` char(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `vm_saison`
--

INSERT INTO `vm_saison` (`Identifiant_Saison`, `Nom_Saison`, `Annee_Saison`, `Nom_Inspecteur`) VALUES
(1, 'Printemps', 2015, 'Flemming'),
(2, 'Été', 2016, 'Minea'),
(3, 'Hiver', 2016, 'Flemming');

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
  `Nom_Departement` char(32) CHARACTER SET latin1 DEFAULT NULL,
  `Nom_Saison` char(32) NOT NULL,
  `Annee_Date_Visite` year(4) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `vm_visites`
--

INSERT INTO `vm_visites` (`Identifiant_Visite`, `Identifiant_Inspecteur`, `Nom_Inspecteur`, `Prenom_Inspecteur`, `Nom_Hebergement`, `Adresse_Hebergement`, `Date_de_visite`, `Identifiant_Saison`, `Identifiant_Departement`, `Nom_Departement`, `Nom_Saison`, `Annee_Date_Visite`) VALUES
(1, 1, 'Flemming', 'Bob', 'LES FLINGUETTES', '19 Rue Des Capucins', '2015-12-08', 1, 1, 'Maine-Et-Loire', 'Printemps', 2015),
(3, 1, 'Flemming', 'Bob', 'L''Everton', '10 Avenue Symbale', '2016-03-11', 3, 1, 'Maine-Et-Loire', 'Hiver', 2016),
(2, 2, 'Minea', 'Douglas', 'La Gullerma', '6 Rue Rémal', '2016-03-11', 2, 2, ' Loire-Atlantique', 'Été', 2016);

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
  ADD CONSTRAINT `contrevisite_ibfk_2` FOREIGN KEY (`IDSAISON`) REFERENCES `saison` (`IDSAISON`),
  ADD CONSTRAINT `contrevisite_ibfk_3` FOREIGN KEY (`IDVISITE`) REFERENCES `visite` (`IDVISITE`);

--
-- Contraintes pour la table `hebergement`
--
ALTER TABLE `hebergement`
  ADD CONSTRAINT `hebergement_ibfk_2` FOREIGN KEY (`IDDEPARTEMENT`) REFERENCES `departement` (`IDDEPARTEMENT`);

--
-- Contraintes pour la table `historique`
--
ALTER TABLE `historique`
  ADD CONSTRAINT `historique_ibfk_1` FOREIGN KEY (`IDVISITE`) REFERENCES `visite` (`IDVISITE`);

--
-- Contraintes pour la table `hotel`
--
ALTER TABLE `hotel`
  ADD CONSTRAINT `hotel_ibfk_1` FOREIGN KEY (`IDHEBERGEMENT`) REFERENCES `hebergement` (`IDHEBERGEMENT`);

--
-- Contraintes pour la table `image`
--
ALTER TABLE `image`
  ADD CONSTRAINT `image_ibfk_1` FOREIGN KEY (`IDINSPECTEUR`) REFERENCES `inspecteur` (`IDINSPECTEUR`);

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
-- Contraintes pour la table `saison_annee`
--
ALTER TABLE `saison_annee`
  ADD CONSTRAINT `saison_annee_ibfk_1` FOREIGN KEY (`IDSAISON`) REFERENCES `saison` (`IDSAISON`),
  ADD CONSTRAINT `saison_annee_ibfk_2` FOREIGN KEY (`ANNEE`) REFERENCES `annee` (`ANNEE`);

--
-- Contraintes pour la table `visite`
--
ALTER TABLE `visite`
  ADD CONSTRAINT `visite_ibfk_1` FOREIGN KEY (`IDINSPECTEUR`) REFERENCES `inspecteur` (`IDINSPECTEUR`),
  ADD CONSTRAINT `visite_ibfk_2` FOREIGN KEY (`IDHEBERGEMENT`) REFERENCES `hebergement` (`IDHEBERGEMENT`),
  ADD CONSTRAINT `visite_ibfk_3` FOREIGN KEY (`IDSAISON`) REFERENCES `saison` (`IDSAISON`),
  ADD CONSTRAINT `visite_ibfk_4` FOREIGN KEY (`IDDATEV`) REFERENCES `datev` (`IDDATEV`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
