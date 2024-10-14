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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Updates an existing Amazon Lightsail bucket.
    /// 
    ///  
    /// <para>
    /// Use this action to update the configuration of an existing bucket, such as versioning,
    /// public accessibility, and the Amazon Web Services accounts that can access the bucket.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LSBucket", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.UpdateBucketResponse")]
    [AWSCmdlet("Calls the Amazon Lightsail UpdateBucket API operation.", Operation = new[] {"UpdateBucket"}, SelectReturnType = typeof(Amazon.Lightsail.Model.UpdateBucketResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.UpdateBucketResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.UpdateBucketResponse object containing multiple properties."
    )]
    public partial class UpdateLSBucketCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessRules_AllowPublicOverride
        /// <summary>
        /// <para>
        /// <para>A Boolean value that indicates whether the access control list (ACL) permissions that
        /// are applied to individual objects override the <c>getObject</c> option that is currently
        /// specified.</para><para>When this is true, you can use the <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutObjectAcl.html">PutObjectAcl</a>
        /// Amazon S3 API action to set individual objects to public (read-only) using the <c>public-read</c>
        /// ACL, or to private using the <c>private</c> ACL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessRules_AllowPublicOverrides")]
        public System.Boolean? AccessRules_AllowPublicOverride { get; set; }
        #endregion
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the bucket to update.</para>
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
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter AccessLogConfig_Destination
        /// <summary>
        /// <para>
        /// <para>The name of the bucket where the access logs are saved. The destination can be a Lightsail
        /// bucket in the same account, and in the same Amazon Web Services Region as the source
        /// bucket.</para><note><para>This parameter is required when enabling the access log for a bucket, and should be
        /// omitted when disabling the access log.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessLogConfig_Destination { get; set; }
        #endregion
        
        #region Parameter AccessLogConfig_Enabled
        /// <summary>
        /// <para>
        /// <para>A Boolean value that indicates whether bucket access logging is enabled for the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AccessLogConfig_Enabled { get; set; }
        #endregion
        
        #region Parameter AccessRules_GetObject
        /// <summary>
        /// <para>
        /// <para>Specifies the anonymous access to all objects in a bucket.</para><para>The following options can be specified:</para><ul><li><para><c>public</c> - Sets all objects in the bucket to public (read-only), making them
        /// readable by anyone in the world.</para><para>If the <c>getObject</c> value is set to <c>public</c>, then all objects in the bucket
        /// default to public regardless of the <c>allowPublicOverrides</c> value.</para></li><li><para><c>private</c> - Sets all objects in the bucket to private, making them readable
        /// only by you or anyone you give access to.</para><para>If the <c>getObject</c> value is set to <c>private</c>, and the <c>allowPublicOverrides</c>
        /// value is set to <c>true</c>, then all objects in the bucket default to private unless
        /// they are configured with a <c>public-read</c> ACL. Individual objects with a <c>public-read</c>
        /// ACL are readable by anyone in the world.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lightsail.AccessType")]
        public Amazon.Lightsail.AccessType AccessRules_GetObject { get; set; }
        #endregion
        
        #region Parameter AccessLogConfig_Prefix
        /// <summary>
        /// <para>
        /// <para>The optional object prefix for the bucket access log.</para><para>The prefix is an optional addition to the object key that organizes your access log
        /// files in the destination bucket. For example, if you specify a <c>logs/</c> prefix,
        /// then each log object will begin with the <c>logs/</c> prefix in its key (for example,
        /// <c>logs/2021-11-01-21-32-16-E568B2907131C0C0</c>).</para><note><para>This parameter can be optionally specified when enabling the access log for a bucket,
        /// and should be omitted when disabling the access log.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessLogConfig_Prefix { get; set; }
        #endregion
        
        #region Parameter ReadonlyAccessAccount
        /// <summary>
        /// <para>
        /// <para>An array of strings to specify the Amazon Web Services account IDs that can access
        /// the bucket.</para><para>You can give a maximum of 10 Amazon Web Services accounts access to a bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReadonlyAccessAccounts")]
        public System.String[] ReadonlyAccessAccount { get; set; }
        #endregion
        
        #region Parameter Versioning
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable or suspend versioning of objects in the bucket.</para><para>The following options can be specified:</para><ul><li><para><c>Enabled</c> - Enables versioning of objects in the specified bucket.</para></li><li><para><c>Suspended</c> - Suspends versioning of objects in the specified bucket. Existing
        /// object versions are retained.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Versioning { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.UpdateBucketResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.UpdateBucketResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BucketName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LSBucket (UpdateBucket)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.UpdateBucketResponse, UpdateLSBucketCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BucketName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccessLogConfig_Destination = this.AccessLogConfig_Destination;
            context.AccessLogConfig_Enabled = this.AccessLogConfig_Enabled;
            context.AccessLogConfig_Prefix = this.AccessLogConfig_Prefix;
            context.AccessRules_AllowPublicOverride = this.AccessRules_AllowPublicOverride;
            context.AccessRules_GetObject = this.AccessRules_GetObject;
            context.BucketName = this.BucketName;
            #if MODULAR
            if (this.BucketName == null && ParameterWasBound(nameof(this.BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ReadonlyAccessAccount != null)
            {
                context.ReadonlyAccessAccount = new List<System.String>(this.ReadonlyAccessAccount);
            }
            context.Versioning = this.Versioning;
            
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
            var request = new Amazon.Lightsail.Model.UpdateBucketRequest();
            
            
             // populate AccessLogConfig
            var requestAccessLogConfigIsNull = true;
            request.AccessLogConfig = new Amazon.Lightsail.Model.BucketAccessLogConfig();
            System.String requestAccessLogConfig_accessLogConfig_Destination = null;
            if (cmdletContext.AccessLogConfig_Destination != null)
            {
                requestAccessLogConfig_accessLogConfig_Destination = cmdletContext.AccessLogConfig_Destination;
            }
            if (requestAccessLogConfig_accessLogConfig_Destination != null)
            {
                request.AccessLogConfig.Destination = requestAccessLogConfig_accessLogConfig_Destination;
                requestAccessLogConfigIsNull = false;
            }
            System.Boolean? requestAccessLogConfig_accessLogConfig_Enabled = null;
            if (cmdletContext.AccessLogConfig_Enabled != null)
            {
                requestAccessLogConfig_accessLogConfig_Enabled = cmdletContext.AccessLogConfig_Enabled.Value;
            }
            if (requestAccessLogConfig_accessLogConfig_Enabled != null)
            {
                request.AccessLogConfig.Enabled = requestAccessLogConfig_accessLogConfig_Enabled.Value;
                requestAccessLogConfigIsNull = false;
            }
            System.String requestAccessLogConfig_accessLogConfig_Prefix = null;
            if (cmdletContext.AccessLogConfig_Prefix != null)
            {
                requestAccessLogConfig_accessLogConfig_Prefix = cmdletContext.AccessLogConfig_Prefix;
            }
            if (requestAccessLogConfig_accessLogConfig_Prefix != null)
            {
                request.AccessLogConfig.Prefix = requestAccessLogConfig_accessLogConfig_Prefix;
                requestAccessLogConfigIsNull = false;
            }
             // determine if request.AccessLogConfig should be set to null
            if (requestAccessLogConfigIsNull)
            {
                request.AccessLogConfig = null;
            }
            
             // populate AccessRules
            var requestAccessRulesIsNull = true;
            request.AccessRules = new Amazon.Lightsail.Model.AccessRules();
            System.Boolean? requestAccessRules_accessRules_AllowPublicOverride = null;
            if (cmdletContext.AccessRules_AllowPublicOverride != null)
            {
                requestAccessRules_accessRules_AllowPublicOverride = cmdletContext.AccessRules_AllowPublicOverride.Value;
            }
            if (requestAccessRules_accessRules_AllowPublicOverride != null)
            {
                request.AccessRules.AllowPublicOverrides = requestAccessRules_accessRules_AllowPublicOverride.Value;
                requestAccessRulesIsNull = false;
            }
            Amazon.Lightsail.AccessType requestAccessRules_accessRules_GetObject = null;
            if (cmdletContext.AccessRules_GetObject != null)
            {
                requestAccessRules_accessRules_GetObject = cmdletContext.AccessRules_GetObject;
            }
            if (requestAccessRules_accessRules_GetObject != null)
            {
                request.AccessRules.GetObject = requestAccessRules_accessRules_GetObject;
                requestAccessRulesIsNull = false;
            }
             // determine if request.AccessRules should be set to null
            if (requestAccessRulesIsNull)
            {
                request.AccessRules = null;
            }
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ReadonlyAccessAccount != null)
            {
                request.ReadonlyAccessAccounts = cmdletContext.ReadonlyAccessAccount;
            }
            if (cmdletContext.Versioning != null)
            {
                request.Versioning = cmdletContext.Versioning;
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
        
        private Amazon.Lightsail.Model.UpdateBucketResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.UpdateBucketRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "UpdateBucket");
            try
            {
                #if DESKTOP
                return client.UpdateBucket(request);
                #elif CORECLR
                return client.UpdateBucketAsync(request).GetAwaiter().GetResult();
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
            public System.String AccessLogConfig_Destination { get; set; }
            public System.Boolean? AccessLogConfig_Enabled { get; set; }
            public System.String AccessLogConfig_Prefix { get; set; }
            public System.Boolean? AccessRules_AllowPublicOverride { get; set; }
            public Amazon.Lightsail.AccessType AccessRules_GetObject { get; set; }
            public System.String BucketName { get; set; }
            public List<System.String> ReadonlyAccessAccount { get; set; }
            public System.String Versioning { get; set; }
            public System.Func<Amazon.Lightsail.Model.UpdateBucketResponse, UpdateLSBucketCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
