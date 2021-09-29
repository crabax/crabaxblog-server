using System;
using System.Collections.Generic;
using System.Text;

namespace CrabaxBlog.Application.DTOs
{
    public enum Types
    {
        NONE,
        ERROR,
        WARNING
    }

    public class JsonResponse<T> : JsonResponse
    {
        public T ResultObject { get; set; }

        public new static JsonResponse<T> Success(string message = "")
        {
            return new JsonResponse<T> { Ok = true, Message = message, Type = Types.NONE.ToString(), TypeEnum = Types.NONE };
        }

        public new static JsonResponse<T> Failed(string message, Types type = Types.ERROR)
        {
            return new JsonResponse<T> { Ok = false, Message = message, Type = type.ToString(), TypeEnum = type };
        }

        public JsonResponse()
        {

        }
    }

    public class JsonResponse
    {
        public bool Ok { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        private protected Types TypeEnum { get; set; }
        public Dictionary<string, object> Values { get; set; } = new Dictionary<string, object>();

        public JsonResponse<T> ToResultObject<T>(T resultObject = default(T))
        {
            var response = new JsonResponse<T>()
            {
                Ok = this.Ok,
                Message = this.Message,
                Type = this.Type.ToString(),
                ResultObject = resultObject
            };
            return response;
        }

        public static JsonResponse Success(string message = "")
        {
            return new JsonResponse { Ok = true, Message = message, Type = Types.NONE.ToString(), TypeEnum = Types.NONE };
        }

        public static JsonResponse Failed(string message, Types Type = Types.ERROR)
        {
            return new JsonResponse { Ok = false, Message = message, Type = Type.ToString(), TypeEnum = Type };
        }

        public JsonResponse()
        {

        }
    }
}
