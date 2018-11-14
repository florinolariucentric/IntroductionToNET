using System;
using System.Collections.Generic;
using System.Linq;
using Fii.Data;

namespace Fii.Business
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public void Create(Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public Todo GetById(Guid id)
        {
            return _context.Todos.Find(id);
        }

        public IReadOnlyList<Todo> GetAll()
        {
            return _context.Todos.ToList();
        }
    }
}
