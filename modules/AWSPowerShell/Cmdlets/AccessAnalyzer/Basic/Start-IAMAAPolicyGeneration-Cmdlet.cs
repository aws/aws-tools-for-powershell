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
using Amazon.AccessAnalyzer;
using Amazon.AccessAnalyzer.Model;

namespace Amazon.PowerShell.Cmdlets.IAMAA
{
    /// <summary>
    /// Starts the policy generation request.
    /// </summary>
    [Cmdlet("Start", "IAMAAPolicyGeneration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IAM Access Analyzer StartPolicyGeneration API operation.", Operation = new[] {"StartPolicyGeneration"}, SelectReturnType = typeof(Amazon.AccessAnalyzer.Model.StartPolicyGenerationResponse))]
    [AWSCmdletOutput("System.String or Amazon.AccessAnalyzer.Model.StartPolicyGenerationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.AccessAnalyzer.Model.StartPolicyGenerationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartIAMAAPolicyGenerationCmdlet : AmazonAccessAnalyzerClientCmdlet, IExecutor
    {
        
        #region Parameter CloudTrailDetails_AccessRole
        /// <summary>
        /// <para>
        /// <para>The ARN of the service role that IAM Access Analyzer uses to access your CloudTrail
        /// trail and service last accessed information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CloudTrailDetails_AccessRole { get; set; }
        #endregion
        
        #region Parameter CloudTrailDetails_EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time range for which IAM Access Analyzer reviews your CloudTrail events.
        /// Events with a timestamp after this time are not considered to generate a policy. If
        /// this is not included in the request, the default value is the current time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CloudTrailDetails_EndTime { get; set; }
        #endregion
        
        #region Parameter PolicyGenerationDetails_PrincipalArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM entity (user or role) for which you are generating a policy.</para>
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
        public System.String PolicyGenerationDetails_PrincipalArn { get; set; }
        #endregion
        
        #region Parameter CloudTrailDetails_StartTime
        /// <summary>
        /// <para>
        /// <para>The start of the time range for which IAM Access Analyzer reviews your CloudTrail
        /// events. Events with a timestamp before this time are not considered to generate a
        /// policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CloudTrailDetails_StartTime { get; set; }
        #endregion
        
        #region Parameter CloudTrailDetails_Trail
        /// <summary>
        /// <para>
        /// <para>A <code>Trail</code> object that contains settings for a trail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CloudTrailDetails_Trails")]
        public Amazon.AccessAnalyzer.Model.Trail[] CloudTrailDetails_Trail { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. Idempotency ensures that an API request completes only once. With an
        /// idempotent request, if the original request completes successfully, the subsequent
        /// retries with the same client token return the result from the original successful
        /// request and they have no additional effect.</para><para>If you do not specify a client token, one is automatically generated by the Amazon
        /// Web Services SDK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AccessAnalyzer.Model.StartPolicyGenerationResponse).
        /// Specifying the name of a property of type Amazon.AccessAnalyzer.Model.StartPolicyGenerationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PolicyGenerationDetails_PrincipalArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PolicyGenerationDetails_PrincipalArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PolicyGenerationDetails_PrincipalArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyGenerationDetails_PrincipalArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-IAMAAPolicyGeneration (StartPolicyGeneration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AccessAnalyzer.Model.StartPolicyGenerationResponse, StartIAMAAPolicyGenerationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PolicyGenerationDetails_PrincipalArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.CloudTrailDetails_AccessRole = this.CloudTrailDetails_AccessRole;
            context.CloudTrailDetails_EndTime = this.CloudTrailDetails_EndTime;
            context.CloudTrailDetails_StartTime = this.CloudTrailDetails_StartTime;
            if (this.CloudTrailDetails_Trail != null)
            {
                context.CloudTrailDetails_Trail = new List<Amazon.AccessAnalyzer.Model.Trail>(this.CloudTrailDetails_Trail);
            }
            context.PolicyGenerationDetails_PrincipalArn = this.PolicyGenerationDetails_PrincipalArn;
            #if MODULAR
            if (this.PolicyGenerationDetails_PrincipalArn == null && ParameterWasBound(nameof(this.PolicyGenerationDetails_PrincipalArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyGenerationDetails_PrincipalArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AccessAnalyzer.Model.StartPolicyGenerationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate CloudTrailDetails
            var requestCloudTrailDetailsIsNull = true;
            request.CloudTrailDetails = new Amazon.AccessAnalyzer.Model.CloudTrailDetails();
            System.String requestCloudTrailDetails_cloudTrailDetails_AccessRole = null;
            if (cmdletContext.CloudTrailDetails_AccessRole != null)
            {
                requestCloudTrailDetails_cloudTrailDetails_AccessRole = cmdletContext.CloudTrailDetails_AccessRole;
            }
            if (requestCloudTrailDetails_cloudTrailDetails_AccessRole != null)
            {
                request.CloudTrailDetails.AccessRole = requestCloudTrailDetails_cloudTrailDetails_AccessRole;
                requestCloudTrailDetailsIsNull = false;
            }
            System.DateTime? requestCloudTrailDetails_cloudTrailDetails_EndTime = null;
            if (cmdletContext.CloudTrailDetails_EndTime != null)
            {
                requestCloudTrailDetails_cloudTrailDetails_EndTime = cmdletContext.CloudTrailDetails_EndTime.Value;
            }
            if (requestCloudTrailDetails_cloudTrailDetails_EndTime != null)
            {
                request.CloudTrailDetails.EndTime = requestCloudTrailDetails_cloudTrailDetails_EndTime.Value;
                requestCloudTrailDetailsIsNull = false;
            }
            System.DateTime? requestCloudTrailDetails_cloudTrailDetails_StartTime = null;
            if (cmdletContext.CloudTrailDetails_StartTime != null)
            {
                requestCloudTrailDetails_cloudTrailDetails_StartTime = cmdletContext.CloudTrailDetails_StartTime.Value;
            }
            if (requestCloudTrailDetails_cloudTrailDetails_StartTime != null)
            {
                request.CloudTrailDetails.StartTime = requestCloudTrailDetails_cloudTrailDetails_StartTime.Value;
                requestCloudTrailDetailsIsNull = false;
            }
            List<Amazon.AccessAnalyzer.Model.Trail> requestCloudTrailDetails_cloudTrailDetails_Trail = null;
            if (cmdletContext.CloudTrailDetails_Trail != null)
            {
                requestCloudTrailDetails_cloudTrailDetails_Trail = cmdletContext.CloudTrailDetails_Trail;
            }
            if (requestCloudTrailDetails_cloudTrailDetails_Trail != null)
            {
                request.CloudTrailDetails.Trails = requestCloudTrailDetails_cloudTrailDetails_Trail;
                requestCloudTrailDetailsIsNull = false;
            }
             // determine if request.CloudTrailDetails should be set to null
            if (requestCloudTrailDetailsIsNull)
            {
                request.CloudTrailDetails = null;
            }
            
             // populate PolicyGenerationDetails
            var requestPolicyGenerationDetailsIsNull = true;
            request.PolicyGenerationDetails = new Amazon.AccessAnalyzer.Model.PolicyGenerationDetails();
            System.String requestPolicyGenerationDetails_policyGenerationDetails_PrincipalArn = null;
            if (cmdletContext.PolicyGenerationDetails_PrincipalArn != null)
            {
                requestPolicyGenerationDetails_policyGenerationDetails_PrincipalArn = cmdletContext.PolicyGenerationDetails_PrincipalArn;
            }
            if (requestPolicyGenerationDetails_policyGenerationDetails_PrincipalArn != null)
            {
                request.PolicyGenerationDetails.PrincipalArn = requestPolicyGenerationDetails_policyGenerationDetails_PrincipalArn;
                requestPolicyGenerationDetailsIsNull = false;
            }
             // determine if request.PolicyGenerationDetails should be set to null
            if (requestPolicyGenerationDetailsIsNull)
            {
                request.PolicyGenerationDetails = null;
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
        
        private Amazon.AccessAnalyzer.Model.StartPolicyGenerationResponse CallAWSServiceOperation(IAmazonAccessAnalyzer client, Amazon.AccessAnalyzer.Model.StartPolicyGenerationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IAM Access Analyzer", "StartPolicyGeneration");
            try
            {
                #if DESKTOP
                return client.StartPolicyGeneration(request);
                #elif CORECLR
                return client.StartPolicyGenerationAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String CloudTrailDetails_AccessRole { get; set; }
            public System.DateTime? CloudTrailDetails_EndTime { get; set; }
            public System.DateTime? CloudTrailDetails_StartTime { get; set; }
            public List<Amazon.AccessAnalyzer.Model.Trail> CloudTrailDetails_Trail { get; set; }
            public System.String PolicyGenerationDetails_PrincipalArn { get; set; }
            public System.Func<Amazon.AccessAnalyzer.Model.StartPolicyGenerationResponse, StartIAMAAPolicyGenerationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
