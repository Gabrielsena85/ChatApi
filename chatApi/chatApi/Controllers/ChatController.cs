using Microsoft.AspNetCore.Mvc;

namespace chatApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private static List<Mensagem> Messages = new List<Mensagem>();

        // Endpoint GET para recuperar todas as mensagens.
        [HttpGet]
        public ActionResult<List<Mensagem>> GetMessages()
        {
            return Messages;
        }

        // Endpoint POST para enviar uma nova mensagem.
        [HttpPost]
        public IActionResult PostMessage([FromBody] Mensagem newMessage)
        {
            if (newMessage.Nickname == "system" && newMessage.Text == "roll1d6")
            {
                Mensagem customMessage = new Mensagem();
                customMessage.Nickname = "SISTEMA";
                customMessage.Text = $"Rolou um d6 e o resultado foi: {new Random().Next(1, 6)}";
                customMessage.Date = DateTime.Now.ToString("G");
                Messages.Add(customMessage);
            }
            else
            {
                newMessage.Date = DateTime.Now.ToString("G");
                Messages.Add(newMessage);
                Console.WriteLine($"{newMessage.Nickname}:{newMessage.Text}");
            }
            return Ok();
        }
    }
}
