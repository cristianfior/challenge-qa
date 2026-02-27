- **Usuários Simulados:** 100, 500 e 1000, usuários simultâneos.

| **Tempo Médio de Resposta** | **Taxa de Erros (%)** | **Tempo de resposta de 95% das req** | **Checks**                 |
|-----------------------------|-----------------------|--------------------------------------|----------------------------|
| 163ms                       | 0.0%                  | 169ms                                | pass: 28513 / fail: 28281  |

- **Análise:** A página se manteve estável nos três cenários, com um aumento linear no tempo de resposta. Acima de 1000 usuários, foi observada degradação no desempenho, nada significativo mas gerou aumento no tempo de resposta e na taxa de erros. Erros de checks são devidos ao mal dimensionamento do teste de checagem, sendo necessário revisa-lo.
