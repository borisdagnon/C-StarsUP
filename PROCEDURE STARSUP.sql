CREATE PROCEDURE cONtrole_visite( IN dateV date)
BEGIN
    IF EXISTS(SELECT * FROM visite WHERE dateVisite=dateV)
      THEN
       SELECT'Cette viste existe déjà, créez en une autre';
       ELSE
       SELECT'Cette visite n\'existe pAS encore';
         IF EXISTS(SELECT * FROM saison s INNER JOIN visite v ON s.IDSAISON=v.IDSAISON WHERE dateV BETWEEN dateDeb AND dateFin )
           THEN
              SELECT'Cette date se situe bien dans une saison';
               ELSE
                 SELECT'Cette date ne se situe dans aucune saison, veuillez insérer une date qui se situe dans une des saion'; 
              END IF;
     END IF;

 END



 ----------------------------------------------------------------------------------------------------------------------------------------------

/*
Ce trigger vérifi que lors de l'insertion d'un camping, il n'existe pas déjà une liaison de faite avec un hôtel ou une chambre hôte.
Réponse à la contrainte suivante : spécificité sur les types d'hébergement
*/

 CREATE TRIGGER avant_insertion_camping BEFORE INSERT
ON camping FOR EACH ROW
 BEGIN
    IF EXISTS(SELECT * FROM hotel WHERE IDHEBERGEMENT=NEW.IDHEBERGEMENT)
       THEN
       signal sqlstate '16440' SET message_text='Cet hébergement est un hotel';
       ELSE
       IF EXISTS(SELECT * FROM chambre_hotte WHERE IDHEBERGEMENT=NEW.IDHEBERGEMENT)
       THEN
       signal sqlstate '16440' SET message_text='Cet hébergement est une chambre_hôte ';
       END IF;
       END IF;
         END
 ----------------------------------------------------------------------------------------------------------------------------------------------

/*

Ce trigger vérifi que lors de l'insertion d'une chambre hôte, il n'existe pas déjà une liaison de faite avec un hôtel ou un camping
Réponse à la contrainte suivante : spécificité sur les types d'hébergement
*/

 CREATE TRIGGER avant_insertion_chambre_hotte BEFORE INSERT
ON chambre_hotte FOR EACH ROW
 BEGIN
    IF EXISTS(SELECT * FROM hotel WHERE IDHEBERGEMENT=NEW.IDHEBERGEMENT)
       THEN
       signal sqlstate '16440' SET message_text='Cet hébergement est un hotel';
       ELSE
       IF EXISTS(SELECT * FROM camping WHERE IDHEBERGEMENT=NEW.IDHEBERGEMENT)
       THEN
       signal sqlstate '16440' SET message_text='Cet hébergement est un camping ';
       END IF;
       END IF;
         END


 ----------------------------------------------------------------------------------------------------------------------------------------------


    /*
    Ce trigger permet de vérifier si l'hébergement correspond à la spécialité de l'inspecteur:
    Si l'isnpecteur a pour attribution des hôtels, il ne peut visiter que des hôtels
    Si l'inspecteur à pour attribution des camping, il ne peut que visiter des camping ainsi de suite
    */


CREATE TRIGGER avant_insertion_visite BEFORE INSERT
ON visite FOR EACH ROW
BEGIN


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
----------------------------------------------------------------------------------------------------------------------------------------------



/*
Avant l'insertion d'une contre-visite ce trigger vérifi que pour l'indentifiant de la visite concerné, l'identifiant de l'inspecteur et la date de visite, ne sont
pas les mêmes.  Réponse à la contrainte suivante: Contre-visite par un autre inspecteur

Le trigger de la contre visite doit vérifier que l'inspecteur qu'on va insérer n'a pas déjà effectué une visite sur cet hébergement à cette saison
Il doit aussi vérifier que l'option CONTREVISITE est coché et si le département de l'inspecteur et de l'hébergement sont similaire ou non
*/



CREATE TRIGGER `avant_insertion_contre_visite` BEFORE INSERT ON `contrevisite`
 FOR EACH ROW
  BEGIN
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


CREATE TRIGGER after_insertion_contre_visite AFTER INSERT ON contrevisite FOR EACH ROW
BEGIN
 DECLARE p0 int(6) DEFAULT 0;
  DECLARE p1 int(6) DEFAULT 0;

SELECT NEW.IDVISITE INTO p0;     
SELECT NEW.NBETOILEMOINS INTO p1 ;

 CALL maj_diminuer_etoille(p0, p1);

END

DROP PROCEDURE `maj_vm_visites`; CREATE DEFINER=`root`@`localhost` PROCEDURE `maj_vm_visites`() NOT DETERMINISTIC CONTAINS SQL SQL SECURITY DEFINER 
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
end




----------------------------------------------------------------------------------------------------------------------------------------------

/*
Avant l'insertion d'un date de visite, on vérifi que la saison et la date de visite on la même annéee, sinon on affiche un message d'erreur
*/

