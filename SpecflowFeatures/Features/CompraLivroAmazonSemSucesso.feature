#language: pt-BR
Funcionalidade: CompraLivroAmazonSemSucesso

A short summary of the feature

@tag1
Cenario:01 - Pesquisa de livro na Amazon
	Dado que esteja no site da Amazon
	Quando pesquiso pelo livro "1984"
	Entao será exibido o livro nos resultados

Cenario:02 - Não efetuar compra por login inválido
	Dado que esteja na tela do produto
	Quando adiciono o produto ao carrinho
		E vou efetuar login
		| Key   | Value								 |
		| Login | usuarioinvalido@teste.com.br		 |
		| Senha | senha123							 |
	Entao será exibida mensagem de login e/ou senha inválido
