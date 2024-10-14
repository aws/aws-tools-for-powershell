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
    /// Deletes a specified stack. Once the call completes successfully, stack deletion starts.
    /// Deleted stacks don't show up in the <a>DescribeStacks</a> operation if the deletion
    /// has been completed successfully.
    /// </summary>
    [Cmdlet("Remove", "CFNStack", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS CloudFormation DeleteStack API operation.", Operation = new[] {"DeleteStack"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.DeleteStackResponse))]
    [AWSCmdletOutput("None or Amazon.CloudFormation.Model.DeleteStackResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudFormation.Model.DeleteStackResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveCFNStackCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for this <c>DeleteStack</c> request. Specify this token if you
        /// plan to retry requests so that CloudFormation knows that you're not attempting to
        /// delete a stack with the same name. You might retry <c>DeleteStack</c> requests to
        /// ensure that CloudFormation successfully received them.</para><para>All events initiated by a given stack operation are assigned the same client request
        /// token, which you can use to track operations. For example, if you execute a <c>CreateStack</c>
        /// operation with the token <c>token1</c>, then all the <c>StackEvents</c> generated
        /// by that operation will have <c>ClientRequestToken</c> set as <c>token1</c>.</para><para>In the console, stack operations display the client request token on the Events tab.
        /// Stack operations that are initiated from the console use the token format <i>Console-StackOperation-ID</i>,
        /// which helps you easily identify the stack operation . For example, if you create a
        /// stack using the console, each stack event would be assigned the same token in the
        /// following format: <c>Console-CreateStack-7f59c3cf-00d2-40c7-b2ff-e75db0987002</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter DeletionMode
        /// <summary>
        /// <para>
        /// <para>Specifies the deletion mode for the stack. Possible values are:</para><ul><li><para><c>STANDARD</c> - Use the standard behavior. Specifying this value is the same as
        /// not specifying this parameter.</para></li><li><para><c>FORCE_DELETE_STACK</c> - Delete the stack if it's stuck in a <c>DELETE_FAILED</c>
        /// state due to resource deletion failure.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.DeletionMode")]
        public Amazon.CloudFormation.DeletionMode DeletionMode { get; set; }
        #endregion
        
        #region Parameter RetainResource
        /// <summary>
        /// <para>
        /// <para>For stacks in the <c>DELETE_FAILED</c> state, a list of resource logical IDs that
        /// are associated with the resources you want to retain. During deletion, CloudFormation
        /// deletes the stack but doesn't delete the retained resources.</para><para>Retaining resources is useful when you can't delete a resource, such as a non-empty
        /// S3 bucket, but you want to delete the stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetainResources")]
        public System.String[] RetainResource { get; set; }
        #endregion
        
        #region Parameter RoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an Identity and Access Management (IAM) role that
        /// CloudFormation assumes to delete the stack. CloudFormation uses the role's credentials
        /// to make calls on your behalf.</para><para>If you don't specify a value, CloudFormation uses the role that was previously associated
        /// with the stack. If no role is available, CloudFormation uses a temporary session that's
        /// generated from your user credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleARN { get; set; }
        #endregion
        
        #region Parameter StackName
        /// <summary>
        /// <para>
        /// <para>The name or the unique stack ID that's associated with the stack.</para>
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
        public System.String StackName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.DeleteStackResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StackName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StackName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StackName' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StackName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CFNStack (DeleteStack)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.DeleteStackResponse, RemoveCFNStackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StackName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.DeletionMode = this.DeletionMode;
            if (this.RetainResource != null)
            {
                context.RetainResource = new List<System.String>(this.RetainResource);
            }
            context.RoleARN = this.RoleARN;
            context.StackName = this.StackName;
            #if MODULAR
            if (this.StackName == null && ParameterWasBound(nameof(this.StackName)))
            {
                WriteWarning("You are passing $null as a value for parameter StackName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudFormation.Model.DeleteStackRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.DeletionMode != null)
            {
                request.DeletionMode = cmdletContext.DeletionMode;
            }
            if (cmdletContext.RetainResource != null)
            {
                request.RetainResources = cmdletContext.RetainResource;
            }
            if (cmdletContext.RoleARN != null)
            {
                request.RoleARN = cmdletContext.RoleARN;
            }
            if (cmdletContext.StackName != null)
            {
                request.StackName = cmdletContext.StackName;
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
        
        private Amazon.CloudFormation.Model.DeleteStackResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.DeleteStackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "DeleteStack");
            try
            {
                #if DESKTOP
                return client.DeleteStack(request);
                #elif CORECLR
                return client.DeleteStackAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public Amazon.CloudFormation.DeletionMode DeletionMode { get; set; }
            public List<System.String> RetainResource { get; set; }
            public System.String RoleARN { get; set; }
            public System.String StackName { get; set; }
            public System.Func<Amazon.CloudFormation.Model.DeleteStackResponse, RemoveCFNStackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
