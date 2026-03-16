using Backend.Contracts.Responses;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/invoices")]
public sealed class InvoiceController(IInvoiceService invoiceService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll([FromQuery] string? orgId, [FromQuery] string? status) =>
        Ok(invoiceService.GetInvoices(orgId, status));
}
