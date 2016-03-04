using HotelApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;

namespace HotelApi.Controllers
{
    // /api/hotel
    public class HotelController : ApiController
    {
        HotelRepository repo = new HotelRepository();

        // GET /api/hotel?id=47
        public Hotel GetById(int id) {
            return repo.FindById(id);
        }

        // GET /api/hotel
        [EnableQuery]
        public IQueryable<Hotel> GetAll(ODataQueryOptions options) {


            return repo.FindAll();
        }

        // GET /api/hotel?regionId=4777
        public List<Hotel> GetByRegion(int regionId) {
            return repo.FindByRegion(regionId);
        }

        // POST /api/hotel
        public void PostHotel(Hotel hotel) {
            repo.SaveHotel(hotel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                this.repo.Dispose();
            }
        }
    }
}
