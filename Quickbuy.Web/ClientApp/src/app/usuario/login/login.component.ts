import { Component, OnInit } from "@angular/core";
import { Usuario } from "../../modelo/Usuario";
import {Router, ActivatedRoute} from "@angular/router"
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})

export class LoginComponent implements OnInit {

  public enderecoImg = "https://d23stzf11uxe1a.cloudfront.net/wp-content/uploads/2019/02/22100711/buying.jpg";
  public tituloPadrao = "Imagem Padrao Site";
  public usuario;
  public usuarioAutenticado: boolean;
  public ativar_spinner: boolean;

  public usuarios = ['usuario1', 'usuario2'];
    public returnUrl: string;
    public mensagem: string;

  constructor(private router: Router, private activatedRouter: ActivatedRoute,
              private usuarioServico: UsuarioServico) {
    
    
  }

  ngOnInit(): void {
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
    this.usuario = new Usuario();
  }

  //public email = "";
  //public senha = "";

  entrar() {
    this.ativar_spinner = true;
    this.usuarioServico.verificarUsuario(this.usuario)
      .subscribe(
        data => {
          //essa linha será executada no caso de retorno sem erros
              //var usuarioRetorno: Usuario;
              //usuarioRetorno = data;
              //sessionStorage.setItem("usuario-autenticado", "1");
              this.usuarioServico.usuario = data;

              if (this.returnUrl == null) {
                  this.router.navigate(['/']);
              } else {
                  this.router.navigate([this.returnUrl]);
              }
        },

        err => {
            console.log(err.error);
            this.mensagem = err.error;
            this.ativar_spinner = false;
        }
      );

  }

}
