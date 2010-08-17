
namespace PublicSuffix.Rules {

    public class ExceptionRule : Rule {
        public ExceptionRule(string name) : base(name) {
            this.Name = this.Name.Substring(1);
        }
    }
}
