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
    /// Updates properties for an alias. To update properties, specify the alias ID to be
    /// updated and provide the information to be changed. To reassign an alias to another
    /// fleet, provide an updated routing strategy. If successful, the updated alias record
    /// is returned.
    /// </summary>
    [Cmdlet("Update", "GMLAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.Alias")]
    [AWSCmdlet("Invokes the UpdateAlias operation against Amazon GameLift Service.", Operation = new[] {"UpdateAlias"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.Alias",
        "This cmdlet returns a Alias object.",
        "The service call response (type Amazon.GameLift.Model.UpdateAliasResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateGMLAliasCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter AliasId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a fleet alias. Specify the alias you want to update. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AliasId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Human-readable description of the alias.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter RoutingStrategy_FleetId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a fleet.</para>
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
        /// <para>Descriptive label associated with this alias. Alias names do not need to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RoutingStrategy_Type
        /// <summary>
        /// <para>
        /// <para>Type of routing strategy. Possible routing types include: <ul><li>SIMPLE: The alias
        /// resolves to one specific fleet. Use this type when routing to active fleets.</li><li>TERMINAL:
        /// The alias does not resolve to a fleet but instead can be used to display a message
        /// to the user. A terminal alias throws a TerminalRoutingStrategyException with the <a>RoutingStrategy</a>
        /// message embedded.</li></ul></para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AliasId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GMLAlias (UpdateAlias)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AliasId = this.AliasId;
            context.Description = this.Description;
            context.Name = this.Name;
            context.RoutingStrategy_FleetId = this.RoutingStrategy_FleetId;
            context.RoutingStrategy_Message = this.RoutingStrategy_Message;
            context.RoutingStrategy_Type = this.RoutingStrategy_Type;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.GameLift.Model.UpdateAliasRequest();
            
            if (cmdletContext.AliasId != null)
            {
                request.AliasId = cmdletContext.AliasId;
            }
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
                var response = client.UpdateAlias(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AliasId { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String RoutingStrategy_FleetId { get; set; }
            public System.String RoutingStrategy_Message { get; set; }
            public Amazon.GameLift.RoutingStrategyType RoutingStrategy_Type { get; set; }
        }
        
    }
}
