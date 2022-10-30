using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P5_FX.Engine.HL;

namespace P5_FX.Engine.Controllers;

[Route("[controller]")]
[ApiController]
public class ApiController : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    [Route("[action]")]
    public ActionResult<Result> Call()
    {
        try
        {
  

            return new Result<dynamic>()
            {
                State = ResultsStates.success,
               
            };

        }
        catch (Exception e)
        {
            return new Result(ResultsStates.error)
            {
                Message = e.Message
            };
        }
    }
}
