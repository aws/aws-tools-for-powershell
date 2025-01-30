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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Returns the current status of Easy DKIM signing for an entity. For domain name identities,
    /// this operation also returns the DKIM tokens that are required for Easy DKIM signing,
    /// and whether Amazon SES has successfully verified that these tokens have been published.
    /// 
    ///  
    /// <para>
    /// This operation takes a list of identities as input and returns the following information
    /// for each:
    /// </para><ul><li><para>
    /// Whether Easy DKIM signing is enabled or disabled.
    /// </para></li><li><para>
    /// A set of DKIM tokens that represent the identity. If the identity is an email address,
    /// the tokens represent the domain of that address.
    /// </para></li><li><para>
    /// Whether Amazon SES has successfully verified the DKIM tokens published in the domain's
    /// DNS. This information is only returned for domain name identities, not for email addresses.
    /// </para></li></ul><para>
    /// This operation is throttled at one request per second and can only get DKIM attributes
    /// for up to 100 identities at a time.
    /// </para><para>
    /// For more information about creating DNS records using DKIM tokens, go to the <a href="https://docs.aws.amazon.com/ses/latest/dg/send-email-authentication-dkim-easy-managing.html">Amazon
    /// SES Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SESIdentityDkimAttribute")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Email Service (SES) GetIdentityDkimAttributes API operation.", Operation = new[] {"GetIdentityDkimAttributes"}, SelectReturnType = typeof(Amazon.SimpleEmail.Model.GetIdentityDkimAttributesResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleEmail.Model.GetIdentityDkimAttributesResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.SimpleEmail.Model.GetIdentityDkimAttributesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSESIdentityDkimAttributeCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Identity
        /// <summary>
        /// <para>
        /// <para>A list of one or more verified identities - email addresses, domains, or both.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DkimAttributes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmail.Model.GetIdentityDkimAttributesResponse).
        /// Specifying the name of a property of type Amazon.SimpleEmail.Model.GetIdentityDkimAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DkimAttributes";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Identity parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Identity' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Identity' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmail.Model.GetIdentityDkimAttributesResponse, GetSESIdentityDkimAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Identity;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            var request = new Amazon.SimpleEmail.Model.GetIdentityDkimAttributesRequest();
            
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
        
        private Amazon.SimpleEmail.Model.GetIdentityDkimAttributesResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.GetIdentityDkimAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service (SES)", "GetIdentityDkimAttributes");
            try
            {
                #if DESKTOP
                return client.GetIdentityDkimAttributes(request);
                #elif CORECLR
                return client.GetIdentityDkimAttributesAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SimpleEmail.Model.GetIdentityDkimAttributesResponse, GetSESIdentityDkimAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DkimAttributes;
        }
        
    }
}
