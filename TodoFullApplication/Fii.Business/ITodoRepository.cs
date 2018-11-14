using System;
using System.Collections.Generic;
using Fii.Data;

namespace Fii.Business
{
    public interface ITodoRepository
    {
        void Create(Todo todo);
        Todo GetById(Guid id);
        IReadOnlyList<Todo> GetAll();
    }
}