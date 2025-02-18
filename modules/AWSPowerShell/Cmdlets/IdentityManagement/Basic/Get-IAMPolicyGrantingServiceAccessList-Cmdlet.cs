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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Retrieves a list of policies that the IAM identity (user, group, or role) can use
    /// to access each specified service.
    /// 
    ///  <note><para>
    /// This operation does not use other policy types when determining whether a resource
    /// could access a service. These other policy types include resource-based policies,
    /// access control lists, Organizations policies, IAM permissions boundaries, and STS
    /// assume role policies. It only applies permissions policy logic. For more about the
    /// evaluation of policy types, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies_evaluation-logic.html#policy-eval-basics">Evaluating
    /// policies</a> in the <i>IAM User Guide</i>.
    /// </para></note><para>
    /// The list of policies returned by the operation depends on the ARN of the identity
    /// that you provide.
    /// </para><ul><li><para><b>User</b> – The list of policies includes the managed and inline policies that
    /// are attached to the user directly. The list also includes any additional managed and
    /// inline policies that are attached to the group to which the user belongs. 
    /// </para></li><li><para><b>Group</b> – The list of policies includes only the managed and inline policies
    /// that are attached to the group directly. Policies that are attached to the group’s
    /// user are not included.
    /// </para></li><li><para><b>Role</b> – The list of policies includes only the managed and inline policies
    /// that are attached to the role.
    /// </para></li></ul><para>
    /// For each managed policy, this operation returns the ARN and policy name. For each
    /// inline policy, it returns the policy name and the entity to which it is attached.
    /// Inline policies do not have an ARN. For more information about these policy types,
    /// see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies_managed-vs-inline.html">Managed
    /// policies and inline policies</a> in the <i>IAM User Guide</i>.
    /// </para><para>
    /// Policies that are attached to users and roles as permissions boundaries are not returned.
    /// To view which managed policy is currently used to set the permissions boundary for
    /// a user or role, use the <a>GetUser</a> or <a>GetRole</a> operations.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "IAMPolicyGrantingServiceAccessList")]
    [OutputType("Amazon.IdentityManagement.Model.ListPoliciesGrantingServiceAccessEntry")]
    [AWSCmdlet("Calls the AWS Identity and Access Management ListPoliciesGrantingServiceAccess API operation.", Operation = new[] {"ListPoliciesGrantingServiceAccess"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.ListPoliciesGrantingServiceAccessResponse))]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.ListPoliciesGrantingServiceAccessEntry or Amazon.IdentityManagement.Model.ListPoliciesGrantingServiceAccessResponse",
        "This cmdlet returns a collection of Amazon.IdentityManagement.Model.ListPoliciesGrantingServiceAccessEntry objects.",
        "The service call response (type Amazon.IdentityManagement.Model.ListPoliciesGrantingServiceAccessResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIAMPolicyGrantingServiceAccessListCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM identity (user, group, or role) whose policies you want to list.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter ServiceNamespace
        /// <summary>
        /// <para>
        /// <para>The service namespace for the Amazon Web Services services whose policies you want
        /// to list.</para><para>To learn the service namespace for a service, see <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/reference_policies_actions-resources-contextkeys.html">Actions,
        /// resources, and condition keys for Amazon Web Services services</a> in the <i>IAM User
        /// Guide</i>. Choose the name of the service to view details for that service. In the
        /// first paragraph, find the service prefix. For example, <c>(service prefix: a4b)</c>.
        /// For more information about service namespaces, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#genref-aws-service-namespaces">Amazon
        /// Web Services service namespaces</a> in the <i>Amazon Web Services General Reference</i>.</para>
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
        [Alias("ServiceNamespaces")]
        public System.String[] ServiceNamespace { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Use this parameter only when paginating results and only after you receive a response
        /// indicating that the results are truncated. Set it to the value of the <c>Marker</c>
        /// element in the response that you received to indicate where the next call should start.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PoliciesGrantingServiceAccess'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.ListPoliciesGrantingServiceAccessResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.ListPoliciesGrantingServiceAccessResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PoliciesGrantingServiceAccess";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.ListPoliciesGrantingServiceAccessResponse, GetIAMPolicyGrantingServiceAccessListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Marker = this.Marker;
            if (this.ServiceNamespace != null)
            {
                context.ServiceNamespace = new List<System.String>(this.ServiceNamespace);
            }
            #if MODULAR
            if (this.ServiceNamespace == null && ParameterWasBound(nameof(this.ServiceNamespace)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceNamespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.IdentityManagement.Model.ListPoliciesGrantingServiceAccessRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.ServiceNamespace != null)
            {
                request.ServiceNamespaces = cmdletContext.ServiceNamespace;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.Marker;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.IdentityManagement.Model.ListPoliciesGrantingServiceAccessResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.ListPoliciesGrantingServiceAccessRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "ListPoliciesGrantingServiceAccess");
            try
            {
                return client.ListPoliciesGrantingServiceAccessAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Marker { get; set; }
            public List<System.String> ServiceNamespace { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.ListPoliciesGrantingServiceAccessResponse, GetIAMPolicyGrantingServiceAccessListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PoliciesGrantingServiceAccess;
        }
        
    }
}
