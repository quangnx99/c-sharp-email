# CSharp Email

Send email from .NET Core. A bunch of useful extension packages make this dead simple and very powerful.

## Installation

```bash
Install-Package CSharpEmail -Version 5.0.0
```

## Usage

Add a new section named "MessageSender" into appsettings.json.

### SendGrid Configuration

```python
{
  "MessageSender": {
    "ApiKey": "",
    "SenderEmail": "",
    "SenderName": ""
  }
}
```
### SmtpClient Configuration
```python
{
  "MessageSender": {
    "UserName": "",
    "Password": "",
    "Host": "smtp.gmail.com",
    "Port": 587,
    "EnableSSL": true,
    "SenderEmail": "",
    "SenderName": ""
  }
}
```
Then you need to register CSharpEmail into your project.
```ruby
public void ConfigureServices(IServiceCollection services)
{
	services.UseCSharpSendGrid(configuration);
}
```
or
```ruby
public void ConfigureServices(IServiceCollection services)
{
	services.UseCSharpSmtpClient(configuration);
}
```
Using IEmailSender to send email via SendEmailAsync method.
```ruby
await emailSender.SendEmailAsync(new Message{
     Email = new string[] {"RECEIPENT'S EMAIL"},
     Subject = "EMAIL SUBJECT",
     Body = "EMAIL CONTENT"
})
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
