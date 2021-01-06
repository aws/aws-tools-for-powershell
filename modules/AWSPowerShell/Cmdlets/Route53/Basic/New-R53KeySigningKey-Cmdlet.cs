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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Creates a new key-signing key (KSK) associated with a hosted zone. You can only have
    /// two KSKs per hosted zone.
    /// </summary>
    [Cmdlet("New", "R53KeySigningKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.CreateKeySigningKeyResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 CreateKeySigningKey API operation.", Operation = new[] {"CreateKeySigningKey"}, SelectReturnType = typeof(Amazon.Route53.Model.CreateKeySigningKeyResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.CreateKeySigningKeyResponse",
        "This cmdlet returns an Amazon.Route53.Model.CreateKeySigningKeyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewR53KeySigningKeyCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request.</para>
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
        public System.String CallerReference { get; set; }
        #endregion
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The unique string (ID) used to identify a hosted zone.</para>
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
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter KeyManagementServiceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon resource name (ARN) for a customer managed customer master key (CMK) in
        /// AWS Key Management Service (AWS KMS). The <code>KeyManagementServiceArn</code> must
        /// be unique for each key-signing key (KSK) in a single hosted zone. To see an example
        /// of <code>KeyManagementServiceArn</code> that grants the correct permissions for DNSSEC,
        /// scroll down to <b>Example</b>. </para><para>You must configure the customer managed CMK as follows:</para><dl><dt>Status</dt><dd><para>Enabled</para></dd><dt>Key spec</dt><dd><para>ECC_NIST_P256</para></dd><dt>Key usage</dt><dd><para>Sign and verify</para></dd><dt>Key policy</dt><dd><para>The key policy must give permission for the following actions:</para><ul><li><para>DescribeKey</para></li><li><para>GetPublicKey</para></li><li><para>Sign</para></li></ul><para>The key policy must also include the Amazon Route 53 service in the principal for
        /// your account. Specify the following:</para><ul><li><para><code>"Service": "api-service.dnssec.route53.aws.internal"</code></para></li></ul></dd></dl><para>For more information about working with a customer managed CMK in AWS KMS, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html">AWS Key
        /// Management Service concepts</a>.</para>
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
        public System.String KeyManagementServiceArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A string used to identify a key-signing key (KSK). <code>Name</code> can include numbers,
        /// letters, and underscores (_). <code>Name</code> must be unique for each key-signing
        /// key in the same hosted zone.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>A string specifying the initial status of the key-signing key (KSK). You can set the
        /// value to <code>ACTIVE</code> or <code>INACTIVE</code>.</para>
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
        public System.String Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.CreateKeySigningKeyResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.CreateKeySigningKeyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the HostedZoneId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^HostedZoneId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^HostedZoneId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HostedZoneId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53KeySigningKey (CreateKeySigningKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.CreateKeySigningKeyResponse, NewR53KeySigningKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.HostedZoneId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CallerReference = this.CallerReference;
            #if MODULAR
            if (this.CallerReference == null && ParameterWasBound(nameof(this.CallerReference)))
            {
                WriteWarning("You are passing $null as a value for parameter CallerReference which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HostedZoneId = this.HostedZoneId;
            #if MODULAR
            if (this.HostedZoneId == null && ParameterWasBound(nameof(this.HostedZoneId)))
            {
                WriteWarning("You are passing $null as a value for parameter HostedZoneId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyManagementServiceArn = this.KeyManagementServiceArn;
            #if MODULAR
            if (this.KeyManagementServiceArn == null && ParameterWasBound(nameof(this.KeyManagementServiceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyManagementServiceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Status = this.Status;
            #if MODULAR
            if (this.Status == null && ParameterWasBound(nameof(this.Status)))
            {
                WriteWarning("You are passing $null as a value for parameter Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53.Model.CreateKeySigningKeyRequest();
            
            if (cmdletContext.CallerReference != null)
            {
                request.CallerReference = cmdletContext.CallerReference;
            }
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }
            if (cmdletContext.KeyManagementServiceArn != null)
            {
                request.KeyManagementServiceArn = cmdletContext.KeyManagementServiceArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.Route53.Model.CreateKeySigningKeyResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.CreateKeySigningKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "CreateKeySigningKey");
            try
            {
                #if DESKTOP
                return client.CreateKeySigningKey(request);
                #elif CORECLR
                return client.CreateKeySigningKeyAsync(request).GetAwaiter().GetResult();
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
            public System.String CallerReference { get; set; }
            public System.String HostedZoneId { get; set; }
            public System.String KeyManagementServiceArn { get; set; }
            public System.String Name { get; set; }
            public System.String Status { get; set; }
            public System.Func<Amazon.Route53.Model.CreateKeySigningKeyResponse, NewR53KeySigningKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
