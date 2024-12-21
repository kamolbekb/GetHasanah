using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace N_Tier.API.Controllers;

[ApiController]
[Route("api/[controller]")]
// [Authorize(Policy = "SuperAdminOnly")]
public class ApiController : ControllerBase { }
