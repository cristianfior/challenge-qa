# Feature responsável por testar a RN006, RN007, RN008 e RN009
# RN006: Após enviar o formulário de cadastro pessoal, o usuário deve ser levado para a página de confirmação de cadastro;
# 	RN006.1: A página de cadastro deve conter informações a respeito do usuário de login e senha recém cadastrados;
# 	RN006.2: A página de cadastro deve ter um botão que redirecione para a página de login;
# RN007: O usuário deve ser levado até a página de login;
# 	RN007.1: A página de login deve conter os campos do tipo input: **Usuário, Senha**;
# 	RN007.2: A página de login deve conter links para recuperação de **Usuário** e **Senha**;
# 	RN007.3: Os campos **Usuário, Senha** devem ser obrigatórios;
# 	RN007.4: Se o usuário digitar um **Usuário** errado, o campo deve apontar alerta de usuário inválido;
# 	RN007.5: Se o usuário digitar sua **Senha** errada, o campo deve apontar alerta de senha inválida;
# 	RN007.6: A página de login deve conter um botão para realizar login;
# 	RN007.7: Caso o usuário tente avançar sem informar usuário e/ou senha, o sistema deve identificar os campos a serem preenchidos;
# RN008: Se o usuário clicar no link de recuperação de usuário, deve ser levado para a página de recuperação de usuário;
# 	RN008.1: A página de recuperação de usuário deve conter um texto informando que o usuário foi recuperado e enviado para o email;
# RN009: Se o usuário clicar no link de recuperação de senha, deve ser levado para a página de recuperação de senha;
# 	RN009.1: A página de recuperação de senha deve conter um texto informando que a senha foi recuperada e enviada para o email;

Feature: Autenticação de usuário
    EU como usuário inscrito do Portal de inscrições
    GOSTARIA de realizar autenticação na plataforma
    ASSIM posso acessar a área do candidato

@happy_path @done
Scenario: Verify authentication page
    Given I have my login credentials
    When I click on the "Acessar área do candidato" button
    Then I see the user and password input

@happy_path @done
Scenario: Successful login
    Given I fill the following mandatory fields:
        | Field   | Value        |
        | Usuário | candidato    |
        | Senha   | subscription |
    When I click on the "Login" button
    Then I should be redirected to Área do candidato page

@happy_path @done
Scenario Outline: Recover credentials
    Given I click on recovery link "<recover_credential>"
    Then I see the recovery confirmation
Examples:
    | recover_credential |
    | Recuperar usuário  |
    | Redefinir senha    |

@unhappy_path @hiremetodo
Scenario Outline: Login without mandatory information
    Given I am on the "Autenticação" page
    When I do not fill the field "<mandatory_field>"
    And I click on the "Login" button
    Then the system should highlight the field "<mandatory_field>" as required
Examples:
    | mandatory_field |
    | Usuário         |
    | Senha           |

@unhappy_path @hiremetodo
Scenario Outline: Login with wrong credentials
    Given I am on the "Autenticação" page
    When I fill the field "<mandatory_field>" with the wrong credential
    And I click on the "Login" button
    Then I should see the alert "<alert>"
Examples:
    | mandatory_field | alert            |
    | Usuário         | Usuário inválido |
    | Senha           | Senha inválida   |