
using System.Linq;

using Machine.Specifications;

namespace PublicSuffix.Specs {

    public class when_rules_come_from_text_file {
        static RulesList list;
        static string[] rules;

        Establish context = () => list = new RulesList();

        Because of = () => rules = list.FromFile(@"data\effective_tld_names.dat");

        It returns_an_array_of_rules    = () => rules.Length.ShouldBeGreaterThan(0);
        It has_no_blank_lines           = () => rules.ShouldNotContain("");
        It has_no_commented_lines       = () => rules.ShouldEachConformTo((line) => !line.StartsWith("//"));
        It has_first_line               = () => rules.First().ShouldEqual("ac");
        It has_last_line                = () => rules.Last().ShouldEqual("*.zw");
    }
}
