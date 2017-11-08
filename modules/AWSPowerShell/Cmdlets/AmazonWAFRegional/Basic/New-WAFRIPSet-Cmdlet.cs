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
using Amazon.WAFRegional;
using Amazon.WAFRegional.Model;

namespace Amazon.PowerShell.Cmdlets.WAFR
{
    /// <summary>
    /// Creates an <a>IPSet</a>, which you use to specify which web requests you want to allow
    /// or block based on the IP addresses that the requests originate from. For example,
    /// if you're receiving a lot of requests from one or more individual IP addresses or
    /// one or more ranges of IP addresses and you want to block the requests, you can create
    /// an <code>IPSet</code> that contains those IP addresses and then configure AWS WAF
    /// to block the requests. 
    /// 
    ///  
    /// <para>
    /// To create and configure an <code>IPSet</code>, perform the following steps:
    /// </para><ol><li><para>
    /// Use <a>GetChangeToken</a> to get the change token that you provide in the <code>ChangeToken</code>
    /// parameter of a <code>CreateIPSet</code> request.
    /// </para></li><li><para>
    /// Submit a <code>CreateIPSet</code> request.
    /// </para></li><li><para>
    /// Use <code>GetChangeToken</code> to get the change token that you provide in the <code>ChangeToken</code>
    /// parameter of an <a>UpdateIPSet</a> request.
    /// </para></li><li><para>
    /// Submit an <code>UpdateIPSet</code> request to specify the IP addresses that you want
    /// AWS WAF to watch for.
    /// </para></li></ol><para>
    /// For more information about how to use the AWS WAF API to allow or block HTTP requests,
    /// see the <a href="http://docs.aws.amazon.com/waf/latest/developerguide/">AWS WAF Developer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "WAFRIPSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WAFRegional.Model.CreateIPSetResponse")]
    [AWSCmdlet("Calls the AWS WAF Regional CreateIPSet API operation.", Operation = new[] {"CreateIPSet"})]
    [AWSCmdletOutput("Amazon.WAFRegional.Model.CreateIPSetResponse",
        "This cmdlet returns a Amazon.WAFRegional.Model.CreateIPSetResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewWAFRIPSetCmdlet : AmazonWAFRegionalClientCmdlet, IExecutor
    {
        
        #region Parameter ChangeToken
        /// <summary>
        /// <para>
        /// <para>The value returned by the most recent call to <a>GetChangeToken</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ChangeToken { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A friendly name or description of the <a>IPSet</a>. You can't change <code>Name</code>
        /// after you create the <code>IPSet</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WAFRIPSet (CreateIPSet)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ChangeToken = this.ChangeToken;
            context.Name = this.Name;
            
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
            var request = new Amazon.WAFRegional.Model.CreateIPSetRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.WAFRegional.Model.CreateIPSetResponse CallAWSServiceOperation(IAmazonWAFRegional client, Amazon.WAFRegional.Model.CreateIPSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF Regional", "CreateIPSet");
            try
            {
                #if DESKTOP
                return client.CreateIPSet(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateIPSetAsync(request);
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
            public System.String ChangeToken { get; set; }
            public System.String Name { get; set; }
        }
        
    }
}
