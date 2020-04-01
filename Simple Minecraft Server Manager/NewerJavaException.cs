using System;
using System.Runtime.Serialization;

namespace Simple_Minecraft_Server_Manager
{
    [Serializable]
    internal class NewerJavaException : Exception
    {
        public float version;

        public NewerJavaException(float val)
        {
            version = val;
        }

        public NewerJavaException(string message) : base(message)
        {
        }

        public NewerJavaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NewerJavaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}