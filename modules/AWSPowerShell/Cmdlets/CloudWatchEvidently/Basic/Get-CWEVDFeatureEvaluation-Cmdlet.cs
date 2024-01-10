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
    /// This operation assigns a feature variation to one given user session. You pass in
    /// an <c>entityID</c> that represents the user. Evidently then checks the evaluation
    /// rules and assigns the variation.
    /// 
    ///  
    /// <para>
    /// The first rules that are evaluated are the override rules. If the user's <c>entityID</c>
    /// matches an override rule, the user is served the variation specified by that rule.
    /// </para><para>
    /// If there is a current launch with this feature that uses segment overrides, and if
    /// the user session's <c>evaluationContext</c> matches a segment rule defined in a segment
    /// override, the configuration in the segment overrides is used. For more information
    /// about segments, see <a href="https://docs.aws.amazon.com/cloudwatchevidently/latest/APIReference/API_CreateSegment.html">CreateSegment</a>
    /// and <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-Evidently-segments.html">Use
    /// segments to focus your audience</a>.
    /// </para><para>
    /// If there is a launch with no segment overrides, the user might be assigned to a variation
    /// in the launch. The chance of this depends on the percentage of users that are allocated
    /// to that launch. If the user is enrolled in the launch, the variation they are served
    /// depends on the allocation of the various feature variations used for the launch.
    /// </para><para>
    /// If the user is not assigned to a launch, and there is an ongoing experiment for this
    /// feature, the user might be assigned to a variation in the experiment. The chance of
    /// this depends on the percentage of users that are allocated to that experiment.
    /// </para><para>
    /// If the experiment uses a segment, then only user sessions with <c>evaluationContext</c>
    /// values that match the segment rule are used in the experiment.
    /// </para><para>
    /// If the user is enrolled in the experiment, the variation they are served depends on
    /// the allocation of the various feature variations used for the experiment. 
    /// </para><para>
    /// If the user is not assigned to a launch or experiment, they are served the default
    /// variation.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWEVDFeatureEvaluation")]
    [OutputType("Amazon.CloudWatchEvidently.Model.EvaluateFeatureResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Evidently EvaluateFeature API operation.", Operation = new[] {"EvaluateFeature"}, SelectReturnType = typeof(Amazon.CloudWatchEvidently.Model.EvaluateFeatureResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchEvidently.Model.EvaluateFeatureResponse",
        "This cmdlet returns an Amazon.CloudWatchEvidently.Model.EvaluateFeatureResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCWEVDFeatureEvaluationCmdlet : AmazonCloudWatchEvidentlyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EntityId
        /// <summary>
        /// <para>
        /// <para>An internal ID that represents a unique user of the application. This <c>entityID</c>
        /// is checked against any override rules assigned for this feature.</para>
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
        public System.String EntityId { get; set; }
        #endregion
        
        #region Parameter EvaluationContext
        /// <summary>
        /// <para>
        /// <para>A JSON object of attributes that you can optionally pass in as part of the evaluation
        /// event sent to Evidently from the user session. Evidently can use this value to match
        /// user sessions with defined audience segments. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-Evidently-segments.html">Use
        /// segments to focus your audience</a>.</para><para>If you include this parameter, the value must be a JSON object. A JSON array is not
        /// supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EvaluationContext { get; set; }
        #endregion
        
        #region Parameter Feature
        /// <summary>
        /// <para>
        /// <para>The name of the feature being evaluated.</para>
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
        public System.String Feature { get; set; }
        #endregion
        
        #region Parameter Project
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the project that contains this feature.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchEvidently.Model.EvaluateFeatureResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchEvidently.Model.EvaluateFeatureResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.CloudWatchEvidently.Model.EvaluateFeatureResponse, GetCWEVDFeatureEvaluationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EntityId = this.EntityId;
            #if MODULAR
            if (this.EntityId == null && ParameterWasBound(nameof(this.EntityId)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EvaluationContext = this.EvaluationContext;
            context.Feature = this.Feature;
            #if MODULAR
            if (this.Feature == null && ParameterWasBound(nameof(this.Feature)))
            {
                WriteWarning("You are passing $null as a value for parameter Feature which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Project = this.Project;
            #if MODULAR
            if (this.Project == null && ParameterWasBound(nameof(this.Project)))
            {
                WriteWarning("You are passing $null as a value for parameter Project which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchEvidently.Model.EvaluateFeatureRequest();
            
            if (cmdletContext.EntityId != null)
            {
                request.EntityId = cmdletContext.EntityId;
            }
            if (cmdletContext.EvaluationContext != null)
            {
                request.EvaluationContext = cmdletContext.EvaluationContext;
            }
            if (cmdletContext.Feature != null)
            {
                request.Feature = cmdletContext.Feature;
            }
            if (cmdletContext.Project != null)
            {
                request.Project = cmdletContext.Project;
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
        
        private Amazon.CloudWatchEvidently.Model.EvaluateFeatureResponse CallAWSServiceOperation(IAmazonCloudWatchEvidently client, Amazon.CloudWatchEvidently.Model.EvaluateFeatureRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Evidently", "EvaluateFeature");
            try
            {
                #if DESKTOP
                return client.EvaluateFeature(request);
                #elif CORECLR
                return client.EvaluateFeatureAsync(request).GetAwaiter().GetResult();
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
            public System.String EntityId { get; set; }
            public System.String EvaluationContext { get; set; }
            public System.String Feature { get; set; }
            public System.String Project { get; set; }
            public System.Func<Amazon.CloudWatchEvidently.Model.EvaluateFeatureResponse, GetCWEVDFeatureEvaluationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
