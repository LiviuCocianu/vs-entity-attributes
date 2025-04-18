using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;

namespace EntityAttributes
{
    internal class EntityAttrCommand : IChatCommand
    {
        private List<string> aliases;

        public IChatCommand this[string name] => throw new NotImplementedException();

        public string FullName => "entityattributes";

        public string Name => "eattr";

        public string Description => "Manage the attributes of an entity";

        public string AdditionalInformation => "This command allows you to get all attributes that an entity has, such as current health, max health, weight and so on, modify an existing attribute or adding new ones";

        public string[] Examples => new string[] {
            "/eattr <target> get",
            "/eattr <target> set <attrName> <dataType> <value>"
        };

        public bool Incomplete => false;

        public List<string> Aliases
        {
            get {
                List<string> aliases = new();
                aliases.AddRange(new string[] { "entityattr" });
                return aliases;
            }
        }

        public List<string> RootAliases => throw new NotImplementedException();

        public string CommandPrefix => throw new NotImplementedException();

        public IEnumerable<IChatCommand> Subcommands => throw new NotImplementedException();

        public Dictionary<string, IChatCommand> AllSubcommands => throw new NotImplementedException();

        public string CallSyntax => throw new NotImplementedException();

        public string CallSyntaxUnformatted => throw new NotImplementedException();

        public void AddParameterSyntax(StringBuilder sb, string indent)
        {
            throw new NotImplementedException();
        }

        public void AddSyntaxExplanation(StringBuilder sb, string indent)
        {
            throw new NotImplementedException();
        }

        public IChatCommand BeginSubCommand(string name)
        {
            throw new NotImplementedException();
        }

        public IChatCommand BeginSubCommands(params string[] name)
        {
            throw new NotImplementedException();
        }

        public IChatCommand EndSubCommand()
        {
            throw new NotImplementedException();
        }

        public void Execute(TextCommandCallingArgs callargs, Action<TextCommandResult> onCommandComplete = null)
        {
            throw new NotImplementedException();
        }

        public string GetCallSyntax(string alias, bool isRootAlias = false)
        {
            throw new NotImplementedException();
        }

        public string GetCallSyntaxUnformatted(string alias, bool isRootAlias = false)
        {
            throw new NotImplementedException();
        }

        public string GetFullName(string alias, bool isRootAlias = false)
        {
            throw new NotImplementedException();
        }

        public string GetFullSyntaxConsole(Caller caller)
        {
            throw new NotImplementedException();
        }

        public string GetFullSyntaxHandbook(Caller caller, string indent = "", bool isRootAlias = false)
        {
            throw new NotImplementedException();
        }

        public IChatCommand HandleWith(OnCommandDelegate handler)
        {
            throw new NotImplementedException();
        }

        public IChatCommand IgnoreAdditionalArgs()
        {
            throw new NotImplementedException();
        }

        public bool IsAvailableTo(Caller caller)
        {
            throw new NotImplementedException();
        }

        public IChatCommand RequiresPlayer()
        {
            throw new NotImplementedException();
        }

        public IChatCommand RequiresPrivilege(string privilege)
        {
            throw new NotImplementedException();
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }

        public IChatCommand WithAdditionalInformation(string detail)
        {
            throw new NotImplementedException();
        }

        public IChatCommand WithAlias(params string[] name)
        {
            throw new NotImplementedException();
        }

        public IChatCommand WithArgs(params ICommandArgumentParser[] args)
        {
            throw new NotImplementedException();
        }

        public IChatCommand WithDescription(string description)
        {
            throw new NotImplementedException();
        }

        public IChatCommand WithExamples(params string[] examaples)
        {
            throw new NotImplementedException();
        }

        public IChatCommand WithName(string name)
        {
            throw new NotImplementedException();
        }

        public IChatCommand WithPreCondition(CommandPreconditionDelegate p)
        {
            throw new NotImplementedException();
        }

        public IChatCommand WithRootAlias(string name)
        {
            throw new NotImplementedException();
        }
    }
}
