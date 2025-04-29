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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Creates a new IP address filter.
    /// 
    ///  
    /// <para>
    /// For information about setting up IP address filters, see the <a href="https://docs.aws.amazon.com/ses/latest/dg/receiving-email-ip-filtering-console-walkthrough.html">Amazon
    /// SES Developer Guide</a>.
    /// </para><para>
    /// You can execute this operation no more than once per second.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SESReceiptFilter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service (SES) CreateReceiptFilter API operation.", Operation = new[] {"CreateReceiptFilter"}, SelectReturnType = typeof(Amazon.SimpleEmail.Model.CreateReceiptFilterResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmail.Model.CreateReceiptFilterResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmail.Model.CreateReceiptFilterResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewSESReceiptFilterCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IpFilter_Cidr
        /// <summary>
        /// <para>
        /// <para>A single IP address or a range of IP addresses to block or allow, specified in Classless
        /// Inter-Domain Routing (CIDR) notation. An example of a single email address is 10.0.0.1.
        /// An example of a range of IP addresses is 10.0.0.1/24. For more information about CIDR
        /// notation, see <a href="https://tools.ietf.org/html/rfc2317">RFC 2317</a>.</para>
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
        [Alias("Filter_IpFilter_Cidr")]
        public System.String IpFilter_Cidr { get; set; }
        #endregion
        
        #region Parameter Filter_Name
        /// <summary>
        /// <para>
        /// <para>The name of the IP address filter. The name must meet the following requirements:</para><ul><li><para>Contain only ASCII letters (a-z, A-Z), numbers (0-9), underscores (_), or dashes (-).</para></li><li><para>Start and end with a letter or number.</para></li><li><para>Contain 64 characters or fewer.</para></li></ul>
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
        public System.String Filter_Name { get; set; }
        #endregion
        
        #region Parameter IpFilter_Policy
        /// <summary>
        /// <para>
        /// <para>Indicates whether to block or allow incoming mail from the specified IP addresses.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Filter_IpFilter_Policy")]
        [AWSConstantClassSource("Amazon.SimpleEmail.ReceiptFilterPolicy")]
        public Amazon.SimpleEmail.ReceiptFilterPolicy IpFilter_Policy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmail.Model.CreateReceiptFilterResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Filter_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SESReceiptFilter (CreateReceiptFilter)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmail.Model.CreateReceiptFilterResponse, NewSESReceiptFilterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IpFilter_Cidr = this.IpFilter_Cidr;
            #if MODULAR
            if (this.IpFilter_Cidr == null && ParameterWasBound(nameof(this.IpFilter_Cidr)))
            {
                WriteWarning("You are passing $null as a value for parameter IpFilter_Cidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IpFilter_Policy = this.IpFilter_Policy;
            #if MODULAR
            if (this.IpFilter_Policy == null && ParameterWasBound(nameof(this.IpFilter_Policy)))
            {
                WriteWarning("You are passing $null as a value for parameter IpFilter_Policy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Filter_Name = this.Filter_Name;
            #if MODULAR
            if (this.Filter_Name == null && ParameterWasBound(nameof(this.Filter_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Filter_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleEmail.Model.CreateReceiptFilterRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
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
            var requestFilter_filter_IpFilterIsNull = true;
            requestFilter_filter_IpFilter = new Amazon.SimpleEmail.Model.ReceiptIpFilter();
            System.String requestFilter_filter_IpFilter_ipFilter_Cidr = null;
            if (cmdletContext.IpFilter_Cidr != null)
            {
                requestFilter_filter_IpFilter_ipFilter_Cidr = cmdletContext.IpFilter_Cidr;
            }
            if (requestFilter_filter_IpFilter_ipFilter_Cidr != null)
            {
                requestFilter_filter_IpFilter.Cidr = requestFilter_filter_IpFilter_ipFilter_Cidr;
                requestFilter_filter_IpFilterIsNull = false;
            }
            Amazon.SimpleEmail.ReceiptFilterPolicy requestFilter_filter_IpFilter_ipFilter_Policy = null;
            if (cmdletContext.IpFilter_Policy != null)
            {
                requestFilter_filter_IpFilter_ipFilter_Policy = cmdletContext.IpFilter_Policy;
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
        
        private Amazon.SimpleEmail.Model.CreateReceiptFilterResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.CreateReceiptFilterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service (SES)", "CreateReceiptFilter");
            try
            {
                return client.CreateReceiptFilterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IpFilter_Cidr { get; set; }
            public Amazon.SimpleEmail.ReceiptFilterPolicy IpFilter_Policy { get; set; }
            public System.String Filter_Name { get; set; }
            public System.Func<Amazon.SimpleEmail.Model.CreateReceiptFilterResponse, NewSESReceiptFilterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
