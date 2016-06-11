using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BrainTrainer.Client.Models
{
    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    //[System.SerializableAttribute()]
    [DebuggerStepThrough()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class search
    {

        private searchQuestion[] itemsField;
        private int total;

        /// <remarks/>
        [XmlElement("question", Form = XmlSchemaForm.Unqualified)]
        public searchQuestion[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [XmlElement("total", Form = XmlSchemaForm.Unqualified)]
        public int Total
        {
            get { return this.total; }
            set { this.total = value; }
        }
    }
}
