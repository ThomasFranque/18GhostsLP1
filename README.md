# [18 Ghosts LP1](https://github.com/ThomasFranque/18GhostsLP1/tree/master/18GhostsGame)

## Colaboradores

- [Tomás Franco](https://github.com/ThomasFranque), a2180330
- [Guilherme Carvalho](https://github.com/GuilhermeCarvalho25), a21803633
([_Fork_](https://github.com/GuilhermeCarvalho25))

## Divisão do trabalho

### Tomás

#### Responsável por

- Impressão de elementos no ecrã, nomeadamente,
o tabuleiro de jogo e as mensagens de informação.

- Jogadores

- Otimização do código.

- Acabamento do código.

- Documentação.

- UML

### Guilherme

#### Responsável por

- Parcial movimento dos fantasmas
  
- Fluxograma

## Descrição da solução

Decidiu-se que se ia dividir o código em duas partes: _Board_ e Jogadores.

Para a conceção do Tabuleiro, foi inicialmente decidido que iria apenas
aceitar 2 argumentos, sendo eles os fantasmas dos Jogadores. Iria então
depois ler os dados recebidos e imprimir no ecrã caracter a caracter, 
verificando a cada iteração se os locais são os corretos para a colocação
de objetos (fantasmas, espelhos e portais).

Para a parte do Jogador, foi criada uma classe `ghost` com as suas respetivas
subclasses para o processamento de dados. A classe `player` controla as
intenções do jogar quando é o turno dele, mudando depois para a classe
`Ghosts` resolvendo o resto das interações (escolher o fantasma, etc...).

## Fluxograma

![Fluxo](https://github.com/ThomasFranque/18GhostsLP1/blob/master/img/18Ghosts_Fluxograma.png)

## Diagrama UML

![UML](https://github.com/ThomasFranque/18GhostsLP1/blob/master/img/18Ghosts_UML.png)

## Conclusões e matéria aprendida

Com este trabalho ficámos mais proficientes a programar e com melhor perceção
de o quanto difícil é implementar um jogo totalmente funcional em código.

Aprendemos e percebemos um pouco mais sobre classes `Static`. E classes
em geral.

Devido a um dos elementos do grupo ser fraco a programação, o código foi
maioritariamente feito por uma única pessoa, mesmo após os esforços da
mesma para o tentar ajudar, o desenvolvimento do programa estava a ser
demasiado lento para entregar a horas. Deste modo, ficou encarregue dos
elementos gráficos.

## Referências

### Links

1. [Verificar se "_index is out of range_"](https://stackoverflow.com/questions/42536752/how-can-i-check-if-an-array-index-is-out-of-range)
2. [Argumentos na linha de comandos](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/main-and-command-args/command-line-arguments)
3. [Validar um _input_](https://codeasy.net/lesson/input_validation)
4. [Imagens em _Markdown_](https://stackoverflow.com/questions/14494747/add-images-to-readme-md-on-github)
5. [Markdown _Cheat Sheet_](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet)

### Trocas de ideias

Em conversa com o colega [Rodrigo Pinheiro](https://github.com/RodrigoPrinheiro)
, a21802488, foi alcançada uma solução a um problema que havia no código
sobre o conflito entre fantasmas após serem transportados por um espelho.
Ajudou também na criação da documentação do _Doxygen_.

## Problemas conhecidos

- Quando é corrido o comando `$ dotnet run` na consola do Ubuntu, o programa
não compila, provavelmente devido à utilização de `Console.ReadKey()` no código.
Porém, compila perfeitamente na _cmd_ do windows.

- Caso o jogador escolha colocar um fantasma com as casas todas ocupadas ficará
preso num _loop_ infinito que lhe pede para escolher uma casa válida.

- Se um fantasma ficar livre, ao escolher mexer esse mesmo fantasma para a
esquerda o fantasma aparecerá na casa 25 (canto inferior direito).

- Se o jogador mover o fantasma indevidamente, perde o turno.

---
