# Reflexão sobre o Teste

1. Qual foi a decisão técnica mais relevante que você tomou durante o teste? Por quê?

    R: A decisão mais relevante foi a de remover os blocos try catch desnecessários na classe Tarefas, pois eles não tinham utilidade. Além do HandleException que ajudou no tratamento de erros do controller.


2. Tem alguma parte do código que você não ficou satisfeito? O que faria diferente com mais tempo?

    R: Implementaria um banco de dados relacional para persistência dos dados, ao invés de usar uma lista em memória. Utilizaria Entity Framework Core para ORM e migrations. Além de utilizar padrões de projeto como Padrão de Repositório e Injeção de Dependência. 


3. Se fosse necessário adicionar um campo "prazo de entrega" na tarefa, o que precisaria mudar no projeto?

    R: Precisaria alterar a classe TarefaDTO para incluir o campo, alterar a classe Tarefas para incluir o campo, além de alterar os métodos que manipulam a lista de tarefas para incluir o campo.


4. Ferramentas utilizadas:
   - [x] Usei IA (qual? como?)
   - [] Documentação oficial
   - [] Stack Overflow / outros sites
   Descreva brevemente como e para quê usou cada ferramenta.

   R: Usei IA (Claude Opus 4.6) integrada ao código com o Antigravity para gerar o código inicial do projeto, para melhorias e correções de código, e para sugestões.


5. (Responda apenas se usou IA) Existe algum trecho de código gerado por IA que você não entendeu completamente mas manteve no projeto? Qual? Por quê?

    R: Não, todo o código gerado por IA foi revisado e compreendido antes de ser mantido no projeto. Inclusive as melhorias em try catch e a criação do método HandleException foram sugeridas por IA e eu implementei após entender a lógica.