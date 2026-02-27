- **Usuários Simulados:** 100, 500 e 1000, usuários simultâneos.

| **Tempo Médio de Resposta** | **Taxa de Erros (%)** | **Tempo de resposta de 95% das req** | **Checks**                 |
|-----------------------------|-----------------------|--------------------------------------|----------------------------|
| 3s                          | 0.52%                 | 6s                                   | pass: 71061 / fail: 78254  |

- **Análise:** A página se manteve estável nos primeiros 30 segundos, após isso foi observada uma degradação no desempenho, com aumento significativo no tempo de resposta e na taxa de erros, resultando em bloqueio de requisição dado tamanho do volume em tão pouco tempo.
