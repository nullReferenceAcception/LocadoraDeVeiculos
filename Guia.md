<h2 style="color:red"> Guia de padr�es e roteiro de processo </h2>

___

*Sum�rio*:
1. [Git](#git)
2. [Apresenta��o](#apresentacao)
3. [Aplica��o](#aplicacao)
4. [Dom�nio](#dominio)
5. [Infra](#infra)
6. [Testes](#testes)
7. 
8.
9.
10.



___


<div id='git'/>
<h1 style="color:white">Git</h1>

Antes de realizar um <span style="color:#db0bb9">_pull_</span>, fa�a um <span style="color:#db0bb9">_fetch_</span> para ver as altera��es que vir�o.

Passos para voltar a <span style="color:#64b2d1">BRANCH</span> na <span style="color:#64b2d1">MAIN</span>:

1. COMMIT

2. CHECKOUT MAIN (...)

3. FETCH => PULL (Main local atualizada com a main remota)

4. Merge 'xxx' into 'main' (Enviando as adi��es de 'xxx' para a 'main' local)

5. RESOLVE THE CONFLICTS

6. Stage no que for necess�rio

7. Push na main

___

<div id='apresentacao'/>
<h1 style="color:#e59866">Apresenta��o</h1>

Ao renomear um campo, deixar o **<span style="color:cyan">NOME ORIGINAL** seguido por sua defini��o:

- textBox1 > textBoxCPF;
- maskedTextBox1 > maskedTextBoxTelefone;
- radioButton1 > radioButtonAdmin;
- label1 > labelLogin;



Ao utilizar maskedTextBoxes, alterar a propriedade 'TextMaskFormat' para 'ExcludePromptAndLiterals' 
=> Verificar poss�veis altera��es nos validadores

Ao criar uma nova tela, utilizar o padr�o j� seguido:

Um groupBox com: 'Dados do xxx', e com os componentes dentro, deixando os bot�es fora do group box.

Lembrar dessa duas funcoes no construtor:<div>
            this.ConfigurarTela();<div>
            primerioTextBox.Focus();


___
<div id='aplicacao'/>
<h1 style="color:#76d7c4">Aplica��o</h1>

Esta � a camada de servi�o.
___

<div id='dominio'/>
<h1 style="color:#ec7063">Dom�nio</h1>

Ao criar uma nova classe, implementar o override de Equals e gerar seus construtores necess�rios
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

<h3>Unit�rios</h3>


<h3>Integra��o</h3>
Realizar os testes por ordem:

a) Inserir<br>
b) Editar<br>
c) Excluir<br>
d) SelecionarPorId<br>
e) SelecionarTodos<br>
f) N�o pode fazer algo<br>

Usando prioritariamente **<span style="color:orange">FluentAssertions</span>**
___
