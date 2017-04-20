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
    /// Updates port settings for a fleet. To update settings, specify the fleet ID to be
    /// updated and list the permissions you want to update. List the permissions you want
    /// to add in <code>InboundPermissionAuthorizations</code>, and permissions you want to
    /// remove in <code>InboundPermissionRevocations</code>. Permissions to be removed must
    /// match existing fleet permissions. If successful, the fleet ID for the updated fleet
    /// is returned.
    /// </summary>
    [Cmdlet("Update", "GMLFleetPortSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the UpdateFleetPortSettings operation against Amazon GameLift Service.", Operation = new[] {"UpdateFleetPortSettings"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.GameLift.Model.UpdateFleetPortSettingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGMLFleetPortSettingCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a fleet to update port settings for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter InboundPermissionAuthorization
        /// <summary>
        /// <para>
        /// <para>Collection of port settings to be added to the fleet record.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InboundPermissionAuthorizations")]
        public Amazon.GameLift.Model.IpPermission[] InboundPermissionAuthorization { get; set; }
        #endregion
        
        #region Parameter InboundPermissionRevocation
        /// <summary>
        /// <para>
        /// <para>Collection of port settings to be removed from the fleet record.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InboundPermissionRevocations")]
        public Amazon.GameLift.Model.IpPermission[] InboundPermissionRevocation { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FleetId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GMLFleetPortSetting (UpdateFleetPortSettings)"))
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
            
            context.FleetId = this.FleetId;
            if (this.InboundPermissionAuthorization != null)
            {
                context.InboundPermissionAuthorizations = new List<Amazon.GameLift.Model.IpPermission>(this.InboundPermissionAuthorization);
            }
            if (this.InboundPermissionRevocation != null)
            {
                context.InboundPermissionRevocations = new List<Amazon.GameLift.Model.IpPermission>(this.InboundPermissionRevocation);
            }
            
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
            var request = new Amazon.GameLift.Model.UpdateFleetPortSettingsRequest();
            
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            if (cmdletContext.InboundPermissionAuthorizations != null)
            {
                request.InboundPermissionAuthorizations = cmdletContext.InboundPermissionAuthorizations;
            }
            if (cmdletContext.InboundPermissionRevocations != null)
            {
                request.InboundPermissionRevocations = cmdletContext.InboundPermissionRevocations;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.FleetId;
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
        
        private Amazon.GameLift.Model.UpdateFleetPortSettingsResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.UpdateFleetPortSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "UpdateFleetPortSettings");
            #if DESKTOP
            return client.UpdateFleetPortSettings(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateFleetPortSettingsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String FleetId { get; set; }
            public List<Amazon.GameLift.Model.IpPermission> InboundPermissionAuthorizations { get; set; }
            public List<Amazon.GameLift.Model.IpPermission> InboundPermissionRevocations { get; set; }
        }
        
    }
}
