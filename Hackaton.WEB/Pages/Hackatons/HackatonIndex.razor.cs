using Hackaton.shared.Entities;
using Hackaton.WEB.Repository;
using Microsoft.AspNetCore.Components;

namespace Hackaton.WEB.Pages.Hackatons;

public partial class HackatonIndex
{
    [Inject] private IRepository Repository { get; set; } = null!;

    private List<HackatonTable>? Hackatons { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var responseHttp = await Repository.GetAsync<List<HackatonTable>>("/api/hackatons");
        Hackatons = responseHttp.Response!;
    }
}