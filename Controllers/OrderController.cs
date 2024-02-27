using aspcore.Data;
using aspcore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspcore.Controllers
{
    [Authorize]

    public class OrderController : Controller
    {

        public ApplicationDbContext _context { get; }


        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Order/set")]
        public ActionResult set(OrderViewModel order)
        {
            IFormFile file = Request.Form.Files.First();
            if (file == null)
            {
                return BadRequest();
            }

            if (file.ContentType != "application/pdf")
            {
                return BadRequest();
            }

            string rootDir = System.IO.Directory.GetCurrentDirectory() + @"\Files\";
            if (!System.IO.Directory.Exists(rootDir))
            {
                System.IO.Directory.CreateDirectory(rootDir);
            }
            string fileName = Guid.NewGuid().ToString() + ".pdf";
            string filePath = Path.Combine(rootDir, fileName);


            using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }

            string relativePath = "/Files/" + fileName;

            foreach (string id in order.list.Split(','))
            {
              var research =  _context.ResearchMUS.FirstOrDefault(item => item.Id == long.Parse(id));
                research.OrderNumber = order.orderNumber;
                research.OrderDate = order.Date;
                research.OrderFile = relativePath;


            }
            _context.SaveChanges();



            return Redirect("/Order");
        }
        public IActionResult Index()
        {
            var list = _context.ResearchMUS.Where(item => item.checkState == "0" && item.viewlvl == 1 && string.IsNullOrWhiteSpace(item.OrderNumber)).ToList();

            return View(list);
        }
    }
}
