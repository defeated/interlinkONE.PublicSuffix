
namespace PublicSuffix.Rules {

    public abstract class Rule {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Pattern { get; set; }
        public string[] Parts { get; protected set; }

        public Rule(string value) : this(value, value) {
        }

        public Rule(string value, string name) {
            this.Value      = (value ?? "").Trim().ToLowerInvariant();
            this.Name       = name;
            this.Pattern    = @"^(.*)\.({0})$";
            this.Parts      = this.Name.Split('.');
        }

        public virtual int Length {
            get {
                return this.Parts.Length;
            }
        }

        public override string ToString() {
            return this.Value;
        }
    }
}
