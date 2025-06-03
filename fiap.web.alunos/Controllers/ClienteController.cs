using fiap.web.alunos.Data;
using fiap.web.alunos.Migrations;
using fiap.web.alunos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fiap.web.alunos.Controllers
{
    public class ClienteController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        //private List<ClienteModel> _clientes;

        public ClienteController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;

        }



        public IActionResult Index()
        {
            var clientes = _databaseContext.Clientes.ToList();
            return View(clientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]        
        public IActionResult Create(ClienteModel clienteModel)
        {

            try
            {
                _databaseContext.Clientes.Add(clienteModel);
                _databaseContext.SaveChanges();

                TempData["SuccessMessage"] = "Cliente cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Erro ao salvar no banco de dados: {ex.Message}");
                Console.WriteLine($"Detalhes do erro interno: {ex.InnerException?.Message}");

                // Você pode adicionar um erro ao ModelState para exibir na View
                ModelState.AddModelError("", "Ocorreu um erro ao salvar o cliente. Por favor, verifique os dados e tente novamente.");
                // Ou uma mensagem mais específica para o usuário
                // ModelState.AddModelError("", $"Erro: {ex.InnerException?.Message}");
                return View(clienteModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
                // Adicione uma mensagem de erro genérica ao ModelState
                ModelState.AddModelError("", "Ocorreu um erro inesperado. Por favor, contate o suporte.");
                return View(clienteModel);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var clienteEncontrado = _databaseContext.Clientes.Find(id);
            return View(clienteEncontrado);
        }
        [HttpPost]
        public IActionResult Edit(ClienteModel clienteModel)
        {
            Console.WriteLine("Chegou aqui");
            _databaseContext.Clientes.Update(clienteModel);
            _databaseContext.SaveChanges();
            TempData["SuccessMessage"] = $"Os dados do cliente {clienteModel.Nome} foram alterados";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var clienteEncontrado = _databaseContext.Clientes.Find(id);
            if(clienteEncontrado != null)
            {
                _databaseContext.Remove(clienteEncontrado);
                _databaseContext.SaveChanges();
                TempData["SuccessMessage"] = $"O cliente {clienteEncontrado.Nome} foi deletado!";
            }

            
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var clienteEncontrado = _databaseContext.Clientes.Find(id);

            return View(clienteEncontrado);
        }


    }
}
