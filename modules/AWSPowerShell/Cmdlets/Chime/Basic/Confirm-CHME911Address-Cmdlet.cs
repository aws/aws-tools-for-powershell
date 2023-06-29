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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Validates an address to be used for 911 calls made with Amazon Chime Voice Connectors.
    /// You can use validated addresses in a Presence Information Data Format Location Object
    /// file that you include in SIP requests. That helps ensure that addresses are routed
    /// to the appropriate Public Safety Answering Point.
    /// 
    ///  <important><para><b>This API is is no longer supported and will not be updated.</b> We recommend using
    /// the latest version, <a href="https://docs.aws.amazon.com/chime-sdk/latest/APIReference/API_voice-chime_ValidateE911Address.html">ValidateE911Address</a>,
    /// in the Amazon Chime SDK.
    /// </para><para>
    /// Using the latest version requires migrating to a dedicated namespace. For more information,
    /// refer to <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/migrate-from-chm-namespace.html">Migrating
    /// from the Amazon Chime namespace</a> in the <i>Amazon Chime SDK Developer Guide</i>.
    /// </para></important><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Confirm", "CHME911Address", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chime.Model.ValidateE911AddressResponse")]
    [AWSCmdlet("Calls the Amazon Chime ValidateE911Address API operation.", Operation = new[] {"ValidateE911Address"}, SelectReturnType = typeof(Amazon.Chime.Model.ValidateE911AddressResponse))]
    [AWSCmdletOutput("Amazon.Chime.Model.ValidateE911AddressResponse",
        "This cmdlet returns an Amazon.Chime.Model.ValidateE911AddressResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    [System.ObsoleteAttribute("Replaced by ValidateE911Address in the Amazon Chime SDK Voice Namespace")]
    public partial class ConfirmCHME911AddressCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The AWS account ID.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter City
        /// <summary>
        /// <para>
        /// <para>The address city, such as <code>Portland</code>.</para>
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
        public System.String City { get; set; }
        #endregion
        
        #region Parameter Country
        /// <summary>
        /// <para>
        /// <para>The address country, such as <code>US</code>. </para>
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
        public System.String Country { get; set; }
        #endregion
        
        #region Parameter PostalCode
        /// <summary>
        /// <para>
        /// <para>The address postal code, such as <code>04352</code>.</para>
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
        public System.String PostalCode { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The address state, such as <code>ME</code>.</para>
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
        public System.String State { get; set; }
        #endregion
        
        #region Parameter StreetInfo
        /// <summary>
        /// <para>
        /// <para>The address street information, such as <code>8th Avenue</code>.</para>
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
        public System.String StreetInfo { get; set; }
        #endregion
        
        #region Parameter StreetNumber
        /// <summary>
        /// <para>
        /// <para>The address street number, such as <code>200</code> or <code>2121</code>.</para>
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
        public System.String StreetNumber { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.ValidateE911AddressResponse).
        /// Specifying the name of a property of type Amazon.Chime.Model.ValidateE911AddressResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AwsAccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AwsAccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Confirm-CHME911Address (ValidateE911Address)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.ValidateE911AddressResponse, ConfirmCHME911AddressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AwsAccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.City = this.City;
            #if MODULAR
            if (this.City == null && ParameterWasBound(nameof(this.City)))
            {
                WriteWarning("You are passing $null as a value for parameter City which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Country = this.Country;
            #if MODULAR
            if (this.Country == null && ParameterWasBound(nameof(this.Country)))
            {
                WriteWarning("You are passing $null as a value for parameter Country which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PostalCode = this.PostalCode;
            #if MODULAR
            if (this.PostalCode == null && ParameterWasBound(nameof(this.PostalCode)))
            {
                WriteWarning("You are passing $null as a value for parameter PostalCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.State = this.State;
            #if MODULAR
            if (this.State == null && ParameterWasBound(nameof(this.State)))
            {
                WriteWarning("You are passing $null as a value for parameter State which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreetInfo = this.StreetInfo;
            #if MODULAR
            if (this.StreetInfo == null && ParameterWasBound(nameof(this.StreetInfo)))
            {
                WriteWarning("You are passing $null as a value for parameter StreetInfo which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreetNumber = this.StreetNumber;
            #if MODULAR
            if (this.StreetNumber == null && ParameterWasBound(nameof(this.StreetNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter StreetNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Chime.Model.ValidateE911AddressRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.City != null)
            {
                request.City = cmdletContext.City;
            }
            if (cmdletContext.Country != null)
            {
                request.Country = cmdletContext.Country;
            }
            if (cmdletContext.PostalCode != null)
            {
                request.PostalCode = cmdletContext.PostalCode;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
            }
            if (cmdletContext.StreetInfo != null)
            {
                request.StreetInfo = cmdletContext.StreetInfo;
            }
            if (cmdletContext.StreetNumber != null)
            {
                request.StreetNumber = cmdletContext.StreetNumber;
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
        
        private Amazon.Chime.Model.ValidateE911AddressResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.ValidateE911AddressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "ValidateE911Address");
            try
            {
                #if DESKTOP
                return client.ValidateE911Address(request);
                #elif CORECLR
                return client.ValidateE911AddressAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String City { get; set; }
            public System.String Country { get; set; }
            public System.String PostalCode { get; set; }
            public System.String State { get; set; }
            public System.String StreetInfo { get; set; }
            public System.String StreetNumber { get; set; }
            public System.Func<Amazon.Chime.Model.ValidateE911AddressResponse, ConfirmCHME911AddressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
