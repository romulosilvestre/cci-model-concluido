using VoeAirlines.Contexts;
using VoeAirlines.Entities;
using VoeAirlines.ViewModels;

namespace VoeAirlines.Services;

public class AeronaveService{
    
    
    //propriedade para injeção de dependência
    private readonly VoeAirlinesContext _context;

    public AeronaveService(VoeAirlinesContext context)
    {
        _context = context;
    }

    public DetalhesAeronaveViewModel AdicionarAeronave(AdicionarAeronaveViewModel dados)
    {
        

        var aeronave = new Aeronave(dados.Fabricante, dados.Modelo, dados.Codigo,dados.Tipo);

        _context.Add(aeronave);
        _context.SaveChanges();

        return new DetalhesAeronaveViewModel
        (
            aeronave.Id,
            aeronave.Fabricante,
            aeronave.Modelo,
            aeronave.Codigo,
            aeronave.Tipo
        );
    } 


    public IEnumerable<ListarAeronaveViewModel> ListarAeronaves(){
         
         return _context.Aeronaves.Select(a=>new  ListarAeronaveViewModel(a.Id,a.Modelo,a.Tipo));
    }




}