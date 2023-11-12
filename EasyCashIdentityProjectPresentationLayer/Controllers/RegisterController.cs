using EasyCashIdentityProjectDtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProjectEntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EasyCashIdentityProjectPresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
           if(ModelState.IsValid) 
            {
                Random random = new Random();
                int code;
                code = random.Next(100000, 1000000);

				AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.Username,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    City="maltepe",
                    District="istanbull",
                    ImageUrl="saadsda",
                    ConfirmCode=code
                };
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded) 
                { if (appUserRegisterDto.Password == appUserRegisterDto.ConfirmPassword)
                    {
                        MimeMessage mimeMessage = new MimeMessage();
                        MailboxAddress mailboxAddressFrom = new MailboxAddress("PARA PARA ADMİN", "mehmetktlk12@gmail.com");
                        MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);
                        mimeMessage.From.Add(mailboxAddressFrom);
                        mimeMessage.To.Add(mailboxAddressTo);
                        var bodyBuilder = new BodyBuilder();
                        bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz : " + code;
                        mimeMessage.Body = bodyBuilder.ToMessageBody();
                        mimeMessage.Subject = "PARA PARA ONAY KODU";
                        SmtpClient Client = new SmtpClient();
                        Client.Connect("smtp.gmail.com", 587, false);
                        Client.Authenticate("mehmetktlk12@gmail.com", "alsfmmlotssazgxu");
                        Client.Send(mimeMessage);
                        Client.Disconnect(true);

                        TempData["Mail"] = appUserRegisterDto.Email;


                        return RedirectToAction("Index", "ConfirmMail");
                    }
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(); 

        }
    }
}
