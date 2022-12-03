# Projeto 1 - Linguagens de Programação II

Componente de mapa com distribuição de terrenos e recursos para um hipotético jogo 4X.

## Autoria

- João Inácio (22202654)
  - Arquitetura do modelo de dados
  - Diagrama UML simples
- Pedro Fernandes (TODO: student number)
  - Arquitetura e implementação do controller
- Pedro Osório (TODO: student number)
  - Arquitetura e implementação da vista
  
## Legenda dos elementos de jogo

| Terreno | Legenda |
| --- | --- |
| [Deserto](images/terrain-desert.png) | Deserto |
| [Planície](images/terrain-plains.png) | Planície |
| [Montes](images/terrain-hills.png) | Montes |
| [Montanhas](images/terrain-mountain.png) | Montanhas |
| [Lago](images/terrain-water.png) | Lago |

| Recurso | Legenda |
| --- | --- |
| [Plantas](images/resource-plants.png) | Plantas |
| [Animais](images/resource-animals.png) | Animais |
| [Metais](images/resource-metals.png) | Metais |
| [Combustível fóssil](images/resource-fossil-fuel.png) | Combustível fóssil |
| [Luxo](images/resource-luxury.png) | Luxo |
| [Pollution](images/resource-pollution.png) | Pollution |

## Arquitetura do programa

O código foi organizado de acordo com o modelo MVC. A representação em dados
do jogo (**modelo**) é consultada e manipulada por um **controlador**.
O controlador comunica com uma **vista** para apresentar informação ao
utilizador. Foi definida uma interface `IGameView` que descreve a funcionalidade
necessária para apresentar graficamente o jogo. Esta interface foi concretizada
numa vista construída com o motor de jogo Unity. O controlador depende apenas
de `IGameView`, de forma a aplicar o princípio SOLID de *dependency inversion*.

O programa faz uso do **iterator pattern**, com a sintaxe `foreach` do C#
e do **observer pattern**, a nível da GUI, com UnityEvents, para ligar o
input do utilizador à ativação de funções do controlador de forma pouco estrita
(*loose coupling*).

![Diagrama UML simples](images/simple-uml.png)
