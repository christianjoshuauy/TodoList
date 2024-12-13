using Blazored.LocalStorage;
using TestBlazor.Models;

namespace TestBlazor.Services;

public class TodoService
{
    private readonly ILocalStorageService _localStorage;

    public TodoService(ILocalStorageService localStorage) => _localStorage = localStorage;

    public async Task<List<TodoItem>> LoadTodos() => await _localStorage.GetItemAsync<List<TodoItem>>("todos") ?? new();
    public async Task SaveTodos(List<TodoItem> todos) => await _localStorage.SetItemAsync("todos", todos);
    public async Task ClearCompleted(List<TodoItem> todos)
    {
        todos.RemoveAll(t => t.IsDone);
        await SaveTodos(todos);
    }
}