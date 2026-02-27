using Bogus;
using Bogus.Extensions.Brazil;

public static class RandomizeData
{
    private static readonly Faker Faker = new Faker("pt_BR");

    public static string GetValue(string field)
    {
        return field switch
        {
        "CPF" => Faker.Person.Cpf(),
        "Nome" => Faker.Name.FirstName(),
        "Sobrenome" => Faker.Name.LastName(),
        "Nome social" => Faker.Internet.UserName(),
        "Email" => Faker.Internet.Email(),
        "Celular" => Faker.Phone.PhoneNumber("###########"),
        "Telefone" => Faker.Phone.PhoneNumber("###########"),
        "CEP" => Faker.Address.ZipCode("########"),
        "Endereço" => Faker.Address.StreetAddress(),
        "Complemento" => Faker.Address.SecondaryAddress(),
        "Bairro" => Faker.Address.County(),
        "Cidade" => Faker.Address.City(),
        "Estado" => Faker.Address.StateAbbr(),
        "País" => Faker.Address.Country()
        };
    }
}