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
    /// Updates the parameter values for stack instances for the specified accounts, within
    /// the specified Amazon Web Services Regions. A stack instance refers to a stack in a
    /// specific account and Region.
    /// 
    ///  
    /// <para>
    /// You can only update stack instances in Amazon Web Services Regions and accounts where
    /// they already exist; to create additional stack instances, use <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_CreateStackInstances.html">CreateStackInstances</a>.
    /// </para><para>
    /// During stack set updates, any parameters overridden for a stack instance aren't updated,
    /// but retain their overridden value.
    /// </para><para>
    /// You can only update the parameter <i>values</i> that are specified in the stack set;
    /// to add or delete a parameter itself, use <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_UpdateStackSet.html">UpdateStackSet</a>
    /// to update the stack set template. If you add a parameter to a template, before you
    /// can override the parameter value specified in the stack set you must first use <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_UpdateStackSet.html">UpdateStackSet</a>
    /// to update all stack instances with the updated template and parameter value specified
    /// in the stack set. Once a stack instance has been updated with the new parameter, you
    /// can then override the parameter value using <c>UpdateStackInstances</c>.
    /// </para><note><para>
    /// The maximum number of organizational unit (OUs) supported by a <c>UpdateStackInstances</c>
    /// operation is 50.
    /// </para><para>
    /// If you need more than 50, consider the following options:
    /// </para><ul><li><para><i>Batch processing:</i> If you don't want to expose your OU hierarchy, split up
    /// the operations into multiple calls with less than 50 OUs each.
    /// </para></li><li><para><i>Parent OU strategy:</i> If you don't mind exposing the OU hierarchy, target a
    /// parent OU that contains all desired child OUs.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Update", "CFNStackInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation UpdateStackInstances API operation.", Operation = new[] {"UpdateStackInstances"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.UpdateStackInstancesResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudFormation.Model.UpdateStackInstancesResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudFormation.Model.UpdateStackInstancesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCFNStackInstanceCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeploymentTargets_AccountFilterType
        /// <summary>
        /// <para>
        /// <para>Limit deployment targets to individual accounts or include additional accounts with
        /// provided OUs.</para><para>The following is a list of possible values for the <c>AccountFilterType</c> operation.</para><ul><li><para><c>INTERSECTION</c>: StackSets deploys to the accounts specified in <c>Accounts</c>
        /// parameter. </para></li><li><para><c>DIFFERENCE</c>: StackSets excludes the accounts specified in <c>Accounts</c> parameter.
        /// This enables user to avoid certain accounts within an OU such as suspended accounts.</para></li><li><para><c>UNION</c>: StackSets includes additional accounts deployment targets. </para><para>This is the default value if <c>AccountFilterType</c> is not provided. This enables
        /// user to update an entire OU and individual accounts from a different OU in one request,
        /// which used to be two separate requests.</para></li><li><para><c>NONE</c>: Deploys to all the accounts in specified organizational units (OU).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.AccountFilterType")]
        public Amazon.CloudFormation.AccountFilterType DeploymentTargets_AccountFilterType { get; set; }
        #endregion
        
        #region Parameter Account
        /// <summary>
        /// <para>
        /// <para>[Self-managed permissions] The account IDs of one or more Amazon Web Services accounts
        /// for which you want to update parameter values for stack instances. The overridden
        /// parameter values will be applied to all stack instances in the specified accounts
        /// and Amazon Web Services Regions.</para><para>You can specify <c>Accounts</c> or <c>DeploymentTargets</c>, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Accounts")]
        public System.String[] Account { get; set; }
        #endregion
        
        #region Parameter DeploymentTargets_Account
        /// <summary>
        /// <para>
        /// <para>The account IDs of the Amazon Web Services accounts. If you have many account numbers,
        /// you can provide those accounts using the <c>AccountsUrl</c> property instead.</para>
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
        /// (approximately 800,000 accounts).</para>
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
        /// <para>The unique identifier for this stack set operation.</para><para>The operation ID also functions as an idempotency token, to ensure that CloudFormation
        /// performs the stack set operation only once, even if you retry the request multiple
        /// times. You might retry stack set operation requests to ensure that CloudFormation
        /// successfully received them.</para><para>If you don't specify an operation ID, the SDK generates one automatically.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperationId { get; set; }
        #endregion
        
        #region Parameter OperationPreference
        /// <summary>
        /// <para>
        /// <para>Preferences for how CloudFormation performs this stack set operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OperationPreferences")]
        public Amazon.CloudFormation.Model.StackSetOperationPreferences OperationPreference { get; set; }
        #endregion
        
        #region Parameter DeploymentTargets_OrganizationalUnitId
        /// <summary>
        /// <para>
        /// <para>The organization root ID or organizational unit (OU) IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentTargets_OrganizationalUnitIds")]
        public System.String[] DeploymentTargets_OrganizationalUnitId { get; set; }
        #endregion
        
        #region Parameter ParameterOverride
        /// <summary>
        /// <para>
        /// <para>A list of input parameters whose values you want to update for the specified stack
        /// instances.</para><para>Any overridden parameter values will be applied to all stack instances in the specified
        /// accounts and Amazon Web Services Regions. When specifying parameters and their values,
        /// be aware of how CloudFormation sets parameter values during stack instance update
        /// operations:</para><ul><li><para>To override the current value for a parameter, include the parameter and specify its
        /// value.</para></li><li><para>To leave an overridden parameter set to its present value, include the parameter and
        /// specify <c>UsePreviousValue</c> as <c>true</c>. (You can't specify both a value and
        /// set <c>UsePreviousValue</c> to <c>true</c>.)</para></li><li><para>To set an overridden parameter back to the value specified in the stack set, specify
        /// a parameter list but don't include the parameter in the list.</para></li><li><para>To leave all parameters set to their present values, don't specify this property at
        /// all.</para></li></ul><para>During stack set updates, any parameter values overridden for a stack instance aren't
        /// updated, but retain their overridden value.</para><para>You can only override the parameter <i>values</i> that are specified in the stack
        /// set; to add or delete a parameter itself, use <c>UpdateStackSet</c> to update the
        /// stack set template. If you add a parameter to a template, before you can override
        /// the parameter value specified in the stack set you must first use <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_UpdateStackSet.html">UpdateStackSet</a>
        /// to update all stack instances with the updated template and parameter value specified
        /// in the stack set. Once a stack instance has been updated with the new parameter, you
        /// can then override the parameter value using <c>UpdateStackInstances</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ParameterOverrides")]
        public Amazon.CloudFormation.Model.Parameter[] ParameterOverride { get; set; }
        #endregion
        
        #region Parameter StackInstanceRegion
        /// <summary>
        /// <para>
        /// <para>The names of one or more Amazon Web Services Regions in which you want to update parameter
        /// values for stack instances. The overridden parameter values will be applied to all
        /// stack instances in the specified accounts and Amazon Web Services Regions.</para>
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
        
        #region Parameter StackSetName
        /// <summary>
        /// <para>
        /// <para>The name or unique ID of the stack set associated with the stack instances.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.UpdateStackInstancesResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.UpdateStackInstancesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OperationId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StackSetName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StackSetName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StackSetName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StackSetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFNStackInstance (UpdateStackInstances)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.UpdateStackInstancesResponse, UpdateCFNStackInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StackSetName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            if (this.ParameterOverride != null)
            {
                context.ParameterOverride = new List<Amazon.CloudFormation.Model.Parameter>(this.ParameterOverride);
            }
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
            var request = new Amazon.CloudFormation.Model.UpdateStackInstancesRequest();
            
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
            if (cmdletContext.ParameterOverride != null)
            {
                request.ParameterOverrides = cmdletContext.ParameterOverride;
            }
            if (cmdletContext.StackInstanceRegion != null)
            {
                request.Regions = cmdletContext.StackInstanceRegion;
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
        
        private Amazon.CloudFormation.Model.UpdateStackInstancesResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.UpdateStackInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "UpdateStackInstances");
            try
            {
                #if DESKTOP
                return client.UpdateStackInstances(request);
                #elif CORECLR
                return client.UpdateStackInstancesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Account { get; set; }
            public Amazon.CloudFormation.CallAs CallAs { get; set; }
            public Amazon.CloudFormation.AccountFilterType DeploymentTargets_AccountFilterType { get; set; }
            public List<System.String> DeploymentTargets_Account { get; set; }
            public System.String DeploymentTargets_AccountsUrl { get; set; }
            public List<System.String> DeploymentTargets_OrganizationalUnitId { get; set; }
            public System.String OperationId { get; set; }
            public Amazon.CloudFormation.Model.StackSetOperationPreferences OperationPreference { get; set; }
            public List<Amazon.CloudFormation.Model.Parameter> ParameterOverride { get; set; }
            public List<System.String> StackInstanceRegion { get; set; }
            public System.String StackSetName { get; set; }
            public System.Func<Amazon.CloudFormation.Model.UpdateStackInstancesResponse, UpdateCFNStackInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationId;
        }
        
    }
}
