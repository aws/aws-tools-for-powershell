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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Creates a software bill of materials (SBOM) report.
    /// </summary>
    [Cmdlet("New", "INS2SbomExport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Inspector2 CreateSbomExport API operation.", Operation = new[] {"CreateSbomExport"}, SelectReturnType = typeof(Amazon.Inspector2.Model.CreateSbomExportResponse))]
    [AWSCmdletOutput("System.String or Amazon.Inspector2.Model.CreateSbomExportResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Inspector2.Model.CreateSbomExportResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewINS2SbomExportCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ResourceFilterCriteria_AccountId
        /// <summary>
        /// <para>
        /// <para>The account IDs used as resource filter criteria.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.ResourceStringFilter[] ResourceFilterCriteria_AccountId { get; set; }
        #endregion
        
        #region Parameter S3Destination_BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket to export findings to.</para>
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
        public System.String S3Destination_BucketName { get; set; }
        #endregion
        
        #region Parameter ResourceFilterCriteria_Ec2InstanceTag
        /// <summary>
        /// <para>
        /// <para>The EC2 instance tags used as resource filter criteria.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceFilterCriteria_Ec2InstanceTags")]
        public Amazon.Inspector2.Model.ResourceMapFilter[] ResourceFilterCriteria_Ec2InstanceTag { get; set; }
        #endregion
        
        #region Parameter ResourceFilterCriteria_EcrImageTag
        /// <summary>
        /// <para>
        /// <para>The ECR image tags used as resource filter criteria.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceFilterCriteria_EcrImageTags")]
        public Amazon.Inspector2.Model.ResourceStringFilter[] ResourceFilterCriteria_EcrImageTag { get; set; }
        #endregion
        
        #region Parameter ResourceFilterCriteria_EcrRepositoryName
        /// <summary>
        /// <para>
        /// <para>The ECR repository names used as resource filter criteria.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.ResourceStringFilter[] ResourceFilterCriteria_EcrRepositoryName { get; set; }
        #endregion
        
        #region Parameter S3Destination_KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The prefix that the findings will be written under.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Destination_KeyPrefix { get; set; }
        #endregion
        
        #region Parameter S3Destination_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key used to encrypt data when exporting findings.</para>
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
        public System.String S3Destination_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter ResourceFilterCriteria_LambdaFunctionName
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Lambda function name used as resource filter criteria.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.ResourceStringFilter[] ResourceFilterCriteria_LambdaFunctionName { get; set; }
        #endregion
        
        #region Parameter ResourceFilterCriteria_LambdaFunctionTag
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Lambda function tags used as resource filter criteria.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceFilterCriteria_LambdaFunctionTags")]
        public Amazon.Inspector2.Model.ResourceMapFilter[] ResourceFilterCriteria_LambdaFunctionTag { get; set; }
        #endregion
        
        #region Parameter ReportFormat
        /// <summary>
        /// <para>
        /// <para>The output format for the software bill of materials (SBOM) report.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Inspector2.SbomReportFormat")]
        public Amazon.Inspector2.SbomReportFormat ReportFormat { get; set; }
        #endregion
        
        #region Parameter ResourceFilterCriteria_ResourceId
        /// <summary>
        /// <para>
        /// <para>The resource IDs used as resource filter criteria.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.ResourceStringFilter[] ResourceFilterCriteria_ResourceId { get; set; }
        #endregion
        
        #region Parameter ResourceFilterCriteria_ResourceType
        /// <summary>
        /// <para>
        /// <para>The resource types used as resource filter criteria.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.ResourceStringFilter[] ResourceFilterCriteria_ResourceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReportId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.CreateSbomExportResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.CreateSbomExportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReportId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReportFormat), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-INS2SbomExport (CreateSbomExport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.CreateSbomExportResponse, NewINS2SbomExportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ReportFormat = this.ReportFormat;
            #if MODULAR
            if (this.ReportFormat == null && ParameterWasBound(nameof(this.ReportFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ResourceFilterCriteria_AccountId != null)
            {
                context.ResourceFilterCriteria_AccountId = new List<Amazon.Inspector2.Model.ResourceStringFilter>(this.ResourceFilterCriteria_AccountId);
            }
            if (this.ResourceFilterCriteria_Ec2InstanceTag != null)
            {
                context.ResourceFilterCriteria_Ec2InstanceTag = new List<Amazon.Inspector2.Model.ResourceMapFilter>(this.ResourceFilterCriteria_Ec2InstanceTag);
            }
            if (this.ResourceFilterCriteria_EcrImageTag != null)
            {
                context.ResourceFilterCriteria_EcrImageTag = new List<Amazon.Inspector2.Model.ResourceStringFilter>(this.ResourceFilterCriteria_EcrImageTag);
            }
            if (this.ResourceFilterCriteria_EcrRepositoryName != null)
            {
                context.ResourceFilterCriteria_EcrRepositoryName = new List<Amazon.Inspector2.Model.ResourceStringFilter>(this.ResourceFilterCriteria_EcrRepositoryName);
            }
            if (this.ResourceFilterCriteria_LambdaFunctionName != null)
            {
                context.ResourceFilterCriteria_LambdaFunctionName = new List<Amazon.Inspector2.Model.ResourceStringFilter>(this.ResourceFilterCriteria_LambdaFunctionName);
            }
            if (this.ResourceFilterCriteria_LambdaFunctionTag != null)
            {
                context.ResourceFilterCriteria_LambdaFunctionTag = new List<Amazon.Inspector2.Model.ResourceMapFilter>(this.ResourceFilterCriteria_LambdaFunctionTag);
            }
            if (this.ResourceFilterCriteria_ResourceId != null)
            {
                context.ResourceFilterCriteria_ResourceId = new List<Amazon.Inspector2.Model.ResourceStringFilter>(this.ResourceFilterCriteria_ResourceId);
            }
            if (this.ResourceFilterCriteria_ResourceType != null)
            {
                context.ResourceFilterCriteria_ResourceType = new List<Amazon.Inspector2.Model.ResourceStringFilter>(this.ResourceFilterCriteria_ResourceType);
            }
            context.S3Destination_BucketName = this.S3Destination_BucketName;
            #if MODULAR
            if (this.S3Destination_BucketName == null && ParameterWasBound(nameof(this.S3Destination_BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Destination_BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Destination_KeyPrefix = this.S3Destination_KeyPrefix;
            context.S3Destination_KmsKeyArn = this.S3Destination_KmsKeyArn;
            #if MODULAR
            if (this.S3Destination_KmsKeyArn == null && ParameterWasBound(nameof(this.S3Destination_KmsKeyArn)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Destination_KmsKeyArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Inspector2.Model.CreateSbomExportRequest();
            
            if (cmdletContext.ReportFormat != null)
            {
                request.ReportFormat = cmdletContext.ReportFormat;
            }
            
             // populate ResourceFilterCriteria
            var requestResourceFilterCriteriaIsNull = true;
            request.ResourceFilterCriteria = new Amazon.Inspector2.Model.ResourceFilterCriteria();
            List<Amazon.Inspector2.Model.ResourceStringFilter> requestResourceFilterCriteria_resourceFilterCriteria_AccountId = null;
            if (cmdletContext.ResourceFilterCriteria_AccountId != null)
            {
                requestResourceFilterCriteria_resourceFilterCriteria_AccountId = cmdletContext.ResourceFilterCriteria_AccountId;
            }
            if (requestResourceFilterCriteria_resourceFilterCriteria_AccountId != null)
            {
                request.ResourceFilterCriteria.AccountId = requestResourceFilterCriteria_resourceFilterCriteria_AccountId;
                requestResourceFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.ResourceMapFilter> requestResourceFilterCriteria_resourceFilterCriteria_Ec2InstanceTag = null;
            if (cmdletContext.ResourceFilterCriteria_Ec2InstanceTag != null)
            {
                requestResourceFilterCriteria_resourceFilterCriteria_Ec2InstanceTag = cmdletContext.ResourceFilterCriteria_Ec2InstanceTag;
            }
            if (requestResourceFilterCriteria_resourceFilterCriteria_Ec2InstanceTag != null)
            {
                request.ResourceFilterCriteria.Ec2InstanceTags = requestResourceFilterCriteria_resourceFilterCriteria_Ec2InstanceTag;
                requestResourceFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.ResourceStringFilter> requestResourceFilterCriteria_resourceFilterCriteria_EcrImageTag = null;
            if (cmdletContext.ResourceFilterCriteria_EcrImageTag != null)
            {
                requestResourceFilterCriteria_resourceFilterCriteria_EcrImageTag = cmdletContext.ResourceFilterCriteria_EcrImageTag;
            }
            if (requestResourceFilterCriteria_resourceFilterCriteria_EcrImageTag != null)
            {
                request.ResourceFilterCriteria.EcrImageTags = requestResourceFilterCriteria_resourceFilterCriteria_EcrImageTag;
                requestResourceFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.ResourceStringFilter> requestResourceFilterCriteria_resourceFilterCriteria_EcrRepositoryName = null;
            if (cmdletContext.ResourceFilterCriteria_EcrRepositoryName != null)
            {
                requestResourceFilterCriteria_resourceFilterCriteria_EcrRepositoryName = cmdletContext.ResourceFilterCriteria_EcrRepositoryName;
            }
            if (requestResourceFilterCriteria_resourceFilterCriteria_EcrRepositoryName != null)
            {
                request.ResourceFilterCriteria.EcrRepositoryName = requestResourceFilterCriteria_resourceFilterCriteria_EcrRepositoryName;
                requestResourceFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.ResourceStringFilter> requestResourceFilterCriteria_resourceFilterCriteria_LambdaFunctionName = null;
            if (cmdletContext.ResourceFilterCriteria_LambdaFunctionName != null)
            {
                requestResourceFilterCriteria_resourceFilterCriteria_LambdaFunctionName = cmdletContext.ResourceFilterCriteria_LambdaFunctionName;
            }
            if (requestResourceFilterCriteria_resourceFilterCriteria_LambdaFunctionName != null)
            {
                request.ResourceFilterCriteria.LambdaFunctionName = requestResourceFilterCriteria_resourceFilterCriteria_LambdaFunctionName;
                requestResourceFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.ResourceMapFilter> requestResourceFilterCriteria_resourceFilterCriteria_LambdaFunctionTag = null;
            if (cmdletContext.ResourceFilterCriteria_LambdaFunctionTag != null)
            {
                requestResourceFilterCriteria_resourceFilterCriteria_LambdaFunctionTag = cmdletContext.ResourceFilterCriteria_LambdaFunctionTag;
            }
            if (requestResourceFilterCriteria_resourceFilterCriteria_LambdaFunctionTag != null)
            {
                request.ResourceFilterCriteria.LambdaFunctionTags = requestResourceFilterCriteria_resourceFilterCriteria_LambdaFunctionTag;
                requestResourceFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.ResourceStringFilter> requestResourceFilterCriteria_resourceFilterCriteria_ResourceId = null;
            if (cmdletContext.ResourceFilterCriteria_ResourceId != null)
            {
                requestResourceFilterCriteria_resourceFilterCriteria_ResourceId = cmdletContext.ResourceFilterCriteria_ResourceId;
            }
            if (requestResourceFilterCriteria_resourceFilterCriteria_ResourceId != null)
            {
                request.ResourceFilterCriteria.ResourceId = requestResourceFilterCriteria_resourceFilterCriteria_ResourceId;
                requestResourceFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.ResourceStringFilter> requestResourceFilterCriteria_resourceFilterCriteria_ResourceType = null;
            if (cmdletContext.ResourceFilterCriteria_ResourceType != null)
            {
                requestResourceFilterCriteria_resourceFilterCriteria_ResourceType = cmdletContext.ResourceFilterCriteria_ResourceType;
            }
            if (requestResourceFilterCriteria_resourceFilterCriteria_ResourceType != null)
            {
                request.ResourceFilterCriteria.ResourceType = requestResourceFilterCriteria_resourceFilterCriteria_ResourceType;
                requestResourceFilterCriteriaIsNull = false;
            }
             // determine if request.ResourceFilterCriteria should be set to null
            if (requestResourceFilterCriteriaIsNull)
            {
                request.ResourceFilterCriteria = null;
            }
            
             // populate S3Destination
            var requestS3DestinationIsNull = true;
            request.S3Destination = new Amazon.Inspector2.Model.Destination();
            System.String requestS3Destination_s3Destination_BucketName = null;
            if (cmdletContext.S3Destination_BucketName != null)
            {
                requestS3Destination_s3Destination_BucketName = cmdletContext.S3Destination_BucketName;
            }
            if (requestS3Destination_s3Destination_BucketName != null)
            {
                request.S3Destination.BucketName = requestS3Destination_s3Destination_BucketName;
                requestS3DestinationIsNull = false;
            }
            System.String requestS3Destination_s3Destination_KeyPrefix = null;
            if (cmdletContext.S3Destination_KeyPrefix != null)
            {
                requestS3Destination_s3Destination_KeyPrefix = cmdletContext.S3Destination_KeyPrefix;
            }
            if (requestS3Destination_s3Destination_KeyPrefix != null)
            {
                request.S3Destination.KeyPrefix = requestS3Destination_s3Destination_KeyPrefix;
                requestS3DestinationIsNull = false;
            }
            System.String requestS3Destination_s3Destination_KmsKeyArn = null;
            if (cmdletContext.S3Destination_KmsKeyArn != null)
            {
                requestS3Destination_s3Destination_KmsKeyArn = cmdletContext.S3Destination_KmsKeyArn;
            }
            if (requestS3Destination_s3Destination_KmsKeyArn != null)
            {
                request.S3Destination.KmsKeyArn = requestS3Destination_s3Destination_KmsKeyArn;
                requestS3DestinationIsNull = false;
            }
             // determine if request.S3Destination should be set to null
            if (requestS3DestinationIsNull)
            {
                request.S3Destination = null;
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
        
        private Amazon.Inspector2.Model.CreateSbomExportResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.CreateSbomExportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "CreateSbomExport");
            try
            {
                return client.CreateSbomExportAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Inspector2.SbomReportFormat ReportFormat { get; set; }
            public List<Amazon.Inspector2.Model.ResourceStringFilter> ResourceFilterCriteria_AccountId { get; set; }
            public List<Amazon.Inspector2.Model.ResourceMapFilter> ResourceFilterCriteria_Ec2InstanceTag { get; set; }
            public List<Amazon.Inspector2.Model.ResourceStringFilter> ResourceFilterCriteria_EcrImageTag { get; set; }
            public List<Amazon.Inspector2.Model.ResourceStringFilter> ResourceFilterCriteria_EcrRepositoryName { get; set; }
            public List<Amazon.Inspector2.Model.ResourceStringFilter> ResourceFilterCriteria_LambdaFunctionName { get; set; }
            public List<Amazon.Inspector2.Model.ResourceMapFilter> ResourceFilterCriteria_LambdaFunctionTag { get; set; }
            public List<Amazon.Inspector2.Model.ResourceStringFilter> ResourceFilterCriteria_ResourceId { get; set; }
            public List<Amazon.Inspector2.Model.ResourceStringFilter> ResourceFilterCriteria_ResourceType { get; set; }
            public System.String S3Destination_BucketName { get; set; }
            public System.String S3Destination_KeyPrefix { get; set; }
            public System.String S3Destination_KmsKeyArn { get; set; }
            public System.Func<Amazon.Inspector2.Model.CreateSbomExportResponse, NewINS2SbomExportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReportId;
        }
        
    }
}
