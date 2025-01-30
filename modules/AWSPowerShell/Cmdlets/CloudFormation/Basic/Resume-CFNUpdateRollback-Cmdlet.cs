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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// For a specified stack that's in the <c>UPDATE_ROLLBACK_FAILED</c> state, continues
    /// rolling it back to the <c>UPDATE_ROLLBACK_COMPLETE</c> state. Depending on the cause
    /// of the failure, you can manually <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/troubleshooting.html#troubleshooting-errors-update-rollback-failed">fix
    /// the error</a> and continue the rollback. By continuing the rollback, you can return
    /// your stack to a working state (the <c>UPDATE_ROLLBACK_COMPLETE</c> state), and then
    /// try to update the stack again.
    /// 
    ///  
    /// <para>
    /// A stack goes into the <c>UPDATE_ROLLBACK_FAILED</c> state when CloudFormation can't
    /// roll back all changes after a failed stack update. For example, you might have a stack
    /// that's rolling back to an old database instance that was deleted outside of CloudFormation.
    /// Because CloudFormation doesn't know the database was deleted, it assumes that the
    /// database instance still exists and attempts to roll back to it, causing the update
    /// rollback to fail.
    /// </para>
    /// </summary>
    [Cmdlet("Resume", "CFNUpdateRollback", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS CloudFormation ContinueUpdateRollback API operation.", Operation = new[] {"ContinueUpdateRollback"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.ContinueUpdateRollbackResponse))]
    [AWSCmdletOutput("None or Amazon.CloudFormation.Model.ContinueUpdateRollbackResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudFormation.Model.ContinueUpdateRollbackResponse) be returned by specifying '-Select *'."
    )]
    public partial class ResumeCFNUpdateRollbackCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for this <c>ContinueUpdateRollback</c> request. Specify this token
        /// if you plan to retry requests so that CloudFormation knows that you're not attempting
        /// to continue the rollback to a stack with the same name. You might retry <c>ContinueUpdateRollback</c>
        /// requests to ensure that CloudFormation successfully received them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ResourcesToSkip
        /// <summary>
        /// <para>
        /// <para>A list of the logical IDs of the resources that CloudFormation skips during the continue
        /// update rollback operation. You can specify only resources that are in the <c>UPDATE_FAILED</c>
        /// state because a rollback failed. You can't specify resources that are in the <c>UPDATE_FAILED</c>
        /// state for other reasons, for example, because an update was canceled. To check why
        /// a resource update failed, use the <a>DescribeStackResources</a> action, and view the
        /// resource status reason.</para><important><para>Specify this property to skip rolling back resources that CloudFormation can't successfully
        /// roll back. We recommend that you <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/troubleshooting.html#troubleshooting-errors-update-rollback-failed">
        /// troubleshoot</a> resources before skipping them. CloudFormation sets the status of
        /// the specified resources to <c>UPDATE_COMPLETE</c> and continues to roll back the stack.
        /// After the rollback is complete, the state of the skipped resources will be inconsistent
        /// with the state of the resources in the stack template. Before performing another stack
        /// update, you must update the stack or resources to be consistent with each other. If
        /// you don't, subsequent stack updates might fail, and the stack will become unrecoverable.</para></important><para>Specify the minimum number of resources required to successfully roll back your stack.
        /// For example, a failed resource update might cause dependent resources to fail. In
        /// this case, it might not be necessary to skip the dependent resources.</para><para>To skip resources that are part of nested stacks, use the following format: <c>NestedStackName.ResourceLogicalID</c>.
        /// If you want to specify the logical ID of a stack resource (<c>Type: AWS::CloudFormation::Stack</c>)
        /// in the <c>ResourcesToSkip</c> list, then its corresponding embedded stack must be
        /// in one of the following states: <c>DELETE_IN_PROGRESS</c>, <c>DELETE_COMPLETE</c>,
        /// or <c>DELETE_FAILED</c>.</para><note><para>Don't confuse a child stack's name with its corresponding logical ID defined in the
        /// parent stack. For an example of a continue update rollback operation with nested stacks,
        /// see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-cfn-updating-stacks-continueupdaterollback.html#nested-stacks">Continue
        /// rolling back from failed nested stack updates</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ResourcesToSkip { get; set; }
        #endregion
        
        #region Parameter RoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that CloudFormation assumes to roll
        /// back the stack. CloudFormation uses the role's credentials to make calls on your behalf.
        /// CloudFormation always uses this role for all future operations on the stack. Provided
        /// that users have permission to operate on the stack, CloudFormation uses this role
        /// even if the users don't have permission to pass it. Ensure that the role grants least
        /// permission.</para><para>If you don't specify a value, CloudFormation uses the role that was previously associated
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
        /// <para>The name or the unique ID of the stack that you want to continue rolling back.</para><note><para>Don't specify the name of a nested stack (a stack that was created by using the <c>AWS::CloudFormation::Stack</c>
        /// resource). Instead, use this operation on the parent stack (the stack that contains
        /// the <c>AWS::CloudFormation::Stack</c> resource).</para></note>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.ContinueUpdateRollbackResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Resume-CFNUpdateRollback (ContinueUpdateRollback)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.ContinueUpdateRollbackResponse, ResumeCFNUpdateRollbackCmdlet>(Select) ??
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
            if (this.ResourcesToSkip != null)
            {
                context.ResourcesToSkip = new List<System.String>(this.ResourcesToSkip);
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
            var request = new Amazon.CloudFormation.Model.ContinueUpdateRollbackRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ResourcesToSkip != null)
            {
                request.ResourcesToSkip = cmdletContext.ResourcesToSkip;
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
        
        private Amazon.CloudFormation.Model.ContinueUpdateRollbackResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.ContinueUpdateRollbackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "ContinueUpdateRollback");
            try
            {
                #if DESKTOP
                return client.ContinueUpdateRollback(request);
                #elif CORECLR
                return client.ContinueUpdateRollbackAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ResourcesToSkip { get; set; }
            public System.String RoleARN { get; set; }
            public System.String StackName { get; set; }
            public System.Func<Amazon.CloudFormation.Model.ContinueUpdateRollbackResponse, ResumeCFNUpdateRollbackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
