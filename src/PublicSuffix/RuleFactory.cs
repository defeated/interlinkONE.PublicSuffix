
using PublicSuffix.Rules;

namespace PublicSuffix {

    public class RuleFactory {
        public static Rule Get(string line) {
            switch(line[0]) {
                case '*'    : return new WildcardRule(line);
                case '!'    : return new ExceptionRule(line);
                default     : return new NormalRule(line);
            }
        }
    }
}
