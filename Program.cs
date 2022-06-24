// See https://aka.ms/new-console-template for more information

using BE5.Classes;

Console.WriteLine(@$"
=================================================================================================================
|                                   Bem Vindo ao sistema de cadastro de                                         |
|                                       Pessoas Fisicas e Jurídicas                                             |
=================================================================================================================
");

BarraCarregamento("Carregando", 500);
string? opcao;
do
{
    Console.Clear();
    Console.WriteLine(@$"
=================================================================================================================
|                                   Escolha uma das Opções abaixo                                               |
|---------------------------------------------------------------------------------------------------------------|
|                                         1- Pessoa Física                                                      |
|                                         2- Pessoa Jurídica                                                    |
|                                                                                                               |
|                                         0- Sair                                                               |
=================================================================================================================

");
    opcao = Console.ReadLine();

    switch (opcao)
    {
                case "0":
                Console.Clear();
                Console.WriteLine($"Obrigado por utilizar nosso sistema!!!");
                BarraCarregamento("Finalizando" , 400);
            break;
        case "1":
            PessoaFisica novaPf = new PessoaFisica();
            Endereco novoEnd = new Endereco ();
            novaPf.ValidarDataNascimento (new DateTime (2000,01,01));
            novaPf.ValidarDataNascimento("01/01/2000");
            novaPf.nome = "Luiz";
            novaPf.dataNascimento = "18/02/1984";
            novaPf.cpf = "12345678901";
            novaPf.rendimento = 15000f;
            novoEnd.logadouro = "Alameda Barão de Limerira";
            novoEnd.numero = 539;
            novoEnd.complemento = "Senai de informatica";
            novoEnd.endComercial  = true;
            novaPf.endereco = novoEnd;
            Console.WriteLine (@$"
                Nome: {novaPf.nome}
                Endereco: {novaPf.endereco.logadouro},{novaPf.endereco.numero}
                Maior de Idade: {novaPf.ValidarDataNascimento(novaPf.dataNascimento)}
                Taxa De Imposto a ser paga é: {novaPf.PagarImposto (novaPf.rendimento).ToString("C")}
                ");
            Console.WriteLine($"Aperte Enter para continuar...");
            Console.ReadLine();    
            break;
        case "2":
            PessoaJuridica metodoPj = new PessoaJuridica();
            PessoaJuridica novaPJ = new PessoaJuridica();
            Endereco novoEndpj = new Endereco();
            novaPJ.nome = "Nome Pj";
            novaPJ.cnpj = "00.000.000/0001-00";
            novaPJ.razao = "Razap social PJ";
            novaPJ.rendimento = 8000.5f;
            novoEndpj.logadouro ="Alamedabarao de limeira";
            novoEndpj.numero = 539;
            novoEndpj.complemento = "Senai Innformatica";
            novoEndpj.endComercial = true;
            novaPJ.endereco = novoEndpj;
            Console.WriteLine(@$"
                Nome: {novaPJ.nome}
                Razao social: {novaPJ.razao}
                CNPJ: {novaPJ.cnpj}
                CNPJ Válido? {metodoPj.ValidarCnpj(novaPJ.cnpj)}
                Taxa De Imposto a ser paga é: {metodoPj.PagarImposto (novaPJ.rendimento).ToString("C")}
                ");
            Console.WriteLine($"Aperte Enter para continuar...");
            Console.ReadLine();
            break;


        default:
            Console.Clear();
            Console.WriteLine($"Opção Inválida, por favor digite outra opçao.");
            Thread.Sleep(2000);
            break;

    }
} while (opcao != "0");

static void BarraCarregamento(string texto, int tempo)
{
    Console.BackgroundColor = ConsoleColor.DarkCyan;
    Console.ForegroundColor = ConsoleColor.Red;

    Console.Write($"{texto} ");

for (var contador = 0; contador < 10; contador++)
    {
        Console.Write(". ");
        Thread.Sleep(tempo);
    }

    Console.ResetColor();
}

