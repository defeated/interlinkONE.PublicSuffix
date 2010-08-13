
using System.Linq;

namespace PublicSuffix {

    public class Domain {

        public string TLD { get; set; }
        public string MainDomain { get; set; }
        public string SubDomain { get; set; }

        public Domain() : this("") {}
        public Domain(string tld) : this(tld, "") {}
        public Domain(string tld, string mainDomain) : this(tld, mainDomain, "") {}

        public Domain(params string[] parts) {
            this.TLD        = parts[0] ?? "";
            this.MainDomain = parts[1] ?? "";
            this.SubDomain  = parts[2] ?? "";
        }

        public override string ToString() {
            return string.Join(".", this.ToArray());
        }

        public string[] ToArray() {
            var array = new[] { this.SubDomain, this.MainDomain, this.TLD };
            array = array.SkipWhile(string.IsNullOrEmpty).ToArray();
            
            return array;
        }

    }
}
