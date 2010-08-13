
namespace PublicSuffix {

    public class Parser {

        public RulesList RulesList { get; private set; }

        public Parser(RulesList rulesList) {
            this.RulesList = rulesList;
        }

    }
}
