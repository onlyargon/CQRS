using System;
using System.Threading.Tasks;
using CQRS.Commands;
using CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMediator mediator;

        public ItemController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var response = await mediator.Send(new GetItemsQuery.Query());
            return response == null ? NotFound() : Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(AddItemCommand.Command command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
