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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// <note><para>
    /// Auto-termination is supported in Amazon EMR versions 5.30.0 and 6.1.0 and later. For
    /// more information, see <a href="https://docs.aws.amazon.com/emr/latest/ManagementGuide/emr-auto-termination-policy.html">Using
    /// an auto-termination policy</a>.
    /// </para></note><para>
    /// Creates or updates an auto-termination policy for an Amazon EMR cluster. An auto-termination
    /// policy defines the amount of idle time in seconds after which a cluster automatically
    /// terminates. For alternative cluster termination options, see <a href="https://docs.aws.amazon.com/emr/latest/ManagementGuide/emr-plan-termination.html">Control
    /// cluster termination</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "EMRAutoTerminationPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce PutAutoTerminationPolicy API operation.", Operation = new[] {"PutAutoTerminationPolicy"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.PutAutoTerminationPolicyResponse))]
    [AWSCmdletOutput("None or Amazon.ElasticMapReduce.Model.PutAutoTerminationPolicyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ElasticMapReduce.Model.PutAutoTerminationPolicyResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteEMRAutoTerminationPolicyCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the Amazon EMR cluster to which the auto-termination policy will
        /// be attached.</para>
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
        public System.String ClusterId { get; set; }
        #endregion
        
        #region Parameter AutoTerminationPolicy_IdleTimeout
        /// <summary>
        /// <para>
        /// <para>Specifies the amount of idle time in seconds after which the cluster automatically
        /// terminates. You can specify a minimum of 60 seconds and a maximum of 604800 seconds
        /// (seven days).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? AutoTerminationPolicy_IdleTimeout { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.PutAutoTerminationPolicyResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EMRAutoTerminationPolicy (PutAutoTerminationPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.PutAutoTerminationPolicyResponse, WriteEMRAutoTerminationPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoTerminationPolicy_IdleTimeout = this.AutoTerminationPolicy_IdleTimeout;
            context.ClusterId = this.ClusterId;
            #if MODULAR
            if (this.ClusterId == null && ParameterWasBound(nameof(this.ClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticMapReduce.Model.PutAutoTerminationPolicyRequest();
            
            
             // populate AutoTerminationPolicy
            var requestAutoTerminationPolicyIsNull = true;
            request.AutoTerminationPolicy = new Amazon.ElasticMapReduce.Model.AutoTerminationPolicy();
            System.Int64? requestAutoTerminationPolicy_autoTerminationPolicy_IdleTimeout = null;
            if (cmdletContext.AutoTerminationPolicy_IdleTimeout != null)
            {
                requestAutoTerminationPolicy_autoTerminationPolicy_IdleTimeout = cmdletContext.AutoTerminationPolicy_IdleTimeout.Value;
            }
            if (requestAutoTerminationPolicy_autoTerminationPolicy_IdleTimeout != null)
            {
                request.AutoTerminationPolicy.IdleTimeout = requestAutoTerminationPolicy_autoTerminationPolicy_IdleTimeout.Value;
                requestAutoTerminationPolicyIsNull = false;
            }
             // determine if request.AutoTerminationPolicy should be set to null
            if (requestAutoTerminationPolicyIsNull)
            {
                request.AutoTerminationPolicy = null;
            }
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
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
        
        private Amazon.ElasticMapReduce.Model.PutAutoTerminationPolicyResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.PutAutoTerminationPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "PutAutoTerminationPolicy");
            try
            {
                #if DESKTOP
                return client.PutAutoTerminationPolicy(request);
                #elif CORECLR
                return client.PutAutoTerminationPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? AutoTerminationPolicy_IdleTimeout { get; set; }
            public System.String ClusterId { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.PutAutoTerminationPolicyResponse, WriteEMRAutoTerminationPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
