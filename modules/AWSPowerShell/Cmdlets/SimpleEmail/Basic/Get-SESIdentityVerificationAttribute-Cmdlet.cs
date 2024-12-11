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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Given a list of identities (email addresses and/or domains), returns the verification
    /// status and (for domain identities) the verification token for each identity.
    /// 
    ///  
    /// <para>
    /// The verification status of an email address is "Pending" until the email address owner
    /// clicks the link within the verification email that Amazon SES sent to that address.
    /// If the email address owner clicks the link within 24 hours, the verification status
    /// of the email address changes to "Success". If the link is not clicked within 24 hours,
    /// the verification status changes to "Failed." In that case, to verify the email address,
    /// you must restart the verification process from the beginning.
    /// </para><para>
    /// For domain identities, the domain's verification status is "Pending" as Amazon SES
    /// searches for the required TXT record in the DNS settings of the domain. When Amazon
    /// SES detects the record, the domain's verification status changes to "Success". If
    /// Amazon SES is unable to detect the record within 72 hours, the domain's verification
    /// status changes to "Failed." In that case, to verify the domain, you must restart the
    /// verification process from the beginning.
    /// </para><para>
    /// This operation is throttled at one request per second and can only get verification
    /// attributes for up to 100 identities at a time.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SESIdentityVerificationAttribute")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Email Service (SES) GetIdentityVerificationAttributes API operation.", Operation = new[] {"GetIdentityVerificationAttributes"}, SelectReturnType = typeof(Amazon.SimpleEmail.Model.GetIdentityVerificationAttributesResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleEmail.Model.GetIdentityVerificationAttributesResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.SimpleEmail.Model.GetIdentityVerificationAttributesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSESIdentityVerificationAttributeCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Identity
        /// <summary>
        /// <para>
        /// <para>A list of identities.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VerificationAttributes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmail.Model.GetIdentityVerificationAttributesResponse).
        /// Specifying the name of a property of type Amazon.SimpleEmail.Model.GetIdentityVerificationAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VerificationAttributes";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmail.Model.GetIdentityVerificationAttributesResponse, GetSESIdentityVerificationAttributeCmdlet>(Select) ??
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
            var request = new Amazon.SimpleEmail.Model.GetIdentityVerificationAttributesRequest();
            
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
        
        private Amazon.SimpleEmail.Model.GetIdentityVerificationAttributesResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.GetIdentityVerificationAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service (SES)", "GetIdentityVerificationAttributes");
            try
            {
                #if DESKTOP
                return client.GetIdentityVerificationAttributes(request);
                #elif CORECLR
                return client.GetIdentityVerificationAttributesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Identity { get; set; }
            public System.Func<Amazon.SimpleEmail.Model.GetIdentityVerificationAttributesResponse, GetSESIdentityVerificationAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VerificationAttributes;
        }
        
    }
}
