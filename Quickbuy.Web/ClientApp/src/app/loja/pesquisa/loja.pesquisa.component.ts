import { Component, OnInit } from "@angular/core"
import { ProdutoServico } from "../../servicos/produto/produto.servico"
import { Produto } from "../../modelo/produto"
import { Router } from "@angular/router";

@Component({
    selector: "app-loja",
    templateUrl: "./loja.pesquisa.component.html",
    styleUrls: ["./loja.pesquisa.component.css"]
})

export class LojaPesquisaComponent implements OnInit {

    public produtos: Produto[];

    ngOnInit(): void {

    }

    constructor(private produtoServico: ProdutoServico, private router: Router) {
        this.produtoServico.obterTodosProdutos()
            .subscribe(
                produtoo => {
                    this.produtos = produtoo;
              },
                e => {
                    console.log(e.error);
                })
    }

    public abrirProduto(produto_selecionado: Produto) {
        sessionStorage.setItem('produtoDetalhe', JSON.stringify(produto_selecionado));
        this.router.navigate(['/loja-produto'])
    }
}
