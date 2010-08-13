
namespace PublicSuffix {

    public class DomainName {

        public string TLD { get; set; }
        public string Domain { get; set; }
        public string SubDomain { get; set; }

        public DomainName() {
        }

        public DomainName(string[] array) {
            this.SubDomain = array[0];
            this.Domain = array[1];
            this.TLD = array[2];
        }

        public string[] ToArray() {
            return new[] { SubDomain, Domain, TLD };
        }

    }
}
