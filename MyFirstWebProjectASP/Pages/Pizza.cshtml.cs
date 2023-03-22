using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFirstWebProjectASP.Models;
using MyFirstWebProjectASP.Services;

namespace MyFirstWebProjectASP.Pages
{
    public class PizzaModel : PageModel
    {
        [BindProperty]
        public Pizza NewPizza { get; set; } = new();
        public List<Pizza> pizzas = new();
        /* �������� � ��������� ��������� ��������� ����� ����, ������� ���������� ��������.
         * ��� ����������� �� ���� ����, ��� ��� ����������� �����, ��� � <input asp-for="Pizza.Name">,
         * ������������ ���� ��������.*/

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            PizzaService.Add(NewPizza);
            return RedirectToAction("Get");
        }

        public void OnGet()
        {
            pizzas = PizzaService.GetAll();
        }

        public string GlutenFreeText(Pizza pizza)
        {
            return pizza.IsGlutenFree ? "Gluten Free" : "Not Gluten Free";
        }

        public IActionResult OnPostDelete(int id)
        {
            PizzaService.Delete(id);
            return RedirectToAction("Get");
        }
    }
}
