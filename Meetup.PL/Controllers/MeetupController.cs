using Meetup.BLL.Interfaces;
using Meetup.BLL.ViewModels.Meetup;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetupController : ControllerBase
    {
        private readonly IMeetupService _meetupService;

        public MeetupController(IMeetupService meetupService)
        {
            _meetupService = meetupService;
        }

        [HttpGet]
        [Route("getall")]
        public List<InfoMeetup> GetAllMeetups()
        {
            return _meetupService.FindMeetupByFunc(null);
        }

        [HttpGet]
        [Route("getbyid")]
        public List<InfoMeetup> GetMeetupById(Guid id)
        {
            return _meetupService.FindMeetupByFunc(m => m.Id == id);
        }

        [HttpGet]
        [Route("updatebyid")]
        public InfoMeetup SetStatusMeetupById(Guid id, int statusId)
        {
            return _meetupService.UpdateMeetupById(id, statusId).Result;
        }

        [HttpGet]
        [Route("delete")]
        public void DeleteMeetupById(Guid id)
        {
            _meetupService.DeleteMeetupById(id);
        }

        [HttpPost]
        public Guid Create([FromForm] CreateMeetup createMeetup)
        {
            return _meetupService.CreateMeetupAsync(createMeetup).Result;
        }
    }
}
