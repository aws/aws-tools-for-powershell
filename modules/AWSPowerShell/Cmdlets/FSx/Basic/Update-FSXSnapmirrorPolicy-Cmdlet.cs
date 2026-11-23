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
using Amazon.FSx;
using Amazon.FSx.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Updates an Amazon FSx for NetApp ONTAP SnapMirror policy.
    /// </summary>
    [Cmdlet("Update", "FSXSnapmirrorPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.SnapmirrorPolicy")]
    [AWSCmdlet("Calls the Amazon FSx UpdateSnapmirrorPolicy API operation.", Operation = new[] {"UpdateSnapmirrorPolicy"}, SelectReturnType = typeof(Amazon.FSx.Model.UpdateSnapmirrorPolicyResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.SnapmirrorPolicy or Amazon.FSx.Model.UpdateSnapmirrorPolicyResponse",
        "This cmdlet returns an Amazon.FSx.Model.SnapmirrorPolicy object.",
        "The service call response (type Amazon.FSx.Model.UpdateSnapmirrorPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateFSXSnapmirrorPolicyCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter NetworkCompressionEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether SnapMirror compresses data when it transfers the data over the network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NetworkCompressionEnabled { get; set; }
        #endregion
        
        #region Parameter RetentionRule
        /// <summary>
        /// <para>
        /// <para>Specifies the rules that determine which snapshots SnapMirror retains on the destination
        /// volume, based on their SnapMirror labels. The rules that you specify replace all the
        /// SnapMirror policy's existing retention rules. To keep an existing rule, include it
        /// in the list. To remove all retention rules, specify an empty list.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetentionRules")]
        public Amazon.FSx.Model.SnapmirrorPolicyRetentionRule[] RetentionRule { get; set; }
        #endregion
        
        #region Parameter SnapmirrorPolicyId
        /// <summary>
        /// <para>
        /// <para>The ID of the SnapMirror policy that you want to update.</para>
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
        public System.String SnapmirrorPolicyId { get; set; }
        #endregion
        
        #region Parameter ThrottleInKbp
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum bandwidth, in kilobytes per second (KBps), that SnapMirror uses
        /// to transfer data. A value of <c>0</c> means that the bandwidth is unlimited.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThrottleInKbps")]
        public System.Int64? ThrottleInKbp { get; set; }
        #endregion
        
        #region Parameter TransferSchedule
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the ONTAP schedule that determines when SnapMirror transfers
        /// data. To remove the transfer schedule, specify an empty string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransferSchedule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SnapmirrorPolicy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.UpdateSnapmirrorPolicyResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.UpdateSnapmirrorPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SnapmirrorPolicy";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SnapmirrorPolicyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FSXSnapmirrorPolicy (UpdateSnapmirrorPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.UpdateSnapmirrorPolicyResponse, UpdateFSXSnapmirrorPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.NetworkCompressionEnabled = this.NetworkCompressionEnabled;
            if (this.RetentionRule != null)
            {
                context.RetentionRule = new List<Amazon.FSx.Model.SnapmirrorPolicyRetentionRule>(this.RetentionRule);
            }
            context.SnapmirrorPolicyId = this.SnapmirrorPolicyId;
            #if MODULAR
            if (this.SnapmirrorPolicyId == null && ParameterWasBound(nameof(this.SnapmirrorPolicyId)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapmirrorPolicyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ThrottleInKbp = this.ThrottleInKbp;
            context.TransferSchedule = this.TransferSchedule;
            
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
            var request = new Amazon.FSx.Model.UpdateSnapmirrorPolicyRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.NetworkCompressionEnabled != null)
            {
                request.NetworkCompressionEnabled = cmdletContext.NetworkCompressionEnabled.Value;
            }
            if (cmdletContext.RetentionRule != null)
            {
                request.RetentionRules = cmdletContext.RetentionRule;
            }
            if (cmdletContext.SnapmirrorPolicyId != null)
            {
                request.SnapmirrorPolicyId = cmdletContext.SnapmirrorPolicyId;
            }
            if (cmdletContext.ThrottleInKbp != null)
            {
                request.ThrottleInKbps = cmdletContext.ThrottleInKbp.Value;
            }
            if (cmdletContext.TransferSchedule != null)
            {
                request.TransferSchedule = cmdletContext.TransferSchedule;
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
        
        private Amazon.FSx.Model.UpdateSnapmirrorPolicyResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.UpdateSnapmirrorPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "UpdateSnapmirrorPolicy");
            try
            {
                return client.UpdateSnapmirrorPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.Boolean? NetworkCompressionEnabled { get; set; }
            public List<Amazon.FSx.Model.SnapmirrorPolicyRetentionRule> RetentionRule { get; set; }
            public System.String SnapmirrorPolicyId { get; set; }
            public System.Int64? ThrottleInKbp { get; set; }
            public System.String TransferSchedule { get; set; }
            public System.Func<Amazon.FSx.Model.UpdateSnapmirrorPolicyResponse, UpdateFSXSnapmirrorPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SnapmirrorPolicy;
        }
        
    }
}
