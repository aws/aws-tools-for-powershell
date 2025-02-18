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

namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Returns the custom MAIL FROM attributes for a list of identities (email addresses
    /// : domains).
    /// 
    ///  
    /// <para>
    /// This operation is throttled at one request per second and can only get custom MAIL
    /// FROM attributes for up to 100 identities at a time.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SESIdentityMailFromDomainAttribute")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Email Service (SES) GetIdentityMailFromDomainAttributes API operation.", Operation = new[] {"GetIdentityMailFromDomainAttributes"}, SelectReturnType = typeof(Amazon.SimpleEmail.Model.GetIdentityMailFromDomainAttributesResponse), LegacyAlias="Get-SESIdentityMailFromDomainAttributes")]
    [AWSCmdletOutput("System.String or Amazon.SimpleEmail.Model.GetIdentityMailFromDomainAttributesResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.SimpleEmail.Model.GetIdentityMailFromDomainAttributesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSESIdentityMailFromDomainAttributeCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Identity
        /// <summary>
        /// <para>
        /// <para>A list of one or more identities.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Identities")]
        public System.String[] Identity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MailFromDomainAttributes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmail.Model.GetIdentityMailFromDomainAttributesResponse).
        /// Specifying the name of a property of type Amazon.SimpleEmail.Model.GetIdentityMailFromDomainAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MailFromDomainAttributes";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmail.Model.GetIdentityMailFromDomainAttributesResponse, GetSESIdentityMailFromDomainAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Identity != null)
            {
                context.Identity = new List<System.String>(this.Identity);
            }
            #if MODULAR
            if (this.Identity == null && ParameterWasBound(nameof(this.Identity)))
            {
                WriteWarning("You are passing $null as a value for parameter Identity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleEmail.Model.GetIdentityMailFromDomainAttributesRequest();
            
            if (cmdletContext.Identity != null)
            {
                request.Identities = cmdletContext.Identity;
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
        
        private Amazon.SimpleEmail.Model.GetIdentityMailFromDomainAttributesResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.GetIdentityMailFromDomainAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service (SES)", "GetIdentityMailFromDomainAttributes");
            try
            {
                return client.GetIdentityMailFromDomainAttributesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Identity { get; set; }
            public System.Func<Amazon.SimpleEmail.Model.GetIdentityMailFromDomainAttributesResponse, GetSESIdentityMailFromDomainAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MailFromDomainAttributes;
        }
        
    }
}
