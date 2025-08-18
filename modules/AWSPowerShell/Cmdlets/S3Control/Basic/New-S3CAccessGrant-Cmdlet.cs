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
using Amazon.S3Control;
using Amazon.S3Control.Model;

namespace Amazon.PowerShell.Cmdlets.S3C
{
    /// <summary>
    /// Creates an access grant that gives a grantee access to your S3 data. The grantee can
    /// be an IAM user or role or a directory user, or group. Before you can create a grant,
    /// you must have an S3 Access Grants instance in the same Region as the S3 data. You
    /// can create an S3 Access Grants instance using the <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_CreateAccessGrantsInstance.html">CreateAccessGrantsInstance</a>.
    /// You must also have registered at least one S3 data location in your S3 Access Grants
    /// instance using <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_CreateAccessGrantsLocation.html">CreateAccessGrantsLocation</a>.
    /// 
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3:CreateAccessGrant</c> permission to use this operation. 
    /// </para></dd><dt>Additional Permissions</dt><dd><para>
    /// For any directory identity - <c>sso:DescribeInstance</c> and <c>sso:DescribeApplication</c></para><para>
    /// For directory users - <c>identitystore:DescribeUser</c></para><para>
    /// For directory groups - <c>identitystore:DescribeGroup</c></para></dd></dl><important><para>
    /// You must URL encode any signed header values that contain spaces. For example, if
    /// your header value is <c>my file.txt</c>, containing two spaces after <c>my</c>, you
    /// must URL encode this value to <c>my%20%20file.txt</c>.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "S3CAccessGrant", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3Control.Model.CreateAccessGrantResponse")]
    [AWSCmdlet("Calls the Amazon S3 Control CreateAccessGrant API operation.", Operation = new[] {"CreateAccessGrant"}, SelectReturnType = typeof(Amazon.S3Control.Model.CreateAccessGrantResponse))]
    [AWSCmdletOutput("Amazon.S3Control.Model.CreateAccessGrantResponse",
        "This cmdlet returns an Amazon.S3Control.Model.CreateAccessGrantResponse object containing multiple properties."
    )]
    public partial class NewS3CAccessGrantCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessGrantsLocationId
        /// <summary>
        /// <para>
        /// <para>The ID of the registered location to which you are granting access. S3 Access Grants
        /// assigns this ID when you register the location. S3 Access Grants assigns the ID <c>default</c>
        /// to the default location <c>s3://</c> and assigns an auto-generated ID to other locations
        /// that you register. </para><para>If you are passing the <c>default</c> location, you cannot create an access grant
        /// for the entire default location. You must also specify a bucket or a bucket and prefix
        /// in the <c>Subprefix</c> field. </para>
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
        public System.String AccessGrantsLocationId { get; set; }
        #endregion
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the S3 Access Grants instance.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter ApplicationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an Amazon Web Services IAM Identity Center application
        /// associated with your Identity Center instance. If an application ARN is included in
        /// the request to create an access grant, the grantee can only access the S3 data through
        /// this application. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationArn { get; set; }
        #endregion
        
        #region Parameter Grantee_GranteeIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the <c>Grantee</c>. If the grantee type is <c>IAM</c>, the
        /// identifier is the IAM Amazon Resource Name (ARN) of the user or role. If the grantee
        /// type is a directory user or group, the identifier is 128-bit universally unique identifier
        /// (UUID) in the format <c>a1b2c3d4-5678-90ab-cdef-EXAMPLE11111</c>. You can obtain this
        /// UUID from your Amazon Web Services IAM Identity Center instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Grantee_GranteeIdentifier { get; set; }
        #endregion
        
        #region Parameter Grantee_GranteeType
        /// <summary>
        /// <para>
        /// <para>The type of the grantee to which access has been granted. It can be one of the following
        /// values:</para><ul><li><para><c>IAM</c> - An IAM user or role.</para></li><li><para><c>DIRECTORY_USER</c> - Your corporate directory user. You can use this option if
        /// you have added your corporate identity directory to IAM Identity Center and associated
        /// the IAM Identity Center instance with your S3 Access Grants instance.</para></li><li><para><c>DIRECTORY_GROUP</c> - Your corporate directory group. You can use this option
        /// if you have added your corporate identity directory to IAM Identity Center and associated
        /// the IAM Identity Center instance with your S3 Access Grants instance.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Control.GranteeType")]
        public Amazon.S3Control.GranteeType Grantee_GranteeType { get; set; }
        #endregion
        
