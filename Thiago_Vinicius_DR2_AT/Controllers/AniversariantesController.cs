using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Thiago_Vinicius_DR2_AT.Models;

namespace Thiago_Vinicius_DR2_AT.Controllers
{
    public class AniversariantesController : Controller
    {

        // Banco de dados
        public readonly AniversariantesContext db;
        public AniversariantesController(AniversariantesContext context)
        {
            db = context;
        }

        //Listagem de todos os aniversáriantes
        public IActionResult Index()
        {
            var pessoas = db.pessoas.ToList();
            return View(pessoas);
        }
        // Criação de um aniversáriante
        public IActionResult Criar(int? id)
        {
            var pessoas = db.pessoas.ToList();

            if (id != null)
            {
                var pessoaSelecionada = pessoas.First(person => person.Id == id);
                return View("Criar", pessoaSelecionada);
            }
            //db.pessoas.Add(aniversariante);
            return View();
        }

        // Manda um post para criar um aniversariante
        [HttpPost]
        public IActionResult PostFromForm(string nome, string sobrenome, string aniversario)
        {
            var aniversariante = new Aniversariante()
            {
                Nome = nome,
                Sobrenome = sobrenome,
                DataDeAniversario = aniversario
            };


            db.Add(aniversariante);
            db.SaveChanges();

            return Redirect("/Aniversariantes");
        }

        //Manda um post para atualizar o aniversariante
        [HttpPost]
        public IActionResult Atualizar(int Id, string nome, string sobrenome, string aniversario)
        {
            var produto = db.pessoas.First(product => product.Id == Id);
            produto.Nome = nome;
            produto.Sobrenome = sobrenome;
            produto.DataDeAniversario = aniversario;

            db.SaveChanges();

            return Redirect("/Aniversariantes");

        }

        public IActionResult Filtrar(string nome)
        {

            var pessoas = db.pessoas.ToList();
            var selectedPersons = pessoas.Where(p => 
            {
                var nomeCompleto = p.Nome + "" + p.Sobrenome;


                return nomeCompleto.Contains(nome);
            }); 

            return View(selectedPersons);
        }

        public IActionResult Listagem()
        {

            var pessoas = db.pessoas.ToList();
            var pessoasOrdenadas = pessoas.OrderBy(p => p.CalcularAniversario());

            var aniversariantesDeHoje = pessoas.Where(p => p.CalcularAniversario() == 0);

            if (aniversariantesDeHoje.IsNullOrEmpty()) aniversariantesDeHoje = null;

            ViewBag.aniversariantesDeHoje = aniversariantesDeHoje;

            return View(pessoasOrdenadas);
        }


        public IActionResult Delete(int Id)
        {
            var pessoas = db.pessoas.ToList();

            var pessoaSelecionada = pessoas.First(person => person.Id == Id);

            db.pessoas.Remove(pessoaSelecionada);
            db.SaveChanges();

            return Redirect("/Aniversariantes");
        }
    }
}
