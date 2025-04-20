using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common.Entities;

namespace EntityAttributes {
    public class EntityAttributesGui : GuiDialog {
        public override string ToggleKeyCombinationCode => "eattrgui";
        private Entity target;

        private Entity Target {
            get { return null; }
            set { target = value; }
        }

        public EntityAttributesGui(ICoreClientAPI capi, Entity en) : base(capi) {
            Target = en;
            SetupDialog();
        }

        private void SetupDialog() {

        }

        private void OnTitleBarCloseClicked() {
            TryClose();
        }
    }
}
