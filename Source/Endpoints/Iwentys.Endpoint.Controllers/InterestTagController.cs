﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Iwentys.Features.Gamification.Models;
using Iwentys.Features.Gamification.Services;
using Microsoft.AspNetCore.Mvc;

namespace Iwentys.Endpoint.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class InterestTagController : ControllerBase
    {
        private readonly InterestTagService _interestTagService;

        public InterestTagController(InterestTagService interestTagService)
        {
            _interestTagService = interestTagService;
        }

        [HttpGet]
        public async Task<ActionResult<List<InterestTagDto>>> GetAllTags()
        {
            List<InterestTagDto> result = await _interestTagService.GetAllTags();
            return Ok(result);
        }

        [HttpGet("students/{studentId}")]
        public async Task<ActionResult<List<InterestTagDto>>> GetStudentTags(int studentId)
        {
            List<InterestTagDto> result = await _interestTagService.GetStudentTags(studentId);
            return result;
        }

        [HttpGet("students/{studentId}/add/{tagId}")]
        public async Task<ActionResult> AddStudentTag(int studentId, int tagId)
        {
            await _interestTagService.AddStudentTag(studentId, tagId);
            return Ok();
        }
        
        [HttpGet("students/{studentId}/remove/{tagId}")]
        public async Task<ActionResult> RemoveStudentTag(int studentId, int tagId)
        {
            await _interestTagService.RemoveStudentTag(studentId, tagId);
            return Ok();
        }
    }
}