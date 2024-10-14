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
    /// Creates an outbound call to a phone number from the phone number specified in the
    /// request, and it invokes the endpoint of the specified <c>sipMediaApplicationId</c>.
    /// 
    ///  <important><para><b>This API is is no longer supported and will not be updated.</b> We recommend using
    /// the latest version, <a href="https://docs.aws.amazon.com/chime-sdk/latest/APIReference/API_voice-chime_CreateSipMediaApplicationCall.html">CreateSipMediaApplicationCall</a>,
    /// in the Amazon Chime SDK.
    /// </para><para>
    /// Using the latest version requires migrating to a dedicated namespace. For more information,
    /// refer to <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/migrate-from-chm-namespace.html">Migrating
    /// from the Amazon Chime namespace</a> in the <i>Amazon Chime SDK Developer Guide</i>.
    /// </para></important><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("New", "CHMSipMediaApplicationCall", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chime.Model.SipMediaApplicationCall")]
    [AWSCmdlet("Calls the Amazon Chime CreateSipMediaApplicationCall API operation.", Operation = new[] {"CreateSipMediaApplicationCall"}, SelectReturnType = typeof(Amazon.Chime.Model.CreateSipMediaApplicationCallResponse))]
    [AWSCmdletOutput("Amazon.Chime.Model.SipMediaApplicationCall or Amazon.Chime.Model.CreateSipMediaApplicationCallResponse",
        "This cmdlet returns an Amazon.Chime.Model.SipMediaApplicationCall object.",
        "The service call response (type Amazon.Chime.Model.CreateSipMediaApplicationCallResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("Replaced by CreateSipMediaApplicationCall in the Amazon Chime SDK Voice Namespace")]
    public partial class NewCHMSipMediaApplicationCallCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FromPhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number that a user calls from. This is a phone number in your Amazon Chime
        /// phone number inventory.</para>
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
        public System.String FromPhoneNumber { get; set; }
        #endregion
        
        #region Parameter SipHeader
        /// <summary>
        /// <para>
        /// <para>The SIP headers added to an outbound call leg.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SipHeaders")]
        public System.Collections.Hashtable SipHeader { get; set; }
        #endregion
        
        #region Parameter SipMediaApplicationId
        /// <summary>
        /// <para>
        /// <para>The ID of the SIP media application.</para>
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
        public System.String SipMediaApplicationId { get; set; }
        #endregion
        
        #region Parameter ToPhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number that the service should call.</para>
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
        public System.String ToPhoneNumber { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SipMediaApplicationCall'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.CreateSipMediaApplicationCallResponse).
        /// Specifying the name of a property of type Amazon.Chime.Model.CreateSipMediaApplicationCallResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SipMediaApplicationCall";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SipMediaApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SipMediaApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SipMediaApplicationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SipMediaApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMSipMediaApplicationCall (CreateSipMediaApplicationCall)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.CreateSipMediaApplicationCallResponse, NewCHMSipMediaApplicationCallCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SipMediaApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FromPhoneNumber = this.FromPhoneNumber;
            #if MODULAR
            if (this.FromPhoneNumber == null && ParameterWasBound(nameof(this.FromPhoneNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter FromPhoneNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SipHeader != null)
            {
                context.SipHeader = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SipHeader.Keys)
                {
                    context.SipHeader.Add((String)hashKey, (System.String)(this.SipHeader[hashKey]));
                }
            }
            context.SipMediaApplicationId = this.SipMediaApplicationId;
            #if MODULAR
            if (this.SipMediaApplicationId == null && ParameterWasBound(nameof(this.SipMediaApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter SipMediaApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ToPhoneNumber = this.ToPhoneNumber;
            #if MODULAR
            if (this.ToPhoneNumber == null && ParameterWasBound(nameof(this.ToPhoneNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter ToPhoneNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Chime.Model.CreateSipMediaApplicationCallRequest();
            
            if (cmdletContext.FromPhoneNumber != null)
            {
                request.FromPhoneNumber = cmdletContext.FromPhoneNumber;
            }
            if (cmdletContext.SipHeader != null)
            {
                request.SipHeaders = cmdletContext.SipHeader;
            }
            if (cmdletContext.SipMediaApplicationId != null)
            {
                request.SipMediaApplicationId = cmdletContext.SipMediaApplicationId;
            }
            if (cmdletContext.ToPhoneNumber != null)
            {
                request.ToPhoneNumber = cmdletContext.ToPhoneNumber;
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
        
        private Amazon.Chime.Model.CreateSipMediaApplicationCallResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.CreateSipMediaApplicationCallRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "CreateSipMediaApplicationCall");
            try
            {
                #if DESKTOP
                return client.CreateSipMediaApplicationCall(request);
                #elif CORECLR
                return client.CreateSipMediaApplicationCallAsync(request).GetAwaiter().GetResult();
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
            public System.String FromPhoneNumber { get; set; }
            public Dictionary<System.String, System.String> SipHeader { get; set; }
            public System.String SipMediaApplicationId { get; set; }
            public System.String ToPhoneNumber { get; set; }
            public System.Func<Amazon.Chime.Model.CreateSipMediaApplicationCallResponse, NewCHMSipMediaApplicationCallCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SipMediaApplicationCall;
        }
        
    }
}
