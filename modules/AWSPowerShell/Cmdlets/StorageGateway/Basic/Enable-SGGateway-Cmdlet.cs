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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Activates the gateway you previously deployed on your host. In the activation process,
    /// you specify information such as the Amazon Web Services Region that you want to use
    /// for storing snapshots or tapes, the time zone for scheduled snapshots the gateway
    /// snapshot schedule window, an activation key, and a name for your gateway. The activation
    /// process also associates your gateway with your account. For more information, see
    /// <a>UpdateGatewayInformation</a>.
    /// 
    ///  <note><para>
    /// You must turn on the gateway VM before you can activate your gateway.
    /// </para></note>
    /// </summary>
    [Cmdlet("Enable", "SGGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Storage Gateway ActivateGateway API operation.", Operation = new[] {"ActivateGateway"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.ActivateGatewayResponse))]
    [AWSCmdletOutput("System.String or Amazon.StorageGateway.Model.ActivateGatewayResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.StorageGateway.Model.ActivateGatewayResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EnableSGGatewayCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ActivationKey
        /// <summary>
        /// <para>
        /// <para>Your gateway activation key. You can obtain the activation key by sending an HTTP
        /// GET request with redirects enabled to the gateway IP address (port 80). The redirect
        /// URL returned in the response provides you the activation key for your gateway in the
        /// query string parameter <c>activationKey</c>. It may also include other activation-related
        /// parameters, however, these are merely defaults -- the arguments you pass to the <c>ActivateGateway</c>
        /// API call determine the actual configuration of your gateway.</para><para>For more information, see <a href="https://docs.aws.amazon.com/storagegateway/latest/userguide/get-activation-key.html">Getting
        /// activation key</a> in the <i>Storage Gateway User Guide</i>.</para>
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
        public System.String ActivationKey { get; set; }
        #endregion
        
        #region Parameter GatewayName
        /// <summary>
        /// <para>
        /// <para>The name you configured for your gateway.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String GatewayName { get; set; }
        #endregion
        
        #region Parameter GatewayRegion
        /// <summary>
        /// <para>
        /// <para>A value that indicates the Amazon Web Services Region where you want to store your
        /// data. The gateway Amazon Web Services Region specified must be the same Amazon Web
        /// Services Region as the Amazon Web Services Region in your <c>Host</c> header in the
        /// request. For more information about available Amazon Web Services Regions and endpoints
        /// for Storage Gateway, see <a href="https://docs.aws.amazon.com/general/latest/gr/sg.html">
        /// Storage Gateway endpoints and quotas</a> in the <i>Amazon Web Services General Reference</i>.</para><para>Valid Values: See <a href="https://docs.aws.amazon.com/general/latest/gr/sg.html">
        /// Storage Gateway endpoints and quotas</a> in the <i>Amazon Web Services General Reference</i>.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String GatewayRegion { get; set; }
        #endregion
        
        #region Parameter GatewayTimezone
        /// <summary>
        /// <para>
        /// <para>A value that indicates the time zone you want to set for the gateway. The time zone
        /// is of the format "GMT", "GMT-hr:mm", or "GMT+hr:mm". For example, GMT indicates Greenwich
        /// Mean Time without any offset. GMT-4:00 indicates the time is 4 hours behind GMT. GMT+2:00
        /// indicates the time is 2 hours ahead of GMT. The time zone is used, for example, for
        /// scheduling snapshots and your gateway's maintenance schedule.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String GatewayTimezone { get; set; }
        #endregion
        
        #region Parameter GatewayType
        /// <summary>
        /// <para>
        /// <para>A value that defines the type of gateway to activate. The type specified is critical
        /// to all later functions of the gateway and cannot be changed after activation. The
        /// default value is <c>CACHED</c>.</para><important><para>Amazon FSx File Gateway is no longer available to new customers. Existing customers
        /// of FSx File Gateway can continue to use the service normally. For capabilities similar
        /// to FSx File Gateway, visit <a href="https://aws.amazon.com/blogs/storage/switch-your-file-share-access-from-amazon-fsx-file-gateway-to-amazon-fsx-for-windows-file-server/">this
        /// blog post</a>.</para></important><para>Valid Values: <c>STORED</c> | <c>CACHED</c> | <c>VTL</c> | <c>FILE_S3</c> | <c>FILE_FSX_SMB</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        public System.String GatewayType { get; set; }
        #endregion
        
        #region Parameter MediumChangerType
        /// <summary>
        /// <para>
        /// <para>The value that indicates the type of medium changer to use for tape gateway. This
        /// field is optional.</para><para>Valid Values: <c>STK-L700</c> | <c>AWS-Gateway-VTL</c> | <c>IBM-03584L32-0402</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MediumChangerType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of up to 50 tags that you can assign to the gateway. Each tag is a key-value
        /// pair.</para><note><para>Valid characters for key and value are letters, spaces, and numbers that can be represented
        /// in UTF-8 format, and the following special characters: + - = . _ : / @. The maximum
        /// length of a tag's key is 128 characters, and the maximum length for a tag's value
        /// is 256 characters.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.StorageGateway.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TapeDriveType
        /// <summary>
        /// <para>
        /// <para>The value that indicates the type of tape drive to use for tape gateway. This field
        /// is optional.</para><para>Valid Values: <c>IBM-ULT3580-TD5</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TapeDriveType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GatewayARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.ActivateGatewayResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.ActivateGatewayResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GatewayARN";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ActivationKey parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ActivationKey' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ActivationKey' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GatewayName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-SGGateway (ActivateGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.ActivateGatewayResponse, EnableSGGatewayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ActivationKey;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ActivationKey = this.ActivationKey;
            #if MODULAR
            if (this.ActivationKey == null && ParameterWasBound(nameof(this.ActivationKey)))
            {
                WriteWarning("You are passing $null as a value for parameter ActivationKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GatewayName = this.GatewayName;
            #if MODULAR
            if (this.GatewayName == null && ParameterWasBound(nameof(this.GatewayName)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GatewayRegion = this.GatewayRegion;
            #if MODULAR
            if (this.GatewayRegion == null && ParameterWasBound(nameof(this.GatewayRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GatewayTimezone = this.GatewayTimezone;
            #if MODULAR
            if (this.GatewayTimezone == null && ParameterWasBound(nameof(this.GatewayTimezone)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayTimezone which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GatewayType = this.GatewayType;
            context.MediumChangerType = this.MediumChangerType;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.StorageGateway.Model.Tag>(this.Tag);
            }
            context.TapeDriveType = this.TapeDriveType;
            
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
            var request = new Amazon.StorageGateway.Model.ActivateGatewayRequest();
            
            if (cmdletContext.ActivationKey != null)
            {
                request.ActivationKey = cmdletContext.ActivationKey;
            }
            if (cmdletContext.GatewayName != null)
            {
                request.GatewayName = cmdletContext.GatewayName;
            }
            if (cmdletContext.GatewayRegion != null)
            {
                request.GatewayRegion = cmdletContext.GatewayRegion;
            }
            if (cmdletContext.GatewayTimezone != null)
            {
                request.GatewayTimezone = cmdletContext.GatewayTimezone;
            }
            if (cmdletContext.GatewayType != null)
            {
                request.GatewayType = cmdletContext.GatewayType;
            }
            if (cmdletContext.MediumChangerType != null)
            {
                request.MediumChangerType = cmdletContext.MediumChangerType;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TapeDriveType != null)
            {
                request.TapeDriveType = cmdletContext.TapeDriveType;
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
        
        private Amazon.StorageGateway.Model.ActivateGatewayResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.ActivateGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "ActivateGateway");
            try
            {
                #if DESKTOP
                return client.ActivateGateway(request);
                #elif CORECLR
                return client.ActivateGatewayAsync(request).GetAwaiter().GetResult();
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
            public System.String ActivationKey { get; set; }
            public System.String GatewayName { get; set; }
            public System.String GatewayRegion { get; set; }
            public System.String GatewayTimezone { get; set; }
            public System.String GatewayType { get; set; }
            public System.String MediumChangerType { get; set; }
            public List<Amazon.StorageGateway.Model.Tag> Tag { get; set; }
            public System.String TapeDriveType { get; set; }
            public System.Func<Amazon.StorageGateway.Model.ActivateGatewayResponse, EnableSGGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GatewayARN;
        }
        
    }
}
