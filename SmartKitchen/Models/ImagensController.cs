﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SmartKitchen.Models
{
	public class ImagensController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: Imagens
		public ActionResult Index()
		{
			var imagens = db.Imagens.Include(i => i.Produto);
			return View(imagens.ToList());
		}

		// GET: Imagens/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Imagens imagens = db.Imagens.Find(id);
			if (imagens == null)
			{
				return HttpNotFound();
			}
			return View(imagens);
		}

		// GET: Imagens/Create
		public ActionResult Create(int? ProdutosFK)
		{
			if (ProdutosFK == null)
			{
				return RedirectToAction("Index", "Produtos",null);
			}
			ViewBag.Produtos = db.Produtos.Find(ProdutosFK);
			return View();
		}

		// POST: Imagens/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Imagem_ID,Img,Ordem,ProdutosFK")] Imagens imagens, HttpPostedFileBase uploadFotografia)
		{

			//ID do nova imagem 
			int idImagem = db.Imagens.Max(a => a.Imagem_ID);
			int idNovaImagem = 0;
			try
			{
				idNovaImagem = db.Imagens.Max(a => a.Imagem_ID) + 1;
				idImagem++;
			}
			catch (Exception)
			{
				idNovaImagem = 1;
			}
			//guarda o ID
			imagens.Imagem_ID = idNovaImagem;

			//escolher o nome do ficheiro 
			string nomeImg = "Imagem_" + idImagem + ".jpg";

			//var auxiliar
			string path = "";

			//validar se a img foi fornecida
			if (uploadFotografia != null)
			{


				path = Path.Combine(Server.MapPath("~/imagens/"), nomeImg);
				imagens.Img = nomeImg;

				try
				{
					uploadFotografia.SaveAs(path);
				
				}
				catch (Exception)
				{
					ModelState.AddModelError("", "Error Creating a new Product");
				}

			}
			else
			{
				ModelState.AddModelError("", "No Image was found. Please insert a image");

				return View(imagens);

			}
			if (ModelState.IsValid)
			{
				db.Imagens.Add(imagens);
				db.SaveChanges();
				return RedirectToAction("Edit","Produtos",new { id = imagens.ProdutosFK});
			}

			ViewBag.ProdutosFK = new SelectList(db.Produtos, "Prod_ID", "NomeProduto", imagens.ProdutosFK);
			return View(imagens);
		

	
}


        // GET: Imagens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
				return RedirectToAction("Index", "Produtos", null);
			}
			Imagens imagens = db.Imagens.Find(id);
            if (imagens == null)
            {
				return RedirectToAction("Index", "Produtos", null);
			}
			ViewBag.ProdutosFK = new SelectList(db.Produtos, "Prod_ID", "NomeProduto", imagens.ProdutosFK);
            return View(imagens);
        }

        // POST: Imagens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Imagem_ID,Img,Ordem,ProdutosFK")] Imagens imagens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagens).State = EntityState.Modified;
                db.SaveChanges();
				return RedirectToAction("Edit", "Produtos", new { id = imagens.ProdutosFK });
			}
			ViewBag.ProdutosFK = new SelectList(db.Produtos, "Prod_ID", "NomeProduto", imagens.ProdutosFK);
            return View(imagens);
        }

        // GET: Imagens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return RedirectToAction("Index", "Produtos", null);
			}
			Imagens imagens = db.Imagens.Find(id);
            if (imagens == null)
            {
				return RedirectToAction("Index", "Produtos",null);
			}
			return View(imagens);
        }

        // POST: Imagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Imagens imagens = db.Imagens.Find(id);
            db.Imagens.Remove(imagens);
            db.SaveChanges();
			return RedirectToAction("Edit", "Produtos", new { id = imagens.ProdutosFK });
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
