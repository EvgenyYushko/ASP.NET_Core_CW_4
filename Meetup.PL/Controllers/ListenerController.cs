using Meetup.BLL.Interfaces;
using Meetup.BLL.ViewModels.Listener;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Meetup.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListenerController : Controller
    {
        private readonly IListenerService _listenerService;

        public ListenerController(IListenerService listenerService)
        {
            _listenerService = listenerService;
        }

        [HttpGet]
        [Route("getall")]
        public List<InfoListener> GetAllListeners()
        {
            return _listenerService.FindListenerByFunc(null);
        }

        [HttpGet]
        [Route("getbyid")]
        public List<InfoListener> GetListenerById(Guid id)
        {
            return _listenerService.FindListenerByFunc(m => m.Id == id);
        }

        [HttpPost]
        public Guid Register([FromForm] RegisterListener registerListener)
        {
            return (_listenerService.RegisterListenerAsync(registerListener)).Result;
        }
    }
}
