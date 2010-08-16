
using PublicSuffix.Rules;

namespace PublicSuffix {

    public class Parser {
        public Rule[] Rules { get; private set; }

        public Parser(Rule[] rules) {
            this.Rules = rules;
        }

        public Domain Parse(string url) {
            return new Domain();
        }
    }

}
