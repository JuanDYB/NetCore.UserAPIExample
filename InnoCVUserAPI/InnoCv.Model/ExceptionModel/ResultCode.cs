namespace InnoCV.Model.ExceptionModel
{
    internal class ResultCode
    {
        internal const ushort OK = 200;
        internal const ushort ALREADY_EXISTS = 201;
        internal const ushort EMPTY = 202;

        internal const ushort NOT_FOUND = 401;
        
        internal const ushort INTERNAL_ERROR = 500;

        private ResultCode() { }
    }
}
