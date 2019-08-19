using System;
namespace MobileTemplateCSharp.Droid.Attributes {
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class ToolbarAttribute : Attribute {

        public int ToolbarResource { get; private set; } 
        public bool NeedBackButton { get; private set; } 

        public ToolbarAttribute(
            int ToolbarResource = Resource.Id.toolbar,
            bool NeedBackButton = false
        ) {
            this.ToolbarResource = ToolbarResource;
            this.NeedBackButton = NeedBackButton;
        }
    }


    [Serializable]
    public class AttributeException : Exception {
        public readonly Attribute Attribute;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AttributeException"/> class
        /// </summary>
        public AttributeException() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AttributeException"/> class
        /// </summary>
        /// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
        public AttributeException(string message) : base(message) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AttributeException"/> class
        /// </summary>
        /// <param name="attribute">A <see cref="T:System.Attrbute"/> that throws excpetion. </param>
        public AttributeException(Attribute attribute) : base($"Wrong usage of attribute {attribute}. Look more in documrntation.") {
            Attribute = attribute;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AttributeException"/> class
        /// </summary>
        /// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
        public AttributeException(Attribute attribute, string message) : base(message) {
            Attribute = attribute;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AttributeException"/> class
        /// </summary>
        /// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
        /// <param name="inner">The exception that is the cause of the current exception. </param>
        public AttributeException(Attribute attribute, string message, System.Exception inner) : base(message, inner) {
            Attribute = attribute;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AttributeException"/> class
        /// </summary>
        /// <param name="context">The contextual information about the source or destination.</param>
        /// <param name="info">The object that holds the serialized object data.</param>
        protected AttributeException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {
        }
    } 
}
