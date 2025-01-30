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
    /// Creates one or more virtual tapes. You write data to the virtual tapes and then archive
    /// the tapes. This operation is only supported in the tape gateway type.
    /// 
    ///  <note><para>
    /// Cache storage must be allocated to the gateway before you can create virtual tapes.
    /// Use the <a>AddCache</a> operation to add cache storage to a gateway.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SGTape", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Storage Gateway CreateTapes API operation.", Operation = new[] {"CreateTapes"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.CreateTapesResponse), LegacyAlias="New-SGTapes")]
    [AWSCmdletOutput("System.String or Amazon.StorageGateway.Model.CreateTapesResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.StorageGateway.Model.CreateTapesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSGTapeCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// <para>The unique Amazon Resource Name (ARN) that represents the gateway to associate the
        /// virtual tapes with. Use the <a>ListGateways</a> operation to return a list of gateways
        /// for your account and Amazon Web Services Region.</para>
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
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter KMSEncrypted
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to use Amazon S3 server-side encryption with your own KMS key,
        /// or <c>false</c> to use a key managed by Amazon S3. Optional.</para><para>Valid Values: <c>true</c> | <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KMSEncrypted { get; set; }
        #endregion
        
        #region Parameter KMSKey
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a symmetric customer master key (CMK) used for Amazon
        /// S3 server-side encryption. Storage Gateway does not support asymmetric CMKs. This
        /// value can only be set when <c>KMSEncrypted</c> is <c>true</c>. Optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KMSKey { get; set; }
        #endregion
        
        #region Parameter NumTapesToCreate
        /// <summary>
        /// <para>
        /// <para>The number of virtual tapes that you want to create.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? NumTapesToCreate { get; set; }
        #endregion
        
        #region Parameter PoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the pool that you want to add your tape to for archiving. The tape in this
        /// pool is archived in the S3 storage class that is associated with the pool. When you
        /// use your backup application to eject the tape, the tape is archived directly into
        /// the storage class (S3 Glacier or S3 Glacier Deep Archive) that corresponds to the
        /// pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PoolId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of up to 50 tags that can be assigned to a virtual tape. Each tag is a key-value
        /// pair.</para><note><para>Valid characters for key and value are letters, spaces, and numbers representable
        /// in UTF-8 format, and the following special characters: + - = . _ : / @. The maximum
        /// length of a tag's key is 128 characters, and the maximum length for a tag's value
        /// is 256.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.StorageGateway.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TapeBarcodePrefix
        /// <summary>
        /// <para>
        /// <para>A prefix that you append to the barcode of the virtual tape you are creating. This
        /// prefix makes the barcode unique.</para><note><para>The prefix must be 1-4 characters in length and must be one of the uppercase letters
        /// from A to Z.</para></note>
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
        public System.String TapeBarcodePrefix { get; set; }
        #endregion
        
        #region Parameter TapeSizeInBytes
        /// <summary>
        /// <para>
        /// <para>The size, in bytes, of the virtual tapes that you want to create.</para><note><para>The size must be aligned by gigabyte (1024*1024*1024 bytes).</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? TapeSizeInBytes { get; set; }
        #endregion
        
        #region Parameter Worm
        /// <summary>
        /// <para>
        /// <para>Set to <c>TRUE</c> if the tape you are creating is to be configured as a write-once-read-many
        /// (WORM) tape.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Worm { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier that you use to retry a request. If you retry a request, use the
        /// same <c>ClientToken</c> you specified in the initial request.</para><note><para>Using the same <c>ClientToken</c> prevents creating the tape multiple times.</para></note>
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
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TapeARNs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.CreateTapesResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.CreateTapesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TapeARNs";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GatewayARN parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GatewayARN' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GatewayARN' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GatewayARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SGTape (CreateTapes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.CreateTapesResponse, NewSGTapeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GatewayARN;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            #if MODULAR
            if (this.ClientToken == null && ParameterWasBound(nameof(this.ClientToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GatewayARN = this.GatewayARN;
            #if MODULAR
            if (this.GatewayARN == null && ParameterWasBound(nameof(this.GatewayARN)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KMSEncrypted = this.KMSEncrypted;
            context.KMSKey = this.KMSKey;
            context.NumTapesToCreate = this.NumTapesToCreate;
            #if MODULAR
            if (this.NumTapesToCreate == null && ParameterWasBound(nameof(this.NumTapesToCreate)))
            {
                WriteWarning("You are passing $null as a value for parameter NumTapesToCreate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PoolId = this.PoolId;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.StorageGateway.Model.Tag>(this.Tag);
            }
            context.TapeBarcodePrefix = this.TapeBarcodePrefix;
            #if MODULAR
            if (this.TapeBarcodePrefix == null && ParameterWasBound(nameof(this.TapeBarcodePrefix)))
            {
                WriteWarning("You are passing $null as a value for parameter TapeBarcodePrefix which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TapeSizeInBytes = this.TapeSizeInBytes;
            #if MODULAR
            if (this.TapeSizeInBytes == null && ParameterWasBound(nameof(this.TapeSizeInBytes)))
            {
                WriteWarning("You are passing $null as a value for parameter TapeSizeInBytes which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Worm = this.Worm;
            
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
            var request = new Amazon.StorageGateway.Model.CreateTapesRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
            }
            if (cmdletContext.KMSEncrypted != null)
            {
                request.KMSEncrypted = cmdletContext.KMSEncrypted.Value;
            }
            if (cmdletContext.KMSKey != null)
            {
                request.KMSKey = cmdletContext.KMSKey;
            }
            if (cmdletContext.NumTapesToCreate != null)
            {
                request.NumTapesToCreate = cmdletContext.NumTapesToCreate.Value;
            }
            if (cmdletContext.PoolId != null)
            {
                request.PoolId = cmdletContext.PoolId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TapeBarcodePrefix != null)
            {
                request.TapeBarcodePrefix = cmdletContext.TapeBarcodePrefix;
            }
            if (cmdletContext.TapeSizeInBytes != null)
            {
                request.TapeSizeInBytes = cmdletContext.TapeSizeInBytes.Value;
            }
            if (cmdletContext.Worm != null)
            {
                request.Worm = cmdletContext.Worm.Value;
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
        
        private Amazon.StorageGateway.Model.CreateTapesResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.CreateTapesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "CreateTapes");
            try
            {
                #if DESKTOP
                return client.CreateTapes(request);
                #elif CORECLR
                return client.CreateTapesAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String GatewayARN { get; set; }
            public System.Boolean? KMSEncrypted { get; set; }
            public System.String KMSKey { get; set; }
            public System.Int32? NumTapesToCreate { get; set; }
            public System.String PoolId { get; set; }
            public List<Amazon.StorageGateway.Model.Tag> Tag { get; set; }
            public System.String TapeBarcodePrefix { get; set; }
            public System.Int64? TapeSizeInBytes { get; set; }
            public System.Boolean? Worm { get; set; }
            public System.Func<Amazon.StorageGateway.Model.CreateTapesResponse, NewSGTapeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TapeARNs;
        }
        
    }
}
