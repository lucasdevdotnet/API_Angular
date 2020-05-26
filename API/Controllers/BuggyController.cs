using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StroreContext _context;

        public BuggyController(StroreContext context)
        {
            this._context = context;
        }

            [HttpGet("notfound")]
            public ActionResult GetNotFoundRequest()
            {

                 var thing  =  _context.Products.Find(42);
                 if(thing== null)
                 {
                     return NotFound(new ApiResponse(404)); // genial  velho   criada  a class   para rerona o error da api  referenciando  o tipo  de retorno  do http
                 }
                  return  Ok();

            }
               [HttpGet("servererror")]
            public ActionResult GetServerError()
            {
                
               var thing  =  _context.Products.Find(42);
               var thingToReturn  = thing.ToString();
                
                  return  Ok();

            }

           [HttpGet("badrequest")]
            public ActionResult GetBadRequest()
            {
                
          
                  return  BadRequest(new ApiResponse(400)); 

            }
               [HttpGet("badrequest/{id}")]
            public ActionResult GetNotFaoundRequest(int id)
            {
                  return  Ok();

            }
             

    }
}