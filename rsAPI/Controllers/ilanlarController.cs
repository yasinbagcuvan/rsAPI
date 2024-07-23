using Microsoft.AspNetCore.Mvc;
using rsAPI.Data;
using rsAPI.Data.Entities.Concrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ilanlarController : ControllerBase
    {
        private AppDbContext _appDbContext;

        public ilanlarController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: api/<ilanlarController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_appDbContext.ilanlar.ToList());
        }

        // GET api/<ilanlarController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_appDbContext.ilanlar.Find(id));
        }

        // POST api/<ilanlarController>
        [HttpPost]
        public IActionResult Post(ilanlar ilan)
        {
            ilan.Created = DateTime.Now;
            if(ModelState.IsValid)
            {
                ilan.Id = 0;
                _appDbContext.ilanlar.Add(ilan);
                _appDbContext.SaveChanges();
                return Created($"/ilan/{ilan.Id})",ilan);
            }
            return BadRequest();
        }

        // PUT api/<ilanlarController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ilanlar ilan)
        {
            ilanlar _ilan = _appDbContext.ilanlar.Find(id);
            if(_ilan == null)
            {
                return NotFound($"ID: {id} olan bir ilan bulunamamıştır.");
            }
            _ilan.ilanBaslik = ilan.ilanBaslik;
            _ilan.ilanAciklama = ilan.ilanAciklama;
            _ilan.ilanFiyat = ilan.ilanFiyat;
            _ilan.ilanResmi = ilan.ilanResmi;
            _ilan.ilanKategorisi = ilan.ilanKategorisi;
            _ilan.ilanDaireTipi = ilan.ilanDaireTipi;
            _ilan.Updated=DateTime.Now;
            _appDbContext.ilanlar.Update(_ilan);
            _appDbContext.SaveChanges();
            return Ok(_ilan);
        }

        // DELETE api/<ilanlarController>/5
        [HttpPatch("{id}")]
        public IActionResult Delete(int id)
        {
            ilanlar? _ilan = _appDbContext.ilanlar.Find(id);
            if(_ilan == null)
            {
                return NotFound($"ID: {id} olan bir ilan bulunamamıştır.");
            }
            _ilan.isDeleted=true;
            _appDbContext.Update(_ilan);
            _appDbContext.SaveChanges();
            return Ok();
        }
    }
}
