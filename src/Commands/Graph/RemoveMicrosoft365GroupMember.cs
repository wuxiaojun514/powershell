﻿using PnP.Framework.Entities;
using PnP.Framework.Graph;
using PnP.PowerShell.Commands.Attributes;
using PnP.PowerShell.Commands.Base;
using PnP.PowerShell.Commands.Base.PipeBinds;
using System.Management.Automation;

namespace PnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Remove, "PnPMicrosoft365GroupMember")]
    [RequiredMinimalApiPermissions("Group.ReadWrite.All")]
    public class RemoveMicrosoft365GroupMember : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Microsoft365GroupPipeBind Identity;

        [Parameter(Mandatory = true)]
        public string[] Users;

        protected override void ExecuteCmdlet()
        {
            UnifiedGroupEntity group = null;

            if (Identity != null)
            {
                group = Identity.GetGroup(AccessToken, false);
            }

            if (group != null)
            {
                UnifiedGroupsUtility.RemoveUnifiedGroupMembers(group.GroupId, Users, AccessToken);
            }
        }
    }
}