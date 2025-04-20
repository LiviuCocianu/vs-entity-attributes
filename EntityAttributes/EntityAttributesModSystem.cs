using System.Collections.Generic;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.CommandAbbr;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Config;
using Vintagestory.API.Datastructures;
using Vintagestory.API.Server;
using Vintagestory.API.Util;
using Vintagestory.Client.NoObf;

namespace EntityAttributes
{
    public class EntityAttributesModSystem : ModSystem
    {

        // Called on server and client
        // Useful for registering block/entity classes on both sides
        public override void Start(ICoreAPI api)
        {

        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            api.ChatCommands.Create("entityattributes")
                .WithDescription(Lang.Get("entityattributes:cmd-desc"))
                .WithAdditionalInformation(Lang.Get("entityattributes:cmd-additional"))
                .WithAlias(new string[] { "entityattr", "eattr" })
                .WithRootAlias("eattr")
                .WithExamples(new string[]
                {
                    "/eattr <target> get",
                    "/eattr <target> revive"
                })
                .RequiresPrivilege(Privilege.chat)
                .RequiresPlayer()
                .WithArgs(new EntitiesArgParser("target", api, true))
                .BeginSub("revive")
                .WithDesc(Lang.Get("entityattributes:cmd-revive-desc"))
                .WithAdditionalInformation(Lang.Get("entityattributes:cmd-revive-additional"))
                .HandleWith((args) => {
                    IPlayer player = args.Caller.Player;
                    var parser = args.Parsers.Find((parser) => parser.ArgumentName == "target").GetValue();
                    Entity[] targets = (Entity[])parser;

                    foreach (Entity en in targets) {
                        string name = en.GetName() == "" ? (en.CodeWithoutParts(1) ?? "Unknown") : en.GetName();
                        float maxHealth = en.WatchedAttributes.GetTreeAttribute("health").GetFloat("maxhealth");

                        if(en.AnimManager.IsAnimationActive("wounded-idle")) {
                            if (en.WatchedAttributes.TryGetFloat("mortallyWoundedTotalHours") != null) {
                                en.WatchedAttributes.RemoveAttribute("mortallyWoundedTotalHours");
                            }

                            if (en.WatchedAttributes.TryGetInt("healthState") != null) {
                                en.WatchedAttributes.SetInt("healthState", 0);
                            }

                            if (en.WatchedAttributes.GetTreeAttribute("health").GetFloat("currenthealth") < maxHealth) {
                                en.WatchedAttributes.GetTreeAttribute("health").SetFloat("currenthealth", maxHealth);
                            }

                            en.AnimManager.StopAnimation("wounded-idle");
                        } else {
                            en.State = EnumEntityState.Active;
                            en.Revive();
                        }

                        api.SendMessage(player, 0, "Entity '" + name + "' (" + en.EntityId + ") has been revived", EnumChatType.Notification);
                    }

                    return TextCommandResult.Success();
                })
                .EndSub()
                .IgnoreAdditionalArgs();
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            
        }

    }
}
