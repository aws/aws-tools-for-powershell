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
using Amazon.Route53Domains;
using Amazon.Route53Domains.Model;

namespace Amazon.PowerShell.Cmdlets.R53D
{
    /// <summary>
    /// Creates a delegation signer (DS) record in the registry zone for this domain name.
    /// 
    ///  
    /// <para>
    /// Note that creating DS record at the registry impacts DNSSEC validation of your DNS
    /// records. This action may render your domain name unavailable on the internet if the
    /// steps are completed in the wrong order, or with incorrect timing. For more information
    /// about DNSSEC signing, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/dns-configuring-dnssec.html">Configuring
    /// DNSSEC signing</a> in the <i>Route 53 developer guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "R53DDelegationSignerToDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Route 53 Domains AssociateDelegationSignerToDomain API operation.", Operation = new[] {"AssociateDelegationSignerToDomain"}, SelectReturnType = typeof(Amazon.Route53Domains.Model.AssociateDelegationSignerToDomainResponse))]
    [AWSCmdletOutput("System.String or Amazon.Route53Domains.Model.AssociateDelegationSignerToDomainResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Route53Domains.Model.AssociateDelegationSignerToDomainResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AddR53DDelegationSignerToDomainCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SigningAttributes_Algorithm
        /// <summary>
        /// <para>
        /// <para> Algorithm which was used to generate the digest from the public key. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SigningAttributes_Algorithm { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter SigningAttributes_Flag
        /// <summary>
        /// <para>
        /// <para>Defines the type of key. It can be either a KSK (key-signing-key, value 257) or ZSK
        /// (zone-signing-key, value 256). Using KSK is always encouraged. Only use ZSK if your
        /// DNS provider isn't Route 53 and you don’t have KSK available.</para><para>If you have KSK and ZSK keys, always use KSK to create a delegations signer (DS) record.
        /// If you have ZSK keys only – use ZSK to create a DS record.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SigningAttributes_Flags")]
        public System.Int32? SigningAttributes_Flag { get; set; }
        #endregion
        
        #region Parameter SigningAttributes_PublicKey
        /// <summary>
        /// <para>
        /// <para> The base64-encoded public key part of the key pair that is passed to the registry.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SigningAttributes_PublicKey { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OperationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Domains.Model.AssociateDelegationSignerToDomainResponse).
        /// Specifying the name of a property of type Amazon.Route53Domains.Model.AssociateDelegationSignerToDomainResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OperationId";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-R53DDelegationSignerToDomain (AssociateDelegationSignerToDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Domains.Model.AssociateDelegationSignerToDomainResponse, AddR53DDelegationSignerToDomainCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SigningAttributes_Algorithm = this.SigningAttributes_Algorithm;
            context.SigningAttributes_Flag = this.SigningAttributes_Flag;
            context.SigningAttributes_PublicKey = this.SigningAttributes_PublicKey;
            
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
            var request = new Amazon.Route53Domains.Model.AssociateDelegationSignerToDomainRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate SigningAttributes
            var requestSigningAttributesIsNull = true;
            request.SigningAttributes = new Amazon.Route53Domains.Model.DnssecSigningAttributes();
            System.Int32? requestSigningAttributes_signingAttributes_Algorithm = null;
            if (cmdletContext.SigningAttributes_Algorithm != null)
            {
                requestSigningAttributes_signingAttributes_Algorithm = cmdletContext.SigningAttributes_Algorithm.Value;
            }
            if (requestSigningAttributes_signingAttributes_Algorithm != null)
            {
                request.SigningAttributes.Algorithm = requestSigningAttributes_signingAttributes_Algorithm.Value;
                requestSigningAttributesIsNull = false;
            }
            System.Int32? requestSigningAttributes_signingAttributes_Flag = null;
            if (cmdletContext.SigningAttributes_Flag != null)
            {
                requestSigningAttributes_signingAttributes_Flag = cmdletContext.SigningAttributes_Flag.Value;
            }
            if (requestSigningAttributes_signingAttributes_Flag != null)
            {
                request.SigningAttributes.Flags = requestSigningAttributes_signingAttributes_Flag.Value;
                requestSigningAttributesIsNull = false;
            }
            System.String requestSigningAttributes_signingAttributes_PublicKey = null;
            if (cmdletContext.SigningAttributes_PublicKey != null)
            {
                requestSigningAttributes_signingAttributes_PublicKey = cmdletContext.SigningAttributes_PublicKey;
            }
            if (requestSigningAttributes_signingAttributes_PublicKey != null)
            {
                request.SigningAttributes.PublicKey = requestSigningAttributes_signingAttributes_PublicKey;
                requestSigningAttributesIsNull = false;
            }
             // determine if request.SigningAttributes should be set to null
            if (requestSigningAttributesIsNull)
            {
                request.SigningAttributes = null;
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
        
        private Amazon.Route53Domains.Model.AssociateDelegationSignerToDomainResponse CallAWSServiceOperation(IAmazonRoute53Domains client, Amazon.Route53Domains.Model.AssociateDelegationSignerToDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Domains", "AssociateDelegationSignerToDomain");
            try
            {
                #if DESKTOP
                return client.AssociateDelegationSignerToDomain(request);
                #elif CORECLR
                return client.AssociateDelegationSignerToDomainAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainName { get; set; }
            public System.Int32? SigningAttributes_Algorithm { get; set; }
            public System.Int32? SigningAttributes_Flag { get; set; }
            public System.String SigningAttributes_PublicKey { get; set; }
            public System.Func<Amazon.Route53Domains.Model.AssociateDelegationSignerToDomainResponse, AddR53DDelegationSignerToDomainCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationId;
        }
        
    }
}
