using System.Collections.Generic;

namespace Web.Communication
{
    public class ResponseResult
    {
        public ResponseResult()
        {
            Errors = new List<string>();
        }

        public string Title { get; set; }
        public int Status { get; set; }
        public List<string> Errors { get; set; }
    }

    public class ResponseErrorMessages
    {
        public ResponseErrorMessages()
        {
            Mensagens = new List<string>();
        }

        public List<string> Mensagens { get; set; }
    }
}