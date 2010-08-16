
using Machine.Specifications;

namespace PublicSuffix.Specs {

    public abstract class WithParser : WithDomain {
        protected static Parser parser;

        Establish context = () => {
            var list = new RulesList();
            var rules = list.FromFile(@"data\effective_tld_names.dat");
            parser = new Parser(rules);
        };
    }

    [Subject("Parser")]
    public class when_given_a_valid_url : WithParser {
        Establish context = () => domain = parser.Parse("google.com");

        It parses_the_tld = () => domain.TLD.ShouldEqual("com");
        It validates_the_tld = () => domain.IsValid.ShouldBeTrue();
    }

    [Subject("Parser")]
    public class when_given_an_invalid_url : WithParser {
        Establish context = () => domain = parser.Parse("fake.zzz");

        It parses_the_tld = () => domain.TLD.ShouldEqual("zzz");
        It validates_the_tld = () => domain.IsValid.ShouldBeFalse();
    }

}
