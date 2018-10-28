using StudyPoints.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace StudyPoints.Controllers.Api
{
    public class PointItemController : ApiController
    {
        private ApplicationDbContext context;

        public PointItemController()
        {
            context = new ApplicationDbContext();
            context.Configuration.LazyLoadingEnabled = false;
        }

        // GET: api/PointItem
        [HttpGet]
        public IEnumerable<PointItem> GetPointItems()
        {
            return context.PointItems;
        }

        // GET: api/PointItem/5
        public PointItem GetPointItemById(int id)
        {
            var pointItem = context.PointItems.SingleOrDefault(c => c.Id == id);
            return pointItem;
        }

        // DELETE: api/PointItem/5
        public void Delete(int id)
        {
            PointItem value = context.PointItems.SingleOrDefault(c => c.Id == id);
            context.PointItems.Remove(value);
            context.SaveChanges();
        }
    }
}
