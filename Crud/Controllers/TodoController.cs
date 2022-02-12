namespace Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
    private readonly AppDbContext _context;
    public TodoController(AppDbContext context)
    {
        _context = context;
    }
        // GET: api/<TodoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //vai pegar so 10 itens do banco de dados
            return (IActionResult)await _context.Todos.Take(10).ToListAsync();
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            var result = await _context.Todos.FindAsync(id);
            if (result == null)
                return (IActionResult)Results.BadRequest();

            return Ok(result);
        }

        // POST api/<TodoController>
        [HttpPost]
        public Task<IActionResult> Post([FromBody] Todo model)
        {
            if (model == null)
                return (Task<IActionResult>)Results.NoContent();

            _context.Todos.Add(model);

            return (Task<IActionResult>)Results.Ok(model);
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public Task<IActionResult> Put(int id, [FromBody] Todo model)
        {
            if (id != model.Id)
                return (Task<IActionResult>)Results.BadRequest();

            _context.Todos.Update(model);

            return (Task<IActionResult>)Results.Ok(model);
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public Task<IActionResult> Delete(int id)
        {
            var result = _context.Todos.Find(id);
            if (result == null)
                return (Task<IActionResult>)Results.NotFound();

            _context.Todos.Remove(result);
            return (Task<IActionResult>)Results.Ok();
        }
    }
}
