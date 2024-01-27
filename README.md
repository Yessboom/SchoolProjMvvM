<!-- PROJECT LOGO -->
<br />
  <p align="center">
    This is an application for a .net MAUI school project. 
<br>

   </p>

<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
* [SOLID Principles](#solid-principles)
* [Functionality](#functionnality)
* [Class Diagram](#class-diagram)
* [Sequence Diagram](#sequence-diagram)


<!--PROJECT DESCRIPTION-->
## About the Project

On vous demande de reprendre l'exercice du labo 2 et de créer une interface MAUI permettant :

de créer des enseignants,
de créer des activités,
de relier les activités aux enseignants,
de créer des étudiants,
d'ajouter une évaluation pour un cours créer pour un étudiant (cote ou appréciation),
d'afficher le bulletin des étudiants
On vous demande également d'ajouter une autre fonctionnalité au choix et de faire en sorte que les données puissent être sauvée de la manière qui vous semblera la meilleure.









### SOLID PRinciples

SRP : Les Repository s'occupent des intéractions avec la BDD. Les Models s'occupent de représenter la structure, Les ViewModels les opérations possibles
Interface

ISP: Chaque page a sa propre a sa propre interface définie dans son propre fichier View ou AddView


### Functionality

* `Add/Edit/Delete Teacher` 

* `Add / Edit / Delete Student` 
* `Add / Edit / Delete Cours` 
* `Enroll a Student in a Class and Giving him a Grade` => Mais je n'arrive pas à l'afficher et calculer sa moyenne:/
* `Added Functionality : Search` 



### Class Diagram

On voit dans notre Diagramme de classe que le programme est basé sur un Observer Pattern : Nos modèles seront notifié 
lorsqu'il y a des changements
![Diagramme de Classe pour la création/édition de Teachers][image1]

### Sequence Diagram 

![Diagramme de Séquence][image2]


