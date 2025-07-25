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
using Amazon.Batch;
using Amazon.Batch.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Creates an Batch scheduling policy.
    /// </summary>
    [Cmdlet("New", "BATSchedulingPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.CreateSchedulingPolicyResponse")]
    [AWSCmdlet("Calls the AWS Batch CreateSchedulingPolicy API operation.", Operation = new[] {"CreateSchedulingPolicy"}, SelectReturnType = typeof(Amazon.Batch.Model.CreateSchedulingPolicyResponse))]
    [AWSCmdletOutput("Amazon.Batch.Model.CreateSchedulingPolicyResponse",
        "This cmdlet returns an Amazon.Batch.Model.CreateSchedulingPolicyResponse object containing multiple properties."
    )]
    public partial class NewBATSchedulingPolicyCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FairsharePolicy_ComputeReservation
        /// <summary>
        /// <para>
        /// <para>A value used to reserve some of the available maximum vCPU for share identifiers that
        /// aren't already used.</para><para>The reserved ratio is <c>(<i>computeReservation</i>/100)^<i>ActiveFairShares</i></c>
        /// where <c><i>ActiveFairShares</i></c> is the number of active share identifiers.</para><para>For example, a <c>computeReservation</c> value of 50 indicates that Batch reserves
        /// 50% of the maximum available vCPU if there's only one share identifier. It reserves
        /// 25% if there are two share identifiers. It reserves 12.5% if there are three share
        /// identifiers. A <c>computeReservation</c> value of 25 indicates that Batch should reserve
        /// 25% of the maximum available vCPU if there's only one share identifier, 6.25% if there
        /// are two fair share identifiers, and 1.56% if there are three share identifiers.</para><para>The minimum value is 0 and the maximum value is 99.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? FairsharePolicy_ComputeReservation { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the fair-share scheduling policy. It can be up to 128 letters long. It
        /// can contain uppercase and lowercase letters, numbers, hyphens (-), and underscores
        /// (_).</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter FairsharePolicy_ShareDecaySecond
        /// <summary>
        /// <para>
        /// <para>The amount of time (in seconds) to use to calculate a fair-share percentage for each
        /// share identifier in use. A value of zero (0) indicates the default minimum time window
        /// (600 seconds). The maximum supported value is 604800 (1 week).</para><para>The decay allows for more recently run jobs to have more weight than jobs that ran
        /// earlier. Consider adjusting this number if you have jobs that (on average) run longer
        /// than ten minutes, or a large difference in job count or job run times between share
        /// identifiers, and the allocation of resources doesn't meet your needs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FairsharePolicy_ShareDecaySeconds")]
        public System.Int32? FairsharePolicy_ShareDecaySecond { get; set; }
        #endregion
        
        #region Parameter FairsharePolicy_ShareDistribution
        /// <summary>
        /// <para>
        /// <para>An array of <c>SharedIdentifier</c> objects that contain the weights for the share
        /// identifiers for the fair-share policy. Share identifiers that aren't included have
        /// a default weight of <c>1.0</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Batch.Model.ShareAttributes[] FairsharePolicy_ShareDistribution { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags that you apply to the scheduling policy to help you categorize and organize
        /// your resources. Each tag consists of a key and an optional value. For more information,
        /// see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services Resources</a> in <i>Amazon Web Services General Reference</i>.</para><para>These tags can be updated or removed using the <a href="https://docs.aws.amazon.com/batch/latest/APIReference/API_TagResource.html">TagResource</a>
        /// and <a href="https://docs.aws.amazon.com/batch/latest/APIReference/API_UntagResource.html">UntagResource</a>
        /// API operations.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Batch.Model.CreateSchedulingPolicyResponse).
        /// Specifying the name of a property of type Amazon.Batch.Model.CreateSchedulingPolicyResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BATSchedulingPolicy (CreateSchedulingPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Batch.Model.CreateSchedulingPolicyResponse, NewBATSchedulingPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FairsharePolicy_ComputeReservation = this.FairsharePolicy_ComputeReservation;
            context.FairsharePolicy_ShareDecaySecond = this.FairsharePolicy_ShareDecaySecond;
            if (this.FairsharePolicy_ShareDistribution != null)
            {
                context.FairsharePolicy_ShareDistribution = new List<Amazon.Batch.Model.ShareAttributes>(this.FairsharePolicy_ShareDistribution);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.Batch.Model.CreateSchedulingPolicyRequest();
            
            
             // populate FairsharePolicy
            var requestFairsharePolicyIsNull = true;
            request.FairsharePolicy = new Amazon.Batch.Model.FairsharePolicy();
            System.Int32? requestFairsharePolicy_fairsharePolicy_ComputeReservation = null;
            if (cmdletContext.FairsharePolicy_ComputeReservation != null)
            {
                requestFairsharePolicy_fairsharePolicy_ComputeReservation = cmdletContext.FairsharePolicy_ComputeReservation.Value;
            }
            if (requestFairsharePolicy_fairsharePolicy_ComputeReservation != null)
            {
                request.FairsharePolicy.ComputeReservation = requestFairsharePolicy_fairsharePolicy_ComputeReservation.Value;
                requestFairsharePolicyIsNull = false;
            }
            System.Int32? requestFairsharePolicy_fairsharePolicy_ShareDecaySecond = null;
            if (cmdletContext.FairsharePolicy_ShareDecaySecond != null)
            {
                requestFairsharePolicy_fairsharePolicy_ShareDecaySecond = cmdletContext.FairsharePolicy_ShareDecaySecond.Value;
            }
            if (requestFairsharePolicy_fairsharePolicy_ShareDecaySecond != null)
            {
                request.FairsharePolicy.ShareDecaySeconds = requestFairsharePolicy_fairsharePolicy_ShareDecaySecond.Value;
                requestFairsharePolicyIsNull = false;
            }
            List<Amazon.Batch.Model.ShareAttributes> requestFairsharePolicy_fairsharePolicy_ShareDistribution = null;
            if (cmdletContext.FairsharePolicy_ShareDistribution != null)
            {
                requestFairsharePolicy_fairsharePolicy_ShareDistribution = cmdletContext.FairsharePolicy_ShareDistribution;
            }
            if (requestFairsharePolicy_fairsharePolicy_ShareDistribution != null)
            {
                request.FairsharePolicy.ShareDistribution = requestFairsharePolicy_fairsharePolicy_ShareDistribution;
                requestFairsharePolicyIsNull = false;
            }
             // determine if request.FairsharePolicy should be set to null
            if (requestFairsharePolicyIsNull)
            {
                request.FairsharePolicy = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Batch.Model.CreateSchedulingPolicyResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.CreateSchedulingPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "CreateSchedulingPolicy");
            try
            {
                return client.CreateSchedulingPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? FairsharePolicy_ComputeReservation { get; set; }
            public System.Int32? FairsharePolicy_ShareDecaySecond { get; set; }
            public List<Amazon.Batch.Model.ShareAttributes> FairsharePolicy_ShareDistribution { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Batch.Model.CreateSchedulingPolicyResponse, NewBATSchedulingPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