        #region Parameter Permission
        /// <summary>
        /// <para>
        /// <para>The type of access that you are granting to your S3 data, which can be set to one
        /// of the following values:</para><ul><li><para><c>READ</c> – Grant read-only access to the S3 data.</para></li><li><para><c>WRITE</c> – Grant write-only access to the S3 data.</para></li><li><para><c>READWRITE</c> – Grant both read and write access to the S3 data.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.S3Control.Permission")]
        public Amazon.S3Control.Permission Permission { get; set; }
        #endregion
        
        #region Parameter S3PrefixType
        /// <summary>
        /// <para>
        /// <para>The type of <c>S3SubPrefix</c>. The only possible value is <c>Object</c>. Pass this
        /// value if the access grant scope is an object. Do not pass this value if the access
        /// grant scope is a bucket or a bucket and a prefix. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Control.S3PrefixType")]
        public Amazon.S3Control.S3PrefixType S3PrefixType { get; set; }
        #endregion
        
        #region Parameter AccessGrantsLocationConfiguration_S3SubPrefix
        /// <summary>
        /// <para>
        /// <para>The <c>S3SubPrefix</c> is appended to the location scope creating the grant scope.
        /// Use this field to narrow the scope of the grant to a subset of the location scope.
        /// This field is required if the location scope is the default location <c>s3://</c>
        /// because you cannot create a grant for all of your S3 data in the Region and must narrow
        /// the scope. For example, if the location scope is the default location <c>s3://</c>,
        /// the <c>S3SubPrefx</c> can be a &lt;bucket-name&gt;/*, so the full grant scope path
        /// would be <c>s3://&lt;bucket-name&gt;/*</c>. Or the <c>S3SubPrefx</c> can be <c>&lt;bucket-name&gt;/&lt;prefix-name&gt;*</c>,
        /// so the full grant scope path would be or <c>s3://&lt;bucket-name&gt;/&lt;prefix-name&gt;*</c>.</para><para>If the <c>S3SubPrefix</c> includes a prefix, append the wildcard character <c>*</c>
        /// after the prefix to indicate that you want to include all object key names in the
        /// bucket that start with that prefix. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessGrantsLocationConfiguration_S3SubPrefix { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services resource tags that you are adding to the access grant. Each
        /// tag is a label consisting of a user-defined key and value. Tags can help you manage,
        /// identify, organize, search for, and filter resources. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.S3Control.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.CreateAccessGrantResponse).
        /// Specifying the name of a property of type Amazon.S3Control.Model.CreateAccessGrantResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AccessGrantsLocationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AccessGrantsLocationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AccessGrantsLocationId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "s3v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccessGrantsLocationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-S3CAccessGrant (CreateAccessGrant)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.CreateAccessGrantResponse, NewS3CAccessGrantCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AccessGrantsLocationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccessGrantsLocationConfiguration_S3SubPrefix = this.AccessGrantsLocationConfiguration_S3SubPrefix;
            context.AccessGrantsLocationId = this.AccessGrantsLocationId;
            #if MODULAR
            if (this.AccessGrantsLocationId == null && ParameterWasBound(nameof(this.AccessGrantsLocationId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessGrantsLocationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApplicationArn = this.ApplicationArn;
            context.Grantee_GranteeIdentifier = this.Grantee_GranteeIdentifier;
            context.Grantee_GranteeType = this.Grantee_GranteeType;
            context.Permission = this.Permission;
            #if MODULAR
            if (this.Permission == null && ParameterWasBound(nameof(this.Permission)))
            {
                WriteWarning("You are passing $null as a value for parameter Permission which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3PrefixType = this.S3PrefixType;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.S3Control.Model.Tag>(this.Tag);
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
            var request = new Amazon.S3Control.Model.CreateAccessGrantRequest();
            
            
             // populate AccessGrantsLocationConfiguration
            var requestAccessGrantsLocationConfigurationIsNull = true;
            request.AccessGrantsLocationConfiguration = new Amazon.S3Control.Model.AccessGrantsLocationConfiguration();
            System.String requestAccessGrantsLocationConfiguration_accessGrantsLocationConfiguration_S3SubPrefix = null;
            if (cmdletContext.AccessGrantsLocationConfiguration_S3SubPrefix != null)
            {
                requestAccessGrantsLocationConfiguration_accessGrantsLocationConfiguration_S3SubPrefix = cmdletContext.AccessGrantsLocationConfiguration_S3SubPrefix;
            }
            if (requestAccessGrantsLocationConfiguration_accessGrantsLocationConfiguration_S3SubPrefix != null)
            {
                request.AccessGrantsLocationConfiguration.S3SubPrefix = requestAccessGrantsLocationConfiguration_accessGrantsLocationConfiguration_S3SubPrefix;
                requestAccessGrantsLocationConfigurationIsNull = false;
            }
             // determine if request.AccessGrantsLocationConfiguration should be set to null
            if (requestAccessGrantsLocationConfigurationIsNull)
            {
                request.AccessGrantsLocationConfiguration = null;
            }
            if (cmdletContext.AccessGrantsLocationId != null)
            {
                request.AccessGrantsLocationId = cmdletContext.AccessGrantsLocationId;
            }
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.ApplicationArn != null)
            {
                request.ApplicationArn = cmdletContext.ApplicationArn;
            }
            
             // populate Grantee
            var requestGranteeIsNull = true;
            request.Grantee = new Amazon.S3Control.Model.Grantee();
            System.String requestGrantee_grantee_GranteeIdentifier = null;
            if (cmdletContext.Grantee_GranteeIdentifier != null)
            {
                requestGrantee_grantee_GranteeIdentifier = cmdletContext.Grantee_GranteeIdentifier;
            }
            if (requestGrantee_grantee_GranteeIdentifier != null)
            {
                request.Grantee.GranteeIdentifier = requestGrantee_grantee_GranteeIdentifier;
                requestGranteeIsNull = false;
            }
            Amazon.S3Control.GranteeType requestGrantee_grantee_GranteeType = null;
            if (cmdletContext.Grantee_GranteeType != null)
            {
                requestGrantee_grantee_GranteeType = cmdletContext.Grantee_GranteeType;
            }
            if (requestGrantee_grantee_GranteeType != null)
            {
                request.Grantee.GranteeType = requestGrantee_grantee_GranteeType;
                requestGranteeIsNull = false;
            }
             // determine if request.Grantee should be set to null
            if (requestGranteeIsNull)
            {
                request.Grantee = null;
            }
            if (cmdletContext.Permission != null)
            {
                request.Permission = cmdletContext.Permission;
            }
            if (cmdletContext.S3PrefixType != null)
            {
                request.S3PrefixType = cmdletContext.S3PrefixType;
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
        
        private Amazon.S3Control.Model.CreateAccessGrantResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.CreateAccessGrantRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "CreateAccessGrant");
            try
            {
                #if DESKTOP
                return client.CreateAccessGrant(request);
                #elif CORECLR
                return client.CreateAccessGrantAsync(request).GetAwaiter().GetResult();
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
            public System.String AccessGrantsLocationConfiguration_S3SubPrefix { get; set; }
            public System.String AccessGrantsLocationId { get; set; }
            public System.String AccountId { get; set; }
            public System.String ApplicationArn { get; set; }
            public System.String Grantee_GranteeIdentifier { get; set; }
            public Amazon.S3Control.GranteeType Grantee_GranteeType { get; set; }
            public Amazon.S3Control.Permission Permission { get; set; }
            public Amazon.S3Control.S3PrefixType S3PrefixType { get; set; }
            public List<Amazon.S3Control.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.S3Control.Model.CreateAccessGrantResponse, NewS3CAccessGrantCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
