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
using Amazon.CertificateManager;
using Amazon.CertificateManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ACM
{
    /// <summary>
    /// Creates a domain validation for an ACME endpoint. Domain validations authorize the
    /// endpoint to issue certificates for specified domain names. You configure prevalidation
    /// to prove domain ownership.
    /// </summary>
    [Cmdlet("New", "ACMAcmeDomainValidation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Certificate Manager CreateAcmeDomainValidation API operation.", Operation = new[] {"CreateAcmeDomainValidation"}, SelectReturnType = typeof(Amazon.CertificateManager.Model.CreateAcmeDomainValidationResponse))]
    [AWSCmdletOutput("System.String or Amazon.CertificateManager.Model.CreateAcmeDomainValidationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CertificateManager.Model.CreateAcmeDomainValidationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewACMAcmeDomainValidationCmdlet : AmazonCertificateManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AcmeEndpointArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the ACME endpoint.</para>
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
        public System.String AcmeEndpointArn { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The domain name to validate.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter PrevalidationOptions_DnsPrevalidation_DomainScope_ExactDomain
        /// <summary>
        /// <para>
        /// <para>Whether validation applies to the exact domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CertificateManager.DomainScopeOption")]
        public Amazon.CertificateManager.DomainScopeOption PrevalidationOptions_DnsPrevalidation_DomainScope_ExactDomain { get; set; }
        #endregion
        
        #region Parameter PrevalidationOptions_DnsPrevalidation_HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The Route 53 hosted zone ID for DNS validation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrevalidationOptions_DnsPrevalidation_HostedZoneId { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter PrevalidationOptions_DnsPrevalidation_DomainScope_Subdomain
        /// <summary>
        /// <para>
        /// <para>Whether validation applies to subdomains.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrevalidationOptions_DnsPrevalidation_DomainScope_Subdomains")]
        [AWSConstantClassSource("Amazon.CertificateManager.DomainScopeOption")]
        public Amazon.CertificateManager.DomainScopeOption PrevalidationOptions_DnsPrevalidation_DomainScope_Subdomain { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags to associate with the domain validation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CertificateManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter PrevalidationOptions_DnsPrevalidation_DomainScope_Wildcard
        /// <summary>
        /// <para>
        /// <para>Whether validation applies to wildcard domains.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrevalidationOptions_DnsPrevalidation_DomainScope_Wildcards")]
        [AWSConstantClassSource("Amazon.CertificateManager.DomainScopeOption")]
        public Amazon.CertificateManager.DomainScopeOption PrevalidationOptions_DnsPrevalidation_DomainScope_Wildcard { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AcmeDomainValidationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CertificateManager.Model.CreateAcmeDomainValidationResponse).
        /// Specifying the name of a property of type Amazon.CertificateManager.Model.CreateAcmeDomainValidationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AcmeDomainValidationArn";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.DomainName),
                nameof(this.AcmeEndpointArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ACMAcmeDomainValidation (CreateAcmeDomainValidation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CertificateManager.Model.CreateAcmeDomainValidationResponse, NewACMAcmeDomainValidationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcmeEndpointArn = this.AcmeEndpointArn;
            #if MODULAR
            if (this.AcmeEndpointArn == null && ParameterWasBound(nameof(this.AcmeEndpointArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AcmeEndpointArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdempotencyToken = this.IdempotencyToken;
            context.PrevalidationOptions_DnsPrevalidation_DomainScope_ExactDomain = this.PrevalidationOptions_DnsPrevalidation_DomainScope_ExactDomain;
            context.PrevalidationOptions_DnsPrevalidation_DomainScope_Subdomain = this.PrevalidationOptions_DnsPrevalidation_DomainScope_Subdomain;
            context.PrevalidationOptions_DnsPrevalidation_DomainScope_Wildcard = this.PrevalidationOptions_DnsPrevalidation_DomainScope_Wildcard;
            context.PrevalidationOptions_DnsPrevalidation_HostedZoneId = this.PrevalidationOptions_DnsPrevalidation_HostedZoneId;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CertificateManager.Model.Tag>(this.Tag);
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
            var request = new Amazon.CertificateManager.Model.CreateAcmeDomainValidationRequest();
            
            if (cmdletContext.AcmeEndpointArn != null)
            {
                request.AcmeEndpointArn = cmdletContext.AcmeEndpointArn;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            
             // populate PrevalidationOptions
            var requestPrevalidationOptionsIsNull = true;
            request.PrevalidationOptions = new Amazon.CertificateManager.Model.PrevalidationOptions();
            Amazon.CertificateManager.Model.DnsPrevalidationOptions requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation = null;
            
             // populate DnsPrevalidation
            var requestPrevalidationOptions_prevalidationOptions_DnsPrevalidationIsNull = true;
            requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation = new Amazon.CertificateManager.Model.DnsPrevalidationOptions();
            System.String requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_HostedZoneId = null;
            if (cmdletContext.PrevalidationOptions_DnsPrevalidation_HostedZoneId != null)
            {
                requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_HostedZoneId = cmdletContext.PrevalidationOptions_DnsPrevalidation_HostedZoneId;
            }
            if (requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_HostedZoneId != null)
            {
                requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation.HostedZoneId = requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_HostedZoneId;
                requestPrevalidationOptions_prevalidationOptions_DnsPrevalidationIsNull = false;
            }
            Amazon.CertificateManager.Model.DomainScope requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope = null;
            
             // populate DomainScope
            var requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScopeIsNull = true;
            requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope = new Amazon.CertificateManager.Model.DomainScope();
            Amazon.CertificateManager.DomainScopeOption requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope_prevalidationOptions_DnsPrevalidation_DomainScope_ExactDomain = null;
            if (cmdletContext.PrevalidationOptions_DnsPrevalidation_DomainScope_ExactDomain != null)
            {
                requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope_prevalidationOptions_DnsPrevalidation_DomainScope_ExactDomain = cmdletContext.PrevalidationOptions_DnsPrevalidation_DomainScope_ExactDomain;
            }
            if (requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope_prevalidationOptions_DnsPrevalidation_DomainScope_ExactDomain != null)
            {
                requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope.ExactDomain = requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope_prevalidationOptions_DnsPrevalidation_DomainScope_ExactDomain;
                requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScopeIsNull = false;
            }
            Amazon.CertificateManager.DomainScopeOption requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope_prevalidationOptions_DnsPrevalidation_DomainScope_Subdomain = null;
            if (cmdletContext.PrevalidationOptions_DnsPrevalidation_DomainScope_Subdomain != null)
            {
                requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope_prevalidationOptions_DnsPrevalidation_DomainScope_Subdomain = cmdletContext.PrevalidationOptions_DnsPrevalidation_DomainScope_Subdomain;
            }
            if (requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope_prevalidationOptions_DnsPrevalidation_DomainScope_Subdomain != null)
            {
                requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope.Subdomains = requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope_prevalidationOptions_DnsPrevalidation_DomainScope_Subdomain;
                requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScopeIsNull = false;
            }
            Amazon.CertificateManager.DomainScopeOption requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope_prevalidationOptions_DnsPrevalidation_DomainScope_Wildcard = null;
            if (cmdletContext.PrevalidationOptions_DnsPrevalidation_DomainScope_Wildcard != null)
            {
                requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope_prevalidationOptions_DnsPrevalidation_DomainScope_Wildcard = cmdletContext.PrevalidationOptions_DnsPrevalidation_DomainScope_Wildcard;
            }
            if (requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope_prevalidationOptions_DnsPrevalidation_DomainScope_Wildcard != null)
            {
                requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope.Wildcards = requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope_prevalidationOptions_DnsPrevalidation_DomainScope_Wildcard;
                requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScopeIsNull = false;
            }
             // determine if requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope should be set to null
            if (requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScopeIsNull)
            {
                requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope = null;
            }
            if (requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope != null)
            {
                requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation.DomainScope = requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation_prevalidationOptions_DnsPrevalidation_DomainScope;
                requestPrevalidationOptions_prevalidationOptions_DnsPrevalidationIsNull = false;
            }
             // determine if requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation should be set to null
            if (requestPrevalidationOptions_prevalidationOptions_DnsPrevalidationIsNull)
            {
                requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation = null;
            }
            if (requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation != null)
            {
                request.PrevalidationOptions.DnsPrevalidation = requestPrevalidationOptions_prevalidationOptions_DnsPrevalidation;
                requestPrevalidationOptionsIsNull = false;
            }
             // determine if request.PrevalidationOptions should be set to null
            if (requestPrevalidationOptionsIsNull)
            {
                request.PrevalidationOptions = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.CertificateManager.Model.CreateAcmeDomainValidationResponse CallAWSServiceOperation(IAmazonCertificateManager client, Amazon.CertificateManager.Model.CreateAcmeDomainValidationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager", "CreateAcmeDomainValidation");
            try
            {
                return client.CreateAcmeDomainValidationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AcmeEndpointArn { get; set; }
            public System.String DomainName { get; set; }
            public System.String IdempotencyToken { get; set; }
            public Amazon.CertificateManager.DomainScopeOption PrevalidationOptions_DnsPrevalidation_DomainScope_ExactDomain { get; set; }
            public Amazon.CertificateManager.DomainScopeOption PrevalidationOptions_DnsPrevalidation_DomainScope_Subdomain { get; set; }
            public Amazon.CertificateManager.DomainScopeOption PrevalidationOptions_DnsPrevalidation_DomainScope_Wildcard { get; set; }
            public System.String PrevalidationOptions_DnsPrevalidation_HostedZoneId { get; set; }
            public List<Amazon.CertificateManager.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.CertificateManager.Model.CreateAcmeDomainValidationResponse, NewACMAcmeDomainValidationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AcmeDomainValidationArn;
        }
        
    }
}
