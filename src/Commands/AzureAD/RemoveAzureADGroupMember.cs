﻿using PnP.PowerShell.Commands.Attributes;
using PnP.PowerShell.Commands.Base;
using PnP.PowerShell.Commands.Base.PipeBinds;
using PnP.PowerShell.Commands.Utilities;
using System.Management.Automation;
using Group = PnP.PowerShell.Commands.Model.Graph.Group;

namespace PnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Remove, "PnPAzureADGroupMember")]
    [RequiredApiApplicationPermissions("graph/Group.ReadWrite.All")]
    [Alias("Remove-PnPEntraIDGroupMember")]
    public class RemoveAzureADGroupMember : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public AzureADGroupPipeBind Identity;

        [Parameter(Mandatory = true)]
        public string[] Users;

        protected override void ExecuteCmdlet()
        {
            Group group = null;

            if (Identity != null)
            {
                group = Identity.GetGroup(RequestHelper);
            }

            if (group != null)
            {
                ClearOwners.RemoveMembers(RequestHelper, new System.Guid(group.Id), Users);
            }
        }
    }
}