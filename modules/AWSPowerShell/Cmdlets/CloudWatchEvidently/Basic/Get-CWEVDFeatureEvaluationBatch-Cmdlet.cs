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
using Amazon.CloudWatchEvidently;
using Amazon.CloudWatchEvidently.Model;

namespace Amazon.PowerShell.Cmdlets.CWEVD
{
    /// <summary>
    /// This operation assigns feature variation to user sessions. For each user session,
    /// you pass in an <c>entityID</c> that represents the user. Evidently then checks the
    /// evaluation rules and assigns the variation.
    /// 
    ///  
    /// <para>
    /// The first rules that are evaluated are the override rules. If the user's <c>entityID</c>
    /// matches an override rule, the user is served the variation specified by that rule.
    /// </para><para>
    /// Next, if there is a launch of the feature, the user might be assigned to a variation
    /// in the launch. The chance of this depends on the percentage of users that are allocated
    /// to that launch. If the user is enrolled in the launch, the variation they are served
    /// depends on the allocation of the various feature variations used for the launch.
    /// </para><para>
    /// If the user is not assigned to a launch, and there is an ongoing experiment for this
    /// feature, the user might be assigned to a variation in the experiment. The chance of
    /// this depends on the percentage of users that are allocated to that experiment. If
    /// the user is enrolled in the experiment, the variation they are served depends on the
    /// allocation of the various feature variations used for the experiment. 
    /// </para><para>
    /// If the user is not assigned to a launch or experiment, they are served the default
    /// variation.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWEVDFeatureEvaluationBatch")]
    [OutputType("Amazon.CloudWatchEvidently.Model.EvaluationResult")]
    [AWSCmdlet("Calls the Amazon CloudWatch Evidently BatchEvaluateFeature API operation.", Operation = new[] {"BatchEvaluateFeature"}, SelectReturnType = typeof(Amazon.CloudWatchEvidently.Model.BatchEvaluateFeatureResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchEvidently.Model.EvaluationResult or Amazon.CloudWatchEvidently.Model.BatchEvaluateFeatureResponse",
        "This cmdlet returns a collection of Amazon.CloudWatchEvidently.Model.EvaluationResult objects.",
        "The service call response (type Amazon.CloudWatchEvidently.Model.BatchEvaluateFeatureResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCWEVDFeatureEvaluationBatchCmdlet : AmazonCloudWatchEvidentlyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Project
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the project that contains the feature being evaluated.</para>
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
        public System.String Project { get; set; }
        #endregion
        
        #region Parameter Request
        /// <summary>
        /// <para>
        /// <para>An array of structures, where each structure assigns a feature variation to one user
        /// session.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Requests")]
        public Amazon.CloudWatchEvidently.Model.EvaluationRequest[] Request { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Results'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchEvidently.Model.BatchEvaluateFeatureResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchEvidently.Model.BatchEvaluateFeatureResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Results";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchEvidently.Model.BatchEvaluateFeatureResponse, GetCWEVDFeatureEvaluationBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Project = this.Project;
            #if MODULAR
            if (this.Project == null && ParameterWasBound(nameof(this.Project)))
            {
                WriteWarning("You are passing $null as a value for parameter Project which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Request != null)
            {
                context.Request = new List<Amazon.CloudWatchEvidently.Model.EvaluationRequest>(this.Request);
            }
            #if MODULAR
            if (this.Request == null && ParameterWasBound(nameof(this.Request)))
            {
                WriteWarning("You are passing $null as a value for parameter Request which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchEvidently.Model.BatchEvaluateFeatureRequest();
            
            if (cmdletContext.Project != null)
            {
                request.Project = cmdletContext.Project;
            }
            if (cmdletContext.Request != null)
            {
                request.Requests = cmdletContext.Request;
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
        
        private Amazon.CloudWatchEvidently.Model.BatchEvaluateFeatureResponse CallAWSServiceOperation(IAmazonCloudWatchEvidently client, Amazon.CloudWatchEvidently.Model.BatchEvaluateFeatureRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Evidently", "BatchEvaluateFeature");
            try
            {
                #if DESKTOP
                return client.BatchEvaluateFeature(request);
                #elif CORECLR
                return client.BatchEvaluateFeatureAsync(request).GetAwaiter().GetResult();
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
            public System.String Project { get; set; }
            public List<Amazon.CloudWatchEvidently.Model.EvaluationRequest> Request { get; set; }
            public System.Func<Amazon.CloudWatchEvidently.Model.BatchEvaluateFeatureResponse, GetCWEVDFeatureEvaluationBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Results;
        }
        
    }
}
