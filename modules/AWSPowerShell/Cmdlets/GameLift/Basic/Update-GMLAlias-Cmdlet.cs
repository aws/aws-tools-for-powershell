/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.GameLift;
using Amazon.GameLift.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// <b>This API works with the following fleet types:</b> EC2, Anywhere, Container
    /// 
    ///  
    /// <para>
    /// Updates properties for an alias. Specify the unique identifier of the alias to be
    /// updated and the new property values.
    /// </para><para>
    /// When reassigning an alias to a new fleet, provide an updated routing strategy. If
    /// successful, the updated alias record is returned.
    /// </para><para><b>Related actions</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/reference-awssdk.html#reference-awssdk-resources-fleets">All
    /// APIs by task</a></para>
    /// </summary>
    [Cmdlet("Update", "GMLAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.Alias")]
    [AWSCmdlet("Calls the Amazon GameLift Service UpdateAlias API operation.", Operation = new[] {"UpdateAlias"}, SelectReturnType = typeof(Amazon.GameLift.Model.UpdateAliasResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.Alias or Amazon.GameLift.Model.UpdateAliasResponse",
        "This cmdlet returns an Amazon.GameLift.Model.Alias object.",
        "The service call response (type Amazon.GameLift.Model.UpdateAliasResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateGMLAliasCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AliasId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the alias that you want to update. You can use either the
        /// alias ID or ARN value.</para>
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
        public System.String AliasId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A human-readable description of the alias.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter RoutingStrategy_FleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the fleet that the alias points to. This value is the fleet
        /// ID, not the fleet ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoutingStrategy_FleetId { get; set; }
        #endregion
        
        #region Parameter RoutingStrategy_Message
        /// <summary>
        /// <para>
        /// <para>The message text to be used with a terminal routing strategy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoutingStrategy_Message { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A descriptive label that is associated with an alias. Alias names do not need to be
        /// unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RoutingStrategy_Type
        /// <summary>
        /// <para>
        /// <para>The type of routing strategy for the alias.</para><para>Possible routing types include the following:</para><ul><li><para><b>SIMPLE</b> - The alias resolves to one specific fleet. Use this type when routing
        /// to active fleets.</para></li><li><para><b>TERMINAL</b> - The alias does not resolve to a fleet but instead can be used to
        /// display a message to the user. A terminal alias throws a TerminalRoutingStrategyException
        /// with the message embedded.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.RoutingStrategyType")]
        public Amazon.GameLift.RoutingStrategyType RoutingStrategy_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Alias'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.UpdateAliasResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.UpdateAliasResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Alias";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AliasId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GMLAlias (UpdateAlias)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.UpdateAliasResponse, UpdateGMLAliasCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AliasId = this.AliasId;
            #if MODULAR
            if (this.AliasId == null && ParameterWasBound(nameof(this.AliasId)))
            {
                WriteWarning("You are passing $null as a value for parameter AliasId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var requestRoutingStrategyIsNull = true;
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
        
        private Amazon.GameLift.Model.UpdateAliasResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.UpdateAliasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "UpdateAlias");
            try
            {
                return client.UpdateAliasAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AliasId { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String RoutingStrategy_FleetId { get; set; }
            public System.String RoutingStrategy_Message { get; set; }
            public Amazon.GameLift.RoutingStrategyType RoutingStrategy_Type { get; set; }
            public System.Func<Amazon.GameLift.Model.UpdateAliasResponse, UpdateGMLAliasCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Alias;
        }
        
    }
}
