using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._Scripts.Global
{
    [System.Serializable]
    public class LocalizationItemsCollection
    {
        public LocalizationItem[] ItemsCollection;
    }

    [System.Serializable]
    public class LocalizationItem
    {
        public string ItemName;
        public string Text;
    }
}
