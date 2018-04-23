using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._Scripts.Global
{
    [Serializable]
    public class LocalizationItemsCollection
    {
        LocalizationItem[] ItemsCollection;
    }

    [Serializable]
    public class LocalizationItem
    {
        public string ItemName { get; set; }
        public string Text { get; set; }
    }
}
