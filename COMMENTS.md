##### ARQUITETURA
Na automação utilizei o modelo page objects para que ficasse mais facilitada a organização e integração entre os cenarios e steps;
Na performance fiz algo parecido e separei por endpoints a serem testados, assim fica mais facil organizar os testes e gerar relatórios;

##### BIBLIOTECAS
Bogus: gerar massa de dados aleatória, eliminando o risco de um teste viciado, massa duplicada e também por funcionar com paralelismo sem o problema de dados duplicados no banco;
htmlReport: gerar relatórios html das métricas e indicadores do output do k6;

##### MELHORIAS FUTURAS
- Terminaria de automatizar os casos de teste responsáveis pelo caminho infeliz e pelo caminho limite;
- Revisaria a reutilização de steps compartilhados, partindo do principio que exista integração real entre as páginas;
- Configuraria a paralelização de navegadores para rodar os testes em vários navegadores ao mesmo tempo;
- Configuraria o Selenium Grid com Docker Compose para exigir menos da máquina fisica, o que por conseguinte ajuda no paralelismo de navegadores, especialmente se tratando de testes em modo assistido;
- Faria os testes de browser utilizando o k6 pra unir funcional e não funcional na mesma suite, cobrindo de forma mais abrangente o sistema;

##### REQUISITOS OBRIGATÓRIOS
Acredito que todos foram entregues.