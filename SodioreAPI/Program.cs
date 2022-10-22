// é uma classe de nível superior, ou seja, não precisa setar namespace para englobar os métodos
// já pode ir direto ao ponto substituindo inclusive a utilização do void main

using api;

// 1 cria o construtor necessário pra aplicação rodar
// 2 webapplication é um handler de configurações para o app
// 3 o createbuilder é responsável pos criar o construtor ouvindo as args a serem passadas
// 4 UseStartup é uma instância de startup que criei no Startup.cs que chama os métodos de startup.cs (configureServices e Configure)
var builder = WebApplication.CreateBuilder(args)
    .UseStartup<Startup>();