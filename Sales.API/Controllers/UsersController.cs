﻿namespace Sales.API.Controllers
{
    using System.IO;
    using System.Web.Http;
    using Newtonsoft.Json.Linq;
    using Sales.API.Helpers;
    using Sales.Common.Models;
    using System;

    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        public IHttpActionResult PostUser(UserRequest userRequest)
        {
            if (userRequest.ImageArray != null && userRequest.ImageArray.Length > 0)
            {
                var stream = new MemoryStream(userRequest.ImageArray);
                var guid = Guid.NewGuid().ToString();
                var file = $"{guid}.jpg";
                var folder = "~/Content/Users";
                var fullPath = $"{folder}/{file}";
                var response = FilesHelper.UploadPhoto(stream, folder, file);

                if (response)
                {
                    userRequest.ImagePath = fullPath;
                }
            }

            var answer = UsersHelper.CreateUserASP(userRequest);

            if (answer.IsSuccess)
            {
                return Ok(answer);
            }

            return BadRequest(answer.Message);
        }

        [HttpPost]
        [Authorize]
        [Route("GetUser")]
        public IHttpActionResult GetUser(JObject form)
        {
            try
            {
                var email = string.Empty;
                dynamic jsonObject = form;

                try
                {
                    email = jsonObject.Email.Value;
                }
                catch
                {
                    return BadRequest("Incorrect call.");
                }

                var user = UsersHelper.GetUserASP(email);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("LoginFacebook")]
        public IHttpActionResult LoginFacebook(FacebookResponse profile)
        {
            var user = UsersHelper.GetUserASP(profile.Id);
            if (user != null)
            {
                return Ok(true);
            }

            var userRequest = new UserRequest
            {
                Email = profile.Id,
                FirstName = profile.FirstName,
                ImagePath = profile.Picture.Data.Url,
                LastName = profile.LastName,
                Password = profile.Id,
            };

            var answer = UsersHelper.CreateUserASP(userRequest);
            return Ok(answer);
        }

        [HttpPost]
        [Route("LoginTwitter")]
        public IHttpActionResult LoginTwitter(TwitterResponse profile)
        {
            var user = UsersHelper.GetUserASP(profile.IdStr);
            if (user != null)
            {
                return Ok(true);
            }

            var userRequest = new UserRequest
            {
                Email = profile.IdStr,
                FirstName = profile.Name,
                ImagePath = profile.ProfileImageUrl,
                LastName = profile.Name,
                Password = profile.IdStr,
            };

            var answer = UsersHelper.CreateUserASP(userRequest);
            return Ok(answer);
        }
    }
}
