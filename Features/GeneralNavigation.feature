# Feature responsável por testar a RN001 e RN002
# RN001: O menu do portal de inscrições deve conter as páginas **Home** e **Privacidade**, deve conter um botão para mudança de tema entre **Claro, Escuro, Sistema**;
# 	RN001.1: A página **Home** deve trazer uma caixa de seleção com as opções **Graduação** e **Pós-graduação**;
# 	RN001.2: A página **Privacidade** deve trazer um texto informativo a respeito da política de privacidade do Portal de Inscrições;
# RN002: O usuário deve escolher uma das opções de nível de ensino, conforme descritas na RN001.1;

Feature: Navegação no Portal
    EU como usuário do Portal de inscrições
    GOSTARIA de navegar pelas páginas
    ASSIM posso conhecer os recursos do portal

Background: 
    Given I have access to the platform

@happy_path @done
Scenario: Verify Privacy Policy page
    When I navigate to the "Privacidade" page
    Then I should see an informative text about privacy policy

@happy_path @done
Scenario: Verify Home page content
    When I navigate to the "Home" page
    Then I should see a level selection box with:
        | Level          |
        | Graduação      |
        | Pós-graduação  |

@happy_path @done
Scenario: Check theme toggle options
    When I click on the theme selection button
    Then I should see the following theme options:
        | Option  |
        | Claro   |
        | Escuro  |
        | Sistema |