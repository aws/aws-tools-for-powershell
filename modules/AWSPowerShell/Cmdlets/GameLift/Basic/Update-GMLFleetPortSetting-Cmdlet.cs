/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Updates permissions that allow inbound traffic to connect to game sessions in the
    /// fleet. 
    /// 
    ///  
    /// <para>
    /// To update settings, specify the fleet ID to be updated and specify the changes to
    /// be made. List the permissions you want to add in <c>InboundPermissionAuthorizations</c>,
    /// and permissions you want to remove in <c>InboundPermissionRevocations</c>. Permissions
    /// to be removed must match existing fleet permissions. 
    /// </para><para>
    /// For a container fleet, inbound permissions must specify port numbers that are defined
    /// in the fleet's connection port settings.
    /// </para><para>
    /// If successful, the fleet ID for the updated fleet is returned. For fleets with remote
    /// locations, port setting updates can take time to propagate across all locations. You
    /// can check the status of updates in each location by calling <c>DescribeFleetPortSettings</c>
    /// with a location name.
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-intro.html">Setting
    /// up Amazon GameLift fleets</a></para>
    /// </summary>
    [Cmdlet("Update", "GMLFleetPortSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon GameLift Service UpdateFleetPortSettings API operation.", Operation = new[] {"UpdateFleetPortSettings"}, SelectReturnType = typeof(Amazon.GameLift.Model.UpdateFleetPortSettingsResponse))]
    [AWSCmdletOutput("System.String or Amazon.GameLift.Model.UpdateFleetPortSettingsResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GameLift.Model.UpdateFleetPortSettingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGMLFleetPortSettingCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the fleet to update port settings for. You can use either
        /// the fleet ID or ARN value.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter InboundPermissionAuthorization
        /// <summary>
        /// <para>
        /// <para>A collection of port settings to be added to the fleet resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InboundPermissionAuthorizations")]
        public Amazon.GameLift.Model.IpPermission[] InboundPermissionAuthorization { get; set; }
        #endregion
        
        #region Parameter InboundPermissionRevocation
        /// <summary>
        /// <para>
        /// <para>A collection of port settings to be removed from the fleet resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InboundPermissionRevocations")]
        public Amazon.GameLift.Model.IpPermission[] InboundPermissionRevocation { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FleetId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.UpdateFleetPortSettingsResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.UpdateFleetPortSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FleetId";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FleetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GMLFleetPortSetting (UpdateFleetPortSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.UpdateFleetPortSettingsResponse, UpdateGMLFleetPortSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FleetId = this.FleetId;
            #if MODULAR
            if (this.FleetId == null && ParameterWasBound(nameof(this.FleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InboundPermissionAuthorization != null)
            {
                context.InboundPermissionAuthorization = new List<Amazon.GameLift.Model.IpPermission>(this.InboundPermissionAuthorization);
            }
            if (this.InboundPermissionRevocation != null)
            {
                context.InboundPermissionRevocation = new List<Amazon.GameLift.Model.IpPermission>(this.InboundPermissionRevocation);
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
            if (cmdletContext.InboundPermissionAuthorization != null)
            {
                request.InboundPermissionAuthorizations = cmdletContext.InboundPermissionAuthorization;
            }
            if (cmdletContext.InboundPermissionRevocation != null)
            {
                request.InboundPermissionRevocations = cmdletContext.InboundPermissionRevocation;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
            try
            {
                #if DESKTOP
                return client.UpdateFleetPortSettings(request);
                #elif CORECLR
                return client.UpdateFleetPortSettingsAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String FleetId { get; set; }
            public List<Amazon.GameLift.Model.IpPermission> InboundPermissionAuthorization { get; set; }
            public List<Amazon.GameLift.Model.IpPermission> InboundPermissionRevocation { get; set; }
            public System.Func<Amazon.GameLift.Model.UpdateFleetPortSettingsResponse, UpdateGMLFleetPortSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FleetId;
        }
        
    }
}
