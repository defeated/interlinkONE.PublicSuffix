
using System.Linq;

namespace PublicSuffix.Rules {

    public class ExceptionRule : Rule {

        public ExceptionRule(string name) : base(name) {
            this.Name = this.Name.Substring(1); // strip "!" character
        }

        public override Domain Parse(string url) {
            var host = this.Canonicalize(url);

            var domain = new Domain() {
                TLD         = string.Join(".", this.Parts.Reverse().Skip(1).ToArray()),
                MainDomain  = this.Parts.Last(),
                SubDomain   = string.Join(".", host.Skip(this.Length).Reverse().ToArray())
            };

            return domain;
        }
    }
}
