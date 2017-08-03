/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Creates an alias for a fleet. In most situations, you can use an alias ID in place
    /// of a fleet ID. By using a fleet alias instead of a specific fleet ID, you can switch
    /// gameplay and players to a new fleet without changing your game client or other game
    /// components. For example, for games in production, using an alias allows you to seamlessly
    /// redirect your player base to a new game server update. 
    /// 
    ///  
    /// <para>
    /// Amazon GameLift supports two types of routing strategies for aliases: simple and terminal.
    /// A simple alias points to an active fleet. A terminal alias is used to display messaging
    /// or link to a URL instead of routing players to an active fleet. For example, you might
    /// use a terminal alias when a game version is no longer supported and you want to direct
    /// players to an upgrade site. 
    /// </para><para>
    /// To create a fleet alias, specify an alias name, routing strategy, and optional description.
    /// Each simple alias can point to only one fleet, but a fleet can have multiple aliases.
    /// If successful, a new alias record is returned, including an alias ID, which you can
    /// reference when creating a game session. You can reassign an alias to another fleet
    /// by calling <code>UpdateAlias</code>.
    /// </para><para>
    /// Alias-related operations include:
    /// </para><ul><li><para><a>CreateAlias</a></para></li><li><para><a>ListAliases</a></para></li><li><para><a>DescribeAlias</a></para></li><li><para><a>UpdateAlias</a></para></li><li><para><a>DeleteAlias</a></para></li><li><para><a>ResolveAlias</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "GMLAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.Alias")]
    [AWSCmdlet("Invokes the CreateAlias operation against Amazon GameLift Service.", Operation = new[] {"CreateAlias"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.Alias",
        "This cmdlet returns a Alias object.",
        "The service call response (type Amazon.GameLift.Model.CreateAliasResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGMLAliasCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Human-readable description of an alias.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter RoutingStrategy_FleetId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a fleet that the alias points to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoutingStrategy_FleetId { get; set; }
        #endregion
        
        #region Parameter RoutingStrategy_Message
        /// <summary>
        /// <para>
        /// <para>Message text to be used with a terminal routing strategy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoutingStrategy_Message { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Descriptive label that is associated with an alias. Alias names do not need to be
        /// unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RoutingStrategy_Type
        /// <summary>
        /// <para>
        /// <para>Type of routing strategy.</para><para>Possible routing types include the following:</para><ul><li><para><b>SIMPLE</b> – The alias resolves to one specific fleet. Use this type when routing
        /// to active fleets.</para></li><li><para><b>TERMINAL</b> – The alias does not resolve to a fleet but instead can be used to
        /// display a message to the user. A terminal alias throws a TerminalRoutingStrategyException
        /// with the <a>RoutingStrategy</a> message embedded.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.GameLift.RoutingStrategyType")]
        public Amazon.GameLift.RoutingStrategyType RoutingStrategy_Type { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLAlias (CreateAlias)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Description = this.Description;
            context.Name = this.Name;
            context.RoutingStrategy_FleetId = this.RoutingStrategy_FleetId;
            context.RoutingStrategy_Message = this.RoutingStrategy_Message;
            context.RoutingStrategy_Type = this.RoutingStrategy_Type;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.GameLift.Model.CreateAliasRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate RoutingStrategy
            bool requestRoutingStrategyIsNull = true;
            request.RoutingStrategy = new Amazon.GameLift.Model.RoutingStrategy();
            System.String requestRoutingStrategy_routingStrategy_FleetId = null;
            if (cmdletContext.RoutingStrategy_FleetId != null)
            {
                requestRoutingStrategy_routingStrategy_FleetId = cmdletContext.RoutingStrategy_FleetId;
            }
            if (requestRoutingStrategy_routingStrategy_FleetId != null)
            {
                request.RoutingStrategy.FleetId = requestRoutingStrategy_routingStrategy_FleetId;
                requestRoutingStrategyIsNull = false;
            }
            System.String requestRoutingStrategy_routingStrategy_Message = null;
            if (cmdletContext.RoutingStrategy_Message != null)
            {
                requestRoutingStrategy_routingStrategy_Message = cmdletContext.RoutingStrategy_Message;
            }
            if (requestRoutingStrategy_routingStrategy_Message != null)
            {
                request.RoutingStrategy.Message = requestRoutingStrategy_routingStrategy_Message;
                requestRoutingStrategyIsNull = false;
            }
            Amazon.GameLift.RoutingStrategyType requestRoutingStrategy_routingStrategy_Type = null;
            if (cmdletContext.RoutingStrategy_Type != null)
            {
                requestRoutingStrategy_routingStrategy_Type = cmdletContext.RoutingStrategy_Type;
            }
            if (requestRoutingStrategy_routingStrategy_Type != null)
            {
                request.RoutingStrategy.Type = requestRoutingStrategy_routingStrategy_Type;
                requestRoutingStrategyIsNull = false;
            }
             // determine if request.RoutingStrategy should be set to null
            if (requestRoutingStrategyIsNull)
            {
                request.RoutingStrategy = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Alias;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.GameLift.Model.CreateAliasResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreateAliasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "CreateAlias");
            #if DESKTOP
            return client.CreateAlias(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateAliasAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String RoutingStrategy_FleetId { get; set; }
            public System.String RoutingStrategy_Message { get; set; }
            public Amazon.GameLift.RoutingStrategyType RoutingStrategy_Type { get; set; }
        }
        
    }
}
