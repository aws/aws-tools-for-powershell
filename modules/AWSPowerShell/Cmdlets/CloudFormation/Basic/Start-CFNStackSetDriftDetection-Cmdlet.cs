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
    /// Detect drift on a stack set. When CloudFormation performs drift detection on a stack
    /// set, it performs drift detection on the stack associated with each stack instance
    /// in the stack set. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-drift.html">How
    /// CloudFormation performs drift detection on a stack set</a>.
    /// 
    ///  
    /// <para><c>DetectStackSetDrift</c> returns the <c>OperationId</c> of the stack set drift
    /// detection operation. Use this operation id with <a>DescribeStackSetOperation</a> to
    /// monitor the progress of the drift detection operation. The drift detection operation
    /// may take some time, depending on the number of stack instances included in the stack
    /// set, in addition to the number of resources included in each stack.
    /// </para><para>
    /// Once the operation has completed, use the following actions to return drift information:
    /// </para><ul><li><para>
    /// Use <a>DescribeStackSet</a> to return detailed information about the stack set, including
    /// detailed information about the last <i>completed</i> drift operation performed on
    /// the stack set. (Information about drift operations that are in progress isn't included.)
    /// </para></li><li><para>
    /// Use <a>ListStackInstances</a> to return a list of stack instances belonging to the
    /// stack set, including the drift status and last drift time checked of each instance.
    /// </para></li><li><para>
    /// Use <a>DescribeStackInstance</a> to return detailed information about a specific stack
    /// instance, including its drift status and last drift time checked.
    /// </para></li></ul><para>
    /// For more information about performing a drift detection operation on a stack set,
    /// see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-drift.html">Detecting
    /// unmanaged changes in stack sets</a>.
    /// </para><para>
    /// You can only run a single drift detection operation on a given stack set at one time.
    /// </para><para>
    /// To stop a drift detection stack set operation, use <a>StopStackSetOperation</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "CFNStackSetDriftDetection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation DetectStackSetDrift API operation.", Operation = new[] {"DetectStackSetDrift"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.DetectStackSetDriftResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudFormation.Model.DetectStackSetDriftResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudFormation.Model.DetectStackSetDriftResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartCFNStackSetDriftDetectionCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CallAs
        /// <summary>
        /// <para>
        /// <para>[Service-managed permissions] Specifies whether you are acting as an account administrator
        /// in the organization's management account or as a delegated administrator in a member
        /// account.</para><para>By default, <c>SELF</c> is specified. Use <c>SELF</c> for stack sets with self-managed
        /// permissions.</para><ul><li><para>If you are signed in to the management account, specify <c>SELF</c>.</para></li><li><para>If you are signed in to a delegated administrator account, specify <c>DELEGATED_ADMIN</c>.</para><para>Your Amazon Web Services account must be registered as a delegated administrator in
        /// the management account. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-orgs-delegated-admin.html">Register
        /// a delegated administrator</a> in the <i>CloudFormation User Guide</i>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.CallAs")]
        public Amazon.CloudFormation.CallAs CallAs { get; set; }
        #endregion
        
        #region Parameter OperationId
        /// <summary>
        /// <para>
        /// <para><i>The ID of the stack set operation.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperationId { get; set; }
        #endregion
        
        #region Parameter OperationPreference
        /// <summary>
        /// <para>
        /// <para>The user-specified preferences for how CloudFormation performs a stack set operation.</para><para>For more information about maximum concurrent accounts and failure tolerance, see
        /// <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/what-is-cfnstacksets.html#stackset-ops-options">Stack
        /// set operation options</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OperationPreferences")]
        public Amazon.CloudFormation.Model.StackSetOperationPreferences OperationPreference { get; set; }
        #endregion
        
        #region Parameter StackSetName
        /// <summary>
        /// <para>
        /// <para>The name of the stack set on which to perform the drift detection operation.</para>
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
        public System.String StackSetName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OperationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.DetectStackSetDriftResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.DetectStackSetDriftResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OperationId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StackSetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CFNStackSetDriftDetection (DetectStackSetDrift)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.DetectStackSetDriftResponse, StartCFNStackSetDriftDetectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CallAs = this.CallAs;
            context.OperationId = this.OperationId;
            context.OperationPreference = this.OperationPreference;
            context.StackSetName = this.StackSetName;
            #if MODULAR
            if (this.StackSetName == null && ParameterWasBound(nameof(this.StackSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter StackSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudFormation.Model.DetectStackSetDriftRequest();
            
            if (cmdletContext.CallAs != null)
            {
                request.CallAs = cmdletContext.CallAs;
            }
            if (cmdletContext.OperationId != null)
            {
                request.OperationId = cmdletContext.OperationId;
            }
            if (cmdletContext.OperationPreference != null)
            {
                request.OperationPreferences = cmdletContext.OperationPreference;
            }
            if (cmdletContext.StackSetName != null)
            {
                request.StackSetName = cmdletContext.StackSetName;
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
        
        private Amazon.CloudFormation.Model.DetectStackSetDriftResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.DetectStackSetDriftRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "DetectStackSetDrift");
            try
            {
                #if DESKTOP
                return client.DetectStackSetDrift(request);
                #elif CORECLR
                return client.DetectStackSetDriftAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CloudFormation.CallAs CallAs { get; set; }
            public System.String OperationId { get; set; }
            public Amazon.CloudFormation.Model.StackSetOperationPreferences OperationPreference { get; set; }
            public System.String StackSetName { get; set; }
            public System.Func<Amazon.CloudFormation.Model.DetectStackSetDriftResponse, StartCFNStackSetDriftDetectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationId;
        }
        
    }
}
