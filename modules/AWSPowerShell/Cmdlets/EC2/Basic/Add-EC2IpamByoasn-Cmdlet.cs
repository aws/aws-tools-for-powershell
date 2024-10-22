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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Provisions your Autonomous System Number (ASN) for use in your Amazon Web Services
    /// account. This action requires authorization context for Amazon to bring the ASN to
    /// an Amazon Web Services account. For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/tutorials-byoasn.html">Tutorial:
    /// Bring your ASN to IPAM</a> in the <i>Amazon VPC IPAM guide</i>.
    /// </summary>
    [Cmdlet("Add", "EC2IpamByoasn", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.Byoasn")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ProvisionIpamByoasn API operation.", Operation = new[] {"ProvisionIpamByoasn"}, SelectReturnType = typeof(Amazon.EC2.Model.ProvisionIpamByoasnResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.Byoasn or Amazon.EC2.Model.ProvisionIpamByoasnResponse",
        "This cmdlet returns an Amazon.EC2.Model.Byoasn object.",
        "The service call response (type Amazon.EC2.Model.ProvisionIpamByoasnResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddEC2IpamByoasnCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Asn
        /// <summary>
        /// <para>
        /// <para>A public 2-byte or 4-byte ASN.</para>
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
        public System.String Asn { get; set; }
        #endregion
        
        #region Parameter IpamId
        /// <summary>
        /// <para>
        /// <para>An IPAM ID.</para>
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
        public System.String IpamId { get; set; }
        #endregion
        
        #region Parameter AsnAuthorizationContext_Message
        /// <summary>
        /// <para>
        /// <para>The authorization context's message.</para>
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
        public System.String AsnAuthorizationContext_Message { get; set; }
        #endregion
        
        #region Parameter AsnAuthorizationContext_Signature
        /// <summary>
        /// <para>
        /// <para>The authorization context's signature.</para>
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
        public System.String AsnAuthorizationContext_Signature { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Byoasn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ProvisionIpamByoasnResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ProvisionIpamByoasnResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Byoasn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IpamId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-EC2IpamByoasn (ProvisionIpamByoasn)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ProvisionIpamByoasnResponse, AddEC2IpamByoasnCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Asn = this.Asn;
            #if MODULAR
            if (this.Asn == null && ParameterWasBound(nameof(this.Asn)))
            {
                WriteWarning("You are passing $null as a value for parameter Asn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AsnAuthorizationContext_Message = this.AsnAuthorizationContext_Message;
            #if MODULAR
            if (this.AsnAuthorizationContext_Message == null && ParameterWasBound(nameof(this.AsnAuthorizationContext_Message)))
            {
                WriteWarning("You are passing $null as a value for parameter AsnAuthorizationContext_Message which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AsnAuthorizationContext_Signature = this.AsnAuthorizationContext_Signature;
            #if MODULAR
            if (this.AsnAuthorizationContext_Signature == null && ParameterWasBound(nameof(this.AsnAuthorizationContext_Signature)))
            {
                WriteWarning("You are passing $null as a value for parameter AsnAuthorizationContext_Signature which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IpamId = this.IpamId;
            #if MODULAR
            if (this.IpamId == null && ParameterWasBound(nameof(this.IpamId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ProvisionIpamByoasnRequest();
            
            if (cmdletContext.Asn != null)
            {
                request.Asn = cmdletContext.Asn;
            }
            
             // populate AsnAuthorizationContext
            var requestAsnAuthorizationContextIsNull = true;
            request.AsnAuthorizationContext = new Amazon.EC2.Model.AsnAuthorizationContext();
            System.String requestAsnAuthorizationContext_asnAuthorizationContext_Message = null;
            if (cmdletContext.AsnAuthorizationContext_Message != null)
            {
                requestAsnAuthorizationContext_asnAuthorizationContext_Message = cmdletContext.AsnAuthorizationContext_Message;
            }
            if (requestAsnAuthorizationContext_asnAuthorizationContext_Message != null)
            {
                request.AsnAuthorizationContext.Message = requestAsnAuthorizationContext_asnAuthorizationContext_Message;
                requestAsnAuthorizationContextIsNull = false;
            }
            System.String requestAsnAuthorizationContext_asnAuthorizationContext_Signature = null;
            if (cmdletContext.AsnAuthorizationContext_Signature != null)
            {
                requestAsnAuthorizationContext_asnAuthorizationContext_Signature = cmdletContext.AsnAuthorizationContext_Signature;
            }
            if (requestAsnAuthorizationContext_asnAuthorizationContext_Signature != null)
            {
                request.AsnAuthorizationContext.Signature = requestAsnAuthorizationContext_asnAuthorizationContext_Signature;
                requestAsnAuthorizationContextIsNull = false;
            }
             // determine if request.AsnAuthorizationContext should be set to null
            if (requestAsnAuthorizationContextIsNull)
            {
                request.AsnAuthorizationContext = null;
            }
            if (cmdletContext.IpamId != null)
            {
                request.IpamId = cmdletContext.IpamId;
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
        
        private Amazon.EC2.Model.ProvisionIpamByoasnResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ProvisionIpamByoasnRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ProvisionIpamByoasn");
            try
            {
                #if DESKTOP
                return client.ProvisionIpamByoasn(request);
                #elif CORECLR
                return client.ProvisionIpamByoasnAsync(request).GetAwaiter().GetResult();
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
            public System.String Asn { get; set; }
            public System.String AsnAuthorizationContext_Message { get; set; }
            public System.String AsnAuthorizationContext_Signature { get; set; }
            public System.String IpamId { get; set; }
            public System.Func<Amazon.EC2.Model.ProvisionIpamByoasnResponse, AddEC2IpamByoasnCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Byoasn;
        }
        
    }
}
