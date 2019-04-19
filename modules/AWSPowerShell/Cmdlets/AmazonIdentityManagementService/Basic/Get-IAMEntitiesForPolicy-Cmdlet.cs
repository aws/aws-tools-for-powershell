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
    /// Lists all IAM users, groups, and roles that the specified managed policy is attached
    /// to.
    /// 
    ///  
    /// <para>
    /// You can use the optional <code>EntityFilter</code> parameter to limit the results
    /// to a particular type of entity (users, groups, or roles). For example, to list only
    /// the roles that are attached to the specified policy, set <code>EntityFilter</code>
    /// to <code>Role</code>.
    /// </para><para>
    /// You can paginate the results using the <code>MaxItems</code> and <code>Marker</code>
    /// parameters.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IAMEntitiesForPolicy")]
    [OutputType("Amazon.IdentityManagement.Model.ListEntitiesForPolicyResponse")]
    [AWSCmdlet("Calls the AWS Identity and Access Management ListEntitiesForPolicy API operation.", Operation = new[] {"ListEntitiesForPolicy"})]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.ListEntitiesForPolicyResponse",
        "This cmdlet returns a Amazon.IdentityManagement.Model.ListEntitiesForPolicyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetIAMEntitiesForPolicyCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter EntityFilter
        /// <summary>
        /// <para>
        /// <para>The entity type to use for filtering the results.</para><para>For example, when <code>EntityFilter</code> is <code>Role</code>, only the roles that
        /// are attached to the specified policy are returned. This parameter is optional. If
        /// it is not included, all attached entities (users, groups, and roles) are returned.
        /// The argument for this parameter must be one of the valid values listed below.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.IdentityManagement.EntityType")]
        public Amazon.IdentityManagement.EntityType EntityFilter { get; set; }
        #endregion
        
        #region Parameter PathPrefix
        /// <summary>
        /// <para>
        /// <para>The path prefix for filtering the results. This parameter is optional. If it is not
        /// included, it defaults to a slash (/), listing all entities.</para><para>This parameter allows (through its <a href="http://wikipedia.org/wiki/regex">regex
        /// pattern</a>) a string of characters consisting of either a forward slash (/) by itself
        /// or a string that must begin and end with forward slashes. In addition, it can contain
        /// any ASCII character from the ! (\u0021) through the DEL character (\u007F), including
        /// most punctuation characters, digits, and upper and lowercased letters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PathPrefix { get; set; }
        #endregion
        
        #region Parameter PolicyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM policy for which you want the versions.</para><para>For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and AWS Service Namespaces</a> in the <i>AWS General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String PolicyArn { get; set; }
        #endregion
        
        #region Parameter PolicyUsageFilter
        /// <summary>
        /// <para>
        /// <para>The policy usage method to use for filtering the results.</para><para>To list only permissions policies, set <code>PolicyUsageFilter</code> to <code>PermissionsPolicy</code>.
        /// To list only the policies used to set permissions boundaries, set the value to <code>PermissionsBoundary</code>.</para><para>This parameter is optional. If it is not included, all policies are returned. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.IdentityManagement.PolicyUsageType")]
        public Amazon.IdentityManagement.PolicyUsageType PolicyUsageFilter { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Use this parameter only when paginating results and only after you receive a response
        /// indicating that the results are truncated. Set it to the value of the <code>Marker</code>
        /// element in the response that you received to indicate where the next call should start.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>Use this only when paginating results to indicate the maximum number of items you
        /// want in the response. If additional items exist beyond the maximum you specify, the
        /// <code>IsTruncated</code> response element is <code>true</code>.</para><para>If you do not include this parameter, the number of items defaults to 100. Note that
        /// IAM might return fewer results, even when there are more results available. In that
        /// case, the <code>IsTruncated</code> response element returns <code>true</code>, and
        /// <code>Marker</code> contains a value to include in the subsequent call that tells
        /// the service where to continue from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public System.Int32 MaxItem { get; set; }
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
            
            context.EntityFilter = this.EntityFilter;
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxItem"))
                context.MaxItems = this.MaxItem;
            context.PathPrefix = this.PathPrefix;
            context.PolicyArn = this.PolicyArn;
            context.PolicyUsageFilter = this.PolicyUsageFilter;
            
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
            var request = new Amazon.IdentityManagement.Model.ListEntitiesForPolicyRequest();
            
            if (cmdletContext.EntityFilter != null)
            {
                request.EntityFilter = cmdletContext.EntityFilter;
            }
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxItems != null)
            {
                request.MaxItems = cmdletContext.MaxItems.Value;
            }
            if (cmdletContext.PathPrefix != null)
            {
                request.PathPrefix = cmdletContext.PathPrefix;
            }
            if (cmdletContext.PolicyArn != null)
            {
                request.PolicyArn = cmdletContext.PolicyArn;
            }
            if (cmdletContext.PolicyUsageFilter != null)
            {
                request.PolicyUsageFilter = cmdletContext.PolicyUsageFilter;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.IdentityManagement.Model.ListEntitiesForPolicyResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.ListEntitiesForPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "ListEntitiesForPolicy");
            try
            {
                #if DESKTOP
                return client.ListEntitiesForPolicy(request);
                #elif CORECLR
                return client.ListEntitiesForPolicyAsync(request).GetAwaiter().GetResult();
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
            public Amazon.IdentityManagement.EntityType EntityFilter { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? MaxItems { get; set; }
            public System.String PathPrefix { get; set; }
            public System.String PolicyArn { get; set; }
            public Amazon.IdentityManagement.PolicyUsageType PolicyUsageFilter { get; set; }
        }
        
    }
}
