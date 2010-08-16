
using Machine.Specifications;

namespace PublicSuffix.Specs {

    [Subject("Parser")]
    public class when_given_a_url {

        static string url;

        Establish context = () => {
            url = "maps.google.com";
        };

        It parses_the_tld;
        It parses_the_domain;
        It parses_the_subdomain;
        It validates_the_tld;
        
    }

}
