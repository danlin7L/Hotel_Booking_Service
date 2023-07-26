using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel_Booking_Backend.Models;
using Hotel_Booking_Backend.Services;

namespace Hotel_Booking_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        // GET: /hotels
        [HttpGet]
        public async Task<IEnumerable<Hotel>> GetAllHotels()
        {


            return await _hotelService.GetAllHotels();
        }

        // GET: /hotels/{id}
        [HttpGet("{id}")]
        public async Task<Hotel> GetHotelById(int id)
        {
            return await _hotelService.GetHotelById(id);
        }

        // POST: /hotels
        [HttpPost]
        public async Task<Hotel> CreateHotel([FromBody] Hotel hotel)
        {
            return await _hotelService.CreateHotel(hotel);
        }

        // PUT: /hotels
        [HttpPut]
        public async Task UpdateHotel([FromBody] Hotel hotel)
        {
            await _hotelService.UpdateHotel(hotel);
        }

        // DELETE: /hotels/{id}
        [HttpDelete("{id}")]
        public async Task DeleteHotel(int id)
        {
            await _hotelService.DeleteHotel(id);
        }
    }
}
