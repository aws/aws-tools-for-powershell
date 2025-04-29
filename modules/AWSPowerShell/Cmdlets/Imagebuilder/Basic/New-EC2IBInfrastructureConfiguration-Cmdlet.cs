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
using System.Threading;
using Amazon.Imagebuilder;
using Amazon.Imagebuilder.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2IB
{
    /// <summary>
    /// Creates a new infrastructure configuration. An infrastructure configuration defines
    /// the environment in which your image will be built and tested.
    /// </summary>
    [Cmdlet("New", "EC2IBInfrastructureConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the EC2 Image Builder CreateInfrastructureConfiguration API operation.", Operation = new[] {"CreateInfrastructureConfiguration"}, SelectReturnType = typeof(Amazon.Imagebuilder.Model.CreateInfrastructureConfigurationResponse))]
    [AWSCmdletOutput("System.String or Amazon.Imagebuilder.Model.CreateInfrastructureConfigurationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Imagebuilder.Model.CreateInfrastructureConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2IBInfrastructureConfigurationCmdlet : AmazonImagebuilderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Placement_AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone where your build and test instances will launch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Placement_AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the infrastructure configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Placement_HostId
        /// <summary>
        /// <para>
        /// <para>The ID of the Dedicated Host on which build and test instances run. This only applies
        /// if <c>tenancy</c> is <c>host</c>. If you specify the host ID, you must not specify
        /// the resource group ARN. If you specify both, Image Builder returns an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Placement_HostId { get; set; }
        #endregion
        
        #region Parameter Placement_HostResourceGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the host resource group in which to launch build
        /// and test instances. This only applies if <c>tenancy</c> is <c>host</c>. If you specify
        /// the resource group ARN, you must not specify the host ID. If you specify both, Image
        /// Builder returns an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Placement_HostResourceGroupArn { get; set; }
        #endregion
        
        #region Parameter InstanceMetadataOptions_HttpPutResponseHopLimit
        /// <summary>
        /// <para>
        /// <para>Limit the number of hops that an instance metadata request can traverse to reach its
        /// destination. The default is one hop. However, if HTTP tokens are required, container
        /// image builds need a minimum of two hops.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceMetadataOptions_HttpPutResponseHopLimit { get; set; }
        #endregion
        
        #region Parameter InstanceMetadataOptions_HttpToken
        /// <summary>
        /// <para>
        /// <para>Indicates whether a signed token header is required for instance metadata retrieval
        /// requests. The values affect the response as follows:</para><ul><li><para><b>required</b> – When you retrieve the IAM role credentials, version 2.0 credentials
        /// are returned in all cases.</para></li><li><para><b>optional</b> – You can include a signed token header in your request to retrieve
        /// instance metadata, or you can leave it out. If you include it, version 2.0 credentials
        /// are returned for the IAM role. Otherwise, version 1.0 credentials are returned.</para></li></ul><para>The default setting is <b>optional</b>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceMetadataOptions_HttpTokens")]
        public System.String InstanceMetadataOptions_HttpToken { get; set; }
        #endregion
        
        #region Parameter InstanceProfileName
        /// <summary>
        /// <para>
        /// <para>The instance profile to associate with the instance used to customize your Amazon
        /// EC2 AMI.</para>
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
        public System.String InstanceProfileName { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance types of the infrastructure configuration. You can specify one or more
        /// instance types to use for this build. The service will pick one of these instance
        /// types based on availability.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceTypes")]
        public System.String[] InstanceType { get; set; }
        #endregion
        
        #region Parameter KeyPair
        /// <summary>
        /// <para>
        /// <para>The key pair of the infrastructure configuration. You can use this to log on to and
        /// debug the instance used to create your image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyPair { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the infrastructure configuration.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ResourceTag
        /// <summary>
        /// <para>
        /// <para>The metadata tags to assign to the Amazon EC2 instance that Image Builder launches
        /// during the build process. Tags are formatted as key value pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTags")]
        public System.Collections.Hashtable ResourceTag { get; set; }
        #endregion
        
        #region Parameter S3Logs_S3BucketName
        /// <summary>
        /// <para>
        /// <para>The S3 bucket in which to store the logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Logging_S3Logs_S3BucketName")]
        public System.String S3Logs_S3BucketName { get; set; }
        #endregion
        
        #region Parameter S3Logs_S3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 path to the bucket where the logs are stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Logging_S3Logs_S3KeyPrefix")]
        public System.String S3Logs_S3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The security group IDs to associate with the instance used to customize your Amazon
        /// EC2 AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SnsTopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the SNS topic to which we send image build event
        /// notifications.</para><note><para>EC2 Image Builder is unable to send notifications to SNS topics that are encrypted
        /// using keys from other accounts. The key that is used to encrypt the SNS topic must
        /// reside in the account that the Image Builder service runs under.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnsTopicArn { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The subnet ID in which to place the instance used to customize your Amazon EC2 AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata tags to assign to the infrastructure configuration resource that Image
        /// Builder creates as output. Tags are formatted as key value pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Placement_Tenancy
        /// <summary>
        /// <para>
        /// <para>The tenancy of the instance. An instance with a tenancy of <c>dedicated</c> runs on
        /// single-tenant hardware. An instance with a tenancy of <c>host</c> runs on a Dedicated
        /// Host.</para><para>If tenancy is set to <c>host</c>, then you can optionally specify one target for placement
        /// – either host ID or host resource group ARN. If automatic placement is enabled for
        /// your host, and you don't specify any placement target, Amazon EC2 will try to find
        /// an available host for your build and test instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Imagebuilder.TenancyType")]
        public Amazon.Imagebuilder.TenancyType Placement_Tenancy { get; set; }
        #endregion
        
        #region Parameter TerminateInstanceOnFailure
        /// <summary>
        /// <para>
        /// <para>The terminate instance on failure setting of the infrastructure configuration. Set
        /// to false if you want Image Builder to retain the instance used to configure your AMI
        /// if the build or test phase of your workflow fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TerminateInstanceOnFailure { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure idempotency of the request.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a> in the <i>Amazon EC2 API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InfrastructureConfigurationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Imagebuilder.Model.CreateInfrastructureConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Imagebuilder.Model.CreateInfrastructureConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InfrastructureConfigurationArn";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2IBInfrastructureConfiguration (CreateInfrastructureConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Imagebuilder.Model.CreateInfrastructureConfigurationResponse, NewEC2IBInfrastructureConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.InstanceMetadataOptions_HttpPutResponseHopLimit = this.InstanceMetadataOptions_HttpPutResponseHopLimit;
            context.InstanceMetadataOptions_HttpToken = this.InstanceMetadataOptions_HttpToken;
            context.InstanceProfileName = this.InstanceProfileName;
            #if MODULAR
            if (this.InstanceProfileName == null && ParameterWasBound(nameof(this.InstanceProfileName)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceProfileName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InstanceType != null)
            {
                context.InstanceType = new List<System.String>(this.InstanceType);
            }
            context.KeyPair = this.KeyPair;
            context.S3Logs_S3BucketName = this.S3Logs_S3BucketName;
            context.S3Logs_S3KeyPrefix = this.S3Logs_S3KeyPrefix;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Placement_AvailabilityZone = this.Placement_AvailabilityZone;
            context.Placement_HostId = this.Placement_HostId;
            context.Placement_HostResourceGroupArn = this.Placement_HostResourceGroupArn;
            context.Placement_Tenancy = this.Placement_Tenancy;
            if (this.ResourceTag != null)
            {
                context.ResourceTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ResourceTag.Keys)
                {
                    context.ResourceTag.Add((String)hashKey, (System.String)(this.ResourceTag[hashKey]));
                }
            }
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            context.SnsTopicArn = this.SnsTopicArn;
            context.SubnetId = this.SubnetId;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.TerminateInstanceOnFailure = this.TerminateInstanceOnFailure;
            
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
            var request = new Amazon.Imagebuilder.Model.CreateInfrastructureConfigurationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate InstanceMetadataOptions
            var requestInstanceMetadataOptionsIsNull = true;
            request.InstanceMetadataOptions = new Amazon.Imagebuilder.Model.InstanceMetadataOptions();
            System.Int32? requestInstanceMetadataOptions_instanceMetadataOptions_HttpPutResponseHopLimit = null;
            if (cmdletContext.InstanceMetadataOptions_HttpPutResponseHopLimit != null)
            {
                requestInstanceMetadataOptions_instanceMetadataOptions_HttpPutResponseHopLimit = cmdletContext.InstanceMetadataOptions_HttpPutResponseHopLimit.Value;
            }
            if (requestInstanceMetadataOptions_instanceMetadataOptions_HttpPutResponseHopLimit != null)
            {
                request.InstanceMetadataOptions.HttpPutResponseHopLimit = requestInstanceMetadataOptions_instanceMetadataOptions_HttpPutResponseHopLimit.Value;
                requestInstanceMetadataOptionsIsNull = false;
            }
            System.String requestInstanceMetadataOptions_instanceMetadataOptions_HttpToken = null;
            if (cmdletContext.InstanceMetadataOptions_HttpToken != null)
            {
                requestInstanceMetadataOptions_instanceMetadataOptions_HttpToken = cmdletContext.InstanceMetadataOptions_HttpToken;
            }
            if (requestInstanceMetadataOptions_instanceMetadataOptions_HttpToken != null)
            {
                request.InstanceMetadataOptions.HttpTokens = requestInstanceMetadataOptions_instanceMetadataOptions_HttpToken;
                requestInstanceMetadataOptionsIsNull = false;
            }
             // determine if request.InstanceMetadataOptions should be set to null
            if (requestInstanceMetadataOptionsIsNull)
            {
                request.InstanceMetadataOptions = null;
            }
            if (cmdletContext.InstanceProfileName != null)
            {
                request.InstanceProfileName = cmdletContext.InstanceProfileName;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceTypes = cmdletContext.InstanceType;
            }
            if (cmdletContext.KeyPair != null)
            {
                request.KeyPair = cmdletContext.KeyPair;
            }
            
             // populate Logging
            var requestLoggingIsNull = true;
            request.Logging = new Amazon.Imagebuilder.Model.Logging();
            Amazon.Imagebuilder.Model.S3Logs requestLogging_logging_S3Logs = null;
            
             // populate S3Logs
            var requestLogging_logging_S3LogsIsNull = true;
            requestLogging_logging_S3Logs = new Amazon.Imagebuilder.Model.S3Logs();
            System.String requestLogging_logging_S3Logs_s3Logs_S3BucketName = null;
            if (cmdletContext.S3Logs_S3BucketName != null)
            {
                requestLogging_logging_S3Logs_s3Logs_S3BucketName = cmdletContext.S3Logs_S3BucketName;
            }
            if (requestLogging_logging_S3Logs_s3Logs_S3BucketName != null)
            {
                requestLogging_logging_S3Logs.S3BucketName = requestLogging_logging_S3Logs_s3Logs_S3BucketName;
                requestLogging_logging_S3LogsIsNull = false;
            }
            System.String requestLogging_logging_S3Logs_s3Logs_S3KeyPrefix = null;
            if (cmdletContext.S3Logs_S3KeyPrefix != null)
            {
                requestLogging_logging_S3Logs_s3Logs_S3KeyPrefix = cmdletContext.S3Logs_S3KeyPrefix;
            }
            if (requestLogging_logging_S3Logs_s3Logs_S3KeyPrefix != null)
            {
                requestLogging_logging_S3Logs.S3KeyPrefix = requestLogging_logging_S3Logs_s3Logs_S3KeyPrefix;
                requestLogging_logging_S3LogsIsNull = false;
            }
             // determine if requestLogging_logging_S3Logs should be set to null
            if (requestLogging_logging_S3LogsIsNull)
            {
                requestLogging_logging_S3Logs = null;
            }
            if (requestLogging_logging_S3Logs != null)
            {
                request.Logging.S3Logs = requestLogging_logging_S3Logs;
                requestLoggingIsNull = false;
            }
             // determine if request.Logging should be set to null
            if (requestLoggingIsNull)
            {
                request.Logging = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Placement
            var requestPlacementIsNull = true;
            request.Placement = new Amazon.Imagebuilder.Model.Placement();
            System.String requestPlacement_placement_AvailabilityZone = null;
            if (cmdletContext.Placement_AvailabilityZone != null)
            {
                requestPlacement_placement_AvailabilityZone = cmdletContext.Placement_AvailabilityZone;
            }
            if (requestPlacement_placement_AvailabilityZone != null)
            {
                request.Placement.AvailabilityZone = requestPlacement_placement_AvailabilityZone;
                requestPlacementIsNull = false;
            }
            System.String requestPlacement_placement_HostId = null;
            if (cmdletContext.Placement_HostId != null)
            {
                requestPlacement_placement_HostId = cmdletContext.Placement_HostId;
            }
            if (requestPlacement_placement_HostId != null)
            {
                request.Placement.HostId = requestPlacement_placement_HostId;
                requestPlacementIsNull = false;
            }
            System.String requestPlacement_placement_HostResourceGroupArn = null;
            if (cmdletContext.Placement_HostResourceGroupArn != null)
            {
                requestPlacement_placement_HostResourceGroupArn = cmdletContext.Placement_HostResourceGroupArn;
            }
            if (requestPlacement_placement_HostResourceGroupArn != null)
            {
                request.Placement.HostResourceGroupArn = requestPlacement_placement_HostResourceGroupArn;
                requestPlacementIsNull = false;
            }
            Amazon.Imagebuilder.TenancyType requestPlacement_placement_Tenancy = null;
            if (cmdletContext.Placement_Tenancy != null)
            {
                requestPlacement_placement_Tenancy = cmdletContext.Placement_Tenancy;
            }
            if (requestPlacement_placement_Tenancy != null)
            {
                request.Placement.Tenancy = requestPlacement_placement_Tenancy;
                requestPlacementIsNull = false;
            }
             // determine if request.Placement should be set to null
            if (requestPlacementIsNull)
            {
                request.Placement = null;
            }
            if (cmdletContext.ResourceTag != null)
            {
                request.ResourceTags = cmdletContext.ResourceTag;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.SnsTopicArn != null)
            {
                request.SnsTopicArn = cmdletContext.SnsTopicArn;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TerminateInstanceOnFailure != null)
            {
                request.TerminateInstanceOnFailure = cmdletContext.TerminateInstanceOnFailure.Value;
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
        
        private Amazon.Imagebuilder.Model.CreateInfrastructureConfigurationResponse CallAWSServiceOperation(IAmazonImagebuilder client, Amazon.Imagebuilder.Model.CreateInfrastructureConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EC2 Image Builder", "CreateInfrastructureConfiguration");
            try
            {
                return client.CreateInfrastructureConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.Int32? InstanceMetadataOptions_HttpPutResponseHopLimit { get; set; }
            public System.String InstanceMetadataOptions_HttpToken { get; set; }
            public System.String InstanceProfileName { get; set; }
            public List<System.String> InstanceType { get; set; }
            public System.String KeyPair { get; set; }
            public System.String S3Logs_S3BucketName { get; set; }
            public System.String S3Logs_S3KeyPrefix { get; set; }
            public System.String Name { get; set; }
            public System.String Placement_AvailabilityZone { get; set; }
            public System.String Placement_HostId { get; set; }
            public System.String Placement_HostResourceGroupArn { get; set; }
            public Amazon.Imagebuilder.TenancyType Placement_Tenancy { get; set; }
            public Dictionary<System.String, System.String> ResourceTag { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public System.String SnsTopicArn { get; set; }
            public System.String SubnetId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Boolean? TerminateInstanceOnFailure { get; set; }
            public System.Func<Amazon.Imagebuilder.Model.CreateInfrastructureConfigurationResponse, NewEC2IBInfrastructureConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InfrastructureConfigurationArn;
        }
        
    }
}
