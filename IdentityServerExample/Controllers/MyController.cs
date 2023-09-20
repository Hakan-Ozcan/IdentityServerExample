using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IdentityServerExample.Controllers
{
    [Authorize("ApiScope")]
    [ApiController]
    [Route("api/[controller]")]
    public class MyController : ControllerBase
    {
      
        [HttpGet]
        public IActionResult Get()
        {
            // Yalnızca "Admin" rolündeki kullanıcılara özel API kodları burada olur
            if (User.IsInRole("Admin"))
            {
                // Özel işlevsellik burada
                var data = new List<string> { "Veri 1", "Veri 2", "Veri 3" };
                return Ok(data);
            }
            else
            {
                return Forbid(); // Yetkisiz erişimi engelle
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] MyModel model)
        {
            // Yalnızca "Admin" rolündeki kullanıcılara özel POST işlevselliği burada olur
            if (User.IsInRole("Admin"))
            {
                // Modeli kullanarak veriyi ekleyebilirsiniz
                // Örneğin, veriyi veritabanına kaydedebilirsiniz.
                return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
            }
            else
            {
                return Forbid(); // Yetkisiz erişimi engelle
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MyModel model)
        {
            // Yalnızca "Admin" rolündeki kullanıcılara özel PUT işlevselliği burada olur
            if (User.IsInRole("Admin"))
            {
                // Modeli kullanarak varolan veriyi güncelleyebilirsiniz
                // Örneğin, id ile belirtilen veriyi güncelleyebilirsiniz.
                return NoContent();
            }
            else
            {
                return Forbid(); // Yetkisiz erişimi engelle
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Yalnızca "Admin" rolündeki kullanıcılara özel DELETE işlevselliği burada olur
            if (User.IsInRole("Admin"))
            {
                // Veriyi silmek için DELETE işlemi burada yapılır
                // Örneğin, id ile belirtilen veriyi silebilirsiniz.
                return NoContent();
            }
            else
            {
                return Forbid(); // Yetkisiz erişimi engelle
            }
        }
    }
}
