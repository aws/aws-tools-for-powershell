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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Checks whether a Lightsail subdomain is available to create. Optionally, reserves
    /// the subdomain for your account for 15 minutes.
    /// 
    ///  
    /// <para>
    /// If you don't reserve the subdomain, another account can create it before you do.
    /// </para>
    /// </summary>
    [Cmdlet("Test", "LSSubdomainAvailability")]
    [OutputType("Amazon.Lightsail.Model.CheckSubdomainAvailabilityResponse")]
    [AWSCmdlet("Calls the Amazon Lightsail CheckSubdomainAvailability API operation.", Operation = new[] {"CheckSubdomainAvailability"}, SelectReturnType = typeof(Amazon.Lightsail.Model.CheckSubdomainAvailabilityResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.CheckSubdomainAvailabilityResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.CheckSubdomainAvailabilityResponse object containing multiple properties."
    )]
    public partial class TestLSSubdomainAvailabilityCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Reserve
        /// <summary>
        /// <para>
        /// <para>Specifies whether to reserve the subdomain for your account if it's available. A reservation
        /// holds the subdomain for 15 minutes so that other accounts can't create it. Checking
        /// the subdomain again doesn't extend the reservation.</para><para>For a nested subdomain, such as <c>blog.mysite</c>, the top-level subdomain (<c>mysite</c>)
        /// is reserved.</para><para>You can have up to 5 active reservations at a time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Reserve { get; set; }
        #endregion
        
        #region Parameter SubdomainName
        /// <summary>
        /// <para>
        /// <para>The subdomain to check (for example, <c>mysite</c> or <c>blog.mysite</c>).</para><para>A subdomain can contain one or two labels separated by a period (<c>.</c>). Each label
        /// must start and end with a lowercase letter or a number, and can contain only lowercase
        /// letters, numbers, and hyphens (<c>-</c>). The name can be up to 39 characters long,
        /// including periods. Labels that start with <c>xn--</c> aren't supported, and some names
        /// are reserved.</para><para>Specify only the subdomain. A web address, such as <c>mysite.amazonlightsail.com</c>,
        /// isn't accepted.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SubdomainName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.CheckSubdomainAvailabilityResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.CheckSubdomainAvailabilityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.CheckSubdomainAvailabilityResponse, TestLSSubdomainAvailabilityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Reserve = this.Reserve;
            context.SubdomainName = this.SubdomainName;
            #if MODULAR
            if (this.SubdomainName == null && ParameterWasBound(nameof(this.SubdomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter SubdomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lightsail.Model.CheckSubdomainAvailabilityRequest();
            
            if (cmdletContext.Reserve != null)
            {
                request.Reserve = cmdletContext.Reserve.Value;
            }
            if (cmdletContext.SubdomainName != null)
            {
                request.SubdomainName = cmdletContext.SubdomainName;
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
        
        private Amazon.Lightsail.Model.CheckSubdomainAvailabilityResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CheckSubdomainAvailabilityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CheckSubdomainAvailability");
            try
            {
                return client.CheckSubdomainAvailabilityAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? Reserve { get; set; }
            public System.String SubdomainName { get; set; }
            public System.Func<Amazon.Lightsail.Model.CheckSubdomainAvailabilityResponse, TestLSSubdomainAvailabilityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
