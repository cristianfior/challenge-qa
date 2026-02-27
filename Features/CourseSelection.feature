# Feature responsável por testar a RN003 e RN004
# RN003: Tendo escolhido o nível **Graduação**, o usuário deve ser levado para a página dos cursos de graduação;
# 	RN003.1: A página deve conter uma caixa de seleção com opções, única e exclusivamente, de cursos de graduação;
# 	RN003.2: A caixa de seleção deve conter uma barra de pesquisa;
# 	RN003.3: A página deve conter um botão para voltar a página anterior;
# 	RN003.4: A página deve conter um botão para avançar para a próxima etapa;
# 	RN003.5: O botão de avanço só deve avançar caso uma opção tenha sido selecionada;
# 	RN003.6: Caso o usuário tente avançar sem selecionar opção, o sistema deve retornar um alerta informando a obrigatoriedade de escolha;
# RN004: Tendo escolhido o nível **Pós-graduação**, o usuário deve ser levado para a página dos cursos de pós-graduação;
# 	RN004.1: A página deve conter uma caixa de seleção com opções, única e exclusivamente, de cursos de graduação;
# 	RN004.2: A caixa de seleção deve conter uma barra de pesquisa;
# 	RN004.3: A página deve conter um botão para voltar a página anterior;
# 	RN004.4: A página deve conter um botão para avançar para a próxima etapa;
# 	RN004.5: O botão de avanço só deve avançar caso uma opção tenha sido selecionada;
# 	RN004.6: Caso o usuário tente avançar sem selecionar opção, o sistema deve retornar um alerta informando a obrigatoriedade de escolha;

Feature: Seleção de curso
    EU como candidato
    GOSTARIA de escolher um curso de gradução ou pós graduação
    ASSIM posso realizar minha inscrição

@happy_path @done
Scenario Outline: Access the specific course list
    Given I am on the "Home" page
    When I select the course level "<level>"
    Then I should be redirected to the "<level>" courses page
Examples:
    | level          |
    | Graduação      |
    | Pós-graduação  |

@happy_path @done
Scenario Outline: Filter courses by level
    Given I am on the course level "<level>" page
    When I click on the courses select box
    Then I see courses options in the list
Examples:
    | level         |
    | Graduação     |
    | Pós-graduação |

@happy_path @done
Scenario Outline: Select a course
    Given I am on the course level "<level>" page
    When I select a course from the select box
    Then I can go to next page
Examples:
    | level         |
    | Graduação     |
    | Pós-graduação |

@happy_path @done
Scenario Outline: Go back button
    Given I am on the course level "<level>" page
    When I click on the "Voltar" button
    Then I should be redirected to the Home page
Examples:
    | level         |
    | Graduação     |
    | Pós-graduação |

@unhappy_path @hiremetodo
Scenario Outline: Advance without choosing a course
    Given I am on the "<level>" page
    When I click on the "Avançar" button
    And do not choose a course
    Then I should see the alert "Por favor, selecione um curso..." on screen
Examples:
    | level         |
    | Graduação     |
    | Pós-graduação |

@unhappy_path @hiremetodo
Scenario Outline: Search for an unregistered course
    Given I am on the "<level>" page
    When I type "Filosofia" in the search bar
    And it is not on the list
    Then I should see the result "Curso não encontrado"
Examples:
    | level         |
    | Graduação     |
    | Pós-graduação |