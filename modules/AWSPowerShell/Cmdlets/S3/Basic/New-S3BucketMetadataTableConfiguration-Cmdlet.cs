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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Creates a metadata table configuration for a general purpose bucket. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/metadata-tables-overview.html">Accelerating
    /// data discovery with S3 Metadata</a> in the <i>Amazon S3 User Guide</i>. 
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// To use this operation, you must have the following permissions. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/metadata-tables-permissions.html">Setting
    /// up permissions for configuring metadata tables</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><para>
    /// If you also want to integrate your table bucket with Amazon Web Services analytics
    /// services so that you can query your metadata table, you need additional permissions.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-tables-integrating-aws.html">
    /// Integrating Amazon S3 Tables with Amazon Web Services analytics services</a> in the
    /// <i>Amazon S3 User Guide</i>.
    /// </para><ul><li><para><c>s3:CreateBucketMetadataTableConfiguration</c></para></li><li><para><c>s3tables:CreateNamespace</c></para></li><li><para><c>s3tables:GetTable</c></para></li><li><para><c>s3tables:CreateTable</c></para></li><li><para><c>s3tables:PutTablePolicy</c></para></li></ul></dd></dl><para>
    /// The following operations are related to <c>CreateBucketMetadataTableConfiguration</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucketMetadataTableConfiguration.html">DeleteBucketMetadataTableConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketMetadataTableConfiguration.html">GetBucketMetadataTableConfiguration</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "S3BucketMetadataTableConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) CreateBucketMetadataTableConfiguration API operation.", Operation = new[] {"CreateBucketMetadataTableConfiguration"}, SelectReturnType = typeof(Amazon.S3.Model.CreateBucketMetadataTableConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.CreateBucketMetadataTableConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.CreateBucketMetadataTableConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewS3BucketMetadataTableConfigurationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The general purpose bucket that you want to create the metadata table configuration in.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// The checksum algorithm to use with your metadata table configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter ContentMD5
        /// <summary>
        /// <para>
        /// The <c>Content-MD5</c> header for the metadata table configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentMD5 { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// The expected owner of the general purpose bucket that contains your metadata table configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter S3TablesDestination_TableBucketArn
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) for the table bucket that's specified as the 
        /// destination in the metadata table configuration. The destination table bucket
        /// must be in the same Region and Amazon Web Services account as the general purpose bucket.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataTableConfiguration_S3TablesDestination_TableBucketArn")]
        public System.String S3TablesDestination_TableBucketArn { get; set; }
        #endregion
        
        #region Parameter S3TablesDestination_TableName
        /// <summary>
        /// <para>
        /// The name for the metadata table in your metadata table configuration.The specified metadata
        /// table name must be unique within the <c>aws_s3_metadata</c> namespace in the destination 
        /// table bucket.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataTableConfiguration_S3TablesDestination_TableName")]
        public System.String S3TablesDestination_TableName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.CreateBucketMetadataTableConfigurationResponse).
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
            this._AWSSignerType = "s3";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-S3BucketMetadataTableConfiguration (CreateBucketMetadataTableConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.CreateBucketMetadataTableConfigurationResponse, NewS3BucketMetadataTableConfigurationCmdlet>(Select) ??
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
            context.BucketName = this.BucketName;
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            context.ContentMD5 = this.ContentMD5;
            context.S3TablesDestination_TableBucketArn = this.S3TablesDestination_TableBucketArn;
            context.S3TablesDestination_TableName = this.S3TablesDestination_TableName;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            
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
            var request = new Amazon.S3.Model.CreateBucketMetadataTableConfigurationRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ChecksumAlgorithm != null)
            {
                request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
            }
            if (cmdletContext.ContentMD5 != null)
            {
                request.ContentMD5 = cmdletContext.ContentMD5;
            }
            
             // populate MetadataTableConfiguration
            var requestMetadataTableConfigurationIsNull = true;
            request.MetadataTableConfiguration = new Amazon.S3.Model.MetadataTableConfiguration();
            Amazon.S3.Model.S3TablesDestination requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination = null;
            
             // populate S3TablesDestination
            var requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestinationIsNull = true;
            requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination = new Amazon.S3.Model.S3TablesDestination();
            System.String requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination_s3TablesDestination_TableBucketArn = null;
            if (cmdletContext.S3TablesDestination_TableBucketArn != null)
            {
                requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination_s3TablesDestination_TableBucketArn = cmdletContext.S3TablesDestination_TableBucketArn;
            }
            if (requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination_s3TablesDestination_TableBucketArn != null)
            {
                requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination.TableBucketArn = requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination_s3TablesDestination_TableBucketArn;
                requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestinationIsNull = false;
            }
            System.String requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination_s3TablesDestination_TableName = null;
            if (cmdletContext.S3TablesDestination_TableName != null)
            {
                requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination_s3TablesDestination_TableName = cmdletContext.S3TablesDestination_TableName;
            }
            if (requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination_s3TablesDestination_TableName != null)
            {
                requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination.TableName = requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination_s3TablesDestination_TableName;
                requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestinationIsNull = false;
            }
             // determine if requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination should be set to null
            if (requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestinationIsNull)
            {
                requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination = null;
            }
            if (requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination != null)
            {
                request.MetadataTableConfiguration.S3TablesDestination = requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination;
                requestMetadataTableConfigurationIsNull = false;
            }
             // determine if request.MetadataTableConfiguration should be set to null
            if (requestMetadataTableConfigurationIsNull)
            {
                request.MetadataTableConfiguration = null;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
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
        
        private Amazon.S3.Model.CreateBucketMetadataTableConfigurationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.CreateBucketMetadataTableConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "CreateBucketMetadataTableConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateBucketMetadataTableConfiguration(request);
                #elif CORECLR
                return client.CreateBucketMetadataTableConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String BucketName { get; set; }
            public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
            public System.String ContentMD5 { get; set; }
            public System.String S3TablesDestination_TableBucketArn { get; set; }
            public System.String S3TablesDestination_TableName { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.Func<Amazon.S3.Model.CreateBucketMetadataTableConfigurationResponse, NewS3BucketMetadataTableConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
