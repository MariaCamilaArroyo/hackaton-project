using CurrieTechnologies.Razor.SweetAlert2;
using Hackaton.shared.Entities;
using Hackaton.WEB.Repository;
using Microsoft.AspNetCore.Components;

namespace Hackaton.WEB.Pages.Hackatons;
public partial class HackatonIndex
{
    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

    private List<HackatonTable>? Hackatons { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadAsync();
    }

    private async Task LoadAsync()
    {
        var responseHppt = await Repository.GetAsync<List<HackatonTable>>("api/hackatons");
        if (responseHppt.Error)
        {
            var message = await responseHppt.GetErrorMessageAsync();
            return;
        }
        Hackatons = responseHppt.Response!;
    }

    private async Task DeleteAsync(HackatonTable hackaton)
    {
        var result = await SweetAlertService.FireAsync(new SweetAlertOptions
        {
            Title = "confirmar",
            Text = "Confirmar Eliminación",
            Icon = SweetAlertIcon.Question,
            ShowCancelButton = true,
            CancelButtonText = "Cancelar"
        });

        var confirm = string.IsNullOrEmpty(result.Value);

        if (confirm)
        {
            return;
        }

        var responseHttp = await Repository.DeleteAsync($"api/hackatons/{hackaton.Id}");
        if (responseHttp.Error)
        {
            if (responseHttp.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                var mensajeError = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", mensajeError, SweetAlertIcon.Error);
            }
            return;
        }

        await LoadAsync();
        var toast = SweetAlertService.Mixin(new SweetAlertOptions
        {
            Toast = true,
            Position = SweetAlertPosition.BottomEnd,
            ShowConfirmButton = true,
            Timer = 3000,
            ConfirmButtonText = "Si"
        });
        toast.FireAsync(icon: SweetAlertIcon.Success, message: "Eliminado");
    }
}
