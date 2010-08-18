
using PublicSuffix.Rules;

namespace PublicSuffix {

    /// <summary>
    /// The RuleFactory
    /// </summary>
    public class RuleFactory {
        
        /// <summary>
        /// Inspects a string of text and returns a matching <see cref="Rule" />
        /// </summary>
        /// <param name="line">A line from a <see cref="RulesList" /></param>
        /// <returns>A matching <see cref="Rule" /></returns>
        public static Rule Get(string line) {
            switch(line[0]) {
                case '*'    : return new WildcardRule(line);
                case '!'    : return new ExceptionRule(line);
                default     : return new NormalRule(line);
            }
        }
    }
}
