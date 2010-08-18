
namespace PublicSuffix.Rules {

    public class WildcardRule : Rule {
        public new static string Indicator { get { return "*"; } }

        public WildcardRule(string name) : base(name) {
        }
    }
}
