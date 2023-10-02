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
using Amazon.MediaConvert;
using Amazon.MediaConvert.Model;

namespace Amazon.PowerShell.Cmdlets.EMC
{
    /// <summary>
    /// Create or change your policy. For more information about policies, see the user guide
    /// at http://docs.aws.amazon.com/mediaconvert/latest/ug/what-is.html
    /// </summary>
    [Cmdlet("Write", "EMCPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConvert.Model.Policy")]
    [AWSCmdlet("Calls the AWS Elemental MediaConvert PutPolicy API operation.", Operation = new[] {"PutPolicy"}, SelectReturnType = typeof(Amazon.MediaConvert.Model.PutPolicyResponse))]
    [AWSCmdletOutput("Amazon.MediaConvert.Model.Policy or Amazon.MediaConvert.Model.PutPolicyResponse",
        "This cmdlet returns an Amazon.MediaConvert.Model.Policy object.",
        "The service call response (type Amazon.MediaConvert.Model.PutPolicyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteEMCPolicyCmdlet : AmazonMediaConvertClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Policy_HttpInput
        /// <summary>
        /// <para>
        /// Allow or disallow jobs that specify HTTP inputs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Policy_HttpInputs")]
        [AWSConstantClassSource("Amazon.MediaConvert.InputPolicy")]
        public Amazon.MediaConvert.InputPolicy Policy_HttpInput { get; set; }
        #endregion
        
        #region Parameter Policy_HttpsInput
        /// <summary>
        /// <para>
        /// Allow or disallow jobs that specify HTTPS
        /// inputs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Policy_HttpsInputs")]
        [AWSConstantClassSource("Amazon.MediaConvert.InputPolicy")]
        public Amazon.MediaConvert.InputPolicy Policy_HttpsInput { get; set; }
        #endregion
        
        #region Parameter Policy_S3Input
        /// <summary>
        /// <para>
        /// Allow or disallow jobs that specify Amazon S3
        /// inputs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Policy_S3Inputs")]
        [AWSConstantClassSource("Amazon.MediaConvert.InputPolicy")]
        public Amazon.MediaConvert.InputPolicy Policy_S3Input { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Policy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConvert.Model.PutPolicyResponse).
        /// Specifying the name of a property of type Amazon.MediaConvert.Model.PutPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Policy";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EMCPolicy (PutPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConvert.Model.PutPolicyResponse, WriteEMCPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Policy_HttpInput = this.Policy_HttpInput;
            context.Policy_HttpsInput = this.Policy_HttpsInput;
            context.Policy_S3Input = this.Policy_S3Input;
            
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
            var request = new Amazon.MediaConvert.Model.PutPolicyRequest();
            
            
             // populate Policy
            var requestPolicyIsNull = true;
            request.Policy = new Amazon.MediaConvert.Model.Policy();
            Amazon.MediaConvert.InputPolicy requestPolicy_policy_HttpInput = null;
            if (cmdletContext.Policy_HttpInput != null)
            {
                requestPolicy_policy_HttpInput = cmdletContext.Policy_HttpInput;
            }
            if (requestPolicy_policy_HttpInput != null)
            {
                request.Policy.HttpInputs = requestPolicy_policy_HttpInput;
                requestPolicyIsNull = false;
            }
            Amazon.MediaConvert.InputPolicy requestPolicy_policy_HttpsInput = null;
            if (cmdletContext.Policy_HttpsInput != null)
            {
                requestPolicy_policy_HttpsInput = cmdletContext.Policy_HttpsInput;
            }
            if (requestPolicy_policy_HttpsInput != null)
            {
                request.Policy.HttpsInputs = requestPolicy_policy_HttpsInput;
                requestPolicyIsNull = false;
            }
            Amazon.MediaConvert.InputPolicy requestPolicy_policy_S3Input = null;
            if (cmdletContext.Policy_S3Input != null)
            {
                requestPolicy_policy_S3Input = cmdletContext.Policy_S3Input;
            }
            if (requestPolicy_policy_S3Input != null)
            {
                request.Policy.S3Inputs = requestPolicy_policy_S3Input;
                requestPolicyIsNull = false;
            }
             // determine if request.Policy should be set to null
            if (requestPolicyIsNull)
            {
                request.Policy = null;
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
        
        private Amazon.MediaConvert.Model.PutPolicyResponse CallAWSServiceOperation(IAmazonMediaConvert client, Amazon.MediaConvert.Model.PutPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConvert", "PutPolicy");
            try
            {
                #if DESKTOP
                return client.PutPolicy(request);
                #elif CORECLR
                return client.PutPolicyAsync(request).GetAwaiter().GetResult();
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
            public Amazon.MediaConvert.InputPolicy Policy_HttpInput { get; set; }
            public Amazon.MediaConvert.InputPolicy Policy_HttpsInput { get; set; }
            public Amazon.MediaConvert.InputPolicy Policy_S3Input { get; set; }
            public System.Func<Amazon.MediaConvert.Model.PutPolicyResponse, WriteEMCPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Policy;
        }
        
    }
}
