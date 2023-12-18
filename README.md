# Rumatuara

## Auteurs

- Luc Enée
- Adam Germain

## _Génération Procédurale de Labyrinthe avec Sliders_

Rumatuara est un générateur de labyrinthe procédural s'inspirant des backrooms et est réalisé dans le cadre du cours de 'Modélisation géométrique/Mondes virtuels '.

- Modifiactions des paramètres à l'aide de sliders
- Génération avec l'algorithme de Wilson
- ✨Magic ✨

## Fonctionnalités

- Modification des dimensions du labyrinthe
- Choix de l'emplacement de la salle de départ
- Sélection de la tailles des pièces
- Sélection de la densité et/ou du nombre de salle

Ce projet est développé en CSharp dans le moteur de jeu Unity.

Après génération du labyrinthe, l'objectif est d'avoir une modélisation 3D basique donnant un aperçu plus concret.

## Motivations

L'objectif de ce projet est d'avoir un générateur simple de labyrinthes, avec quelques paramètres modifiables pour obtenir un résultat satisfaisant. De plus, les labyrinthes sont très présents dans le monde du jeu vidéo.

## Backrooms

<img width="600" alt="Backrooms" src="https://github.com/Ryacuda/Rumatuara/blob/main/readme_mats/Backrooms_model.jpg?raw=true">

> The Backrooms est une légende urbaine effrayante dite creepypasta, diffusée sur Internet. Elle raconte l'histoire d'endroits accessibles en se noclippant de la réalité. Cet endroit est considéré comme une dimension parallèle, vide, à plusieurs niveaux connectés entre eux, utilisant pratiquement tous des espaces possédant des caractéristiques telles que des grandes pièces vides et répétitives, donnant une sensation de déjà-vu à tout ceux qui s'y aventureraient.

## Algorithme de Wilson

<img width="400" alt="Labyrinthe 15x15 généré avec l'algorithme de Wilson" src="https://github.com/Ryacuda/Rumatuara/blob/main/readme_mats/15x15.png?raw=true">

Pour générer le labyrinthe, on utilise l'algorithme de Wilson, qui applique des Loop-Erased Random Walk itérativement. Cet algorithme est une méthode utilisée pour générer une marche aléatoire sur un graphe tout en évitant la formation de boucles (boucles fermées). Cet algorithme est souvent utilisé pour générer un arbre couvrant uniformément aléatoire sur un graphe connexe. L'algorithme peut être découpé comme suit :

- L'initialisation
- La marche aléatoire
- Loop-Erased

L'initialisation consiste à choisir un nœud initial arbitraire dans le graphe et à le marquer comme visité. C'est le point de départ de la marche aléatoire. À chaque étape, l'algorithme choisi un voisin non visité du nœud actuel et se déplace vers ce voisin. Il continue jusqu'à ce qu'il atteigne un nœud déjà visité. Ensuite, si à un certain point de la marche aléatoire, un cycle (boucle) est formé, l'algorithm élimine cette boucle du chemin parcouru. Cela signifie que si il retourne à un nœud déjà visité, il supprime toutes les arêtes entre ce nœud et le nœud actuel dans le chemin qu'il a parcouru. La marche aléatoire continue après avoir éliminé la boucle. Ces étapes se répètent jusqu'à ce que tous les nœuds du graphe soient visités. Une fois que tous les nœuds ont été visités, l'ensemble des arêtes parcourues forme un arbre couvrant uniformément aléatoire du graphe.

Après la génération de ce labyrinthe avec l'algorithme de Wilson, on ajoute des grandes salles (grandes à l'opposé des couloirs). Pour cela, un paramètre de densité est disponible, qui régit le nombre de salles par rapport à la taille du labyrinthe. On peut aussi régler la taille moyenne de ces salles.

## Sources

[Génération de labyrinthes - Wikipedia](https://en.wikipedia.org/wiki/Maze_generation_algorithm)

[Backrooms - Wikipedia](https://en.wikipedia.org/wiki/The_Backrooms)

