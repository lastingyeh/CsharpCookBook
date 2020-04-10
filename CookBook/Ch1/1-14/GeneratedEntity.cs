using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1
{
    public partial class GeneratedEntity
    {
        public string EntityName { get; }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                ChangingProperty("FirstName", FirstName, value);
                _FirstName = value;
            }
        }

        private string _State;
        public string State
        {
            get { return _State; }
            set
            {
                ChangingProperty("State", _State, value);
                _State = value;
            }
        }
        public GeneratedEntity(string entityName)
        {
            EntityName = entityName;
        }

        // define partial method
        partial void ChangingProperty(string name, string originalValue, string newValue);
    }
}
