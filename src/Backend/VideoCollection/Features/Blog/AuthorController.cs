using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace VideoCollection.Features.Blog
{
    [Authorize]
    [RoutePrefix("api/author")]
    public class AuthorController : ApiController
    {
        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateAuthorCommand.AddOrUpdateAuthorResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateAuthorCommand.AddOrUpdateAuthorRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateAuthorCommand.AddOrUpdateAuthorResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateAuthorCommand.AddOrUpdateAuthorRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetAuthorsQuery.GetAuthorsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetAuthorsQuery.GetAuthorsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetAuthorByIdQuery.GetAuthorByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetAuthorByIdQuery.GetAuthorByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveAuthorCommand.RemoveAuthorResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveAuthorCommand.RemoveAuthorRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
