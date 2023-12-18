# Rumatuara
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

## Backrooms

> The Backrooms est une légende urbaine effrayante dite creepypasta, diffusée sur Internet. Elle raconte l'histoire d'endroits accessibles en se noclippant de la réalité. Cet endroit est considéré comme une dimension parallèle, vide, à plusieurs niveaux connectés entre eux, utilisant pratiquement tous des espaces possédant des caractéristiques telles que des grandes pièces vides et répétitives, donnant une sensation de déjà-vu à tout ceux qui s'y aventureraient.

## Algorithme de Wilson

<img width="400" alt="Labyrinthe 15x15 généré avec l'algorithme de Wilson" src="https://github.com/Ryacuda/Rumatuara/blob/main/readme_mats/15x15.png?raw=true">

Pour générer le labyrinthe, on utilise l'algorithme de Wilson, qui applique des Loop-Erased Random Walk itérativement. Cet algorithme est une méthode utilisée pour générer une marche aléatoire sur un graphe tout en évitant la formation de boucles (boucles fermées). Cet algorithme est souvent utilisé pour générer un arbre couvrant uniformément aléatoire sur un graphe connexe. On peut découper l'algorithme de Wilson en 5 grande étapes. 

- L'initialisation
- La marche aléatoire
- Loop-Erased
- La répétition
- L'arbre couvrant

L'initialisation consiste à choisir un nœud initial arbitraire dans le graphe et marquez-le comme visité. C'est le point de départ de la marche aléatoire. À chaque étape, l'algorithme choisi un voisin non visité du nœud actuel et se déplace vers ce voisin. Il continu jusqu'à ce qu'il atteigne un nœud déjà visité. Ensuite, si à un certain point de la marche aléatoire, un cycle (boucle) est formé, l'algorithm élimine cette boucle du chemin parcouru. Cela signifie que si il retourne à un nœud déjà visité, il supprime toutes les arêtes entre ce nœud et le nœud actuel dans le chemin qu'il a parcouru. La marche aléatoire continue après avoir éliminé la boucle. Ces étapes se répètent jusqu'à ce que tous les nœuds du graphe soient visités. Une fois que tous les nœuds ont été visités, l'ensemble des arêtes parcourues forme un arbre couvrant uniformément aléatoire du graphe.

L'idée clé de l'algorithme est de garantir que le chemin résultant ne contient pas de boucles, ce qui garantit que l'arbre couvrant généré est uniformément aléatoire. Cela signifie que tous les arbres couvrants possibles ont la même probabilité d'être générés.
L'algorithme de Wilson est utilisé dans le contexte de la théorie des graphes et de l'informatique pour générer des structures aléatoires tout en évitant les biais associés à certaines méthodes de génération d'arbres couvrants.

## Sources

[Génération de labyrinthes - Wikipedia](https://en.wikipedia.org/wiki/Maze_generation_algorithm)
