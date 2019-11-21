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
using Amazon.WAF;
using Amazon.WAF.Model;

namespace Amazon.PowerShell.Cmdlets.WAF
{
    /// <summary>
    /// When you want to create, update, or delete AWS WAF objects, get a change token and
    /// include the change token in the create, update, or delete request. Change tokens ensure
    /// that your application doesn't submit conflicting requests to AWS WAF.
    /// 
    ///  
    /// <para>
    /// Each create, update, or delete request must use a unique change token. If your application
    /// submits a <code>GetChangeToken</code> request and then submits a second <code>GetChangeToken</code>
    /// request before submitting a create, update, or delete request, the second <code>GetChangeToken</code>
    /// request returns the same value as the first <code>GetChangeToken</code> request.
    /// </para><para>
    /// When you use a change token in a create, update, or delete request, the status of
    /// the change token changes to <code>PENDING</code>, which indicates that AWS WAF is
    /// propagating the change to all AWS WAF servers. Use <code>GetChangeTokenStatus</code>
    /// to determine the status of your change token.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "WAFChangeToken")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF GetChangeToken API operation.", Operation = new[] {"GetChangeToken"}, SelectReturnType = typeof(Amazon.WAF.Model.GetChangeTokenResponse))]
    [AWSCmdletOutput("System.String or Amazon.WAF.Model.GetChangeTokenResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WAF.Model.GetChangeTokenResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetWAFChangeTokenCmdlet : AmazonWAFClientCmdlet, IExecutor
    {
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChangeToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAF.Model.GetChangeTokenResponse).
        /// Specifying the name of a property of type Amazon.WAF.Model.GetChangeTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChangeToken";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAF.Model.GetChangeTokenResponse, GetWAFChangeTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.WAF.Model.GetChangeTokenRequest();
            
            
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
        
        private Amazon.WAF.Model.GetChangeTokenResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.GetChangeTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF", "GetChangeToken");
            try
            {
                #if DESKTOP
                return client.GetChangeToken(request);
                #elif CORECLR
                return client.GetChangeTokenAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.WAF.Model.GetChangeTokenResponse, GetWAFChangeTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChangeToken;
        }
        
    }
}
