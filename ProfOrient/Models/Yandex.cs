namespace ProfOrient.Models
{
    public class YandexTokenInfo
    {
        public string iamToken { get; set; }
        public DateTime expiresAt { get; set; }
    }

    /// <summary>
    /// ////////////
    /// </summary>

    public class CompletionOptions
    {
        public bool stream { get; set; }
        public double temperature { get; set; }
        public string maxTokens { get; set; }
    }

    public class Message
    {
        public string role { get; set; }
        public string text { get; set; }
    }

    public class YandexGptRequest
    {
        public string modelUri { get; set; }
        public CompletionOptions completionOptions { get; set; }
        public List<Message> messages { get; set; }
    }

    /// <summary>
    /// ////////////
    /// </summary>

    public class Alternative
    {
        public Message message { get; set; }
        public string status { get; set; }
    }

    public class Result
    {
        public List<Alternative> alternatives { get; set; }
        public Usage usage { get; set; }
        public string modelVersion { get; set; }
    }

    public class YandexGptResponse
    {
        public Result result { get; set; }
    }

    public class Usage
    {
        public string inputTextTokens { get; set; }
        public string completionTokens { get; set; }
        public string totalTokens { get; set; }
    }
}
