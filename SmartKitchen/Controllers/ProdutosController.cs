using System;
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
        private SmartKitchenDB db = new SmartKitchenDB();//variável que representa a BD

        // GET: Produtos
        public ActionResult Index()
        {
           // var produtos = db.Produtos.Include(p => p.Categoria);
            return View(db.Produtos.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
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
        public ActionResult Create([Bind(Include = "Prod_ID,NomeProduto,Descricao,IVAVenda,PrecoVenda,Stock,CategoriasFK")] Produtos produto, HttpPostedFileBase[] Uploadimagens)//para ter multiplas imagens faco um array e um ciclo for para ir buscar cada imagem. uma coisa q o vs faz por ti ex: produto.imgem.caminho
        {
			foreach (HttpPostedFileBase Uploadimagem in Uploadimagens)
			{

				string name = System.IO.Path.GetFileName(Uploadimagem.FileName);
				Uploadimagem.SaveAs(Server.MapPath("~/Images/" + name));

				string filename = "Images/" + name;

				//ID do novo produto 
				int idNovoPoduto = db.Produtos.Max(a => a.Prod_ID) + 1;
				//guarda o ID
				produto.Prod_ID = idNovoPoduto;

				//escolher o nome do ficheiro 
				string nomeImg = "Produto_" + idNovoPoduto + ".jpg";

				//var auxiliar
				string path = "";

				//validar se a img foi fornecida
				if (Uploadimagens != null)
				{
					path = Path.Combine(Server.MapPath("~/imagens/"), nomeImg);
					produto.ListaDeImagens = nomeImg;
				}
				else
				{
					ModelState.AddModelError("", "No Image");

					return View(produto);
				}
			}
			if (ModelState.IsValid)
			{
				db.Produtos.Add(produto);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			//ViewBag.CategoriasFK = new SelectList(db.Categorias, "Cat_ID", "NomeCateg", produto.CategoriasFK);
			return View(produto);
		}

		// GET: Produtos/Edit/5
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriasFK = new SelectList(db.Categorias, "Cat_ID", "NomeCateg", produtos.CategoriasFK);
            return View(produtos);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Prod_ID,NomeProduto,Descricao,IVAVenda,PrecoVenda,Stock,CategoriasFK")] Produtos produtos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriasFK = new SelectList(db.Categorias, "Cat_ID", "NomeCateg", produtos.CategoriasFK);
            return View(produtos);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produtos produtos = db.Produtos.Find(id);
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
