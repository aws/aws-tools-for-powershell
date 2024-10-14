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
using Amazon.IVSRealTime;
using Amazon.IVSRealTime.Model;

namespace Amazon.PowerShell.Cmdlets.IVSRT
{
    /// <summary>
    /// Creates an additional token for a specified stage. This can be done after stage creation
    /// or when tokens expire. Tokens always are scoped to the stage for which they are created.
    /// 
    ///  
    /// <para>
    /// Encryption keys are owned by Amazon IVS and never used directly by your application.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IVSRTParticipantToken", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IVSRealTime.Model.ParticipantToken")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service RealTime CreateParticipantToken API operation.", Operation = new[] {"CreateParticipantToken"}, SelectReturnType = typeof(Amazon.IVSRealTime.Model.CreateParticipantTokenResponse))]
    [AWSCmdletOutput("Amazon.IVSRealTime.Model.ParticipantToken or Amazon.IVSRealTime.Model.CreateParticipantTokenResponse",
        "This cmdlet returns an Amazon.IVSRealTime.Model.ParticipantToken object.",
        "The service call response (type Amazon.IVSRealTime.Model.CreateParticipantTokenResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewIVSRTParticipantTokenCmdlet : AmazonIVSRealTimeClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>Application-provided attributes to encode into the token and attach to a stage. Map
        /// keys and values can contain UTF-8 encoded text. The maximum length of this field is
        /// 1 KB total. <i>This field is exposed to all stage participants and should not be used
        /// for personally identifying, confidential, or sensitive information.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter Capability
        /// <summary>
        /// <para>
        /// <para>Set of capabilities that the user is allowed to perform in the stage. Default: <c>PUBLISH,
        /// SUBSCRIBE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities")]
        public System.String[] Capability { get; set; }
        #endregion
        
        #region Parameter Duration
        /// <summary>
        /// <para>
        /// <para>Duration (in minutes), after which the token expires. Default: 720 (12 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Duration { get; set; }
        #endregion
        
        #region Parameter StageArn
        /// <summary>
        /// <para>
        /// <para>ARN of the stage to which this token is scoped.</para>
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
        public System.String StageArn { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>Name that can be specified to help identify the token. This can be any UTF-8 encoded
        /// text. <i>This field is exposed to all stage participants and should not be used for
        /// personally identifying, confidential, or sensitive information.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ParticipantToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVSRealTime.Model.CreateParticipantTokenResponse).
        /// Specifying the name of a property of type Amazon.IVSRealTime.Model.CreateParticipantTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ParticipantToken";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StageArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StageArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StageArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StageArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IVSRTParticipantToken (CreateParticipantToken)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IVSRealTime.Model.CreateParticipantTokenResponse, NewIVSRTParticipantTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StageArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (System.String)(this.Attribute[hashKey]));
                }
            }
            if (this.Capability != null)
            {
                context.Capability = new List<System.String>(this.Capability);
            }
            context.Duration = this.Duration;
            context.StageArn = this.StageArn;
            #if MODULAR
            if (this.StageArn == null && ParameterWasBound(nameof(this.StageArn)))
            {
                WriteWarning("You are passing $null as a value for parameter StageArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserId = this.UserId;
            
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
            var request = new Amazon.IVSRealTime.Model.CreateParticipantTokenRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.Capability != null)
            {
                request.Capabilities = cmdletContext.Capability;
            }
            if (cmdletContext.Duration != null)
            {
                request.Duration = cmdletContext.Duration.Value;
            }
            if (cmdletContext.StageArn != null)
            {
                request.StageArn = cmdletContext.StageArn;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
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
        
        private Amazon.IVSRealTime.Model.CreateParticipantTokenResponse CallAWSServiceOperation(IAmazonIVSRealTime client, Amazon.IVSRealTime.Model.CreateParticipantTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service RealTime", "CreateParticipantToken");
            try
            {
                #if DESKTOP
                return client.CreateParticipantToken(request);
                #elif CORECLR
                return client.CreateParticipantTokenAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public List<System.String> Capability { get; set; }
            public System.Int32? Duration { get; set; }
            public System.String StageArn { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.IVSRealTime.Model.CreateParticipantTokenResponse, NewIVSRTParticipantTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ParticipantToken;
        }
        
    }
}
