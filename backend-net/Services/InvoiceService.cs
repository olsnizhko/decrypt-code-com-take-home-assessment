using Backend.Data;
using Backend.Models;

namespace Backend.Services;

public interface IInvoiceService
{
    IEnumerable<Invoice> GetInvoices(string? orgId, string? status);
}

public sealed class InvoiceService(MockStore store) : IInvoiceService
{
    public IEnumerable<Invoice> GetInvoices(string? orgId, string? status)
    {
        IEnumerable<Invoice> data = store.Invoices;

        if (!string.IsNullOrWhiteSpace(orgId))
        {
            data = data.Where(invoice => invoice.OrgId == orgId);
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            data = data.Where(invoice => invoice.Status == status);
        }

        return data;
    }
}
