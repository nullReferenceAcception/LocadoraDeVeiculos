<h2 style="color:red" id='topo'> Guia de padrões e roteiro de processo </h2>

___
<a href="https://i.ibb.co/k4TC8N8/image.png">Modelo atual MVC</a>

___

*Sumário*:
1. [Git](#git)
   * [Erros no Git](#errosGit) 
2. [Apresentação](#apresentacao)
3. [Aplicação](#aplicacao)
4. [Domínio](#dominio)
5. [Infra](#infra)
6. [Testes](#testes)




___


<div id='git'/>
<h1 style="color:white">Git</h1>

Antes de realizar um <span style="color:#db0bb9">_pull_</span>, faça um <span style="color:#db0bb9">_fetch_</span> para ver as alterações que virão.

Passos para voltar a <span style="color:#64b2d1">BRANCH</span> na <span style="color:#64b2d1">MAIN</span>:

1. COMMIT

2. CHECKOUT MAIN (...)

3. FETCH => PULL (Main local atualizada com a main remota)

4. Merge 'xxx' into 'main' (Enviando as adições de 'xxx' para a 'main' local)

5. RESOLVE THE CONFLICTS

6. Stage no que for necessário

7. Push na main

<a href="https://i.ibb.co/TB9Kj37/fluxoGit.png"><strong style="color:HotPink">Imagem auxiliar</strong></a>

___
<h3 id='errosGit' style="color:violet">Erros</h3>

Se um arquivo está causando problemas por ser definido a todo hora como "modificado" (M), e está na lista do .gitignore, uma possível solução é:

1. Ajustar o arquivo .gitignore incluindo as extensões indesejadas.
2. Deletar a pasta/arquivo que está causando o problema do respositório do Git.
3. Desfazer as mudanças da main local que envolvem o arquivo problemático.
4. <strong style="color:red">RAPIDAMENTE</strong> fazer um pull para que a pasta/arquivo seja removida da main loca.

Se tudo ocorreu certo, o problema deve se encerrar.
___

<div id='apresentacao'/>
<h1 style="color:#e59866">Apresentação</h1>

Ao renomear um campo, deixar o **<span style="color:cyan">NOME ORIGINAL** seguido por sua definição:

- textBox1 > textBoxCPF;
- maskedTextBox1 > maskedTextBoxTelefone;
- radioButton1 > radioButtonAdmin;
- label1 > labelLogin;



Ao utilizar maskedTextBoxes, alterar a propriedade 'TextMaskFormat' para 'ExcludePromptAndLiterals' 
=> Verificar possíveis alterações nos validadores

Ao criar uma nova tela, utilizar o padrão já seguido:

Um groupBox com: 'Dados do xxx', e com os componentes dentro, deixando os botões fora do groupBox.

Lembrar dessa duas funcoes no construtor:<div>
            this.ConfigurarTela();<div>
            primerioTextBox.Focus();


___
<div id='aplicacao'/>
<h1 style="color:#76d7c4">Aplicação</h1>

Esta é a camada de serviço.
___

<div id='dominio'/>
<h1 style="color:#ec7063">Domínio</h1>

Ao criar uma nova classe, implementar o override de Equals e gerar seus construtores necessários
___

<div id='infra'/>
<h1 style="color:#a569bd">Infra</h1>

Quando fizer o repositorio da classe o SQL de excluir e o de selecionarPorId precisa ser @ID exemplo: 

```SQL
protected override string sqlExcluir
{
get =>
@"DELETE 
    FROM
        TB_TAXA
    WHERE
        ID_TAXA = @ID;"; ---->@ID aqui
}

protected override string sqlSelecionarPorID
{
get =>
@"SELECT
    ID_TAXA AS ID_TAXA,
        DESCRICAO AS DESCRICAO_TAXA,
        VALOR AS VALOR_TAXA
    FROM
        TB_TAXA
    WHERE
        ID_TAXA = @ID;"; ---->@ID aqui tambem
}
```
___

<div id='testes'/>
<h1 style="color:#566573">Testes</h1>

<h3>Unitários</h3>


<h3>Integração</h3>
Realizar os testes por ordem:

a) Inserir<br>
b) Editar<br>
c) Excluir<br>
d) SelecionarPorId<br>
e) SelecionarTodos<br>
f) Não pode fazer algo<br>

Usando prioritariamente **<span style="color:orange">FluentAssertions</span>**
___

<a href="#topo">Topo</a>