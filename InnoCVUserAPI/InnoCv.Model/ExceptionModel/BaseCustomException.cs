using InnoCV.Model.Dictionary;
using System;

namespace InnoCV.Model.ExceptionModel
{
    public class BaseCustomException : Exception
    {
        public ushort ErrorCode { get; private set; }

        public BaseCustomException (string Message) : base(Message)
        {

        }

        public BaseCustomException(string Message, ushort ErrorCode) : base(Message)
        {
            this.ErrorCode = ErrorCode;
        }
    }

    public class UserAlreadyExistsException : BaseCustomException
    {
        public UserAlreadyExistsException() : base(CoreDictionary.UserAlreadyExist, ResultCode.ALREADY_EXISTS) { }
    }

    public class UserNotFoundException : BaseCustomException
    {
        public UserNotFoundException() : base(CoreDictionary.UserNotFound, ResultCode.NOT_FOUND) { }
    }

    public class UsersEmptyException : BaseCustomException
    {
        public UsersEmptyException() : base(CoreDictionary.UsersEmpty, ResultCode.EMPTY) { }
    }
}
