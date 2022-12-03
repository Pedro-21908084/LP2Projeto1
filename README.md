# Projeto 1 - Linguagens de Programação II

Componente de mapa com distribuição de terrenos e recursos para um hipotético jogo 4X.

## Autoria

- João Inácio (22202654)
  - Arquitetura do modelo de dados
  - Diagrama UML simples
- Pedro Fernandes (21908084)
  - Arquitetura e implementação do controller
- Pedro Osório (22002513)
  - Arquitetura e implementação da vista
  
## Legenda dos elementos de jogo

| Terreno | Legenda |
| --- | --- |
| <img src="images/terrain-desert.png" alt="Deserto" width="60" /> | Deserto |
| <img src="images/terrain-plains.png" alt="Planície" width="60" /> | Planície |
| <img src="images/terrain-hills.png" alt="Montes" width="60" /> | Montes |
| <img src="images/terrain-mountain.png" alt="Montanhas" width="60" /> | Montanhas |
| <img src="images/terrain-water.png" alt="Lago" width="60" /> | Lago |

| Recurso | Legenda |
| --- | --- |
| <img src="images/resource-plants.png" alt="Animais" width="60" /> | Plantas |
| <img src="images/resource-animals.png" alt="Metais" width="60" /> | Animais |
| <img src="images/resource-metals.png" alt="Combustível fóssil" width="60" /> | Metais |
| <img src="images/resource-fossil-fuel.png" alt="Luxo" width="60" /> | Combustível fóssil |
| <img src="images/resource-luxury.png" alt="Pollution" width="60" /> | Luxo |
| <img src="images/resource-pollution.png" alt="Plantas" width="60" /> | Pollution |

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
