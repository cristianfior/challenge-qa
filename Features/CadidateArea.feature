# Feature responsável por testar a RN010, RN011 e RN012
# RN010: Se o usuário realizar login, deve ser levado para a página da área do candidato;
# 	RN010.1: A página do candidato deve ter menu lateral com campo de pesquisa e as páginas **Minhas inscrições, Financeiro**
# RN011: Se o usuário clicar na página **Minhas inscrições**, deve ser levado para a página de minhas inscrições;
# 	RN011.1: A página de minhas inscrições devem listar todos os cursos em que o usuário logado encontra-se cadastrado;
# 	RN011.2: A página de minhas inscrições deve conter um botão para retornar para a página anterior;
# RN012: Se o usuário clicar na página **Financeiro**, deve ser levado para a página de suas informações financeiras;
# 	RN012.1: A página de informações financeiras deve retornar informações a respeito de débitos do usuário;
# 	RN012.2: A página de informações financeiras deve conter um botão para retornar a página anterior;

Feature: Acessando área do candidato
    EU como candidato autenticado do Portal de inscrições
    GOSTARIA de acessar minha área de candidato
    ASSIM posso acessar e gerenciar minhas inscrições e financeiro

Background:
    Given I am logged into the Candidate Area

@happy_path @done
Scenario: Verify side menu structure
    Then I should see a side menu containing:
        | Item              |
        | Minhas inscrições |
        | Financeiro        |

@happy_path @done
Scenario: Access Subscription details
    When I click on the "Minhas inscrições" page
    Then I should see a list of all courses I am enrolled in
    And I should see a back button to return to the dashboard

@happy_path @done
Scenario: Access Financial data
    When I click on the "Financeiro" page
    Then I should see my current debts and financial status
    And I should see a back button to return to the dashboard