Feature: Pesquisa Globo Google

Acessar a globo.com a partir de consulta no Google.

Scenario: Pesquisar globo.com no Google
	Given que eu acesse o site "http://www.google.com.br"
	When pesquiso por "globo.com"
	Then acesso o site da globo.com