
using Machine.Specifications;

namespace PublicSuffix.Specs {

    public abstract class WithDomain {
        protected static Domain domain;
        protected static string[] parts;
    }

    [Subject(typeof(Domain))]
    public class when_given_a_tld : WithDomain {
        Establish context = () => domain = new Domain("com");

        It has_a_tld            = () => domain.TLD.ShouldEqual("com");
        It converts_to_a_string = () => domain.ToString().ShouldEqual("com");
    }

    [Subject(typeof(Domain))]
    public class when_given_a_maindomain : WithDomain {
        Establish context = () => domain = new Domain("com", "google");

        It has_a_tld                = () => domain.TLD.ShouldEqual("com");
        It has_a_domain             = () => domain.MainDomain.ShouldEqual("google");
        It has_a_registered_domain  = () => domain.RegisteredDomain.ShouldEqual("google.com");
        It converts_to_a_string     = () => domain.ToString().ShouldEqual("google.com");
    }

    [Subject(typeof(Domain))]
    public class when_given_a_subdomain : WithDomain {
        Establish context = () => domain = new Domain("com", "google", "maps");

        It has_a_tld                = () => domain.TLD.ShouldEqual("com");
        It has_a_domain             = () => domain.MainDomain.ShouldEqual("google");
        It has_a_subdomain          = () => domain.SubDomain.ShouldEqual("maps");
        It has_a_registered_domain  = () => domain.RegisteredDomain.ShouldEqual("google.com");
        It converts_to_a_string     = () => domain.ToString().ShouldEqual("maps.google.com");
    }

    [Subject(typeof(Domain))]
    public class when_subdomain_converts_to_array : WithDomain {
        Establish context = () => domain = new Domain("com", "google", "maps");
        
        Because of = () => parts = domain.ToArray();

        It only_has_three_items = () => parts.Length.ShouldEqual(3);
        It has_a_subdomain      = () => parts[0].ShouldEqual("maps");
        It has_a_domain         = () => parts[1].ShouldEqual("google");
        It has_a_tld            = () => parts[2].ShouldEqual("com");
    }

    [Subject(typeof(Domain))]
    public class when_domain_converts_to_array : WithDomain {
        Establish context = () => domain = new Domain("com", "google");

        Because of = () => parts = domain.ToArray();

        It only_has_two_items   = () => parts.Length.ShouldEqual(2);
        It has_a_domain         = () => parts[0].ShouldEqual("google");
        It has_a_tld            = () => parts[1].ShouldEqual("com");
    }

    [Subject(typeof(Domain))]
    public class when_tld_converts_to_array : WithDomain {
        Establish context = () => domain = new Domain("com");

        Because of = () => parts = domain.ToArray();

        It only_has_one_item    = () => parts.Length.ShouldEqual(1);
        It has_a_tld            = () => parts[0].ShouldEqual("com");
    }

}
