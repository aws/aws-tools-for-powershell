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
    /// Registers your account as a publisher of public extensions in the CloudFormation registry.
    /// Public extensions are available for use by all CloudFormation users. This publisher
    /// ID applies to your account in all Amazon Web Services Regions.
    /// 
    ///  
    /// <para>
    /// For information about requirements for registering as a public extension publisher,
    /// see <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/publish-extension.html#publish-extension-prereqs">Registering
    /// your account to publish CloudFormation extensions</a> in the <i>CloudFormation CLI
    /// User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "CFNPublisher", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation RegisterPublisher API operation.", Operation = new[] {"RegisterPublisher"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.RegisterPublisherResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudFormation.Model.RegisterPublisherResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudFormation.Model.RegisterPublisherResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterCFNPublisherCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AcceptTermsAndCondition
        /// <summary>
        /// <para>
        /// <para>Whether you accept the <a href="https://cloudformation-registry-documents.s3.amazonaws.com/Terms_and_Conditions_for_AWS_CloudFormation_Registry_Publishers.pdf">Terms
        /// and Conditions</a> for publishing extensions in the CloudFormation registry. You must
        /// accept the terms and conditions in order to register to publish public extensions
        /// to the CloudFormation registry.</para><para>The default is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AcceptTermsAndConditions")]
        public System.Boolean? AcceptTermsAndCondition { get; set; }
        #endregion
        
        #region Parameter ConnectionArn
        /// <summary>
        /// <para>
        /// <para>If you are using a Bitbucket or GitHub account for identity verification, the Amazon
        /// Resource Name (ARN) for your connection to that account.</para><para>For more information, see <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/publish-extension.html#publish-extension-prereqs">Registering
        /// your account to publish CloudFormation extensions</a> in the <i>CloudFormation CLI
        /// User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectionArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PublisherId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.RegisterPublisherResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.RegisterPublisherResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PublisherId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-CFNPublisher (RegisterPublisher)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.RegisterPublisherResponse, RegisterCFNPublisherCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcceptTermsAndCondition = this.AcceptTermsAndCondition;
            context.ConnectionArn = this.ConnectionArn;
            
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
            var request = new Amazon.CloudFormation.Model.RegisterPublisherRequest();
            
            if (cmdletContext.AcceptTermsAndCondition != null)
            {
                request.AcceptTermsAndConditions = cmdletContext.AcceptTermsAndCondition.Value;
            }
            if (cmdletContext.ConnectionArn != null)
            {
                request.ConnectionArn = cmdletContext.ConnectionArn;
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
        
        private Amazon.CloudFormation.Model.RegisterPublisherResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.RegisterPublisherRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "RegisterPublisher");
            try
            {
                #if DESKTOP
                return client.RegisterPublisher(request);
                #elif CORECLR
                return client.RegisterPublisherAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AcceptTermsAndCondition { get; set; }
            public System.String ConnectionArn { get; set; }
            public System.Func<Amazon.CloudFormation.Model.RegisterPublisherResponse, RegisterCFNPublisherCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PublisherId;
        }
        
    }
}
