- **Usuários Simulados:** 100, 500 e 1000, usuários simultâneos.

| **Tempo Médio de Resposta** | **Taxa de Erros (%)** | **Tempo de resposta de 95% das req** | **Checks**             |
|-----------------------------|-----------------------|--------------------------------------|------------------------|
| 187ms                       | 0.0%                  | 184ms                                | pass: 78588 / fail: 8  |

- **Análise:** A página se manteve estável nos três cenários, com tempo de resposta inferior a pagina my_messages, mesmo que aqui exista payload a ser enviado. Acima de 1000 usuários foi observada uma degradação no desempenho, com presença de alguns erros de thresholds e checks, porém nada significativo.
