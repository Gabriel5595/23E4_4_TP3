using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeStore.Model;
using PokeStore.Service;

namespace PokeStore.Pages;

public class CreateProductModel : PageModel
{
    //PROPRIEDADES E ATRIBUTOS
    private IProductService _service;

    [BindProperty]
    public Product Product { get; set; }
    
    //CONSTRUTOR
    public CreateProductModel(IProductService productService)
    {
        _service = productService;
    }

    //MÉTODOS
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _service.AddProduct(Product);

        return RedirectToPage("/List");
    }
}
