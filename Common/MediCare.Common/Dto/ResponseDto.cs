using MediCare.Common.Enum;
using System.Net;

namespace MediCare.Common.Dto
{
    public class ResponseDto<T>
    {
        #region Properties
        public ResultStatusEnum Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        #endregion

        #region Constructor
        public ResponseDto(string message)
        {
            Code = ResultStatusEnum.Error;
            Message = message;
        }
        public ResponseDto()
        {
            Code = ResultStatusEnum.Error;
        }
        #endregion

        #region Methods
        public ResponseDto<T> GetSuccessResponse(string message = null)
        {
            SetSuccessResponse(message);
            return this;
        }
        public ResponseDto<T> GetSuccessResponse(T responseData, string message = null)
        {
            SetSuccessResponse(responseData, message);
            return this;
        }
        public void SetSuccessResponse(T data, string message = null)
        {
            SetSuccessResponse(message);
            Data = data;
        }
        public void SetSuccessResponse(string message = null)
        {
            Code = ResultStatusEnum.Success;
            Message = message;
        }

        public ResponseDto<T> GetErrorResponse(string message = null, ResultStatusEnum code = ResultStatusEnum.Error)
        {
            Code = code;
            SetErrorResponse(message, code);
            return this;
        }
        public ResponseDto<T> GetErrorResponse(T data, string message = null)
        {
            SetErrorResponse(data, message);
            return this;
        }
        public ResponseDto<T> GetErrorResponse(HttpStatusCode httpStatusCode)
        {
            SetErrorResponse(httpStatusCode);
            return this;
        }
        public void SetErrorResponse(string message = null, ResultStatusEnum code = ResultStatusEnum.Error)
        {
            Code = code;
            Message = message;
        }
        public void SetErrorResponse(T data, string message = null)
        {
            SetErrorResponse(message);
            Data = data;
        }
        public void SetErrorResponse(HttpStatusCode httpStatusCode)
        {
            Code = ResultStatusEnum.Error;
        }
        #endregion
    }
}
