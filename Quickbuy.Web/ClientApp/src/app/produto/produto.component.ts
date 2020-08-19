import { Component, OnInit } from "@angular/core"
import { Produto } from "../modelo/produto";
import { ProdutoServico } from "../servicos/produto/produto.servico";
import { Route } from "@angular/compiler/src/core";
import { Router } from "@angular/router";

@Component({
  //Defini o nome da tag do component em qual tag sera renderizado
    selector: "app-produto",
    templateUrl: "./produto.component.html",
    styleUrls: ["./produto.component.css"]
  //Estrutura em html onde renderiza o componente
  

})

export class ProdutoComponent implements OnInit { // Nome das classes começando com maisuculos por conta da convernção PascalCase

  //camelCase para variaveis, atributos e nomes das funções
    public produto: Produto;
    public arquivoSelecionado: File;
    public ativar_spinner: boolean;
    public mensagem: string;

    constructor(private produtoServico: ProdutoServico, private router: Router) {

    }

    ngOnInit(): void {
        var produtoSession = sessionStorage.getItem('produtoSession');
        if (produtoSession) {
            this.produto = JSON.parse(produtoSession);
        } else {
            this.produto = new Produto();
        }
    }

    public inputChange(files: FileList) {

        this.arquivoSelecionado = files.item(0);
        this.ativar_spinner = true;
        this.produtoServico.enviarArquivo(this.arquivoSelecionado)
            .subscribe(
                nomeArquivo => {

                    this.produto.nomeArquivo = nomeArquivo;
                    this.ativar_spinner = false;
                    alert(this.produto.nomeArquivo);
                    
                },
                e => {
                    this.ativar_spinner = false;
                    console.log(e.error);
                });
 
    }

    public cadastrar() {
        //this.produto;
        this.ativarEspera();
        this.produtoServico.cadastrar(this.produto)
            .subscribe(
                produtoJson => {
                    console.log(produtoJson);
                    this.desativarEsperar();
                    this.router.navigate(['/pesquisar-produto']);

                },
                e => {
                    console.log(e.error);
                    this.mensagem = e.error
                    this.desativarEsperar();
                }
            );
    }

    public ativarEspera() {
        this.ativar_spinner = true;
    }

    public desativarEsperar() {
        this.ativar_spinner = false;
    }
}
