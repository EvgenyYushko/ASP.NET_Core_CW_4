using Meetup.BLL.Interfaces;
using Meetup.BLL.ViewModels.Speaker;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerController : Controller
    {
        private readonly ISpeakerService _speakerService;

        public SpeakerController(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        [HttpGet]
        [Route("getall")]
        public List<InfoSpeaker> GetAllListeners()
        {
            return _speakerService.FindSpeakerByFunc(null);
        }

        [HttpGet]
        [Route("getbyid")]
        public List<InfoSpeaker> GetListenerById(Guid id)
        {
            return _speakerService.FindSpeakerByFunc(m => m.Id == id);
        }

        [HttpPost]
        public Guid Register([FromForm] RegisterSpeaker registerSpeaker)
        {
            return (_speakerService.RegisterSpeakerAsync(registerSpeaker)).Result;
        }
    }
}
