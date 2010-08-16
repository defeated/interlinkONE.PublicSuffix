
using Machine.Specifications;

namespace PublicSuffix.Specs {

    [Subject(typeof(Domain))]
    public class when_given_a_tld {
        static Domain domain;

        Establish context = () => domain = new Domain("com");

        It has_a_tld            = () => domain.TLD.ShouldEqual("com");
        It converts_to_a_string = () => domain.ToString().ShouldEqual("com");
    }

    [Subject(typeof(Domain))]
    public class when_given_a_maindomain {
        static Domain domain;

        Establish context = () => domain = new Domain("com", "google");

        It has_a_tld            = () => domain.TLD.ShouldEqual("com");
        It has_a_domain         = () => domain.MainDomain.ShouldEqual("google");
        It converts_to_a_string = () => domain.ToString().ShouldEqual("google.com");
    }

    [Subject(typeof(Domain))]
    public class when_given_a_subdomain {
        static Domain domain;

        Establish context = () => domain = new Domain("com", "google", "maps");

        It has_a_tld            = () => domain.TLD.ShouldEqual("com");
        It has_a_domain         = () => domain.MainDomain.ShouldEqual("google");
        It has_a_subdomain      = () => domain.SubDomain.ShouldEqual("maps");
        It converts_to_a_string = () => domain.ToString().ShouldEqual("maps.google.com");
    }

    [Subject(typeof(Domain))]
    public class when_subdomain_converts_to_array {
        static Domain domain;
        static string[] parts;

        Establish context = () => domain = new Domain("com", "google", "maps");
        
        Because of = () => parts = domain.ToArray();

        It only_has_three_items = () => parts.Length.ShouldEqual(3);
        It has_a_subdomain      = () => parts[0].ShouldEqual("maps");
        It has_a_domain         = () => parts[1].ShouldEqual("google");
        It has_a_tld            = () => parts[2].ShouldEqual("com");
    }

    [Subject(typeof(Domain))]
    public class when_domain_converts_to_array {
        static Domain domain;
        static string[] parts;

        Establish context = () => domain = new Domain("com", "google");

        Because of = () => parts = domain.ToArray();

        It only_has_two_items   = () => parts.Length.ShouldEqual(2);
        It has_a_domain         = () => parts[0].ShouldEqual("google");
        It has_a_tld            = () => parts[1].ShouldEqual("com");
    }

    [Subject(typeof(Domain))]
    public class when_tld_converts_to_array {
        static Domain domain;
        static string[] parts;

        Establish context = () => domain = new Domain("com");

        Because of = () => parts = domain.ToArray();

        It only_has_one_item    = () => parts.Length.ShouldEqual(1);
        It has_a_tld            = () => parts[0].ShouldEqual("com");
    }

}
