/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Returns the requested sending authorization policies for the given identity (an email
    /// address or a domain). The policies are returned as a map of policy names to policy
    /// contents. You can retrieve a maximum of 20 policies at a time.
    /// 
    ///  <note><para>
    /// This API is for the identity owner only. If you have not verified the identity, this
    /// API will return an error.
    /// </para></note><para>
    /// Sending authorization is a feature that enables an identity owner to authorize other
    /// senders to use its identities. For information about using sending authorization,
    /// see the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/sending-authorization.html">Amazon
    /// SES Developer Guide</a>.
    /// </para><para>
    /// You can execute this operation no more than once per second.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SESIdentityPolicy")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the GetIdentityPolicies operation against Amazon Simple Email Service.", Operation = new[] {"GetIdentityPolicies"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.SimpleEmail.Model.GetIdentityPoliciesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSESIdentityPolicyCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Identity
        /// <summary>
        /// <para>
        /// <para>The identity for which the policies will be retrieved. You can specify an identity
        /// by using its name or by using its Amazon Resource Name (ARN). Examples: <code>user@example.com</code>,
        /// <code>example.com</code>, <code>arn:aws:ses:us-east-1:123456789012:identity/example.com</code>.</para><para>To successfully call this API, you must own the identity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Identity { get; set; }
        #endregion
        
        #region Parameter PolicyName
        /// <summary>
        /// <para>
        /// <para>A list of the names of policies to be retrieved. You can retrieve a maximum of 20
        /// policies at a time. If you do not know the names of the policies that are attached
        /// to the identity, you can use <code>ListIdentityPolicies</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("PolicyNames")]
        public System.String[] PolicyName { get; set; }
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
            
            context.Identity = this.Identity;
            if (this.PolicyName != null)
            {
                context.PolicyNames = new List<System.String>(this.PolicyName);
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
            // create request
            var request = new Amazon.SimpleEmail.Model.GetIdentityPoliciesRequest();
            
            if (cmdletContext.Identity != null)
            {
                request.Identity = cmdletContext.Identity;
            }
            if (cmdletContext.PolicyNames != null)
            {
                request.PolicyNames = cmdletContext.PolicyNames;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Policies;
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
        
        private Amazon.SimpleEmail.Model.GetIdentityPoliciesResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.GetIdentityPoliciesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service", "GetIdentityPolicies");
            try
            {
                #if DESKTOP
                return client.GetIdentityPolicies(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetIdentityPoliciesAsync(request);
                return task.Result;
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
            public System.String Identity { get; set; }
            public List<System.String> PolicyNames { get; set; }
        }
        
    }
}
