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
using Amazon.WAF;
using Amazon.WAF.Model;

namespace Amazon.PowerShell.Cmdlets.WAF
{
    /// <summary>
    /// Inserts or deletes <a>IPSetDescriptor</a> objects in an <code>IPSet</code>. For each
    /// <code>IPSetDescriptor</code> object, you specify the following values: 
    /// 
    ///  <ul><li><para>
    /// Whether to insert or delete the object from the array. If you want to change an <code>IPSetDescriptor</code>
    /// object, you delete the existing object and add a new one.
    /// </para></li><li><para>
    /// The IP address version, <code>IPv4</code> or <code>IPv6</code>. 
    /// </para></li><li><para>
    /// The IP address in CIDR notation, for example, <code>192.0.2.0/24</code> (for the range
    /// of IP addresses from <code>192.0.2.0</code> to <code>192.0.2.255</code>) or <code>192.0.2.44/32</code>
    /// (for the individual IP address <code>192.0.2.44</code>). 
    /// </para></li></ul><para>
    /// AWS WAF supports /8, /16, /24, and /32 IP address ranges for IPv4, and /24, /32, /48,
    /// /56, /64 and /128 for IPv6. For more information about CIDR notation, see the Wikipedia
    /// entry <a href="https://en.wikipedia.org/wiki/Classless_Inter-Domain_Routing">Classless
    /// Inter-Domain Routing</a>.
    /// </para><para>
    /// IPv6 addresses can be represented using any of the following formats:
    /// </para><ul><li><para>
    /// 1111:0000:0000:0000:0000:0000:0000:0111/128
    /// </para></li><li><para>
    /// 1111:0:0:0:0:0:0:0111/128
    /// </para></li><li><para>
    /// 1111::0111/128
    /// </para></li><li><para>
    /// 1111::111/128
    /// </para></li></ul><para>
    /// You use an <code>IPSet</code> to specify which web requests you want to allow or block
    /// based on the IP addresses that the requests originated from. For example, if you're
    /// receiving a lot of requests from one or a small number of IP addresses and you want
    /// to block the requests, you can create an <code>IPSet</code> that specifies those IP
    /// addresses, and then configure AWS WAF to block the requests. 
    /// </para><para>
    /// To create and configure an <code>IPSet</code>, perform the following steps:
    /// </para><ol><li><para>
    /// Submit a <a>CreateIPSet</a> request.
    /// </para></li><li><para>
    /// Use <a>GetChangeToken</a> to get the change token that you provide in the <code>ChangeToken</code>
    /// parameter of an <a>UpdateIPSet</a> request.
    /// </para></li><li><para>
    /// Submit an <code>UpdateIPSet</code> request to specify the IP addresses that you want
    /// AWS WAF to watch for.
    /// </para></li></ol><para>
    /// When you update an <code>IPSet</code>, you specify the IP addresses that you want
    /// to add and/or the IP addresses that you want to delete. If you want to change an IP
    /// address, you delete the existing IP address and add the new one.
    /// </para><para>
    /// For more information about how to use the AWS WAF API to allow or block HTTP requests,
    /// see the <a href="http://docs.aws.amazon.com/waf/latest/developerguide/">AWS WAF Developer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "WAFIPSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the UpdateIPSet operation against AWS WAF.", Operation = new[] {"UpdateIPSet"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.WAF.Model.UpdateIPSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateWAFIPSetCmdlet : AmazonWAFClientCmdlet, IExecutor
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
        
        #region Parameter IPSetId
        /// <summary>
        /// <para>
        /// <para>The <code>IPSetId</code> of the <a>IPSet</a> that you want to update. <code>IPSetId</code>
        /// is returned by <a>CreateIPSet</a> and by <a>ListIPSets</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String IPSetId { get; set; }
        #endregion
        
        #region Parameter Update
        /// <summary>
        /// <para>
        /// <para>An array of <code>IPSetUpdate</code> objects that you want to insert into or delete
        /// from an <a>IPSet</a>. For more information, see the applicable data types:</para><ul><li><para><a>IPSetUpdate</a>: Contains <code>Action</code> and <code>IPSetDescriptor</code></para></li><li><para><a>IPSetDescriptor</a>: Contains <code>Type</code> and <code>Value</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Updates")]
        public Amazon.WAF.Model.IPSetUpdate[] Update { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("IPSetId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAFIPSet (UpdateIPSet)"))
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
            context.IPSetId = this.IPSetId;
            if (this.Update != null)
            {
                context.Updates = new List<Amazon.WAF.Model.IPSetUpdate>(this.Update);
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
            var request = new Amazon.WAF.Model.UpdateIPSetRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            if (cmdletContext.IPSetId != null)
            {
                request.IPSetId = cmdletContext.IPSetId;
            }
            if (cmdletContext.Updates != null)
            {
                request.Updates = cmdletContext.Updates;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ChangeToken;
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
        
        private Amazon.WAF.Model.UpdateIPSetResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.UpdateIPSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF", "UpdateIPSet");
            #if DESKTOP
            return client.UpdateIPSet(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateIPSetAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ChangeToken { get; set; }
            public System.String IPSetId { get; set; }
            public List<Amazon.WAF.Model.IPSetUpdate> Updates { get; set; }
        }
        
    }
}
