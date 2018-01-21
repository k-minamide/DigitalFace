using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalFace.Data
{
    public abstract class KeyBaseAttribute : Attribute
    {
        public bool IsUnique
        { get; private set; } = false;

        public int KeyNo
        { get; private set; } = -1;

        public int KeyOrder
        { get; private set; } = -1;

        public KeyBaseAttribute(bool isUnique, int keyNo, int keyOrder)
        {
            this.IsUnique = isUnique;
            this.KeyNo = keyNo;
            this.KeyOrder = keyOrder;
        }
    }

    public class PrimaryKeyAttribute : KeyBaseAttribute
    {
        public PrimaryKeyAttribute(int keyNo, int keyOrder) : base(true, keyNo, keyOrder)
        { }
    }

    public class UniqueKeyAttribute : KeyBaseAttribute
    {
        public UniqueKeyAttribute(int keyOrder) : base(true, 1, keyOrder)
        { }
    }

    public class NonUniqueKeyAttribute : KeyBaseAttribute
    {
        public NonUniqueKeyAttribute(int keyNo, int keyOrder) : base(false, keyNo, keyOrder)
        { }
    }

    public class Row
    {
        public string Key01 { get; set; }
        public string Key02 { get; set; }
        public string Key03 { get; set; }
        public string Key04 { get; set; }

        public string Value01 { get; set; }
        public string Value02 { get; set; }
        public string Value03 { get; set; }
        public string Value04 { get; set; }
    }

    public class Table
    {
        Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, Row>>>>
            pk = new Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, Row>>>>();

        public Table()
        {
              
        }
    }
}
