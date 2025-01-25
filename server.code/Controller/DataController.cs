using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.code.ApplicationContext;
using server.code.Entity;
using server.code.Model;

namespace server.code.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController:ControllerBase
    {
        
        private readonly IdentityContext _context;

        public DataController(IdentityContext context){
            _context = context;
        }


        [HttpPost("ekleme")]
        public async Task<IActionResult> DataAdd(DataModel model)
        {
            try{
                var data = new DataTables{
                Name= model.Name, //kullanıcının girdiği veri
                Time= DateTime.Now  //Şimdiki zaman olarak ayarlandı
                };
                _context.DataTables.Add(data);
                _context?.SaveChangesAsync();
                return Ok();
            }catch(Exception ex){
                return BadRequest("Hata: "+ ex.Message);
            }
            
        }

        [HttpDelete("sil/{id}")]
        public async Task<IActionResult> DataDelete(int id)
        {
            try{
               var data = await _context.DataTables.FirstOrDefaultAsync(x=>x.Id == id);
               if(data!=null){
                _context.DataTables.Remove(data);
                _context?.SaveChangesAsync();
                return Ok();
               }else{
                return BadRequest("Veri yok.");
               }
            }catch(Exception ex){
                return BadRequest("Hata: "+ ex.Message);
            }
            
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> DataUpdate(int id, DataModel model)
        {
            try{
               var data = await _context.DataTables.FirstOrDefaultAsync(x=>x.Id == id);
               if(data!=null){
                data.Name=model.Name; //yeni veri ataması
                data.Time= DateTime.Now; //yeni veri ataması

                _context.DataTables.Update(data);
                _context?.SaveChangesAsync();
                return Ok();
               }else{
                return BadRequest("Veri yok.");
               }
            }catch(Exception ex){
                return BadRequest("Hata: "+ ex.Message);
            }
            
        }
    }
}