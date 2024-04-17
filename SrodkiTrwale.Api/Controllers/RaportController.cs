using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SrodkiTrwale.Api.Models;
using SrodkiTrwale.Api.Models.Raports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SrodkiTrwale.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RaportController : Controller
    {
        private readonly SystemSrodkowTrwalychContext _context;

        public RaportController(SystemSrodkowTrwalychContext context)
        {
            _context = context;
        }

        [HttpGet("GetRaports")]
        public async Task<List<User>> GetRaports()
        {
            var users = await _context.Users.ToListAsync();
            var fixedAssets = await _context.FixedAssets.ToListAsync();

            foreach (var user in users)
                user.FixedAssets = fixedAssets.Where(x => x.UserId == user.Id).ToList();

            var fixedAssetsLast30 = fixedAssets.Where(x => x.DateOfCollections > DateTime.UtcNow.AddDays(-30)).ToList();

            return users;
        }

        [HttpGet("GetRaports2")]
        public async Task<UserFixedAssets> GetRaports2()
        {
            UserFixedAssets response = new();
            var users = await _context.Users.ToListAsync();
            var fixedAssets = await _context.FixedAssets.ToListAsync();

            foreach (var user in users)
                user.FixedAssets = fixedAssets.Where(x => x.UserId == user.Id).ToList();

            var fixedAssetsLast30 = fixedAssets.Where(x => x.DateOfCollections > DateTime.UtcNow.AddDays(-30)).Count();
            
            response.Users = users;
            response.AssetsRegisteredInLast30Days = fixedAssetsLast30;
            return response;
        }
    }
}
