﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBuy.dominio.Contratos;
using QuickBuy.dominio.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Quickbuy.Web.Controllers
{
    [Route("api/[Controller]")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private IHttpContextAccessor _httpContextAccessor;
        private IHostingEnvironment _hostingEnvironment;
        public ProdutoController(IProdutoRepositorio produtoRepositorio, IHttpContextAccessor httpContextAccessor, IHostingEnvironment hostingEnvironment)
        {
            _produtoRepositorio = produtoRepositorio;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_produtoRepositorio.ObterTodos());
                //if(condicao == false)
                //{
                //    return BadRequest("Problema foram encontrados");
                //}
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
                
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Produto produto)
        {
            try
            {
                produto.Validate();

                if (!produto.EhValido)
                {
                    return BadRequest(produto.ObterMensagensValidacao());
                }

                if ( produto.Id != null)
                {
                    _produtoRepositorio.Atualizar(produto);
                }
                else
                {
                    _produtoRepositorio.Adicionar(produto);
                }

                return Created("api/produto", produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
                
            }
        }

        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody] Produto produto)
        {
            try
            {
                //produto recebido do frombody deve ter a propriedade ID > 0
                _produtoRepositorio.Remover(produto);
                return Json(_produtoRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpPost("EnviarArquivo")]
        public IActionResult EnviarArquivo()
        {
            try
            {
                //Chave usada para ter acesso ao arquivo
                var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"];
                var nomeArquivo = formFile.FileName;
                //Pega a ultima posição do array
                var extensao = nomeArquivo.Split(".").Last();
                //Com o take pegamos o nome do arquivo e transformamos em ele no tamanho desejado
                var arrayNomeCompacto = Path.GetFileNameWithoutExtension(nomeArquivo).Take(10).ToArray();
                var novoNomeArquivo = new string(arrayNomeCompacto).Replace(" ", "-") + "." + extensao;
                novoNomeArquivo = $"{novoNomeArquivo}_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.{extensao}";
                var pastaArquivos =  _hostingEnvironment.WebRootPath + "\\arquivos\\";
                var nomeCompleto = pastaArquivos + novoNomeArquivo;

                using(var streamArquivo = new FileStream(nomeCompleto, FileMode.Create))
                {
                    formFile.CopyTo(streamArquivo);
                }

                return Json(novoNomeArquivo);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
    }
}