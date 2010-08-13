
namespace PublicSuffix.Rules {

    public abstract class Rule {
        public string Name { get; set; }

        public Rule(string name) {
            this.Name = (name ?? "").Trim().ToLowerInvariant();
        }

        public override string ToString() {
            return this.Name;
        }
    }
}
