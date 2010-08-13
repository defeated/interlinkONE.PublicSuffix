
using System.Linq;

using PublicSuffix.Rules;

using Machine.Specifications;

namespace PublicSuffix.Specs {

    public class when_given_a_normal_rule {
        It should_return_a_normal_rule = () => RuleFactory.Get("com").ShouldBe(typeof(NormalRule));
    }

    public class when_given_a_wildcard_rule {
        It should_return_a_wildcard_rule = () => RuleFactory.Get("*.zw").ShouldBe(typeof(WildcardRule));
    }

    public class when_given_an_exception_rule {
        It should_return_an_exception_rule = () => RuleFactory.Get("!metro.tokyo.jp").ShouldBe(typeof(ExceptionRule));
    }
}
