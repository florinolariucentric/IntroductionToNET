using System;
using System.Collections.Generic;
using System.Linq;
using Fii.Business;
using Fii.Data;
using Microsoft.AspNetCore.Mvc;
using TodoViewModel = TodoFullApplication.ViewModel.TodoViewModel;

namespace TodoFullApplication.Controllers
{
    public class TodosController : Controller
    {
        private readonly ITodoRepository _repository;

        public TodosController(ITodoRepository repository)
        {
            _repository=repository;
        }
        public IActionResult Index()
        {
            var todos = _repository.GetAll();

            var todosVM = todos.Select(todo => new TodoViewModel
            {
                Description = todo.Description
            })
                .ToList();

            return View(todosVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Description")] TodoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var todo = new Todo
            {
                Id = Guid.NewGuid(),
                Description = viewModel.Description
            };
            _repository.Create(todo);
            return RedirectToAction(nameof(Index));
        }

    }
}