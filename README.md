# SeuLanche
Venda personalizada de lanches

#### Descrição:
 
Somos uma startup do ramo de alimentos e precisamos de uma aplicação para gerir nosso negócio. Nossa especialidade é a venda de lanches, de modo que alguns lanches são opções de cardápio e outros podem conter ingredientes personalizados.
 
A seguir, apresentamos a lista de ingredientes disponíveis:
 
INGREDIENTE | VALOR
----------- | ------------
Alface | R$ 0.40
Bacon | R$ 2,00
Hambúrguer de carne | R$ 3,00
Ovo | R$ 0,80
Queijo | R$ 1,50

Segue as opções de cardápio e seus respectivos ingredientes:

LANCHE | INGREDIENTES
----------- | ------------
X-Bacon | Bacon, hambúrguer de carne e queijo
X-Burger | Hambúrguer de carne e queijo
X-Egg | Ovo, hambúrguer de carne e queijo
X-Egg Bacon | Ovo, bacon, hambúrguer de carne e queijo

O valor de cada opção do cardápio é dado pela soma dos ingredientes que compõem o lanche. 

Além destas opções, o cliente pode personalizar seu lanche e escolher os ingredientes que desejar. Nesse caso, o preço do lanche também será calculado pela soma dos ingredientes.

Existe uma exceção à regra para o cálculo de preço, quando o lanche pertencer à uma promoção. A seguir, apresentamos a lista de promoções e suas respectivas regras de negócio:

PROMOÇÃO | REGRA DE NEGÓCIO
----------- | ------------
Light | Se o lanche tem alface e não tem bacon, ganha 10% de desconto.
Muita carne | A cada 3 porções de carne o cliente só paga 2. Se o lanche tiver 6 porções, ocliente pagará 4. Assim por diante...
Muito queijo | A cada 3 porções de queijo o cliente só paga 2. Se o lanche tiver 6 porções, ocliente pagará 4. Assim por diante...
Inflação | Os valores dos ingredientes são alterados com frequência e não gostaríamos que isso influenciasse nos testes automatizados.

No formulário de realização de pedido deve ter um timer contando quanto tempo o usuário está na tela de pedidos. Esse tempo deve ser incremental a cada 1 segundo.

#### CRITÉRIOS DE COMPLETUDE

O projeto deve ser entregue atendendo aos seguintes critérios:
 - Client-side deve ser desenvolvido em  Windows Forms VB.Net ou C#.

 - Server-side deve ser desenvolvido em .NET C# WEBAPI.

 - Banco de dados deve ser desenvolvido em T-SQL (SQL Server), com utilização de stored procedures. Scripts e funções SQL devem ser compatíveis com a versão 2014 Standard.

 - Possuir cobertura de testes automatizados para os seguintes pontos:
  Valor dos lanches de cardápio, regra para cálculo de preço e promoções.
  Não é necessário se preocupar com a autenticação dos usuários.
