import { Component, OnInit } from "@angular/core"
import { LojaCarrinhoCompras } from "../carrinho-compras/loja.carrinho.compras.component"
import { Produto } from "../../modelo/produto";
import { Pedido } from "../../modelo/pedido";
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";
import { ItemPedido } from "../../modelo/ItemPedido";
import { PedidoServico } from "../../servicos/pedido/pedido.servico";
import { Router } from "@angular/router";

@Component({
    selector: "loja-efetivar",
    templateUrl: "./loja.efetivar.component.html",
    styleUrls: ["./loja.efetivar.component.css"]
})

export class LojaEfetivarComponent implements OnInit {
    public carrinhoCompras: LojaCarrinhoCompras;
    public produtos: Produto[];
    public total: number;

    ngOnInit(): void {
        this.carrinhoCompras = new LojaCarrinhoCompras();
        this.produtos = this.carrinhoCompras.obterProdutos();
        this.atualizarTotal();
    }

    constructor(private usaurioServico: UsuarioServico, private pedidoServico: PedidoServico, private router: Router) {

    }

    public atualizarPreco(produto: Produto, quantidade: number) {
        if (!produto.precoOriginal) {
            produto.precoOriginal = produto.preco;
        }

        if (quantidade <= 0) {
            quantidade = 1;
            produto.quantidade = quantidade;
        }

        produto.preco = produto.precoOriginal * quantidade;
        this.carrinhoCompras.atualizar(this.produtos);
        this.atualizarTotal();
    }

    public remover(produto: Produto) {
        this.carrinhoCompras.removerProduto(produto);
        this.produtos = this.carrinhoCompras.obterProdutos();
        this.atualizarTotal();
    }

    public atualizarTotal() {
        this.total = this.produtos.reduce((acc, produto) => acc + produto.preco, 0);
    }

    public efetivarCompra() {
        let pedido = this.criarPedido();
        this.pedidoServico.efetivarCompra(pedido)
            .subscribe(
                pedidoId => {
                    sessionStorage.setItem("pedidoId", pedidoId.toString());
                    this.produtos = [];
                    this.carrinhoCompras.limparCarrinhoCompras();
                    this.router.navigate(["/compra-realizada-sucesso"]);

                },
                e => {

                });

    }

    public criarPedido(): Pedido {

        let pedido = new Pedido();
        pedido.usuarioId = this.usaurioServico.usuario.id;
        pedido.cep = "17208510";
        pedido.cidade = "Sao Paulo";
        pedido.estado = "Sao Paulo";
        pedido.dataPrevisaoEntrega = new Date();
        pedido.formaPagamentoId = 1;
        pedido.numeroEndereco = "2222";
        pedido.enderecoCompleto = "Teste";
        this.produtos = this.carrinhoCompras.obterProdutos();
        for (let produto of this.produtos) {
            let itemPedido = new ItemPedido();
            itemPedido.produtoId = produto.id.toString();
            
            if (!produto.quantidade)
                produto.quantidade = 1;
            itemPedido.quantidade = produto.quantidade;
            pedido.itensPedidos.push(itemPedido);
        }
        return pedido;
    }
}
