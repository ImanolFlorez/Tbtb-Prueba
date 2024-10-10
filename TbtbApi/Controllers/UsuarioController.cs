using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TbtbApi.Data;
using TbtbApi.Models;
using TbtbApi.Models.Dto;

namespace TbtbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;
        private ResponseDto _response;


        public UsuarioController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDto();
        }

        [HttpGet("GetUsers")]
        public ResponseDto GetUsers()
        {
            try
            {
                IEnumerable<UsuarioClass> usuarios = _context.Usuario.ToList();
                _response.Data = usuarios;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetUserById/{id}")]
        public ResponseDto GetUserById(int id)
        {
            try
            {
                var Usuario = _context.Usuario.FirstOrDefault(p => p.Id == id);
                _response.Data = Usuario;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpPost("PostUser")]
        public ResponseDto PostUser([FromBody] UsuarioClass usuario)
        {
            try
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();

                _response.Data = usuario;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpPut("PutUser")]
        public ResponseDto PutUser([FromBody] UsuarioClass usuario)
        {
            try
            {
                _context.Usuario.Update(usuario);
                _context.SaveChanges();

                _response.Data = usuario;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete("DeleteUser/{id}")]
        public ResponseDto DeleteUser(int id)
        {
            try
            {
                var usuario = _context.Usuario.FirstOrDefault(p => p.Id == id);
                _ = _context.Remove(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
