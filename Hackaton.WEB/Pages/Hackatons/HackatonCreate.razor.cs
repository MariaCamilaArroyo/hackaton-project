using CurrieTechnologies.Razor.SweetAlert2;
using Hackaton.WEB.Repository;
using Hackaton.shared.Entities;
using Microsoft.AspNetCore.Components;

namespace Hackaton.WEB.Pages.Hackatons;

public partial class HackatonCreate
{
    private  HackatonForm?  HackatonForm;
    private HackatonTable hackaton = new();

    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

    private async Task CreateAsync()
    {
        var responseHttp = await Repository.PostAsync("/api/hackatons", hackaton);
        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
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
         HackatonForm!.FormPostedSuccessfully = true;
        NavigationManager.NavigateTo("/Hackatons");
    }
}
