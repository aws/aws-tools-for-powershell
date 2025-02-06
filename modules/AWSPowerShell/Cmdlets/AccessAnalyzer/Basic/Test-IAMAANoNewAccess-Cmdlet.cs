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
using Amazon.AccessAnalyzer;
using Amazon.AccessAnalyzer.Model;

namespace Amazon.PowerShell.Cmdlets.IAMAA
{
    /// <summary>
    /// Checks whether new access is allowed for an updated policy when compared to the existing
    /// policy.
    /// 
    ///  
    /// <para>
    /// You can find examples for reference policies and learn how to set up and run a custom
    /// policy check for new access in the <a href="https://github.com/aws-samples/iam-access-analyzer-custom-policy-check-samples">IAM
    /// Access Analyzer custom policy checks samples</a> repository on GitHub. The reference
    /// policies in this repository are meant to be passed to the <c>existingPolicyDocument</c>
    /// request parameter.
    /// </para>
    /// </summary>
    [Cmdlet("Test", "IAMAANoNewAccess")]
    [OutputType("Amazon.AccessAnalyzer.Model.CheckNoNewAccessResponse")]
    [AWSCmdlet("Calls the AWS IAM Access Analyzer CheckNoNewAccess API operation.", Operation = new[] {"CheckNoNewAccess"}, SelectReturnType = typeof(Amazon.AccessAnalyzer.Model.CheckNoNewAccessResponse))]
    [AWSCmdletOutput("Amazon.AccessAnalyzer.Model.CheckNoNewAccessResponse",
        "This cmdlet returns an Amazon.AccessAnalyzer.Model.CheckNoNewAccessResponse object containing multiple properties."
    )]
    public partial class TestIAMAANoNewAccessCmdlet : AmazonAccessAnalyzerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExistingPolicyDocument
        /// <summary>
        /// <para>
        /// <para>The JSON policy document to use as the content for the existing policy.</para>
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
        public System.String ExistingPolicyDocument { get; set; }
        #endregion
        
        #region Parameter NewPolicyDocument
        /// <summary>
        /// <para>
        /// <para>The JSON policy document to use as the content for the updated policy.</para>
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
        public System.String NewPolicyDocument { get; set; }
        #endregion
        
        #region Parameter PolicyType
        /// <summary>
        /// <para>
        /// <para>The type of policy to compare. Identity policies grant permissions to IAM principals.
        /// Identity policies include managed and inline policies for IAM roles, users, and groups.</para><para>Resource policies grant permissions on Amazon Web Services resources. Resource policies
        /// include trust policies for IAM roles and bucket policies for Amazon S3 buckets. You
        /// can provide a generic input such as identity policy or resource policy or a specific
        /// input such as managed policy or Amazon S3 bucket policy.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AccessAnalyzer.AccessCheckPolicyType")]
        public Amazon.AccessAnalyzer.AccessCheckPolicyType PolicyType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AccessAnalyzer.Model.CheckNoNewAccessResponse).
        /// Specifying the name of a property of type Amazon.AccessAnalyzer.Model.CheckNoNewAccessResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.AccessAnalyzer.Model.CheckNoNewAccessResponse, TestIAMAANoNewAccessCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExistingPolicyDocument = this.ExistingPolicyDocument;
            #if MODULAR
            if (this.ExistingPolicyDocument == null && ParameterWasBound(nameof(this.ExistingPolicyDocument)))
            {
                WriteWarning("You are passing $null as a value for parameter ExistingPolicyDocument which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewPolicyDocument = this.NewPolicyDocument;
            #if MODULAR
            if (this.NewPolicyDocument == null && ParameterWasBound(nameof(this.NewPolicyDocument)))
            {
                WriteWarning("You are passing $null as a value for parameter NewPolicyDocument which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyType = this.PolicyType;
            #if MODULAR
            if (this.PolicyType == null && ParameterWasBound(nameof(this.PolicyType)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AccessAnalyzer.Model.CheckNoNewAccessRequest();
            
            if (cmdletContext.ExistingPolicyDocument != null)
            {
                request.ExistingPolicyDocument = cmdletContext.ExistingPolicyDocument;
            }
            if (cmdletContext.NewPolicyDocument != null)
            {
                request.NewPolicyDocument = cmdletContext.NewPolicyDocument;
            }
            if (cmdletContext.PolicyType != null)
            {
                request.PolicyType = cmdletContext.PolicyType;
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
        
        private Amazon.AccessAnalyzer.Model.CheckNoNewAccessResponse CallAWSServiceOperation(IAmazonAccessAnalyzer client, Amazon.AccessAnalyzer.Model.CheckNoNewAccessRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IAM Access Analyzer", "CheckNoNewAccess");
            try
            {
                #if DESKTOP
                return client.CheckNoNewAccess(request);
                #elif CORECLR
                return client.CheckNoNewAccessAsync(request).GetAwaiter().GetResult();
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
            public System.String ExistingPolicyDocument { get; set; }
            public System.String NewPolicyDocument { get; set; }
            public Amazon.AccessAnalyzer.AccessCheckPolicyType PolicyType { get; set; }
            public System.Func<Amazon.AccessAnalyzer.Model.CheckNoNewAccessResponse, TestIAMAANoNewAccessCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
