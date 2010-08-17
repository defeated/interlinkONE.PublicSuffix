
namespace PublicSuffix.Rules {

    public class WildcardRule : Rule {
        public WildcardRule(string value) : base(value) {
            this.Pattern = @"^(.*)\.(.*?\.{0})$";
        }

        //public override int Length {
        //    get {
        //        return base.Length + 1;
        //    }
        //}
    }
}
