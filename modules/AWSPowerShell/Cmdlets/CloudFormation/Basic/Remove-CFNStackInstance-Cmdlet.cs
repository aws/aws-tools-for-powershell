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
using System.Threading;
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Deletes stack instances for the specified accounts, in the specified Amazon Web Services
    /// Regions.
    /// 
    ///  <note><para>
    /// The maximum number of organizational unit (OUs) supported by a <c>DeleteStackInstances</c>
    /// operation is 50.
    /// </para><para>
    /// If you need more than 50, consider the following options:
    /// </para><ul><li><para><i>Batch processing:</i> If you don't want to expose your OU hierarchy, split up
    /// the operations into multiple calls with less than 50 OUs each.
    /// </para></li><li><para><i>Parent OU strategy:</i> If you don't mind exposing the OU hierarchy, target a
    /// parent OU that contains all desired child OUs.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Remove", "CFNStackInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation DeleteStackInstances API operation.", Operation = new[] {"DeleteStackInstances"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.DeleteStackInstancesResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudFormation.Model.DeleteStackInstancesResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudFormation.Model.DeleteStackInstancesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveCFNStackInstanceCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeploymentTargets_AccountFilterType
        /// <summary>
        /// <para>
        /// <para>Refines which accounts will have stack operations performed on them by specifying
        /// how to use the <c>Accounts</c> and <c>OrganizationalUnitIds</c> properties together.</para><para>The following values determine how CloudFormation selects target accounts:</para><ul><li><para><c>INTERSECTION</c>: Performs stack operations only on specific individual accounts
        /// within the selected OUs. Only accounts that are both specified in the <c>Accounts</c>
        /// property and belong to the specified OUs will be targeted.</para></li><li><para><c>DIFFERENCE</c>: Performs stack operations on all accounts in the selected OUs
        /// except for specific accounts listed in the <c>Accounts</c> property. This enables
        /// you to exclude certain accounts within an OU, such as suspended accounts.</para></li><li><para><c>UNION</c>: Performs stack operations on the specified OUs plus additional individual
        /// accounts listed in the <c>Accounts</c> property. This is the default value if <c>AccountFilterType</c>
        /// is not provided. This lets you target an entire OU and individual accounts from a
        /// different OU in one request. Note that <c>UNION</c> is not supported for <c>CreateStackInstances</c>
        /// operations.</para></li><li><para><c>NONE</c>: Performs stack operations on all accounts in the specified organizational
        /// units (OUs).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.AccountFilterType")]
        public Amazon.CloudFormation.AccountFilterType DeploymentTargets_AccountFilterType { get; set; }
        #endregion
        
        #region Parameter Account
        /// <summary>
        /// <para>
        /// <para>[Self-managed permissions] The account IDs of the Amazon Web Services accounts that
        /// you want to delete stack instances for.</para><para>You can specify <c>Accounts</c> or <c>DeploymentTargets</c>, but not both.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Accounts")]
        public System.String[] Account { get; set; }
        #endregion
        
        #region Parameter DeploymentTargets_Account
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account IDs where you want to perform stack operations. How
        /// these accounts are used depends on the <c>AccountFilterType</c> property.</para><para>If you have many account numbers, you can provide those accounts using the <c>AccountsUrl</c>
        /// property instead.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentTargets_Accounts")]
        public System.String[] DeploymentTargets_Account { get; set; }
        #endregion
        
        #region Parameter DeploymentTargets_AccountsUrl
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URL path to a file that contains a list of Amazon Web Services account
        /// IDs. The file format must be either <c>.csv</c> or <c>.txt</c>, and the data can be
        /// comma-separated or new-line-separated. There is currently a 10MB limit for the data
        /// (approximately 800,000 accounts).</para><para>This property serves the same purpose as <c>Accounts</c> but allows you to specify
        /// a large number of accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeploymentTargets_AccountsUrl { get; set; }
        #endregion
        
        #region Parameter CallAs
        /// <summary>
        /// <para>
        /// <para>[Service-managed permissions] Specifies whether you are acting as an account administrator
        /// in the organization's management account or as a delegated administrator in a member
        /// account.</para><para>By default, <c>SELF</c> is specified. Use <c>SELF</c> for StackSets with self-managed
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
        /// <para>The unique identifier for this StackSet operation.</para><para>If you don't specify an operation ID, the SDK generates one automatically.</para><para>The operation ID also functions as an idempotency token, to ensure that CloudFormation
        /// performs the StackSet operation only once, even if you retry the request multiple
        /// times. You can retry StackSet operation requests to ensure that CloudFormation successfully
        /// received them.</para><para>Repeating this StackSet operation with a new operation ID retries all stack instances
        /// whose status is <c>OUTDATED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperationId { get; set; }
        #endregion
        
        #region Parameter OperationPreference
        /// <summary>
        /// <para>
        /// <para>Preferences for how CloudFormation performs this StackSet operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OperationPreferences")]
        public Amazon.CloudFormation.Model.StackSetOperationPreferences OperationPreference { get; set; }
        #endregion
        
        #region Parameter DeploymentTargets_OrganizationalUnitId
        /// <summary>
        /// <para>
        /// <para>The organization root ID or organizational unit (OU) IDs where you want to perform
        /// stack operations. CloudFormation will perform operations on accounts within these
        /// OUs and their child OUs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentTargets_OrganizationalUnitIds")]
        public System.String[] DeploymentTargets_OrganizationalUnitId { get; set; }
        #endregion
        
        #region Parameter StackInstanceRegion
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Regions where you want to delete StackSet instances.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String[] StackInstanceRegion { get; set; }
        #endregion
        
        #region Parameter RetainStack
        /// <summary>
        /// <para>
        /// <para>Removes the stack instances from the specified StackSet, but doesn't delete the stacks.
        /// You can't reassociate a retained stack or add an existing, saved stack to a new stack
        /// set.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-concepts.html#stackset-ops-options">StackSet
        /// operation options</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("RetainStacks")]
        public System.Boolean? RetainStack { get; set; }
        #endregion
        
        #region Parameter StackSetName
        /// <summary>
        /// <para>
        /// <para>The name or unique ID of the StackSet that you want to delete stack instances for.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.DeleteStackInstancesResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.DeleteStackInstancesResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StackSetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CFNStackInstance (DeleteStackInstances)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.DeleteStackInstancesResponse, RemoveCFNStackInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Account != null)
            {
                context.Account = new List<System.String>(this.Account);
            }
            context.CallAs = this.CallAs;
            context.DeploymentTargets_AccountFilterType = this.DeploymentTargets_AccountFilterType;
            if (this.DeploymentTargets_Account != null)
            {
                context.DeploymentTargets_Account = new List<System.String>(this.DeploymentTargets_Account);
            }
            context.DeploymentTargets_AccountsUrl = this.DeploymentTargets_AccountsUrl;
            if (this.DeploymentTargets_OrganizationalUnitId != null)
            {
                context.DeploymentTargets_OrganizationalUnitId = new List<System.String>(this.DeploymentTargets_OrganizationalUnitId);
            }
            context.OperationId = this.OperationId;
            context.OperationPreference = this.OperationPreference;
            if (this.StackInstanceRegion != null)
            {
                context.StackInstanceRegion = new List<System.String>(this.StackInstanceRegion);
            }
            #if MODULAR
            if (this.StackInstanceRegion == null && ParameterWasBound(nameof(this.StackInstanceRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter StackInstanceRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RetainStack = this.RetainStack;
            #if MODULAR
            if (this.RetainStack == null && ParameterWasBound(nameof(this.RetainStack)))
            {
                WriteWarning("You are passing $null as a value for parameter RetainStack which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.CloudFormation.Model.DeleteStackInstancesRequest();
            
            if (cmdletContext.Account != null)
            {
                request.Accounts = cmdletContext.Account;
            }
            if (cmdletContext.CallAs != null)
            {
                request.CallAs = cmdletContext.CallAs;
            }
            
             // populate DeploymentTargets
            var requestDeploymentTargetsIsNull = true;
            request.DeploymentTargets = new Amazon.CloudFormation.Model.DeploymentTargets();
            Amazon.CloudFormation.AccountFilterType requestDeploymentTargets_deploymentTargets_AccountFilterType = null;
            if (cmdletContext.DeploymentTargets_AccountFilterType != null)
            {
                requestDeploymentTargets_deploymentTargets_AccountFilterType = cmdletContext.DeploymentTargets_AccountFilterType;
            }
            if (requestDeploymentTargets_deploymentTargets_AccountFilterType != null)
            {
                request.DeploymentTargets.AccountFilterType = requestDeploymentTargets_deploymentTargets_AccountFilterType;
                requestDeploymentTargetsIsNull = false;
            }
            List<System.String> requestDeploymentTargets_deploymentTargets_Account = null;
            if (cmdletContext.DeploymentTargets_Account != null)
            {
                requestDeploymentTargets_deploymentTargets_Account = cmdletContext.DeploymentTargets_Account;
            }
            if (requestDeploymentTargets_deploymentTargets_Account != null)
            {
                request.DeploymentTargets.Accounts = requestDeploymentTargets_deploymentTargets_Account;
                requestDeploymentTargetsIsNull = false;
            }
            System.String requestDeploymentTargets_deploymentTargets_AccountsUrl = null;
            if (cmdletContext.DeploymentTargets_AccountsUrl != null)
            {
                requestDeploymentTargets_deploymentTargets_AccountsUrl = cmdletContext.DeploymentTargets_AccountsUrl;
            }
            if (requestDeploymentTargets_deploymentTargets_AccountsUrl != null)
            {
                request.DeploymentTargets.AccountsUrl = requestDeploymentTargets_deploymentTargets_AccountsUrl;
                requestDeploymentTargetsIsNull = false;
            }
            List<System.String> requestDeploymentTargets_deploymentTargets_OrganizationalUnitId = null;
            if (cmdletContext.DeploymentTargets_OrganizationalUnitId != null)
            {
                requestDeploymentTargets_deploymentTargets_OrganizationalUnitId = cmdletContext.DeploymentTargets_OrganizationalUnitId;
            }
            if (requestDeploymentTargets_deploymentTargets_OrganizationalUnitId != null)
            {
                request.DeploymentTargets.OrganizationalUnitIds = requestDeploymentTargets_deploymentTargets_OrganizationalUnitId;
                requestDeploymentTargetsIsNull = false;
            }
             // determine if request.DeploymentTargets should be set to null
            if (requestDeploymentTargetsIsNull)
            {
                request.DeploymentTargets = null;
            }
            if (cmdletContext.OperationId != null)
            {
                request.OperationId = cmdletContext.OperationId;
            }
            if (cmdletContext.OperationPreference != null)
            {
                request.OperationPreferences = cmdletContext.OperationPreference;
            }
            if (cmdletContext.StackInstanceRegion != null)
            {
                request.Regions = cmdletContext.StackInstanceRegion;
            }
            if (cmdletContext.RetainStack != null)
            {
                request.RetainStacks = cmdletContext.RetainStack.Value;
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
        
        private Amazon.CloudFormation.Model.DeleteStackInstancesResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.DeleteStackInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "DeleteStackInstances");
            try
            {
                return client.DeleteStackInstancesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Account { get; set; }
            public Amazon.CloudFormation.CallAs CallAs { get; set; }
            public Amazon.CloudFormation.AccountFilterType DeploymentTargets_AccountFilterType { get; set; }
            public List<System.String> DeploymentTargets_Account { get; set; }
            public System.String DeploymentTargets_AccountsUrl { get; set; }
            public List<System.String> DeploymentTargets_OrganizationalUnitId { get; set; }
            public System.String OperationId { get; set; }
            public Amazon.CloudFormation.Model.StackSetOperationPreferences OperationPreference { get; set; }
            public List<System.String> StackInstanceRegion { get; set; }
            public System.Boolean? RetainStack { get; set; }
            public System.String StackSetName { get; set; }
            public System.Func<Amazon.CloudFormation.Model.DeleteStackInstancesResponse, RemoveCFNStackInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationId;
        }
        
    }
}
