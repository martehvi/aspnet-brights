using Conduit.Domain.Entities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conduit.Presentation.Controllers;

[Route("[controller]")]
[ApiExplorerSettings(GroupName = "Orders")]
[Authorize]
public class OrdersController
{
    public OrdersController()
    {

    }

    /// <summary>
    /// Get recent orders globally
    /// </summary>
    /// <remarks>Get all orders globally. </remarks>
    /// <returns></returns>
    [HttpGet(Name = "GetOrders")]
    [AllowAnonymous]
    public void List()
    {
        // insert GET logic here
        // should return something similar as the GET endpoint in the other *Controller.cs files - like Task<MutlipleOrderResponse>
    }
}
