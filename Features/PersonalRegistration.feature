# Feature responsável por testar a RN005
# RN005: Após escolher o curso, o usuário deve ser levado para a página de cadastro pessoal;
# 	RN005.1: A página de cadastro pessoal deve conter um formulário com os campos do tipo input: **CPF, Nome, Sobrenome, Nome social, Data de nascimento, Email, Celular, Telefone, CEP, Endereço, Complemento, Bairro, Cidade, Estado, País**; e um campo do tipo Checkbox;
# 	RN005.2: Os campos **CPF, Nome, Sobrenome, Data de nascimento, Email, Celular, CEP, Endereço, Bairro, Cidade, Estado, País** devem ser obrigatórios;
# 	RN005.3: O campo **CPF** deve ter validação matemática do valor informado;
# 	RN005.4: O checkbox deve possuir o texto **Possui alguma deficiência?**;
# 	RN005.5: Se o checkbox for marcado, deve habilitar um campo do tipo input com título **Qual deficiência**, não obrigatório;
# 	RN005.6: O formulário deve ter um botão para voltar para a página anterior;
# 	RN005.7: O formulário deve ter um botão para avançar para a próxima etapa;
# 	RN005.8: Caso o usuário tente avançar sem informar um ou mais campos obrigatórios, o sistema deve identificar os campos a serem preenchidos;

Feature: Cadastro pessoal
    EU como usuário interessado em um curso
    GOSTARIA de preencher meus dados pessoais
    ASSIM posso concluir minha inscrição no portal

Background:
    Given I am on the Dados pessoais page

@happy_path @done
Scenario: Successful registration with all fields
    When I fill the fields:
        | Field              | Value              |
        | CPF                | [RANDOM]           |
        | Nome               | [RANDOM]           |
        | Sobrenome          | [RANDOM]           |
        | Nome social        | [RANDOM]           |
        | Email              | [RANDOM]           |
        | Celular            | [RANDOM]           |
        | Telefone           | [RANDOM]           |
        | CEP                | [RANDOM]           |
        | Endereço           | [RANDOM]           |
        | Complemento        | [RANDOM]           |
        | Bairro             | [RANDOM]           |
        | Cidade             | [RANDOM]           |
        | Estado             | [RANDOM]           |
        | País               | [RANDOM]           |
    And I click on the "Avançar" button
    Then I should be redirected to the confirmation page

@happy_path @done
Scenario: Successful registration with only mandatory fields
    When I fill the fields:
        | Field              | Value              |
        | CPF                | [RANDOM]           |
        | Nome               | [RANDOM]           |
        | Sobrenome          | [RANDOM]           |
        | Email              | [RANDOM]           |
        | Celular            | [RANDOM]           |
        | CEP                | [RANDOM]           |
        | Endereço           | [RANDOM]           |
        | Bairro             | [RANDOM]           |
        | Cidade             | [RANDOM]           |
        | Estado             | [RANDOM]           |
        | País               | [RANDOM]           |
    And I click on the "Avançar" button
    Then I should be redirected to the confirmation page

@happy_path @done
Scenario: Toggle disability information field
    When I check the "Possui alguma deficiência?" checkbox
    Then the input field Qual deficiência should be enabled

@unhappy_path @hiremetodo
Scenario Outline: Registration without mandatory information
    When I leave the field "<mandatory_field>" empty
    And I click on the "Avançar" button
    Then the system should highlight the field "<mandatory_field>" as required
Examples:
    | mandatory_field    |
    | CPF                |
    | Nome               |
    | Sobrenome          |
    | Data de nascimento |
    | Email              |
    | Celular            |
    | CEP                |
    | Endereço           |
    | Bairro             |
    | Cidade             |
    | Estado             |
    | País               |