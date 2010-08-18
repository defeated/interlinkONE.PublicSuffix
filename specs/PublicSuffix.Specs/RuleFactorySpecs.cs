
using System.Linq;

using PublicSuffix.Rules;

using Machine.Specifications;

namespace PublicSuffix.Specs {

    public abstract class WithFactory {
        protected static RuleFactory factory;

        Establish context = () => factory = new RuleFactory();
    }

    [Subject(typeof(RuleFactory))]
    public class when_given_a_normal_rule_string : WithFactory {
        It should_return_a_normal_rule_type = () => factory.FromLine("com").ShouldBe(typeof(NormalRule));
    }

    [Subject(typeof(RuleFactory))]
    public class when_given_a_wildcard_rule_string : WithFactory {
        It should_return_a_wildcard_rule_type = () => factory.FromLine("*.zw").ShouldBe(typeof(WildcardRule));
    }

    [Subject(typeof(RuleFactory))]
    public class when_given_an_exception_rule_string : WithFactory {
        It should_return_an_exception_rule_type = () => factory.FromLine("!metro.tokyo.jp").ShouldBe(typeof(ExceptionRule));
    }
}
