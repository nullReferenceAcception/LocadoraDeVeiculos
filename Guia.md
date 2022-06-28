<h2 style="color:red"> Guia de padrões e roteiro de processo </h2>

___

*Sumário*:
1. [Apresentação](#apresentacao)
2. [Aplicação](#aplicacao)
3. [Domínio](#dominio)
4. [Infra](#infra)
5. [Testes](#testes)

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

Um groupBox com: 'Dados do xxx', e com os componentes dentro, deixando os botões fora do group box.
___
<div id='aplicacao'/>
<h1 style="color:#76d7c4">Apliacação</h1>

___

<div id='dominio'/>
<h1 style="color:#ec7063">Domínio</h1>

___

<div id='infra'/>
<h1 style="color:#a569bd">Infra</h1>

___

<div id='testes'/>
<h1 style="color:#566573">Testes</h1>

___
