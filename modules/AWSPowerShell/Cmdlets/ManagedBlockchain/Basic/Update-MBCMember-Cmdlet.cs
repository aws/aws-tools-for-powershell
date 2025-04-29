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
using Amazon.ManagedBlockchain;
using Amazon.ManagedBlockchain.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MBC
{
    /// <summary>
    /// Updates a member configuration with new parameters.
    /// 
    ///  
    /// <para>
    /// Applies only to Hyperledger Fabric.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "MBCMember", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Managed Blockchain UpdateMember API operation.", Operation = new[] {"UpdateMember"}, SelectReturnType = typeof(Amazon.ManagedBlockchain.Model.UpdateMemberResponse))]
    [AWSCmdletOutput("None or Amazon.ManagedBlockchain.Model.UpdateMemberResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ManagedBlockchain.Model.UpdateMemberResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateMBCMemberCmdlet : AmazonManagedBlockchainClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Cloudwatch_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether logging is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogPublishingConfiguration_Fabric_CaLogs_Cloudwatch_Enabled")]
        public System.Boolean? Cloudwatch_Enabled { get; set; }
        #endregion
        
        #region Parameter MemberId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the member.</para>
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
        public System.String MemberId { get; set; }
        #endregion
        
        #region Parameter NetworkId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Managed Blockchain network to which the member belongs.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String NetworkId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedBlockchain.Model.UpdateMemberResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MemberId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MBCMember (UpdateMember)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ManagedBlockchain.Model.UpdateMemberResponse, UpdateMBCMemberCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Cloudwatch_Enabled = this.Cloudwatch_Enabled;
            context.MemberId = this.MemberId;
            #if MODULAR
            if (this.MemberId == null && ParameterWasBound(nameof(this.MemberId)))
            {
                WriteWarning("You are passing $null as a value for parameter MemberId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkId = this.NetworkId;
            #if MODULAR
            if (this.NetworkId == null && ParameterWasBound(nameof(this.NetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ManagedBlockchain.Model.UpdateMemberRequest();
            
            
             // populate LogPublishingConfiguration
            var requestLogPublishingConfigurationIsNull = true;
            request.LogPublishingConfiguration = new Amazon.ManagedBlockchain.Model.MemberLogPublishingConfiguration();
            Amazon.ManagedBlockchain.Model.MemberFabricLogPublishingConfiguration requestLogPublishingConfiguration_logPublishingConfiguration_Fabric = null;
            
             // populate Fabric
            var requestLogPublishingConfiguration_logPublishingConfiguration_FabricIsNull = true;
            requestLogPublishingConfiguration_logPublishingConfiguration_Fabric = new Amazon.ManagedBlockchain.Model.MemberFabricLogPublishingConfiguration();
            Amazon.ManagedBlockchain.Model.LogConfigurations requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs = null;
            
             // populate CaLogs
            var requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogsIsNull = true;
            requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs = new Amazon.ManagedBlockchain.Model.LogConfigurations();
            Amazon.ManagedBlockchain.Model.LogConfiguration requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs_logPublishingConfiguration_Fabric_CaLogs_Cloudwatch = null;
            
             // populate Cloudwatch
            var requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs_logPublishingConfiguration_Fabric_CaLogs_CloudwatchIsNull = true;
            requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs_logPublishingConfiguration_Fabric_CaLogs_Cloudwatch = new Amazon.ManagedBlockchain.Model.LogConfiguration();
            System.Boolean? requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs_logPublishingConfiguration_Fabric_CaLogs_Cloudwatch_cloudwatch_Enabled = null;
            if (cmdletContext.Cloudwatch_Enabled != null)
            {
                requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs_logPublishingConfiguration_Fabric_CaLogs_Cloudwatch_cloudwatch_Enabled = cmdletContext.Cloudwatch_Enabled.Value;
            }
            if (requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs_logPublishingConfiguration_Fabric_CaLogs_Cloudwatch_cloudwatch_Enabled != null)
            {
                requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs_logPublishingConfiguration_Fabric_CaLogs_Cloudwatch.Enabled = requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs_logPublishingConfiguration_Fabric_CaLogs_Cloudwatch_cloudwatch_Enabled.Value;
                requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs_logPublishingConfiguration_Fabric_CaLogs_CloudwatchIsNull = false;
            }
             // determine if requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs_logPublishingConfiguration_Fabric_CaLogs_Cloudwatch should be set to null
            if (requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs_logPublishingConfiguration_Fabric_CaLogs_CloudwatchIsNull)
            {
                requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs_logPublishingConfiguration_Fabric_CaLogs_Cloudwatch = null;
            }
            if (requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs_logPublishingConfiguration_Fabric_CaLogs_Cloudwatch != null)
            {
                requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs.Cloudwatch = requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs_logPublishingConfiguration_Fabric_CaLogs_Cloudwatch;
                requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogsIsNull = false;
            }
             // determine if requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs should be set to null
            if (requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogsIsNull)
            {
                requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs = null;
            }
            if (requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs != null)
            {
                requestLogPublishingConfiguration_logPublishingConfiguration_Fabric.CaLogs = requestLogPublishingConfiguration_logPublishingConfiguration_Fabric_logPublishingConfiguration_Fabric_CaLogs;
                requestLogPublishingConfiguration_logPublishingConfiguration_FabricIsNull = false;
            }
             // determine if requestLogPublishingConfiguration_logPublishingConfiguration_Fabric should be set to null
            if (requestLogPublishingConfiguration_logPublishingConfiguration_FabricIsNull)
            {
                requestLogPublishingConfiguration_logPublishingConfiguration_Fabric = null;
            }
            if (requestLogPublishingConfiguration_logPublishingConfiguration_Fabric != null)
            {
                request.LogPublishingConfiguration.Fabric = requestLogPublishingConfiguration_logPublishingConfiguration_Fabric;
                requestLogPublishingConfigurationIsNull = false;
            }
             // determine if request.LogPublishingConfiguration should be set to null
            if (requestLogPublishingConfigurationIsNull)
            {
                request.LogPublishingConfiguration = null;
            }
            if (cmdletContext.MemberId != null)
            {
                request.MemberId = cmdletContext.MemberId;
            }
            if (cmdletContext.NetworkId != null)
            {
                request.NetworkId = cmdletContext.NetworkId;
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
        
        private Amazon.ManagedBlockchain.Model.UpdateMemberResponse CallAWSServiceOperation(IAmazonManagedBlockchain client, Amazon.ManagedBlockchain.Model.UpdateMemberRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Blockchain", "UpdateMember");
            try
            {
                return client.UpdateMemberAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? Cloudwatch_Enabled { get; set; }
            public System.String MemberId { get; set; }
            public System.String NetworkId { get; set; }
            public System.Func<Amazon.ManagedBlockchain.Model.UpdateMemberResponse, UpdateMBCMemberCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
