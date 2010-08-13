
using Machine.Specifications;

namespace PublicSuffix.Specs {

    public class when_given_a_domain_name {

        static DomainName domain;

        Establish context = () => {
            domain = new DomainName();
        };

        Because of = () => {
            domain.TLD = "com";
            domain.Domain = "google";
            domain.SubDomain = "maps";
        };

        It has_a_tld = () => {
            domain.TLD.ShouldEqual("com");
        };

        It has_a_domain = () => {
            domain.Domain.ShouldEqual("google");
        };

        It has_a_subdomain = () => {
            domain.SubDomain.ShouldEqual("maps");
        };

        It converts_to_an_array = () => {
            var array = domain.ToArray();
            array[0].ShouldEqual("maps");
            array[1].ShouldEqual("google");
            array[2].ShouldEqual("com");
        };

        It converts_from_an_array = () => {
            var array = new[] { "maps", "google", "com" };
            var domain = new DomainName(array);
            domain.TLD.ShouldEqual("com");
            domain.Domain.ShouldEqual("google");
            domain.SubDomain.ShouldEqual("maps");
        };
    }

}
