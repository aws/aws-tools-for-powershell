/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// access control lists, AWS Organizations policies, IAM permissions boundaries, and
    /// AWS STS assume role policies. It only applies permissions policy logic. For more about
    /// the evaluation of policy types, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies_evaluation-logic.html#policy-eval-basics">Evaluating
    /// Policies</a> in the <i>IAM User Guide</i>.
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
    /// see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies_managed-vs-inline.html">Managed
    /// Policies and Inline Policies</a> in the <i>IAM User Guide</i>.
    /// </para><para>
    /// Policies that are attached to users and roles as permissions boundaries are not returned.
    /// To view which managed policy is currently used to set the permissions boundary for
    /// a user or role, use the <a>GetUser</a> or <a>GetRole</a> operations.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "IAMPolicyGrantingServiceAccessList")]
    [OutputType("Amazon.IdentityManagement.Model.ListPoliciesGrantingServiceAccessEntry")]
    [AWSCmdlet("Calls the AWS Identity and Access Management ListPoliciesGrantingServiceAccess API operation.", Operation = new[] {"ListPoliciesGrantingServiceAccess"})]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.ListPoliciesGrantingServiceAccessEntry",
        "This cmdlet returns a collection of ListPoliciesGrantingServiceAccessEntry objects.",
        "The service call response (type Amazon.IdentityManagement.Model.ListPoliciesGrantingServiceAccessResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: IsTruncated (type System.Boolean), Marker (type System.String)"
    )]
    public partial class GetIAMPolicyGrantingServiceAccessListCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM identity (user, group, or role) whose policies you want to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter ServiceNamespace
        /// <summary>
        /// <para>
        /// <para>The service namespace for the AWS services whose policies you want to list.</para><para>To learn the service namespace for a service, go to <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies_actions-resources-contextkeys.html">Actions,
        /// Resources, and Condition Keys for AWS Services</a> in the <i>IAM User Guide</i>. Choose
        /// the name of the service to view details for that service. In the first paragraph,
        /// find the service prefix. For example, <code>(service prefix: a4b)</code>. For more
        /// information about service namespaces, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#genref-aws-service-namespaces">AWS
        /// Service Namespaces</a> in the <i>AWS General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ServiceNamespaces")]
        public System.String[] ServiceNamespace { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Use this parameter only when paginating results and only after you receive a response
        /// indicating that the results are truncated. Set it to the value of the <code>Marker</code>
        /// element in the response that you received to indicate where the next call should start.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.Marker, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Arn = this.Arn;
            context.Marker = this.Marker;
            if (this.ServiceNamespace != null)
            {
                context.ServiceNamespaces = new List<System.String>(this.ServiceNamespace);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.IdentityManagement.Model.ListPoliciesGrantingServiceAccessRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.ServiceNamespaces != null)
            {
                request.ServiceNamespaces = cmdletContext.ServiceNamespaces;
            }
            
            // Initialize loop variant and commence piping
            System.String _nextMarker = null;
            bool _userControllingPaging = false;
            if (ParameterWasBound("Marker"))
            {
                _nextMarker = cmdletContext.Marker;
                _userControllingPaging = true;
            }
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.PoliciesGrantingServiceAccess;
                        notes = new Dictionary<string, object>();
                        notes["IsTruncated"] = response.IsTruncated;
                        notes["Marker"] = response.Marker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        if (_userControllingPaging)
                        {
                            int _receivedThisCall = response.PoliciesGrantingServiceAccess.Count;
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.Marker;
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                    
                } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextMarker));
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
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
                #if DESKTOP
                return client.ListPoliciesGrantingServiceAccess(request);
                #elif CORECLR
                return client.ListPoliciesGrantingServiceAccessAsync(request).GetAwaiter().GetResult();
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
            public System.String Marker { get; set; }
            public List<System.String> ServiceNamespaces { get; set; }
        }
        
    }
}
