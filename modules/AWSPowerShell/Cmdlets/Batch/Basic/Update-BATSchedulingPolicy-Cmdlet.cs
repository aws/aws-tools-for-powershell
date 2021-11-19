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
using Amazon.Batch;
using Amazon.Batch.Model;

namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Updates a scheduling policy.
    /// </summary>
    [Cmdlet("Update", "BATSchedulingPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Batch UpdateSchedulingPolicy API operation.", Operation = new[] {"UpdateSchedulingPolicy"}, SelectReturnType = typeof(Amazon.Batch.Model.UpdateSchedulingPolicyResponse))]
    [AWSCmdletOutput("None or Amazon.Batch.Model.UpdateSchedulingPolicyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Batch.Model.UpdateSchedulingPolicyResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateBATSchedulingPolicyCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the scheduling policy to update.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter FairsharePolicy_ComputeReservation
        /// <summary>
        /// <para>
        /// <para>A value used to reserve some of the available maximum vCPU for fair share identifiers
        /// that have not yet been used.</para><para>The reserved ratio is <code>(<i>computeReservation</i>/100)^<i>ActiveFairShares</i></code> where <code><i>ActiveFairShares</i></code> is the number of active fair
        /// share identifiers.</para><para>For example, a <code>computeReservation</code> value of 50 indicates that Batch should
        /// reserve 50% of the maximum available vCPU if there is only one fair share identifier,
        /// 25% if there are two fair share identifiers, and 12.5% if there are three fair share
        /// identifiers. A <code>computeReservation</code> value of 25 indicates that Batch should
        /// reserve 25% of the maximum available vCPU if there is only one fair share identifier,
        /// 6.25% if there are two fair share identifiers, and 1.56% if there are three fair share
        /// identifiers.</para><para>The minimum value is 0 and the maximum value is 99.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? FairsharePolicy_ComputeReservation { get; set; }
        #endregion
        
        #region Parameter FairsharePolicy_ShareDecaySecond
        /// <summary>
        /// <para>
        /// <para>The time period to use to calculate a fair share percentage for each fair share identifier
        /// in use, in seconds. A value of zero (0) indicates that only current usage should be
        /// measured. The decay allows for more recently run jobs to have more weight than jobs
        /// that ran earlier. The maximum supported value is 604800 (1 week).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FairsharePolicy_ShareDecaySeconds")]
        public System.Int32? FairsharePolicy_ShareDecaySecond { get; set; }
        #endregion
        
        #region Parameter FairsharePolicy_ShareDistribution
        /// <summary>
        /// <para>
        /// <para>An array of <code>SharedIdentifier</code> objects that contain the weights for the
        /// fair share identifiers for the fair share policy. Fair share identifiers that aren't
        /// included have a default weight of <code>1.0</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Batch.Model.ShareAttributes[] FairsharePolicy_ShareDistribution { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Batch.Model.UpdateSchedulingPolicyResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Arn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BATSchedulingPolicy (UpdateSchedulingPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Batch.Model.UpdateSchedulingPolicyResponse, UpdateBATSchedulingPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Arn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FairsharePolicy_ComputeReservation = this.FairsharePolicy_ComputeReservation;
            context.FairsharePolicy_ShareDecaySecond = this.FairsharePolicy_ShareDecaySecond;
            if (this.FairsharePolicy_ShareDistribution != null)
            {
                context.FairsharePolicy_ShareDistribution = new List<Amazon.Batch.Model.ShareAttributes>(this.FairsharePolicy_ShareDistribution);
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
            var request = new Amazon.Batch.Model.UpdateSchedulingPolicyRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            
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
        
        private Amazon.Batch.Model.UpdateSchedulingPolicyResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.UpdateSchedulingPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "UpdateSchedulingPolicy");
            try
            {
                #if DESKTOP
                return client.UpdateSchedulingPolicy(request);
                #elif CORECLR
                return client.UpdateSchedulingPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public System.Int32? FairsharePolicy_ComputeReservation { get; set; }
            public System.Int32? FairsharePolicy_ShareDecaySecond { get; set; }
            public List<Amazon.Batch.Model.ShareAttributes> FairsharePolicy_ShareDistribution { get; set; }
            public System.Func<Amazon.Batch.Model.UpdateSchedulingPolicyResponse, UpdateBATSchedulingPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
