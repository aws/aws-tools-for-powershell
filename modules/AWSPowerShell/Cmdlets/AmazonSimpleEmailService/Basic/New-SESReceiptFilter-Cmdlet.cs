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
    /// Creates a new IP address filter.
    /// 
    ///  
    /// <para>
    /// For information about setting up IP address filters, see the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/receiving-email-ip-filters.html">Amazon
    /// SES Developer Guide</a>.
    /// </para><para>
    /// This action is throttled at one request per second.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SESReceiptFilter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Invokes the CreateReceiptFilter operation against Amazon Simple Email Service.", Operation = new[] {"CreateReceiptFilter"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.SimpleEmail.Model.CreateReceiptFilterResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewSESReceiptFilterCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        #region Parameter IpFilter_Cidr
        /// <summary>
        /// <para>
        /// <para>A single IP address or a range of IP addresses that you want to block or allow, specified
        /// in Classless Inter-Domain Routing (CIDR) notation. An example of a single email address
        /// is 10.0.0.1. An example of a range of IP addresses is 10.0.0.1/24. For more information
        /// about CIDR notation, see <a href="https://tools.ietf.org/html/rfc2317">RFC 2317</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_IpFilter_Cidr")]
        public System.String IpFilter_Cidr { get; set; }
        #endregion
        
        #region Parameter Filter_Name
        /// <summary>
        /// <para>
        /// <para>The name of the IP address filter. The name must:</para><ul><li><para>Contain only ASCII letters (a-z, A-Z), numbers (0-9), periods (.), underscores (_),
        /// or dashes (-).</para></li><li><para>Start and end with a letter or number.</para></li><li><para>Contain less than 64 characters.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Filter_Name { get; set; }
        #endregion
        
        #region Parameter IpFilter_Policy
        /// <summary>
        /// <para>
        /// <para>Indicates whether to block or allow incoming mail from the specified IP addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_IpFilter_Policy")]
        [AWSConstantClassSource("Amazon.SimpleEmail.ReceiptFilterPolicy")]
        public Amazon.SimpleEmail.ReceiptFilterPolicy IpFilter_Policy { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Filter_Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SESReceiptFilter (CreateReceiptFilter)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Filter_IpFilter_Cidr = this.IpFilter_Cidr;
            context.Filter_IpFilter_Policy = this.IpFilter_Policy;
            context.Filter_Name = this.Filter_Name;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.SimpleEmail.Model.CreateReceiptFilterRequest();
            
            
             // populate Filter
            bool requestFilterIsNull = true;
            request.Filter = new Amazon.SimpleEmail.Model.ReceiptFilter();
            System.String requestFilter_filter_Name = null;
            if (cmdletContext.Filter_Name != null)
            {
                requestFilter_filter_Name = cmdletContext.Filter_Name;
            }
            if (requestFilter_filter_Name != null)
            {
                request.Filter.Name = requestFilter_filter_Name;
                requestFilterIsNull = false;
            }
            Amazon.SimpleEmail.Model.ReceiptIpFilter requestFilter_filter_IpFilter = null;
            
             // populate IpFilter
            bool requestFilter_filter_IpFilterIsNull = true;
            requestFilter_filter_IpFilter = new Amazon.SimpleEmail.Model.ReceiptIpFilter();
            System.String requestFilter_filter_IpFilter_ipFilter_Cidr = null;
            if (cmdletContext.Filter_IpFilter_Cidr != null)
            {
                requestFilter_filter_IpFilter_ipFilter_Cidr = cmdletContext.Filter_IpFilter_Cidr;
            }
            if (requestFilter_filter_IpFilter_ipFilter_Cidr != null)
            {
                requestFilter_filter_IpFilter.Cidr = requestFilter_filter_IpFilter_ipFilter_Cidr;
                requestFilter_filter_IpFilterIsNull = false;
            }
            Amazon.SimpleEmail.ReceiptFilterPolicy requestFilter_filter_IpFilter_ipFilter_Policy = null;
            if (cmdletContext.Filter_IpFilter_Policy != null)
            {
                requestFilter_filter_IpFilter_ipFilter_Policy = cmdletContext.Filter_IpFilter_Policy;
            }
            if (requestFilter_filter_IpFilter_ipFilter_Policy != null)
            {
                requestFilter_filter_IpFilter.Policy = requestFilter_filter_IpFilter_ipFilter_Policy;
                requestFilter_filter_IpFilterIsNull = false;
            }
             // determine if requestFilter_filter_IpFilter should be set to null
            if (requestFilter_filter_IpFilterIsNull)
            {
                requestFilter_filter_IpFilter = null;
            }
            if (requestFilter_filter_IpFilter != null)
            {
                request.Filter.IpFilter = requestFilter_filter_IpFilter;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
        
        private static Amazon.SimpleEmail.Model.CreateReceiptFilterResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.CreateReceiptFilterRequest request)
        {
            return client.CreateReceiptFilter(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Filter_IpFilter_Cidr { get; set; }
            public Amazon.SimpleEmail.ReceiptFilterPolicy Filter_IpFilter_Policy { get; set; }
            public System.String Filter_Name { get; set; }
        }
        
    }
}
