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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Tests a registered extension to make sure it meets all necessary requirements for
    /// being published in the CloudFormation registry.
    /// 
    ///  <ul><li><para>
    /// For resource types, this includes passing all contracts tests defined for the type.
    /// </para></li><li><para>
    /// For modules, this includes determining if the module's model meets all necessary requirements.
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/publish-extension.html#publish-extension-testing">Testing
    /// your public extension prior to publishing</a> in the <i>CloudFormation CLI User Guide</i>.
    /// </para><para>
    /// If you do not specify a version, CloudFormation uses the default version of the extension
    /// in your account and region for testing.
    /// </para><para>
    /// To perform testing, CloudFormation assumes the execution role specified when the test
    /// was registered. For more information, see <a href="AWSCloudFormation/latest/APIReference/API_RegisterType.html">RegisterType</a>.
    /// </para><para>
    /// Once you've initiated testing on an extension using <code>TestType</code>, you can
    /// use <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_DescribeType.html">DescribeType</a>
    /// to monitor the current test status and test status description for the extension.
    /// </para><para>
    /// An extension must have a test status of <code>PASSED</code> before it can be published.
    /// For more information, see <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/resource-type-publish.html">Publishing
    /// extensions to make them available for public use</a> in the <i>CloudFormation CLI
    /// User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Test", "CFNType")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation TestType API operation.", Operation = new[] {"TestType"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.TestTypeResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudFormation.Model.TestTypeResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudFormation.Model.TestTypeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestCFNTypeCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the extension.</para><para>Conditional: You must specify <code>Arn</code>, or <code>TypeName</code> and <code>Type</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter LogDeliveryBucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket to which CloudFormation delivers the contract test execution logs.</para><para>CloudFormation delivers the logs by the time contract testing has completed and the
        /// extension has been assigned a test type status of <code>PASSED</code> or <code>FAILED</code>.</para><para>The user calling <code>TestType</code> must be able to access items in the specified
        /// S3 bucket. Specifically, the user needs the following permissions:</para><ul><li><para>GetObject</para></li><li><para>PutObject</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_amazons3.html">Actions,
        /// Resources, and Condition Keys for Amazon S3</a> in the <i>AWS Identity and Access
        /// Management User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogDeliveryBucket { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the extension to test.</para><para>Conditional: You must specify <code>Arn</code>, or <code>TypeName</code> and <code>Type</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.ThirdPartyType")]
        public Amazon.CloudFormation.ThirdPartyType Type { get; set; }
        #endregion
        
        #region Parameter TypeName
        /// <summary>
        /// <para>
        /// <para>The name of the extension to test.</para><para>Conditional: You must specify <code>Arn</code>, or <code>TypeName</code> and <code>Type</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TypeName { get; set; }
        #endregion
        
        #region Parameter VersionId
        /// <summary>
        /// <para>
        /// <para>The version of the extension to test.</para><para>You can specify the version id with either <code>Arn</code>, or with <code>TypeName</code>
        /// and <code>Type</code>.</para><para>If you do not specify a version, CloudFormation uses the default version of the extension
        /// in this account and region for testing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TypeVersionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.TestTypeResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.TestTypeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TypeVersionArn";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.TestTypeResponse, TestCFNTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
            context.LogDeliveryBucket = this.LogDeliveryBucket;
            context.Type = this.Type;
            context.TypeName = this.TypeName;
            context.VersionId = this.VersionId;
            
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
            var request = new Amazon.CloudFormation.Model.TestTypeRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.LogDeliveryBucket != null)
            {
                request.LogDeliveryBucket = cmdletContext.LogDeliveryBucket;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.TypeName != null)
            {
                request.TypeName = cmdletContext.TypeName;
            }
            if (cmdletContext.VersionId != null)
            {
                request.VersionId = cmdletContext.VersionId;
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
        
        private Amazon.CloudFormation.Model.TestTypeResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.TestTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "TestType");
            try
            {
                #if DESKTOP
                return client.TestType(request);
                #elif CORECLR
                return client.TestTypeAsync(request).GetAwaiter().GetResult();
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
            public System.String LogDeliveryBucket { get; set; }
            public Amazon.CloudFormation.ThirdPartyType Type { get; set; }
            public System.String TypeName { get; set; }
            public System.String VersionId { get; set; }
            public System.Func<Amazon.CloudFormation.Model.TestTypeResponse, TestCFNTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TypeVersionArn;
        }
        
    }
}
