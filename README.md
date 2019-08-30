# Conteúdo da aulas de Web API

> Cursos => Seja Fullstack com Asp.NET Web API 2 e Javascript + SQL.

> OBS: Toda a informação contida aqui e referênte a versão final, nele inclui uma pasta chamada 
página que tem umas páginas para testar a **WebApp** do tipo HTML com Javascript, e também na soluction 
tem o projeto **SiteAspNetMVC** que é uma página feita no Visual Studio 2017 para testar a Web API.

Aqui contém algumas informações à respeito do curso feito acima. Dê acordo com o curso o conteúdo 
foi dividido em seção para facilitar a compreensão.

A pasta escrita versão final contém as duas parte do projeto academico das aula, tanto a **Web API**
quanto a página em html com javascript usada para consumir à **Web API**.


### Referências usadas no projeto:

Todas as referências listadas você encontra no NuGet package do Visual Studio 2017 ou 2019.

    INSTALAÇÕES DO 'Owin' NO PROMPT DO 'NuGet'
    ============================================
    install-package Microsoft.AspNet.WebApi.Owin
    install-Package Microsoft.Owin.Host.SystemWeb
    install-Package Microsoft.Owin.Cors

> OBS: Todas as instalações listadas acima e para o projeto **WebApp** da soluction. 
Ao terminar a instalação acima, clique com o botão direito do mouse, escolha add Owin Startup Class
para instalar o classe de inicilização do Owin, fazendo isto não precisará mais do **Global.asax**
da **WebApp** para inicializar a Web API pois o **Startup** fará isto no lugar.

-------------------------------------------------------------------------------------------------------
A soluction é dividido em 3 projetos.

- App.Domain
- App.Repository
- WebApp


### App.Domain
Aqui é feita entidade ou o **Data Tranfer Object** que nada mais e que o objeto utilizado para 
enviar é receber dados de um bando de dados. Ele e compartilhado com o **App.Repository** e o
**WebApp**.

### App.Repository
E onde fica a conexão com banco de dados. Nele contém uma referência **App.Domain** que e para
acessa o **DTO** do projeto, o **App.Domain** e compartilhado também com o **WebApp**.

### WebApp
E a propria **Web API**, e onde estebelece as rotas que serão usadas pela API, o tipos de seguranças,
e as chamadas de conexões com o banco de dados que ver de **App.Repository**. Ele também utiliza
o **DTO** do **App.Domain** para transferência de dados. Nele também contém o arquivo de inicializa
'Startup.cs' que fica no lugar do 'Global.asax', o 'ProviderDeTokensDeAcesso.cs' para a 
validação do token e também o 'BaseUsuarios.cs' que e a base de dados usada para os usuários do
sistema acadêmico.

### SiteAspNetMVC
Que é uma página o tipo **Asp.Net MVC** para os testes da **WebApp** que é a **Web API** do sistema acadêmico. 


-------------------------------------------------------------------------------------------------------

# Demostrativos das telas das páginas
Página em HTML com Javascript.

### Login
![Tela de login.](https://user-images.githubusercontent.com/34901033/64053790-609e6800-cb5a-11e9-838a-fb294f7e4cb2.jpg)

### Cadastrar alunos.
![Cadastrar alunos](https://user-images.githubusercontent.com/34901033/64053794-61cf9500-cb5a-11e9-97b8-43d6d408476f.jpg)

### Formulário de cadastro de aluno.
![Formulário de cadastro de aluno](https://user-images.githubusercontent.com/34901033/64054429-516ce980-cb5d-11e9-982f-e94fb31959f7.jpg)

### Formulário de edição de aluno.
![Formulário de edição de aluno](https://user-images.githubusercontent.com/34901033/64053792-6136fe80-cb5a-11e9-9dbb-d18586859ab7.jpg)

### Excluir aluno.
![Excluir aluno](https://user-images.githubusercontent.com/34901033/64053793-6136fe80-cb5a-11e9-98be-1e814ce3138a.jpg)


-------------------------------------------------------------------------------------------------------

Página em Asp.Net MVC.
> OBS: Neste caso a unica página que foi alterada foi o "Cadastrar alunos" o resto das páginas continua sendo
a mesma coisa que as páginas citadas acima.

### Cadastrar alunos.
![Cadastrar alunos](https://user-images.githubusercontent.com/34901033/64053806-72800b00-cb5a-11e9-9620-dc7143e362b6.jpg)
