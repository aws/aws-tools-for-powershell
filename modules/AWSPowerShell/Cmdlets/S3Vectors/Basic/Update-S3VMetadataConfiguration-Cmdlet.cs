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
using Amazon.S3Vectors;
using Amazon.S3Vectors.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3V
{
    /// <summary>
    /// Adds or deletes text search configurations on a vector index. Specify either <c>add</c>
    /// or <c>delete</c>, but not both. The vector index must be in <c>ENHANCED</c> mode.
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3vectors:UpdateMetadataConfiguration</c> permission to use this
    /// operation.
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("Update", "S3VMetadataConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon S3 Vectors UpdateMetadataConfiguration API operation.", Operation = new[] {"UpdateMetadataConfiguration"}, SelectReturnType = typeof(Amazon.S3Vectors.Model.UpdateMetadataConfigurationResponse))]
    [AWSCmdletOutput("System.String or Amazon.S3Vectors.Model.UpdateMetadataConfigurationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.S3Vectors.Model.UpdateMetadataConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateS3VMetadataConfigurationCmdlet : AmazonS3VectorsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IndexArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the vector index to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IndexArn { get; set; }
        #endregion
        
        #region Parameter IndexName
        /// <summary>
        /// <para>
        /// <para>The name of the vector index to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IndexName { get; set; }
        #endregion
        
        #region Parameter Add_TextSearchConfiguration
        /// <summary>
        /// <para>
        /// <para>Text search configurations to add. Amazon S3 Vectors begins building the corresponding
        /// full-text indexes after the update is accepted.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Add_TextSearchConfigurations")]
        public Amazon.S3Vectors.Model.TextSearchConfiguration[] Add_TextSearchConfiguration { get; set; }
        #endregion
        
        #region Parameter Delete_TextSearchConfiguration
        /// <summary>
        /// <para>
        /// <para>Searchable metadata keys whose text search configurations to delete.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Delete_TextSearchConfigurations")]
        public Amazon.S3Vectors.Model.TextSearchConfigurationKey[] Delete_TextSearchConfiguration { get; set; }
        #endregion
        
        #region Parameter VectorBucketName
        /// <summary>
        /// <para>
        /// <para>The name of the vector bucket that contains the vector index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VectorBucketName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IndexArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Vectors.Model.UpdateMetadataConfigurationResponse).
        /// Specifying the name of a property of type Amazon.S3Vectors.Model.UpdateMetadataConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IndexArn";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.IndexName),
                nameof(this.VectorBucketName),
                nameof(this.IndexArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-S3VMetadataConfiguration (UpdateMetadataConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Vectors.Model.UpdateMetadataConfigurationResponse, UpdateS3VMetadataConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Add_TextSearchConfiguration != null)
            {
                context.Add_TextSearchConfiguration = new List<Amazon.S3Vectors.Model.TextSearchConfiguration>(this.Add_TextSearchConfiguration);
            }
            if (this.Delete_TextSearchConfiguration != null)
            {
                context.Delete_TextSearchConfiguration = new List<Amazon.S3Vectors.Model.TextSearchConfigurationKey>(this.Delete_TextSearchConfiguration);
            }
            context.IndexArn = this.IndexArn;
            context.IndexName = this.IndexName;
            context.VectorBucketName = this.VectorBucketName;
            
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
            var request = new Amazon.S3Vectors.Model.UpdateMetadataConfigurationRequest();
            
            
             // populate Add
            var requestAddIsNull = true;
            request.Add = new Amazon.S3Vectors.Model.MetadataConfigurationAdd();
            List<Amazon.S3Vectors.Model.TextSearchConfiguration> requestAdd_add_TextSearchConfiguration = null;
            if (cmdletContext.Add_TextSearchConfiguration != null)
            {
                requestAdd_add_TextSearchConfiguration = cmdletContext.Add_TextSearchConfiguration;
            }
            if (requestAdd_add_TextSearchConfiguration != null)
            {
                request.Add.TextSearchConfigurations = requestAdd_add_TextSearchConfiguration;
                requestAddIsNull = false;
            }
             // determine if request.Add should be set to null
            if (requestAddIsNull)
            {
                request.Add = null;
            }
            
             // populate Delete
            var requestDeleteIsNull = true;
            request.Delete = new Amazon.S3Vectors.Model.MetadataConfigurationDelete();
            List<Amazon.S3Vectors.Model.TextSearchConfigurationKey> requestDelete_delete_TextSearchConfiguration = null;
            if (cmdletContext.Delete_TextSearchConfiguration != null)
            {
                requestDelete_delete_TextSearchConfiguration = cmdletContext.Delete_TextSearchConfiguration;
            }
            if (requestDelete_delete_TextSearchConfiguration != null)
            {
                request.Delete.TextSearchConfigurations = requestDelete_delete_TextSearchConfiguration;
                requestDeleteIsNull = false;
            }
             // determine if request.Delete should be set to null
            if (requestDeleteIsNull)
            {
                request.Delete = null;
            }
            if (cmdletContext.IndexArn != null)
            {
                request.IndexArn = cmdletContext.IndexArn;
            }
            if (cmdletContext.IndexName != null)
            {
                request.IndexName = cmdletContext.IndexName;
            }
            if (cmdletContext.VectorBucketName != null)
            {
                request.VectorBucketName = cmdletContext.VectorBucketName;
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
        
        private Amazon.S3Vectors.Model.UpdateMetadataConfigurationResponse CallAWSServiceOperation(IAmazonS3Vectors client, Amazon.S3Vectors.Model.UpdateMetadataConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Vectors", "UpdateMetadataConfiguration");
            try
            {
                return client.UpdateMetadataConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.S3Vectors.Model.TextSearchConfiguration> Add_TextSearchConfiguration { get; set; }
            public List<Amazon.S3Vectors.Model.TextSearchConfigurationKey> Delete_TextSearchConfiguration { get; set; }
            public System.String IndexArn { get; set; }
            public System.String IndexName { get; set; }
            public System.String VectorBucketName { get; set; }
            public System.Func<Amazon.S3Vectors.Model.UpdateMetadataConfigurationResponse, UpdateS3VMetadataConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IndexArn;
        }
        
    }
}
