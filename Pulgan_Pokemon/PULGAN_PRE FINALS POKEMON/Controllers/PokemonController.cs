using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace PULGAN_PRE_FINALS_POKEMON.Controllers
{
    public class PokemonController : Controller
    {

            private readonly HttpClient _httpClient;

            public PokemonController()
            {
                _httpClient = new HttpClient();
            }

            public async Task<IActionResult> Index(string name = "jigglypuff")
            {
                var pokemon = await GetPokemon(name);
                return View(pokemon);
            }

            private async Task<Pokemon> GetPokemon(string name)
            {
                var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{name}");
                return JsonConvert.DeserializeObject<Pokemon>(response);
            }
        }
    }