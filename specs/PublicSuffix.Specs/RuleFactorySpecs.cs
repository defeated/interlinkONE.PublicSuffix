
using System.Linq;

using PublicSuffix.Rules;

using Machine.Specifications;

namespace PublicSuffix.Specs {

    [Subject(typeof(RuleFactory))]
    public class when_given_a_normal_rule_string {
        It should_return_a_normal_rule_type = () => RuleFactory.Get("com").ShouldBe(typeof(NormalRule));
    }

    [Subject(typeof(RuleFactory))]
    public class when_given_a_wildcard_rule_string {
        It should_return_a_wildcard_rule_type = () => RuleFactory.Get("*.zw").ShouldBe(typeof(WildcardRule));
    }

    [Subject(typeof(RuleFactory))]
    public class when_given_an_exception_rule_string {
        It should_return_an_exception_rule_type = () => RuleFactory.Get("!metro.tokyo.jp").ShouldBe(typeof(ExceptionRule));
    }
}
