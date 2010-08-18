
namespace PublicSuffix.Rules {

    public class NormalRule : Rule {
        public new static string Indicator { get { return ""; } }

        public NormalRule(string name) : base(name) {
        }
    }
}
