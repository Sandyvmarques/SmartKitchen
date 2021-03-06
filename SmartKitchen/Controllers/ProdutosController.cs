﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartKitchen.Models;

namespace SmartKitchen.Controllers
{
    public class ProdutosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();//variável que representa a BD

        // GET: Produtos
        public ActionResult Index()
        {
			var ListaDeProdutos = db.Produtos.OrderBy(p => p.Categoria.NomeCateg).ToList();
			return View(ListaDeProdutos);
			
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
				return RedirectToAction("Index");
			}
            Produtos produto = db.Produtos.Find(id);
            if (produto == null)
            {
				return RedirectToAction("Index");
			}
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.CategoriasFK = new SelectList(db.Categorias, "Cat_ID", "NomeCateg");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Prod_ID,NomeProduto,Descricao,IVAVenda,PrecoVenda,Stock,CategoriasFK")]Produtos produto, HttpPostedFileBase[] Uploadimagens)//para ter multiplas imagens faco um array e um ciclo for para ir buscar cada imagem. uma coisa q o vs faz por ti ex: produto.imgem.caminho
        {

			int idImagem = db.Imagens.Max(a => a.Imagem_ID);
			foreach (var Uploadimagem in Uploadimagens)
			{

				string name = System.IO.Path.GetFileName(Uploadimagem.FileName);
				Uploadimagem.SaveAs(Server.MapPath("~/Imagens/" + name));

				string filename = "Imagens/" + name;

				//ID do novo produto 
				int idNovoPoduto = 0;
				try
				{
					 idNovoPoduto = db.Produtos.Max(a => a.Prod_ID) + 1;
					idImagem++;
				}
				catch (Exception)
				{
					idNovoPoduto = 1;
				}
				//guarda o ID
				produto.Prod_ID = idNovoPoduto;

				//escolher o nome do ficheiro 
				string nomeImg = "Imagem_" + idImagem + ".jpg";

				//var auxiliar
				string path = "";

				//validar se a img foi fornecida
				if (Uploadimagens != null)
				{

				
					path = Path.Combine(Server.MapPath("~/imagens/"), nomeImg);
					//produto.ListaDeImagens= nomeImg;
					Imagens imagem = new Imagens
					{
						Img = nomeImg,
						Ordem = ""
					};

					try
					{
						Uploadimagem.SaveAs(path);
						produto.ListaDeImagens.Add(imagem);
					}
					catch (Exception)
					{
						ModelState.AddModelError("", "Error Creating a new Product");
					}

				}
				else
				{
					ModelState.AddModelError("", "No Image was found. Please insert a image");

					return View(produto);
				}
			}
			if (ModelState.IsValid)
			{
				try
				{
					db.Produtos.Add(produto);
					db.SaveChanges();
					return RedirectToAction("Index");
				}
				catch (Exception) {
					ModelState.AddModelError("", "Error Creating a new Product");
				}
				}

			//ViewBag.CategoriasFK = new SelectList(db.Categorias, "Cat_ID", "NomeCateg", produto.CategoriasFK);
			return View(produto);
		}

		// GET: Produtos/Edit/5
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
				return RedirectToAction("Index");
			}
            Produtos produto = db.Produtos.Find(id);
            if (produto == null)
            {
				return RedirectToAction("Index");
			}
            ViewBag.CategoriasFK = new SelectList(db.Categorias, "Cat_ID", "NomeCateg", produto.CategoriasFK);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Prod_ID,NomeProduto,Descricao,IVAVenda,PrecoVenda,Stock,CategoriasFK")] Produtos produto, HttpPostedFileBase[] Uploadimagens)
        {
			if (ModelState.IsValid)
			{
				try
				{
					db.Entry(produto).State = EntityState.Modified;
					db.SaveChanges();
					//if (Uploadimagens != null){
					//nomeAntigo = produto.ListaDeImagens
					//novoNome="Produto_" + produto.ProdID +DateTime.Now.ToString("_yyyyMMdd_hhmmss") +Path.GetExtension(UploadImagens.FileName1);
					//produto.ListaDeImagens = novoNome
					//Uploadimagens.SaveAs(Path.Combine(Server.MapPath("~/imagens/"), produto.ListaDeImagens));
					return RedirectToAction("Index");
				}
				catch (Exception)
				{
					ModelState.AddModelError("", string.Format("An ERROR occured during the edition of the product.", produto.NomeProduto));
				}
			}
            ViewBag.CategoriasFK = new SelectList(db.Categorias, "Cat_ID", "NomeCateg", produto.CategoriasFK);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return RedirectToAction("Index");
			}
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
				return RedirectToAction("Index");
			}
            return View(produtos);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produtos produtos = db.Produtos.Find(id);
			int tam = produtos.ListaDeImagens.Count;
			var imagens = produtos.ListaDeImagens.ToArray();
			for (int i=0; i< imagens.Length; i++)
			{

				produtos.ListaDeImagens.Remove(db.Imagens.Remove(imagens[i]));

			}
            db.Produtos.Remove(produtos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