----------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE vm_visites
ENGINE=InnoDB
SELECT v.IDINSPECTEUR AS Identifiant_Inspecteur,NOMINSPECTEUR AS Nom_Inspecteur,PRENOMINSPECTEUR AS Prenom_Inspecteur,
 h.NOMHEBERGEMENT AS Nom_Hebergement, DATEV AS Date_de_visite,s.IDSAISON AS Identifiant_SaisON,d.IDDEPARTEMENT AS Identifiant_Departement,
 LIBDEPARTEMENT AS Nom_Departement FROM visite v INNER JOIN hebergement h ON v.IDHEBERGEMENT=h.IDHEBERGEMENT 
 INNER JOIN historique his ON h.IDHEBERGEMENT=his.IDHEBERGEMENT INNER JOIN saisON s ON his.IDSAISON=s.IDSAISON 
 INNER JOIN datev dv ON s.IDSAISON=dv.IDSAISON INNER JOIN departement d ON h.IDDEPARTEMENT=d.IDDEPARTEMENT 
 INNER JOIN inspecteur i ON v.IDINSPECTEUR=i.IDINSPECTEUR;

CREATE TRIGGER avant_insertion_hotel BEFORE INSERT
ON hotel FOR EACH ROW
 BEGIN
    IF EXISTS(SELECT * FROM chambre_hotte WHERE IDHEBERGEMENT=NEW.IDHEBERGEMENT)
       THEN
       signal sqlstate '16440' SET message_text='Cet hébergement est une chambre_hôte';
       ELSE
       IF EXISTS(SELECT * FROM camping WHERE IDHEBERGEMENT=NEW.IDHEBERGEMENT)
       THEN
       signal sqlstate '16440' SET message_text='Cet hébergement est un camping ';
       END IF;
       END IF;
         END

        
        

CREATE TRIGGER avant_insertion_inspecteur BEFORE INSERT
ON visite FOR EACH ROW
BEGIN
   IF NOT EXISTS( SELECT * FROM inspecteur i inner join hebergement h WHERE  h.IDDEPARTEMENT=i.IDDEPARTEMENT)
      THEN
         signal sqlstate'16440' SET message_text='Visite Impossible: le département de l\'inspecteur et de l\'hébergement sont différents';
         call maj_vm_visites();
         ELSE
         IF EXISTS(SELECT * FROM )
         END IF;
         END




CREATE PROCEDURE ETOILLE (IN Nom_Inspecteur varchar(30))
BEGIN

       SELECT i.IDINSPECTEUR,i.NOMINSPECTEUR,i.PRENOMINSPECTEUR,NUMEROTEL,LIBSPECIALITE,h.NOMHEBERGEMENT,dv.DATEV,his.ETOILLE 
       FROM inspecteur i INNER JOIN visite v ON i.IDINSPECTEUR=v.IDINSPECTEUR 
       INNER JOIN hebergement h ON v.IDHEBERGEMENT=h.IDHEBERGEMENT 
       INNER JOIN datev dv ON v.IDDATEV=dv.IDDATEV 
       INNER JOIN historique his ON h.IDHEBERGEMENT=his.IDHEBERGEMENT 
       INNER JOIN specialite s ON i.IDSPECIALITEI=s.IDSPECIALITE 
       WHERE v.IDINSPECTEUR=(SELECT i.IDINSPECTEUR FROM inspecteur WHERE NOMINSPECTEUR=Nom_Inspecteur);
       END

        

        CREATE TRIGGER avant_maj_historique BEFORE UPDATE
        ON historique FOR EACH ROW
       BEGIN
     
           
      CALL maj_etoille(NEW.IDHEBERGEMENT,NEW.IDSAISON,NEW.ETOILLE);

END

CREATE PROCEDURE maj_ajout_etoille (IN IdVisite int(6), IN EtoileAj int(6))
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
       END


       

       CREATE PROCEDURE maj_diminuer_etoille (IN IdVisite smallint(6), IN EtoileAj smallint(6))
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
       END


     CREATE PROCEDURE maj_vm_saison()
     BEGIN
TRUNCATE vm_saison;
INSERT INTO vm_saison
SELECT s.IDSAISON AS Identifiant_Saison,s.LIBSAISON AS Nom_Saison,s_a.ANNEE AS Annee_Saison 
FROM inspecteur i INNER JOIN visite v ON v.IDINSPECTEUR = i.IDINSPECTEUR 
INNER JOIN hebergement h ON h.IDHEBERGEMENT = v.IDHEBERGEMENT 
INNER JOIN datev d_v ON v.IDDATEV = d_v.IDDATEV 
INNER JOIN saison s ON s.IDSAISON = v.IDSAISON 
INNER JOIN saison_annee s_a ON s_a.IDSAISON = v.IDSAISON 
WHERE ANNEE = YEAR(DATEV);
END