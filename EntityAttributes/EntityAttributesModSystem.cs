using System.Collections.Generic;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.CommandAbbr;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Config;
using Vintagestory.API.Datastructures;
using Vintagestory.API.Server;
using Vintagestory.API.Util;

namespace EntityAttributes
{
    public class EntityAttributesModSystem : ModSystem
    {

        // Called on server and client
        // Useful for registering block/entity classes on both sides
        public override void Start(ICoreAPI api)
        {
            Lang.Load(api.Logger, api.Assets);
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            api.ChatCommands.Create("entityattributes")
                .WithDescription(Lang.Get("eattr-cmd-desc"))
                .WithAdditionalInformation(Lang.Get("eattr-cmd-additional"))
                .WithAlias(new string[] { "entityattr", "eattr" })
                .WithRootAlias("eattr")
                .WithExamples(new string[]
                {
                    "/eattr <target> get",
                    "/eattr <target> set <attrName> <value>",
                    "/eattr <target> revive"
                })
                .RequiresPrivilege(Privilege.chat)
                .RequiresPlayer()
                .WithArgs(api.ChatCommands.Parsers.Entities("target"))
                .IgnoreAdditionalArgs()
                .HandleWith((args) =>
                {
                    IPlayer player = args.Caller.Player;
                    var parser = args.Parsers.Find((parser) => parser.ArgumentName == "target").GetValue();

                    if (args.ArgCount > 0)
                    {
                        Entity[] targets = (Entity[]) parser;

                        if(targets.Length > 1)
                        {
                            return TextCommandResult.Error("Only one entity can be selected at a time!");
                        }

                        if(args.ArgCount > 1)
                        {
                            switch(args[1])
                            {
                                case "revive":
                                    foreach (Entity en in targets)
                                    {
                                        float maxHealth = en.WatchedAttributes.GetTreeAttribute("health").GetFloat("maxhealth");

                                        if (en.WatchedAttributes.TryGetFloat("mortallyWoundedTotalHours") != null)
                                        {
                                            en.WatchedAttributes.RemoveAttribute("mortallyWoundedTotalHours");
                                        }

                                        if(en.WatchedAttributes.TryGetInt("healthState") != null)
                                        {
                                            en.WatchedAttributes.SetInt("healthState", 1);
                                        }

                                        if (en.WatchedAttributes.GetTreeAttribute("health").GetFloat("currenthealth") < maxHealth)
                                        {
                                            en.WatchedAttributes.GetTreeAttribute("health").SetFloat("maxhealth", maxHealth);
                                        }

                                        api.SendMessage(player, 0, "Entity '" + en.EntityId + "' has been revived", EnumChatType.Notification);
                                    }

                                    return TextCommandResult.Success();
                                default:
                                    return TextCommandResult.Error("Unknown argument! Type '/help eattr' for examples");
                            }
                        } else
                        {
                            return TextCommandResult.Error("Invalid syntax! Type '/help eattr' for examples");
                        }
                    } else
                    {
                        return TextCommandResult.Error("Too few arguments");
                    }
                });
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            
        }

    }
}
