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
    /// Updates a stack using the input information that was provided when the specified change
    /// set was created. After the call successfully completes, CloudFormation starts updating
    /// the stack. Use the <a>DescribeStacks</a> action to view the status of the update.
    /// 
    ///  
    /// <para>
    /// When you execute a change set, CloudFormation deletes all other change sets associated
    /// with the stack because they aren't valid for the updated stack.
    /// </para><para>
    /// If a stack policy is associated with the stack, CloudFormation enforces the policy
    /// during the update. You can't specify a temporary stack policy that overrides the current
    /// policy.
    /// </para><para>
    /// To create a change set for the entire stack hierarchy, <c>IncludeNestedStacks</c>
    /// must have been set to <c>True</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "CFNChangeSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS CloudFormation ExecuteChangeSet API operation.", Operation = new[] {"ExecuteChangeSet"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.ExecuteChangeSetResponse))]
    [AWSCmdletOutput("None or Amazon.CloudFormation.Model.ExecuteChangeSetResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudFormation.Model.ExecuteChangeSetResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCFNChangeSetCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChangeSetName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the change set that you want use to update
        /// the specified stack.</para>
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
        public System.String ChangeSetName { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for this <c>ExecuteChangeSet</c> request. Specify this token if
        /// you plan to retry requests so that CloudFormation knows that you're not attempting
        /// to execute a change set to update a stack with the same name. You might retry <c>ExecuteChangeSet</c>
        /// requests to ensure that CloudFormation successfully received them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter DisableRollback
        /// <summary>
        /// <para>
        /// <para>Preserves the state of previously provisioned resources when an operation fails. This
        /// parameter can't be specified when the <c>OnStackFailure</c> parameter to the <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_CreateChangeSet.html">CreateChangeSet</a>
        /// API operation was specified.</para><ul><li><para><c>True</c> - if the stack creation fails, do nothing. This is equivalent to specifying
        /// <c>DO_NOTHING</c> for the <c>OnStackFailure</c> parameter to the <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_CreateChangeSet.html">CreateChangeSet</a>
        /// API operation.</para></li><li><para><c>False</c> - if the stack creation fails, roll back the stack. This is equivalent
        /// to specifying <c>ROLLBACK</c> for the <c>OnStackFailure</c> parameter to the <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_CreateChangeSet.html">CreateChangeSet</a>
        /// API operation.</para></li></ul><para>Default: <c>True</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DisableRollback { get; set; }
        #endregion
        
        #region Parameter RetainExceptOnCreate
        /// <summary>
        /// <para>
        /// <para>When set to <c>true</c>, newly created resources are deleted when the operation rolls
        /// back. This includes newly created resources marked with a deletion policy of <c>Retain</c>.</para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RetainExceptOnCreate { get; set; }
        #endregion
        
        #region Parameter StackName
        /// <summary>
        /// <para>
        /// <para>If you specified the name of a change set, specify the stack name or Amazon Resource
        /// Name (ARN) that's associated with the change set you want to execute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String StackName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.ExecuteChangeSetResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ChangeSetName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ChangeSetName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ChangeSetName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChangeSetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CFNChangeSet (ExecuteChangeSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.ExecuteChangeSetResponse, StartCFNChangeSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ChangeSetName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ChangeSetName = this.ChangeSetName;
            #if MODULAR
            if (this.ChangeSetName == null && ParameterWasBound(nameof(this.ChangeSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.DisableRollback = this.DisableRollback;
            context.RetainExceptOnCreate = this.RetainExceptOnCreate;
            context.StackName = this.StackName;
            
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
            var request = new Amazon.CloudFormation.Model.ExecuteChangeSetRequest();
            
            if (cmdletContext.ChangeSetName != null)
            {
                request.ChangeSetName = cmdletContext.ChangeSetName;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.DisableRollback != null)
            {
                request.DisableRollback = cmdletContext.DisableRollback.Value;
            }
            if (cmdletContext.RetainExceptOnCreate != null)
            {
                request.RetainExceptOnCreate = cmdletContext.RetainExceptOnCreate.Value;
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
        
        private Amazon.CloudFormation.Model.ExecuteChangeSetResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.ExecuteChangeSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "ExecuteChangeSet");
            try
            {
                #if DESKTOP
                return client.ExecuteChangeSet(request);
                #elif CORECLR
                return client.ExecuteChangeSetAsync(request).GetAwaiter().GetResult();
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
            public System.String ChangeSetName { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.Boolean? DisableRollback { get; set; }
            public System.Boolean? RetainExceptOnCreate { get; set; }
            public System.String StackName { get; set; }
            public System.Func<Amazon.CloudFormation.Model.ExecuteChangeSetResponse, StartCFNChangeSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
