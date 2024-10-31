using CurrieTechnologies.Razor.SweetAlert2;
using Hackaton.WEB.Repository;
using Hackaton.shared.Entities;
using Microsoft.AspNetCore.Components;

namespace Hackaton.WEB.Pages.Hackatons;

public partial class HackatonEdit
{
    private HackatonTable hackaton;
    private HackatonForm? hackatonForm;

    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

    [Parameter] public int Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var responseHttp = await Repository.GetAsync<HackatonTable>($"api/Hackatons/{Id}");

        if (responseHttp.Error)
        {
            if (responseHttp.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                NavigationManager.NavigateTo("Hackaton");
            }
            else
            {
                var messageError = await responseHttp.GetErrorMessageAsync();
            }
        }
        else
        {
            hackaton = responseHttp.Response;
        }
    }

    private async Task EditAsync()
    {
        var responseHttp = await Repository.PutAsync("api/hackatons", hackaton);

        if (responseHttp.Error)
        {
            var mensajeError = await responseHttp.GetErrorMessageAsync();
            return;
        }

        Return();
        var toast = SweetAlertService.Mixin(new SweetAlertOptions
        {
            Toast = true,
            Position = SweetAlertPosition.BottomEnd,
            ShowConfirmButton = true,
            Timer = 3000
        });
    }

    private void Return()
    {
        hackatonForm!.FormPostedSuccessfully = true;
        NavigationManager.NavigateTo("hackaton");
    }
}

