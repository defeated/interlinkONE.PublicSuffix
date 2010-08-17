
using System.Collections.Generic;

namespace PublicSuffix.Rules {

    public class ExceptionRule : Rule {
        public ExceptionRule(string value) : base(value, value.Substring(1)) {
            //this.Parts = this.RemoveFirstLabel();
        }

        private string[] RemoveFirstLabel() {
            var list = new List<string>(this.Name.Split('.'));
            list.RemoveAt(0);

            return list.ToArray();
        }
    }
}
