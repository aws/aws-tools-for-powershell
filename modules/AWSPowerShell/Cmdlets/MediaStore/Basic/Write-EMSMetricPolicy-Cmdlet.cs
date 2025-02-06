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
using Amazon.MediaStore;
using Amazon.MediaStore.Model;

namespace Amazon.PowerShell.Cmdlets.EMS
{
    /// <summary>
    /// The metric policy that you want to add to the container. A metric policy allows AWS
    /// Elemental MediaStore to send metrics to Amazon CloudWatch. It takes up to 20 minutes
    /// for the new policy to take effect.
    /// </summary>
    [Cmdlet("Write", "EMSMetricPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Elemental MediaStore PutMetricPolicy API operation.", Operation = new[] {"PutMetricPolicy"}, SelectReturnType = typeof(Amazon.MediaStore.Model.PutMetricPolicyResponse))]
    [AWSCmdletOutput("None or Amazon.MediaStore.Model.PutMetricPolicyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MediaStore.Model.PutMetricPolicyResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteEMSMetricPolicyCmdlet : AmazonMediaStoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MetricPolicy_ContainerLevelMetric
        /// <summary>
        /// <para>
        /// <para>A setting to enable or disable metrics at the container level.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("MetricPolicy_ContainerLevelMetrics")]
        [AWSConstantClassSource("Amazon.MediaStore.ContainerLevelMetrics")]
        public Amazon.MediaStore.ContainerLevelMetrics MetricPolicy_ContainerLevelMetric { get; set; }
        #endregion
        
        #region Parameter ContainerName
        /// <summary>
        /// <para>
        /// <para>The name of the container that you want to add the metric policy to.</para>
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
        public System.String ContainerName { get; set; }
        #endregion
        
        #region Parameter MetricPolicy_MetricPolicyRule
        /// <summary>
        /// <para>
        /// <para>A parameter that holds an array of rules that enable metrics at the object level.
        /// This parameter is optional, but if you choose to include it, you must also include
        /// at least one rule. By default, you can include up to five rules. You can also <a href="https://console.aws.amazon.com/servicequotas/home?region=us-east-1#!/services/mediastore/quotas">request
        /// a quota increase</a> to allow up to 300 rules per policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricPolicy_MetricPolicyRules")]
        public Amazon.MediaStore.Model.MetricPolicyRule[] MetricPolicy_MetricPolicyRule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaStore.Model.PutMetricPolicyResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContainerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EMSMetricPolicy (PutMetricPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaStore.Model.PutMetricPolicyResponse, WriteEMSMetricPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContainerName = this.ContainerName;
            #if MODULAR
            if (this.ContainerName == null && ParameterWasBound(nameof(this.ContainerName)))
            {
                WriteWarning("You are passing $null as a value for parameter ContainerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetricPolicy_ContainerLevelMetric = this.MetricPolicy_ContainerLevelMetric;
            #if MODULAR
            if (this.MetricPolicy_ContainerLevelMetric == null && ParameterWasBound(nameof(this.MetricPolicy_ContainerLevelMetric)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricPolicy_ContainerLevelMetric which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MetricPolicy_MetricPolicyRule != null)
            {
                context.MetricPolicy_MetricPolicyRule = new List<Amazon.MediaStore.Model.MetricPolicyRule>(this.MetricPolicy_MetricPolicyRule);
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
            var request = new Amazon.MediaStore.Model.PutMetricPolicyRequest();
            
            if (cmdletContext.ContainerName != null)
            {
                request.ContainerName = cmdletContext.ContainerName;
            }
            
             // populate MetricPolicy
            var requestMetricPolicyIsNull = true;
            request.MetricPolicy = new Amazon.MediaStore.Model.MetricPolicy();
            Amazon.MediaStore.ContainerLevelMetrics requestMetricPolicy_metricPolicy_ContainerLevelMetric = null;
            if (cmdletContext.MetricPolicy_ContainerLevelMetric != null)
            {
                requestMetricPolicy_metricPolicy_ContainerLevelMetric = cmdletContext.MetricPolicy_ContainerLevelMetric;
            }
            if (requestMetricPolicy_metricPolicy_ContainerLevelMetric != null)
            {
                request.MetricPolicy.ContainerLevelMetrics = requestMetricPolicy_metricPolicy_ContainerLevelMetric;
                requestMetricPolicyIsNull = false;
            }
            List<Amazon.MediaStore.Model.MetricPolicyRule> requestMetricPolicy_metricPolicy_MetricPolicyRule = null;
            if (cmdletContext.MetricPolicy_MetricPolicyRule != null)
            {
                requestMetricPolicy_metricPolicy_MetricPolicyRule = cmdletContext.MetricPolicy_MetricPolicyRule;
            }
            if (requestMetricPolicy_metricPolicy_MetricPolicyRule != null)
            {
                request.MetricPolicy.MetricPolicyRules = requestMetricPolicy_metricPolicy_MetricPolicyRule;
                requestMetricPolicyIsNull = false;
            }
             // determine if request.MetricPolicy should be set to null
            if (requestMetricPolicyIsNull)
            {
                request.MetricPolicy = null;
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
        
        private Amazon.MediaStore.Model.PutMetricPolicyResponse CallAWSServiceOperation(IAmazonMediaStore client, Amazon.MediaStore.Model.PutMetricPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaStore", "PutMetricPolicy");
            try
            {
                #if DESKTOP
                return client.PutMetricPolicy(request);
                #elif CORECLR
                return client.PutMetricPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String ContainerName { get; set; }
            public Amazon.MediaStore.ContainerLevelMetrics MetricPolicy_ContainerLevelMetric { get; set; }
            public List<Amazon.MediaStore.Model.MetricPolicyRule> MetricPolicy_MetricPolicyRule { get; set; }
            public System.Func<Amazon.MediaStore.Model.PutMetricPolicyResponse, WriteEMSMetricPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
