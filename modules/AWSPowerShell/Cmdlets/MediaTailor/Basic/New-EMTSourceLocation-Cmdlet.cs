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
using Amazon.MediaTailor;
using Amazon.MediaTailor.Model;

namespace Amazon.PowerShell.Cmdlets.EMT
{
    /// <summary>
    /// Creates a source location. A source location is a container for sources. For more
    /// information about source locations, see <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/channel-assembly-source-locations.html">Working
    /// with source locations</a> in the <i>MediaTailor User Guide</i>.
    /// </summary>
    [Cmdlet("New", "EMTSourceLocation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaTailor.Model.CreateSourceLocationResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaTailor CreateSourceLocation API operation.", Operation = new[] {"CreateSourceLocation"}, SelectReturnType = typeof(Amazon.MediaTailor.Model.CreateSourceLocationResponse))]
    [AWSCmdletOutput("Amazon.MediaTailor.Model.CreateSourceLocationResponse",
        "This cmdlet returns an Amazon.MediaTailor.Model.CreateSourceLocationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEMTSourceLocationCmdlet : AmazonMediaTailorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessConfiguration_AccessType
        /// <summary>
        /// <para>
        /// <para>The type of authentication used to access content from <code>HttpConfiguration::BaseUrl</code>
        /// on your source location.</para><para><code>S3_SIGV4</code> - AWS Signature Version 4 authentication for Amazon S3 hosted
        /// virtual-style access. If your source location base URL is an Amazon S3 bucket, MediaTailor
        /// can use AWS Signature Version 4 (SigV4) authentication to access the bucket where
        /// your source content is stored. Your MediaTailor source location baseURL must follow
        /// the S3 virtual hosted-style request URL format. For example, https://bucket-name.s3.Region.amazonaws.com/key-name.</para><para>Before you can use <code>S3_SIGV4</code>, you must meet these requirements:</para><para>• You must allow MediaTailor to access your S3 bucket by granting mediatailor.amazonaws.com
        /// principal access in IAM. For information about configuring access in IAM, see Access
        /// management in the IAM User Guide.</para><para>• The mediatailor.amazonaws.com service principal must have permissions to read all
        /// top level manifests referenced by the VodSource packaging configurations.</para><para>• The caller of the API must have s3:GetObject IAM permissions to read all top level
        /// manifests referenced by your MediaTailor VodSource packaging configurations.</para><para><code>AUTODETECT_SIGV4</code> - AWS Signature Version 4 authentication for a set
        /// of supported services: MediaPackage Version 2 and Amazon S3 hosted virtual-style access.
        /// If your source location base URL is a MediaPackage Version 2 endpoint or an Amazon
        /// S3 bucket, MediaTailor can use AWS Signature Version 4 (SigV4) authentication to access
        /// the resource where your source content is stored.</para><para>Before you can use <code>AUTODETECT_SIGV4</code> with a MediaPackage Version 2 endpoint,
        /// you must meet these requirements:</para><para>• You must grant MediaTailor access to your MediaPackage endpoint by granting <code>mediatailor.amazonaws.com</code>
        /// principal access in an Origin Access policy on the endpoint.</para><para>• Your MediaTailor source location base URL must be a MediaPackage V2 endpoint.</para><para>• The caller of the API must have <code>mediapackagev2:GetObject</code> IAM permissions
        /// to read all top level manifests referenced by the MediaTailor source packaging configurations.</para><para>Before you can use <code>AUTODETECT_SIGV4</code> with an Amazon S3 bucket, you must
        /// meet these requirements:</para><para>• You must grant MediaTailor access to your S3 bucket by granting <code>mediatailor.amazonaws.com</code>
        /// principal access in IAM. For more information about configuring access in IAM, see
        /// <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access.html">Access management</a>
        /// in the <i>IAM User Guide.</i>.</para><para>• The <code>mediatailor.amazonaws.com</code> service principal must have permissions
        /// to read all top-level manifests referenced by the <code>VodSource</code> packaging
        /// configurations.</para><para>• The caller of the API must have <code>s3:GetObject</code> IAM permissions to read
        /// all top level manifests referenced by your MediaTailor <code>VodSource</code> packaging
        /// configurations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaTailor.AccessType")]
        public Amazon.MediaTailor.AccessType AccessConfiguration_AccessType { get; set; }
        #endregion
        
        #region Parameter DefaultSegmentDeliveryConfiguration_BaseUrl
        /// <summary>
        /// <para>
        /// <para>The hostname of the server that will be used to serve segments. This string must include
        /// the protocol, such as <b>https://</b>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSegmentDeliveryConfiguration_BaseUrl { get; set; }
        #endregion
        
        #region Parameter HttpConfiguration_BaseUrl
        /// <summary>
        /// <para>
        /// <para>The base URL for the source location host server. This string must include the protocol,
        /// such as <b>https://</b>.</para>
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
        public System.String HttpConfiguration_BaseUrl { get; set; }
        #endregion
        
        #region Parameter SecretsManagerAccessTokenConfiguration_HeaderName
        /// <summary>
        /// <para>
        /// <para>The name of the HTTP header used to supply the access token in requests to the source
        /// location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessConfiguration_SecretsManagerAccessTokenConfiguration_HeaderName")]
        public System.String SecretsManagerAccessTokenConfiguration_HeaderName { get; set; }
        #endregion
        
        #region Parameter SecretsManagerAccessTokenConfiguration_SecretArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Secrets Manager secret that contains the
        /// access token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessConfiguration_SecretsManagerAccessTokenConfiguration_SecretArn")]
        public System.String SecretsManagerAccessTokenConfiguration_SecretArn { get; set; }
        #endregion
        
        #region Parameter SecretsManagerAccessTokenConfiguration_SecretStringKey
        /// <summary>
        /// <para>
        /// <para>The AWS Secrets Manager <a href="https://docs.aws.amazon.com/secretsmanager/latest/apireference/API_CreateSecret.html#SecretsManager-CreateSecret-request-SecretString.html">SecretString</a>
        /// key associated with the access token. MediaTailor uses the key to look up SecretString
        /// key and value pair containing the access token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessConfiguration_SecretsManagerAccessTokenConfiguration_SecretStringKey")]
        public System.String SecretsManagerAccessTokenConfiguration_SecretStringKey { get; set; }
        #endregion
        
        #region Parameter SegmentDeliveryConfiguration
        /// <summary>
        /// <para>
        /// <para>A list of the segment delivery configurations associated with this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SegmentDeliveryConfigurations")]
        public Amazon.MediaTailor.Model.SegmentDeliveryConfiguration[] SegmentDeliveryConfiguration { get; set; }
        #endregion
        
        #region Parameter SourceLocationName
        /// <summary>
        /// <para>
        /// <para>The name associated with the source location.</para>
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
        public System.String SourceLocationName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the source location. Tags are key-value pairs that you can associate
        /// with Amazon resources to help with organization, access control, and cost tracking.
        /// For more information, see <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/tagging.html">Tagging
        /// AWS Elemental MediaTailor Resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaTailor.Model.CreateSourceLocationResponse).
        /// Specifying the name of a property of type Amazon.MediaTailor.Model.CreateSourceLocationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceLocationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceLocationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceLocationName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceLocationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMTSourceLocation (CreateSourceLocation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaTailor.Model.CreateSourceLocationResponse, NewEMTSourceLocationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceLocationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccessConfiguration_AccessType = this.AccessConfiguration_AccessType;
            context.SecretsManagerAccessTokenConfiguration_HeaderName = this.SecretsManagerAccessTokenConfiguration_HeaderName;
            context.SecretsManagerAccessTokenConfiguration_SecretArn = this.SecretsManagerAccessTokenConfiguration_SecretArn;
            context.SecretsManagerAccessTokenConfiguration_SecretStringKey = this.SecretsManagerAccessTokenConfiguration_SecretStringKey;
            context.DefaultSegmentDeliveryConfiguration_BaseUrl = this.DefaultSegmentDeliveryConfiguration_BaseUrl;
            context.HttpConfiguration_BaseUrl = this.HttpConfiguration_BaseUrl;
            #if MODULAR
            if (this.HttpConfiguration_BaseUrl == null && ParameterWasBound(nameof(this.HttpConfiguration_BaseUrl)))
            {
                WriteWarning("You are passing $null as a value for parameter HttpConfiguration_BaseUrl which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SegmentDeliveryConfiguration != null)
            {
                context.SegmentDeliveryConfiguration = new List<Amazon.MediaTailor.Model.SegmentDeliveryConfiguration>(this.SegmentDeliveryConfiguration);
            }
            context.SourceLocationName = this.SourceLocationName;
            #if MODULAR
            if (this.SourceLocationName == null && ParameterWasBound(nameof(this.SourceLocationName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceLocationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.MediaTailor.Model.CreateSourceLocationRequest();
            
            
             // populate AccessConfiguration
            var requestAccessConfigurationIsNull = true;
            request.AccessConfiguration = new Amazon.MediaTailor.Model.AccessConfiguration();
            Amazon.MediaTailor.AccessType requestAccessConfiguration_accessConfiguration_AccessType = null;
            if (cmdletContext.AccessConfiguration_AccessType != null)
            {
                requestAccessConfiguration_accessConfiguration_AccessType = cmdletContext.AccessConfiguration_AccessType;
            }
            if (requestAccessConfiguration_accessConfiguration_AccessType != null)
            {
                request.AccessConfiguration.AccessType = requestAccessConfiguration_accessConfiguration_AccessType;
                requestAccessConfigurationIsNull = false;
            }
            Amazon.MediaTailor.Model.SecretsManagerAccessTokenConfiguration requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration = null;
            
             // populate SecretsManagerAccessTokenConfiguration
            var requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfigurationIsNull = true;
            requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration = new Amazon.MediaTailor.Model.SecretsManagerAccessTokenConfiguration();
            System.String requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration_secretsManagerAccessTokenConfiguration_HeaderName = null;
            if (cmdletContext.SecretsManagerAccessTokenConfiguration_HeaderName != null)
            {
                requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration_secretsManagerAccessTokenConfiguration_HeaderName = cmdletContext.SecretsManagerAccessTokenConfiguration_HeaderName;
            }
            if (requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration_secretsManagerAccessTokenConfiguration_HeaderName != null)
            {
                requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration.HeaderName = requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration_secretsManagerAccessTokenConfiguration_HeaderName;
                requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfigurationIsNull = false;
            }
            System.String requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration_secretsManagerAccessTokenConfiguration_SecretArn = null;
            if (cmdletContext.SecretsManagerAccessTokenConfiguration_SecretArn != null)
            {
                requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration_secretsManagerAccessTokenConfiguration_SecretArn = cmdletContext.SecretsManagerAccessTokenConfiguration_SecretArn;
            }
            if (requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration_secretsManagerAccessTokenConfiguration_SecretArn != null)
            {
                requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration.SecretArn = requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration_secretsManagerAccessTokenConfiguration_SecretArn;
                requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfigurationIsNull = false;
            }
            System.String requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration_secretsManagerAccessTokenConfiguration_SecretStringKey = null;
            if (cmdletContext.SecretsManagerAccessTokenConfiguration_SecretStringKey != null)
            {
                requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration_secretsManagerAccessTokenConfiguration_SecretStringKey = cmdletContext.SecretsManagerAccessTokenConfiguration_SecretStringKey;
            }
            if (requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration_secretsManagerAccessTokenConfiguration_SecretStringKey != null)
            {
                requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration.SecretStringKey = requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration_secretsManagerAccessTokenConfiguration_SecretStringKey;
                requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfigurationIsNull = false;
            }
             // determine if requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration should be set to null
            if (requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfigurationIsNull)
            {
                requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration = null;
            }
            if (requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration != null)
            {
                request.AccessConfiguration.SecretsManagerAccessTokenConfiguration = requestAccessConfiguration_accessConfiguration_SecretsManagerAccessTokenConfiguration;
                requestAccessConfigurationIsNull = false;
            }
             // determine if request.AccessConfiguration should be set to null
            if (requestAccessConfigurationIsNull)
            {
                request.AccessConfiguration = null;
            }
            
             // populate DefaultSegmentDeliveryConfiguration
            var requestDefaultSegmentDeliveryConfigurationIsNull = true;
            request.DefaultSegmentDeliveryConfiguration = new Amazon.MediaTailor.Model.DefaultSegmentDeliveryConfiguration();
            System.String requestDefaultSegmentDeliveryConfiguration_defaultSegmentDeliveryConfiguration_BaseUrl = null;
            if (cmdletContext.DefaultSegmentDeliveryConfiguration_BaseUrl != null)
            {
                requestDefaultSegmentDeliveryConfiguration_defaultSegmentDeliveryConfiguration_BaseUrl = cmdletContext.DefaultSegmentDeliveryConfiguration_BaseUrl;
            }
            if (requestDefaultSegmentDeliveryConfiguration_defaultSegmentDeliveryConfiguration_BaseUrl != null)
            {
                request.DefaultSegmentDeliveryConfiguration.BaseUrl = requestDefaultSegmentDeliveryConfiguration_defaultSegmentDeliveryConfiguration_BaseUrl;
                requestDefaultSegmentDeliveryConfigurationIsNull = false;
            }
             // determine if request.DefaultSegmentDeliveryConfiguration should be set to null
            if (requestDefaultSegmentDeliveryConfigurationIsNull)
            {
                request.DefaultSegmentDeliveryConfiguration = null;
            }
            
             // populate HttpConfiguration
            var requestHttpConfigurationIsNull = true;
            request.HttpConfiguration = new Amazon.MediaTailor.Model.HttpConfiguration();
            System.String requestHttpConfiguration_httpConfiguration_BaseUrl = null;
            if (cmdletContext.HttpConfiguration_BaseUrl != null)
            {
                requestHttpConfiguration_httpConfiguration_BaseUrl = cmdletContext.HttpConfiguration_BaseUrl;
            }
            if (requestHttpConfiguration_httpConfiguration_BaseUrl != null)
            {
                request.HttpConfiguration.BaseUrl = requestHttpConfiguration_httpConfiguration_BaseUrl;
                requestHttpConfigurationIsNull = false;
            }
             // determine if request.HttpConfiguration should be set to null
            if (requestHttpConfigurationIsNull)
            {
                request.HttpConfiguration = null;
            }
            if (cmdletContext.SegmentDeliveryConfiguration != null)
            {
                request.SegmentDeliveryConfigurations = cmdletContext.SegmentDeliveryConfiguration;
            }
            if (cmdletContext.SourceLocationName != null)
            {
                request.SourceLocationName = cmdletContext.SourceLocationName;
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
        
        private Amazon.MediaTailor.Model.CreateSourceLocationResponse CallAWSServiceOperation(IAmazonMediaTailor client, Amazon.MediaTailor.Model.CreateSourceLocationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaTailor", "CreateSourceLocation");
            try
            {
                #if DESKTOP
                return client.CreateSourceLocation(request);
                #elif CORECLR
                return client.CreateSourceLocationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.MediaTailor.AccessType AccessConfiguration_AccessType { get; set; }
            public System.String SecretsManagerAccessTokenConfiguration_HeaderName { get; set; }
            public System.String SecretsManagerAccessTokenConfiguration_SecretArn { get; set; }
            public System.String SecretsManagerAccessTokenConfiguration_SecretStringKey { get; set; }
            public System.String DefaultSegmentDeliveryConfiguration_BaseUrl { get; set; }
            public System.String HttpConfiguration_BaseUrl { get; set; }
            public List<Amazon.MediaTailor.Model.SegmentDeliveryConfiguration> SegmentDeliveryConfiguration { get; set; }
            public System.String SourceLocationName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.MediaTailor.Model.CreateSourceLocationResponse, NewEMTSourceLocationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
