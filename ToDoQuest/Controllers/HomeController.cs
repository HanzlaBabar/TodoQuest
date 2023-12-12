using Microsoft.AspNetCore.Mvc;
using ToDoQuest.Models;
using ToDoQuest.Services;

namespace ToDoQuest.Controllers;

public class HomeController : Controller
{
    private readonly ITodoItemService _todoItemService;

    public HomeController(ITodoItemService todoItemService)
    {
        _todoItemService = todoItemService;
    }

    public async Task<IActionResult> Index()
    {
        var todoItems = await _todoItemService.GetTodoItemsAsync();

        return View(todoItems);
    }

    public async Task<IActionResult> Create()
    {
        var model = new TodoViewModel();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TodoViewModel model)
    {
        if (ModelState.IsValid)
        {
            await _todoItemService.CreateTodoItemAsync(model);

            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return View("NotFound");
        }

        var todoItem = await _todoItemService.GetTodoItemById(id.Value);

        if (todoItem == null)
        {
            return View("NotFound");
        }

        return View(todoItem);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(TodoViewModel model)
    {
        if (ModelState.IsValid)
        {
            await _todoItemService.UpdateTodoItemAsync(model);

            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return View("Not Found");
        }

        var todoItem = await _todoItemService.GetTodoItemById(id.Value);

        if (todoItem == null)
        {
            return View("Not Found");
        }

        return View(todoItem);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _todoItemService.DeleteTodoItemAsync(id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Complete(int id)
    {
        await _todoItemService.CompleteTodoItemAsync(id);

        return RedirectToAction(nameof(Index));
    }
}
