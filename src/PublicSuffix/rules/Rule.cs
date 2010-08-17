
using System.Collections.Generic;
using System.Linq;

namespace PublicSuffix.Rules {

    public abstract class Rule {
        public string Name { get; set; }
        public string Value { get; set; }

        public Rule(string name) {
            this.Name   = name.ToLowerInvariant();
            this.Value  = this.Name;
        }

        public IEnumerable<string> Parts {
            get {
                return this.Name.Split('.').Reverse();
            }
        }

        public int Length {
            get {
                return this.Parts.Count();
            }
        }

        public override string ToString() {
            return this.Name;
        }
    }
}
