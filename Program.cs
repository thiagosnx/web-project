namespace Projeto_Web_Lh_Pets_Alunos;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Projeto_Web-Lh_Pets_Alunos");

        app.UseStaticFiles();
        app.MapGet("/index", (HttpContext context) => {
            context.Response.Redirect("index.html", false);
        });

        Banco dba = new Banco();
        app.MapGet("/listaClientes", (HttpContext context) => {
            context.Response.WriteAsync(dba.GetListaString());
        });

        app.Run();
    }
}
