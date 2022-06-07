

CREATE TABLE ENSEIGNANT 
(
        IdEns                  INT                   NOT NULL,
        NomEns                 VARCHAR(32)           NOT NULL,
        PrenomEns              VARCHAR(32)           NOT NULL,
      CONSTRAINT ENSEIGNANT_PK PRIMARY KEY (IdEns)
) ;

CREATE TABLE MATIERE 
(
        CodeMat                INT                   NOT NULL,
        LibMat                 VARCHAR(32)           NOT NULL,
      CONSTRAINT MATIERE_PK PRIMARY KEY (CodeMat)
) ;

CREATE TABLE ENSEIGNER 
(
        IdEns                  INT                   NOT NULL,
        CodeMat                INT                   NOT NULL,
      CONSTRAINT ENSEIGNER_PK PRIMARY KEY (IdEns, CodeMat),
      CONSTRAINT ENSEIGNER_ENSEIGNANT_FK FOREIGN KEY (IdEns)
          REFERENCES ENSEIGNANT (IdEns),
      CONSTRAINT ENSEIGNER_MATIERE_FK FOREIGN KEY (CodeMat)
          REFERENCES MATIERE (CodeMat)
) ;

CREATE TABLE SALLE 
(
        CodeSal                INT                   NOT NULL,
        NomSalle               VARCHAR(32)           NOT NULL,  
      CONSTRAINT SALLE_PK PRIMARY KEY (CodeSal)
) ;

CREATE TABLE GROUPE 
(
        GroupClas              INT                   NOT NULL,
      CONSTRAINT GROUPE_PK PRIMARY KEY (GroupClas)
) ;

CREATE TABLE SEMESTRE 
(
        CodeSem                CHAR(6)               NOT NULL,
      CONSTRAINT SEMESTRE_PK PRIMARY KEY (CodeSem)
) ;

CREATE TABLE JOUR 
(
        IdJour                 INT                   NOT NULL,
      CONSTRAINT JOUR_PK PRIMARY KEY (IdJour)
) ;

CREATE TABLE COURS 
(
        CodeSem                INT                   NOT NULL,
        IdJour                 INT                   NOT NULL,
        HeureDebut             INT                   NOT NULL,
        IdEns                  INT                   NOT NULL,
        Duree                  INT                   NOT NULL,
        CodeMat                INT                   NOT NULL,
        GroupClas              INT                   NOT NULL,
        CodeSal                INT                   NOT NULL,
      CONSTRAINT COURS_K1 PRIMARY KEY (CodeSem, IdJour, HeureDebut, IdEns),
      CONSTRAINT COURS_K2 UNIQUE (CodeSem, IdJour, HeureDebut, GroupClas),
      CONSTRAINT COURS_K3 UNIQUE (CodeSem, IdJour, HeureDebut, CodeSal),
      CONSTRAINT COURS_ENSEIGNER_FK FOREIGN KEY (IdEns, CodeMat)
          REFERENCES ENSEIGNER (IdEns, CodeMat),
      CONSTRAINT COURS_GROUPE_FK FOREIGN KEY (GroupClas)
          REFERENCES GROUPE (GroupClas),
      CONSTRAINT COURS_SALLE_FK FOREIGN KEY (CodeSal)
          REFERENCES SALLE (CodeSal),
      CONSTRAINT COURS_SEMESTRE_FK FOREIGN KEY (CodeSem)
          REFERENCES SEMESTRE (CodeSem),
      CONSTRAINT COURS_JOUR_FK FOREIGN KEY (IdJour)
          REFERENCES JOUR (IdJour)
) ;