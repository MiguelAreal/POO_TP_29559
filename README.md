
# POO_TP_29559 - Left Click

Programação Orientada a Objetos

Licenciatura em Engenharia de Sistemas Informáticos (*regime pós-laboral*) 2024-25

## Autor
Miguel Areal - Nº29559 - a29559@alunos.ipca.pt
## Sobre
**LeftClick** é uma aplicação desenvolvida com .NET Windows Forms para gerir de forma eficiente uma loja online de comércio eletrónico. Projetada como parte da unidade curricular de Programação Orientada a Objetos, a aplicação utiliza conceitos modernos de POO, como herança, interfaces, e encapsulamento, para garantir uma estrutura modular, escalável e de fácil manutenção.

## Funcionalidades
O sistema permite a gestão de diversos elementos relacionados com uma loja online:

 - **Gestão de Utilizadores**
	 - Registo e autenticação com validações avançadas.
	 - Perfis de cliente e administrador com permissões diferentes.
 - **Gestão de Produtos**
	 - Adição, edição e remoção de produtos.
	 - Organização por categorias e marcas.
	 - Controlo de inventário em tempo real.
 - **Gestão de Vendas e Compras**
	 - Registo de transações com histórico detalhado.
	 - Controlo de garantias e devoluções.
	 - Relatórios de vendas filtrados por cliente ou data.
 - **Gestão de Campanhas e Descontos**
	 - Criação de campanhas promocionais baseadas em categorias de produtos.
	 - Aplicação de descontos automáticos em categorias elegíveis.
  
 - **Outras Funcionalidades**
	 - Pesquisa e filtragem em tempo real.
	 - Suporte a múltiplos métodos de pagamento.

## Tecnologias Utilizadas
 - Linguagem: C#
 - Framework: .NET 8.0 Windows Forms
 - Persistência de Dados: JSON.
 - Interface Gráfica: Windows Forms, MetroFramework para design moderno e responsivo.
 - Arquitetura: Baseada em Programação Orientada a Objetos.
 
## Destaques
### **1. Estrutura Modular e Flexível**
O projeto segue boas práticas de POO, dividindo responsabilidades de forma clara:
-   **Controladores:** Gerem a lógica de negócio e interações entre dados e a interface.
-   **Modelos:** Representam as entidades da aplicação, como `Produto`, `Utilizador` e `Campanha`.
-   **Repositórios:** Garantem persistência e abstraem a gestão de dados.

### **2. Validações Inteligentes**
O sistema inclui validações avançadas para campos de entrada:
-   Verificação de NIF e contacto com máscaras e regras específicas.
-   Garantia de dados consistentes com mensagens de erro interativas.

## Compilar o Projeto
### Pré-requisitos
 - NET 8.0 ou superior instalado no sistema.
 - Windows 10 ou superior recomendado.
### Passos
-   Clone este repositório:
     `git clone https://github.com/MiguelAreal/POO_TP_29559.git` 
-   Abra o ficheiro `LeftClick.sln` no Visual Studio.
-   Compile e execute o projeto pressionando `F5`.
