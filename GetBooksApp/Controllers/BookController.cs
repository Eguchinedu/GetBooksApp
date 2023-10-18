using AutoMapper;
using GetBooksApp.Dtos;
using GetBooksApp.Interfaces;
using GetBooksApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GetBooksApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookModel>))]

        public IActionResult GetBooks()
        {
            var books = _mapper.Map<List<BookDto>>(_bookRepository.GetBooks());

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(books);
        }

        [HttpGet("{bookId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookModel>))]
        [ProducesResponseType(400)]

        public IActionResult GetBook(int bookId)
        {
            if(!_bookRepository.BookExists(bookId))
            {
                return NotFound();
            }

            var book = _mapper.Map<BookDto>(_bookRepository.GetBook(bookId));

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateBook([FromBody] BookForCreationDto bookCreate)
        {
            if(bookCreate == null)
            {
                return BadRequest();
            }

            var book = _bookRepository.GetBooks().Where(c => c.Title.Trim().ToLower() ==  bookCreate.Title.ToLower()).FirstOrDefault();

            if(book != null)
            {
                ModelState.AddModelError("", "Book Already exists");
                return StatusCode(422, ModelState);
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookMap = _mapper.Map<BookModel>(bookCreate);

            if (!_bookRepository.CreateBook(bookMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPut("{bookId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult UpdateBook(int bookId, [FromBody] BookDto bookUpdate)
        {
            if(bookUpdate == null)
            {
                return BadRequest(ModelState);
            }

            if(bookId != bookUpdate.Id)
            {
                return BadRequest(ModelState);
            }
            if(!_bookRepository.BookExists(bookId))
            {
                return NotFound();

            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var bookMap = _mapper.Map<BookModel>(bookUpdate);

            if (!_bookRepository.UpdateBook(bookMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating book");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete("{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteBook(int bookId)
        {
            if (!_bookRepository.BookExists(bookId))
            {
                return NotFound();
            }

            var bookToDelete = _bookRepository.GetBook(bookId);

      

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_bookRepository.DeleteBook(bookToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting book");
            }
            return NoContent();
        }

    }
}
