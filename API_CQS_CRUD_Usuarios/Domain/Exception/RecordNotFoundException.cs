using System;
using System.Runtime.Serialization;

namespace API_CQS_CRUD_Usuarios.Domain.Exception
{
    [Serializable]
    public class RecordNotFoundException : SystemException
    {
        public override string Message { get; }

        /// <inheritdoc />
        public RecordNotFoundException()
        {
        }

        /// <inheritdoc />
        public RecordNotFoundException(string message) : base(message: message)
        {
        }

        /// <inheritdoc />
        public RecordNotFoundException(string entity, object key)
        {
            Message = $"Entity '{entity}' does not matter with the '{key}' key.";
        }

        /// <inheritdoc />
        public RecordNotFoundException(string message, SystemException inner) : base(message: message, innerException: inner)
        {
        }

        /// <inheritdoc />
        protected RecordNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info: info, context: context)
        {
        }
    }
}
