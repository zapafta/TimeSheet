using DataAccess.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Models
{
    public class AnswerClientServer
    {
        public bool Error { get; set; }


        public string Message { get; set; }

        public ErrorCode ErrorType { get; set; }

        public int Operation { get; set; }

        public string Data { get; set; }

        public static AnswerClientServer GetErrorAnswer(string message)
        {
            return new AnswerClientServer
            {
                Error = true,
                Message = message,
                ErrorType = ErrorCode.Error,
                Operation = 0
            };
        }

        public static AnswerClientServer GetWarningAnswer(string message)
        {
            return new AnswerClientServer
            {
                Error = false,
                Message = message,
                ErrorType = ErrorCode.Warning,
                Operation = 0
            };
        }

        public static AnswerClientServer GetSuccessAnswerWithMessage(string message)
        {
            return new AnswerClientServer
            {
                Error = false,
                Message = message,
                ErrorType = ErrorCode.Sucess,
                Operation = 0
            };
        }

        public static AnswerClientServer GetSuccessAnswerWithData(string data)
        {
            return new AnswerClientServer
            {
                Error = false,
                Data = data,
                ErrorType = ErrorCode.Sucess,
                Operation = 0
            };
        }
    }
}
