using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", DateTime.Now, "hroad"));
            _items.Add(new TodoItem("Tarefa 2", DateTime.Now, "hroad"));
            _items.Add(new TodoItem("Tarefa 3", DateTime.Now, "andrebaltieri"));
        }

        [TestMethod]
        public void Deve_retornar_tarefas_apenas_do_usuario_hroad()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("hroad"));
            Assert.AreEqual(2, result.Count());
        }
    }
}