using System;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.API.Controllers
{
	public class AuthorsController : ControllerBase
	{
		private readonly ICourseLibraryRepository _courseLibraryRepository;

		public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
		{
			_courseLibraryRepository = courseLibraryRepository ??
				throw new ArgumentNullException(nameof(courseLibraryRepository));
		}

		[HttpGet()]
        public IActionResult GetAuthors()
        {
			var authorsFromRepo = _courseLibraryRepository.GetAuthors();
			return Ok(authorsFromRepo);
        }

		public IActionResult GetAuthor(Guid authorId)
        {
			var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);

			if (authorFromRepo == null)
            {
				return NotFound();
            }

			return Ok(authorFromRepo);
        }
    }
}

