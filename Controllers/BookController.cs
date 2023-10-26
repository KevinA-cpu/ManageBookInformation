using AutoMapper;
using ManageBookInformation.Data;
using ManageBookInformation.DTOs;
using ManageBookInformation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ManageBookInformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController:ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public BookController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Books = _dataContext.Books.ToList();
            return Ok(Books);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id) {

            var book = _dataContext.Books.FirstOrDefault(book => book.Id == id);
            if(book == null)
            {
                return NotFound();
            }
            var bookDTO = _mapper
                .Map<BookDTO>(book);
            return Ok(bookDTO);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            _dataContext.Books.Add(book);
            _dataContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, bookDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] BookDTO bookDTO )
        {
            var book = _dataContext.Books.FirstOrDefault(book => book.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            _mapper.Map(bookDTO, book);
            _dataContext.SaveChanges();
            return Ok(bookDTO);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var book = _dataContext.Books.FirstOrDefault(book => book.Id == id);
            if(book == null)
            {
                return NotFound();
            }
            _dataContext.Books.Remove(book);
            _dataContext.SaveChanges(); 
            var bookDTO = _mapper.Map<BookDTO>(book);   
            return Ok(bookDTO);
        }



    }


}
