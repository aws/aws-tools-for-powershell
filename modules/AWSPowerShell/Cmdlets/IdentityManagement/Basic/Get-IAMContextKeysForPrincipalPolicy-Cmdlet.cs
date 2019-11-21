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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Gets a list of all of the context keys referenced in all the IAM policies that are
    /// attached to the specified IAM entity. The entity can be an IAM user, group, or role.
    /// If you specify a user, then the request also includes all of the policies attached
    /// to groups that the user is a member of.
    /// 
    ///  
    /// <para>
    /// You can optionally include a list of one or more additional policies, specified as
    /// strings. If you want to include <i>only</i> a list of policies by string, use <a>GetContextKeysForCustomPolicy</a>
    /// instead.
    /// </para><para><b>Note:</b> This API discloses information about the permissions granted to other
    /// users. If you do not want users to see other user's permissions, then consider allowing
    /// them to use <a>GetContextKeysForCustomPolicy</a> instead.
    /// </para><para>
    /// Context keys are variables maintained by AWS and its services that provide details
    /// about the context of an API query request. Context keys can be evaluated by testing
    /// against a value in an IAM policy. Use <a>GetContextKeysForPrincipalPolicy</a> to understand
    /// what key names and values you must supply when you call <a>SimulatePrincipalPolicy</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IAMContextKeysForPrincipalPolicy")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Identity and Access Management GetContextKeysForPrincipalPolicy API operation.", Operation = new[] {"GetContextKeysForPrincipalPolicy"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.GetContextKeysForPrincipalPolicyResponse))]
    [AWSCmdletOutput("System.String or Amazon.IdentityManagement.Model.GetContextKeysForPrincipalPolicyResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.IdentityManagement.Model.GetContextKeysForPrincipalPolicyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetIAMContextKeysForPrincipalPolicyCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter PolicyInputList
        /// <summary>
        /// <para>
        /// <para>An optional list of additional policies for which you want the list of context keys
        /// that are referenced.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> used to validate this
        /// parameter is a string of characters consisting of the following:</para><ul><li><para>Any printable ASCII character ranging from the space character (\u0020) through the
        /// end of the ASCII character range</para></li><li><para>The printable characters in the Basic Latin and Latin-1 Supplement character set (through
        /// \u00FF)</para></li><li><para>The special characters tab (\u0009), line feed (\u000A), and carriage return (\u000D)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PolicyInputList { get; set; }
        #endregion
        
        #region Parameter PolicySourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of a user, group, or role whose policies contain the context keys that you
        /// want listed. If you specify a user, the list includes context keys that are found
        /// in all policies that are attached to the user. The list also includes all groups that
        /// the user is a member of. If you pick a group or a role, then it includes only those
        /// context keys that are found in policies attached to that entity. Note that all parameters
        /// are shown in unencoded form here for clarity, but must be URL encoded to be included
        /// as a part of a real HTML request.</para><para>For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and AWS Service Namespaces</a> in the <i>AWS General Reference</i>.</para>
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
        public System.String PolicySourceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContextKeyNames'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.GetContextKeysForPrincipalPolicyResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.GetContextKeysForPrincipalPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContextKeyNames";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.GetContextKeysForPrincipalPolicyResponse, GetIAMContextKeysForPrincipalPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.PolicyInputList != null)
            {
                context.PolicyInputList = new List<System.String>(this.PolicyInputList);
            }
            context.PolicySourceArn = this.PolicySourceArn;
            #if MODULAR
            if (this.PolicySourceArn == null && ParameterWasBound(nameof(this.PolicySourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicySourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IdentityManagement.Model.GetContextKeysForPrincipalPolicyRequest();
            
            if (cmdletContext.PolicyInputList != null)
            {
                request.PolicyInputList = cmdletContext.PolicyInputList;
            }
            if (cmdletContext.PolicySourceArn != null)
            {
                request.PolicySourceArn = cmdletContext.PolicySourceArn;
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
        
        private Amazon.IdentityManagement.Model.GetContextKeysForPrincipalPolicyResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.GetContextKeysForPrincipalPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "GetContextKeysForPrincipalPolicy");
            try
            {
                #if DESKTOP
                return client.GetContextKeysForPrincipalPolicy(request);
                #elif CORECLR
                return client.GetContextKeysForPrincipalPolicyAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> PolicyInputList { get; set; }
            public System.String PolicySourceArn { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.GetContextKeysForPrincipalPolicyResponse, GetIAMContextKeysForPrincipalPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContextKeyNames;
        }
        
    }
}
