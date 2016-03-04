using HotelApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApi
{
    public class HotelRepository: IDisposable
    {
        HotelDbContext ctx = new HotelDbContext();

        public HotelRepository()
        {
            ctx.Configuration.ProxyCreationEnabled = false;
            // ctx.Configuration.LazyLoadingEnabled = false;
        }

        public Hotel FindById(int id)
        {
            return ctx
                    .Hotel
                    .Include(h => h.HotelBuchung)
                    .Where(h => h.HotelId == id)
                    .FirstOrDefault();

        }

        public IQueryable<Hotel> FindAll()
        {
            ctx.Database.Log += (sql) => {
                Debug.WriteLine(sql);

            };
            return ctx.Hotel.Where(h => h.RegionId == 3);
        }

        public List<Hotel> FindByRegion(int regionId)
        {
            return ctx
                    .Hotel
                    .Where(h => h.RegionId == regionId)
                    .ToList();
        }

        public void SaveHotel(Hotel hotel)
        {
            if (hotel.HotelId == 0)
            {
                ctx.Hotel.Add(hotel);
            }
            else {
                ctx.Hotel.Attach(hotel);
                ctx.Entry(hotel).State = EntityState.Modified;
                ApplyChanges();
                // ctx.ApplayChanges();
            }

            ctx.SaveChanges();

            ResetChanges();

        }

        private void ResetChanges()
        {
            foreach (var entry in ctx.ChangeTracker.Entries())
            {
                entry.State = EntityState.Unchanged;
            }
        }

        private void ApplyChanges()
        {
            foreach (var entry in ctx.ChangeTracker.Entries())
            {
                var entity = entry.Entity;
                var entityWithState = entity as IEntityWithState;

                if (entityWithState != null)
                {
                    var state = entityWithState.State;
                    entry.State = state;
                }
            }
        }

        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}
