using OrchardCore.Commerce.ViewModels;
using System.Threading.Tasks;

namespace OrchardCore.Commerce.Abstractions;
public interface ICardPaymentService
{
    Task<CardPaymentReceiptViewModel> CreateAsync(CardPaymentViewModel viewModel);
}
