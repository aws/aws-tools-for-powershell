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
using Amazon.Odb;
using Amazon.Odb.Model;

namespace Amazon.PowerShell.Cmdlets.ODB
{
    /// <summary>
    /// Creates an ODB network.
    /// </summary>
    [Cmdlet("New", "ODBOdbNetwork", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Odb.Model.CreateOdbNetworkResponse")]
    [AWSCmdlet("Calls the Oracle Database@Amazon Web Services CreateOdbNetwork API operation.", Operation = new[] {"CreateOdbNetwork"}, SelectReturnType = typeof(Amazon.Odb.Model.CreateOdbNetworkResponse))]
    [AWSCmdletOutput("Amazon.Odb.Model.CreateOdbNetworkResponse",
        "This cmdlet returns an Amazon.Odb.Model.CreateOdbNetworkResponse object containing multiple properties."
    )]
    public partial class NewODBOdbNetworkCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Availability Zone (AZ) where the ODB network is located.</para><para>This operation requires that you specify a value for either <c>availabilityZone</c>
        /// or <c>availabilityZoneId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneId
        /// <summary>
        /// <para>
        /// <para>The AZ ID of the AZ where the ODB network is located.</para><para>This operation requires that you specify a value for either <c>availabilityZone</c>
        /// or <c>availabilityZoneId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZoneId { get; set; }
        #endregion
        
        #region Parameter BackupSubnetCidr
        /// <summary>
        /// <para>
        /// <para>The CIDR range of the backup subnet for the ODB network.</para><para>Constraints:</para><ul><li><para>Must not overlap with the CIDR range of the client subnet.</para></li><li><para>Must not overlap with the CIDR ranges of the VPCs that are connected to the ODB network.</para></li><li><para>Must not use the following CIDR ranges that are reserved by OCI:</para><ul><li><para><c>100.106.0.0/16</c> and <c>100.107.0.0/16</c></para></li><li><para><c>169.254.0.0/16</c></para></li><li><para><c>224.0.0.0 - 239.255.255.255</c></para></li><li><para><c>240.0.0.0 - 255.255.255.255</c></para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BackupSubnetCidr { get; set; }
        #endregion
        
        #region Parameter ClientSubnetCidr
        /// <summary>
        /// <para>
        /// <para>The CIDR range of the client subnet for the ODB network.</para><para>Constraints:</para><ul><li><para>Must not overlap with the CIDR range of the backup subnet.</para></li><li><para>Must not overlap with the CIDR ranges of the VPCs that are connected to the ODB network.</para></li><li><para>Must not use the following CIDR ranges that are reserved by OCI:</para><ul><li><para><c>100.106.0.0/16</c> and <c>100.107.0.0/16</c></para></li><li><para><c>169.254.0.0/16</c></para></li><li><para><c>224.0.0.0 - 239.255.255.255</c></para></li><li><para><c>240.0.0.0 - 255.255.255.255</c></para></li></ul></li></ul>
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
        public System.String ClientSubnetCidr { get; set; }
        #endregion
        
        #region Parameter CrossRegionS3RestoreSourcesToEnable
        /// <summary>
        /// <para>
        /// <para>The cross-Region Amazon S3 restore sources to enable for the ODB network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] CrossRegionS3RestoreSourcesToEnable { get; set; }
        #endregion
        
        #region Parameter CustomDomainName
        /// <summary>
        /// <para>
        /// <para>The domain name to use for the resources in the ODB network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomDomainName { get; set; }
        #endregion
        
        #region Parameter DefaultDnsPrefix
        /// <summary>
        /// <para>
        /// <para>The DNS prefix to the default DNS domain name. The default DNS domain name is oraclevcn.com.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultDnsPrefix { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>A user-friendly name for the ODB network.</para>
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
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter KmsAccess
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Key Management Service (KMS) access configuration for the
        /// ODB network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.Access")]
        public Amazon.Odb.Access KmsAccess { get; set; }
        #endregion
        
        #region Parameter KmsPolicyDocument
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Key Management Service (KMS) policy document that defines
        /// permissions for key usage within the ODB network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsPolicyDocument { get; set; }
        #endregion
        
        #region Parameter S3Access
        /// <summary>
        /// <para>
        /// <para>Specifies the configuration for Amazon S3 access from the ODB network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.Access")]
        public Amazon.Odb.Access S3Access { get; set; }
        #endregion
        
        #region Parameter S3PolicyDocument
        /// <summary>
        /// <para>
        /// <para>Specifies the endpoint policy for Amazon S3 access from the ODB network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3PolicyDocument { get; set; }
        #endregion
        
        #region Parameter StsAccess
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Security Token Service (STS) access configuration for the
        /// ODB network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.Access")]
        public Amazon.Odb.Access StsAccess { get; set; }
        #endregion
        
        #region Parameter StsPolicyDocument
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Security Token Service (STS) policy document that defines
        /// permissions for token service usage within the ODB network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StsPolicyDocument { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The list of resource tags to apply to the ODB network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ZeroEtlAccess
        /// <summary>
        /// <para>
        /// <para>Specifies the configuration for Zero-ETL access from the ODB network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.Access")]
        public Amazon.Odb.Access ZeroEtlAccess { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If you don't specify a client token, the Amazon Web Services SDK automatically
        /// generates a client token and uses it for the request to ensure idempotency. The client
        /// token is valid for up to 24 hours after it's first used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.CreateOdbNetworkResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.CreateOdbNetworkResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DisplayName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DisplayName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DisplayName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DisplayName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ODBOdbNetwork (CreateOdbNetwork)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.CreateOdbNetworkResponse, NewODBOdbNetworkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DisplayName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AvailabilityZone = this.AvailabilityZone;
            context.AvailabilityZoneId = this.AvailabilityZoneId;
            context.BackupSubnetCidr = this.BackupSubnetCidr;
            context.ClientSubnetCidr = this.ClientSubnetCidr;
            #if MODULAR
            if (this.ClientSubnetCidr == null && ParameterWasBound(nameof(this.ClientSubnetCidr)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientSubnetCidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            if (this.CrossRegionS3RestoreSourcesToEnable != null)
            {
                context.CrossRegionS3RestoreSourcesToEnable = new List<System.String>(this.CrossRegionS3RestoreSourcesToEnable);
            }
            context.CustomDomainName = this.CustomDomainName;
            context.DefaultDnsPrefix = this.DefaultDnsPrefix;
            context.DisplayName = this.DisplayName;
            #if MODULAR
            if (this.DisplayName == null && ParameterWasBound(nameof(this.DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsAccess = this.KmsAccess;
            context.KmsPolicyDocument = this.KmsPolicyDocument;
            context.S3Access = this.S3Access;
            context.S3PolicyDocument = this.S3PolicyDocument;
            context.StsAccess = this.StsAccess;
            context.StsPolicyDocument = this.StsPolicyDocument;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.ZeroEtlAccess = this.ZeroEtlAccess;
            
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
            var request = new Amazon.Odb.Model.CreateOdbNetworkRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.AvailabilityZoneId != null)
            {
                request.AvailabilityZoneId = cmdletContext.AvailabilityZoneId;
            }
            if (cmdletContext.BackupSubnetCidr != null)
            {
                request.BackupSubnetCidr = cmdletContext.BackupSubnetCidr;
            }
            if (cmdletContext.ClientSubnetCidr != null)
            {
                request.ClientSubnetCidr = cmdletContext.ClientSubnetCidr;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CrossRegionS3RestoreSourcesToEnable != null)
            {
                request.CrossRegionS3RestoreSourcesToEnable = cmdletContext.CrossRegionS3RestoreSourcesToEnable;
            }
            if (cmdletContext.CustomDomainName != null)
            {
                request.CustomDomainName = cmdletContext.CustomDomainName;
            }
            if (cmdletContext.DefaultDnsPrefix != null)
            {
                request.DefaultDnsPrefix = cmdletContext.DefaultDnsPrefix;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.KmsAccess != null)
            {
                request.KmsAccess = cmdletContext.KmsAccess;
            }
            if (cmdletContext.KmsPolicyDocument != null)
            {
                request.KmsPolicyDocument = cmdletContext.KmsPolicyDocument;
            }
            if (cmdletContext.S3Access != null)
            {
                request.S3Access = cmdletContext.S3Access;
            }
            if (cmdletContext.S3PolicyDocument != null)
            {
                request.S3PolicyDocument = cmdletContext.S3PolicyDocument;
            }
            if (cmdletContext.StsAccess != null)
            {
                request.StsAccess = cmdletContext.StsAccess;
            }
            if (cmdletContext.StsPolicyDocument != null)
            {
                request.StsPolicyDocument = cmdletContext.StsPolicyDocument;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.ZeroEtlAccess != null)
            {
                request.ZeroEtlAccess = cmdletContext.ZeroEtlAccess;
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
        
        private Amazon.Odb.Model.CreateOdbNetworkResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.CreateOdbNetworkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Oracle Database@Amazon Web Services", "CreateOdbNetwork");
            try
            {
                #if DESKTOP
                return client.CreateOdbNetwork(request);
                #elif CORECLR
                return client.CreateOdbNetworkAsync(request).GetAwaiter().GetResult();
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
            public System.String AvailabilityZone { get; set; }
            public System.String AvailabilityZoneId { get; set; }
            public System.String BackupSubnetCidr { get; set; }
            public System.String ClientSubnetCidr { get; set; }
            public System.String ClientToken { get; set; }
            public List<System.String> CrossRegionS3RestoreSourcesToEnable { get; set; }
            public System.String CustomDomainName { get; set; }
            public System.String DefaultDnsPrefix { get; set; }
            public System.String DisplayName { get; set; }
            public Amazon.Odb.Access KmsAccess { get; set; }
            public System.String KmsPolicyDocument { get; set; }
            public Amazon.Odb.Access S3Access { get; set; }
            public System.String S3PolicyDocument { get; set; }
            public Amazon.Odb.Access StsAccess { get; set; }
            public System.String StsPolicyDocument { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.Odb.Access ZeroEtlAccess { get; set; }
            public System.Func<Amazon.Odb.Model.CreateOdbNetworkResponse, NewODBOdbNetworkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
