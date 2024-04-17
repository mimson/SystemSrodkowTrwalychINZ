using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SrodkiTrwale.Api.ApiModels;
using SrodkiTrwale.Api.Models;
using SrodkiTrwale.Context;
using SrodkiTrwale.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SrodkiTrwale.Api.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class FixedAssetsController : ControllerBase
    {
        private readonly SystemSrodkowTrwalychContext _context;
        public FixedAssetsController()
        {
            _context = new SystemSrodkowTrwalychContext();
        }


        // GET: api/<FixedAssetsController>
        [HttpGet]
        public List<FixedAssetApiModel> GetFixedAssets()
        {       
            List<FixedAssetApiModel> models = new List<FixedAssetApiModel>();
            var fixeds = _context.FixedAssets.Include(u=>u.User).Include(c=>c.Categories).Where(x=>x.DateOfCollections>=System.DateTime.Today && x.DateOfCollections<= System.DateTime.Today.AddDays(1)).ToList();
            if (fixeds.Count > 0)
            {
                foreach(var asset in fixeds)
                {
                    models.Add(new FixedAssetApiModel
                    {
                        id = asset.Id,
                        categoryName =asset.Categories.CatTypes,
                        dateOfCollections = asset.DateOfCollections,
                        name = asset.Name,
                        userName = asset.User.FirstName + asset.User.LastName
                    });
                }
                return models;
            }
            else
            {
                return null;
            }
                  
        }



        // GET api/<FixedAssetsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
