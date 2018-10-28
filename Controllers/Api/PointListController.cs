using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudyPoints.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using System.Web.Security;
using AutoMapper;
using StudyPoints.Logics;

namespace StudyPoints.Controllers.Api
{
    public class PointListController : ApiController
    {
        private ApplicationDbContext context;

        public PointListController()
        {
            context = new ApplicationDbContext();
            context.Configuration.LazyLoadingEnabled = false;
        }

        // GET: api/PointList/
        public IHttpActionResult GetPointList()
        {
            if (User.IsInRole("CanManagePointItem"))
            {
                var result = context.PointLists
                    .ToList()
                    .Select(Mapper.Map<PointList, PointListDto>)
                    .OrderByDescending(a => a.DateAdded);
                return Ok(result);
            }
            else
            {
                string userId = User.Identity.GetUserId();
                var result = context.PointLists
                    .Where(c => c.UserId == userId)
                    .ToList()
                    .Select(Mapper.Map<PointList,PointListDto>)
                    .OrderByDescending(a => a.DateAdded);
                return Ok(result);
            }
        }

        // GET: api/PointList/GetPointSummary
        [Route("api/pointlist/getpointsummary")]
        public PointSummary GetPointSummary()
        {
            string userId = User.Identity.GetUserId();
            if (User.IsInRole("CanManagePointItem"))
            {
                //return context.PointLists.Sum(c => c.Points);
                return new PointSummary();
            }
            else
            {
                decimal totalPoints = context.PointLists.Where(c => c.UserId == userId).Sum(c => c.Points);
                var level = (int)Math.Floor(totalPoints / 50) + 1;
                return new PointSummary()
                {
                    UserName = User.Identity.GetUserName(),
                    TotalPoints = (int)totalPoints,
                    Level = level,
                    PointsToNextLevel = (level * 50) - (int)totalPoints
                };
            }            
        }
        [HttpPost]
        [Route("api/pointlist/update")]
        // POST: api/PointList/
        public IHttpActionResult PostPointList([FromBody]JObject jObject)
        {
            dynamic jobject = jObject;
            var pointItemId = (int)jobject.pointItemId;
            string userId = User.Identity.GetUserId();
            string userName = User.Identity.GetUserName();
            PointItem result = context.PointItems.SingleOrDefault(c => c.Id == pointItemId);
            var value = new PointList
            {
                UserId = userId,
                UserName = userName,
                PointItemId = result.Id,
                PointItemName = result.Name,
                Points = result.Points,
                Remark = "",
                DateAdded = DateTime.Now
            };
            context.PointLists.Add(value);
            context.SaveChanges();

            //管理者情報の取得
            var mailContext = context.Users
                .Join(context.UserRoles, a => a.Id, b => b.UserId, (a, b) => new { a.UserName, a.Email, b.RoleId })
                .Join(context.Roles, ab => ab.RoleId, d => d.Id, (ab, c) => new { ab.UserName, ab.Email, c.Name })
                .Where(d => d.Name == "CanManagePointItem")
                .FirstOrDefault();

            //SendGridのメール配信呼び出し
            SendEmail sendEmail = new SendEmail();
            var mailResult = sendEmail.CallSendGridApi(userName, mailContext.UserName, mailContext.Email);

            return Ok();
        }

        // DELETE: api/PointList/5
        public void DeletePointList(int id)
        {
            var value = context.PointLists.SingleOrDefault(c => c.Id == id);
            context.PointLists.Remove(value);
            context.SaveChanges();
        }
    }
}
