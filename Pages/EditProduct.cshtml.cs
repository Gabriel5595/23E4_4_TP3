using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeStore.Model;
using PokeStore.Service;

namespace PokeStore.Pages;

public class EditProductModel : PageModel
{
    //PROPRIEDADE E ATRIBUTOS
    private IProductService _service;
    [BindProperty]
    public Product Product { get; set; }

    //CONSTRUTOR
    public EditProductModel(IProductService productService)
    {
        _service = productService;
    }

    //MÉTODOS
    public void OnGet(int id)
    {
        Product = _service.FindProduct(id);
    }

    public IActionResult OnPost()
    {

        if (!ModelState.IsValid)
        {
            return Page();
        }
        Console.WriteLine(Product.toString());
        _service.EditProduct(Product);

        return RedirectToPage("/List");

    }

    public IActionResult OnPostDelete()
    {
        _service.DeleteProduct(Product.ProductId);

        TempData["TempMensagemSucesso"] = true;

        return RedirectToPage("/List");
    }
}
