using SendGrid;
using SendGrid.Helpers.Mail;
using System.Configuration;

namespace StudyPoints.Logics
{
    public class SendEmail
    {
        public string CallSendGridApi(string userName, string adminUserName, string adminUserEmail)
        {
            var apiKey = ConfigurationManager.AppSettings["SendGridKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@example.com", "スタディポイント");
            var subject = "【スタディポイント】ポイント登録のお知らせ";
            var to = new EmailAddress(adminUserEmail, adminUserName);
            var plainTextContent = userName + "さんのポイントが登録されました";
            var htmlContent = "<strong>" + userName + "さんのポイントが登録されました</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
            return response.ToString();
        }
    }
}