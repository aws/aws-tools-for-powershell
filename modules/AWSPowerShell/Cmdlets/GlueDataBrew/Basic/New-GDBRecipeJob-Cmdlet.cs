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
using Amazon.GlueDataBrew;
using Amazon.GlueDataBrew.Model;

namespace Amazon.PowerShell.Cmdlets.GDB
{
    /// <summary>
    /// Creates a new job to transform input data, using steps defined in an existing Glue
    /// DataBrew recipe
    /// </summary>
    [Cmdlet("New", "GDBRecipeJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue DataBrew CreateRecipeJob API operation.", Operation = new[] {"CreateRecipeJob"}, SelectReturnType = typeof(Amazon.GlueDataBrew.Model.CreateRecipeJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.GlueDataBrew.Model.CreateRecipeJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GlueDataBrew.Model.CreateRecipeJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGDBRecipeJobCmdlet : AmazonGlueDataBrewClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DatabaseOutput
        /// <summary>
        /// <para>
        /// <para>Represents a list of JDBC database output objects which defines the output destination
        /// for a DataBrew recipe job to write to. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatabaseOutputs")]
        public Amazon.GlueDataBrew.Model.DatabaseOutput[] DatabaseOutput { get; set; }
        #endregion
        
        #region Parameter DataCatalogOutput
        /// <summary>
        /// <para>
        /// <para>One or more artifacts that represent the Glue Data Catalog output from running the
        /// job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataCatalogOutputs")]
        public Amazon.GlueDataBrew.Model.DataCatalogOutput[] DataCatalogOutput { get; set; }
        #endregion
        
        #region Parameter DatasetName
        /// <summary>
        /// <para>
        /// <para>The name of the dataset that this job processes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatasetName { get; set; }
        #endregion
        
        #region Parameter EncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an encryption key that is used to protect the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter EncryptionMode
        /// <summary>
        /// <para>
        /// <para>The encryption mode for the job, which can be one of the following:</para><ul><li><para><c>SSE-KMS</c> - Server-side encryption with keys managed by KMS.</para></li><li><para><c>SSE-S3</c> - Server-side encryption with keys managed by Amazon S3.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GlueDataBrew.EncryptionMode")]
        public Amazon.GlueDataBrew.EncryptionMode EncryptionMode { get; set; }
        #endregion
        
        #region Parameter LogSubscription
        /// <summary>
        /// <para>
        /// <para>Enables or disables Amazon CloudWatch logging for the job. If logging is enabled,
        /// CloudWatch writes one log stream for each job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GlueDataBrew.LogSubscription")]
        public Amazon.GlueDataBrew.LogSubscription LogSubscription { get; set; }
        #endregion
        
        #region Parameter MaxCapacity
        /// <summary>
        /// <para>
        /// <para>The maximum number of nodes that DataBrew can consume when the job processes data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxCapacity { get; set; }
        #endregion
        
        #region Parameter MaxRetry
        /// <summary>
        /// <para>
        /// <para>The maximum number of times to retry the job after a job run fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRetries")]
        public System.Int32? MaxRetry { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A unique name for the job. Valid characters are alphanumeric (A-Z, a-z, 0-9), hyphen
        /// (-), period (.), and space.</para>
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
        
        #region Parameter RecipeReference_Name
        /// <summary>
        /// <para>
        /// <para>The name of the recipe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecipeReference_Name { get; set; }
        #endregion
        
        #region Parameter Output
        /// <summary>
        /// <para>
        /// <para>One or more artifacts that represent the output from running the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Outputs")]
        public Amazon.GlueDataBrew.Model.Output[] Output { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>Either the name of an existing project, or a combination of a recipe and a dataset
        /// to associate with the recipe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter RecipeReference_RecipeVersion
        /// <summary>
        /// <para>
        /// <para>The identifier for the version for the recipe. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecipeReference_RecipeVersion { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Identity and Access Management (IAM) role to
        /// be assumed when DataBrew runs the job.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata tags to apply to this job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para>The job's timeout in minutes. A job that attempts to run longer than this timeout
        /// period ends with a status of <c>TIMEOUT</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Timeout { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Name'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlueDataBrew.Model.CreateRecipeJobResponse).
        /// Specifying the name of a property of type Amazon.GlueDataBrew.Model.CreateRecipeJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Name";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GDBRecipeJob (CreateRecipeJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GlueDataBrew.Model.CreateRecipeJobResponse, NewGDBRecipeJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DatabaseOutput != null)
            {
                context.DatabaseOutput = new List<Amazon.GlueDataBrew.Model.DatabaseOutput>(this.DatabaseOutput);
            }
            if (this.DataCatalogOutput != null)
            {
                context.DataCatalogOutput = new List<Amazon.GlueDataBrew.Model.DataCatalogOutput>(this.DataCatalogOutput);
            }
            context.DatasetName = this.DatasetName;
            context.EncryptionKeyArn = this.EncryptionKeyArn;
            context.EncryptionMode = this.EncryptionMode;
            context.LogSubscription = this.LogSubscription;
            context.MaxCapacity = this.MaxCapacity;
            context.MaxRetry = this.MaxRetry;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Output != null)
            {
                context.Output = new List<Amazon.GlueDataBrew.Model.Output>(this.Output);
            }
            context.ProjectName = this.ProjectName;
            context.RecipeReference_Name = this.RecipeReference_Name;
            context.RecipeReference_RecipeVersion = this.RecipeReference_RecipeVersion;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Timeout = this.Timeout;
            
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
            var request = new Amazon.GlueDataBrew.Model.CreateRecipeJobRequest();
            
            if (cmdletContext.DatabaseOutput != null)
            {
                request.DatabaseOutputs = cmdletContext.DatabaseOutput;
            }
            if (cmdletContext.DataCatalogOutput != null)
            {
                request.DataCatalogOutputs = cmdletContext.DataCatalogOutput;
            }
            if (cmdletContext.DatasetName != null)
            {
                request.DatasetName = cmdletContext.DatasetName;
            }
            if (cmdletContext.EncryptionKeyArn != null)
            {
                request.EncryptionKeyArn = cmdletContext.EncryptionKeyArn;
            }
            if (cmdletContext.EncryptionMode != null)
            {
                request.EncryptionMode = cmdletContext.EncryptionMode;
            }
            if (cmdletContext.LogSubscription != null)
            {
                request.LogSubscription = cmdletContext.LogSubscription;
            }
            if (cmdletContext.MaxCapacity != null)
            {
                request.MaxCapacity = cmdletContext.MaxCapacity.Value;
            }
            if (cmdletContext.MaxRetry != null)
            {
                request.MaxRetries = cmdletContext.MaxRetry.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Output != null)
            {
                request.Outputs = cmdletContext.Output;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
            }
            
             // populate RecipeReference
            var requestRecipeReferenceIsNull = true;
            request.RecipeReference = new Amazon.GlueDataBrew.Model.RecipeReference();
            System.String requestRecipeReference_recipeReference_Name = null;
            if (cmdletContext.RecipeReference_Name != null)
            {
                requestRecipeReference_recipeReference_Name = cmdletContext.RecipeReference_Name;
            }
            if (requestRecipeReference_recipeReference_Name != null)
            {
                request.RecipeReference.Name = requestRecipeReference_recipeReference_Name;
                requestRecipeReferenceIsNull = false;
            }
            System.String requestRecipeReference_recipeReference_RecipeVersion = null;
            if (cmdletContext.RecipeReference_RecipeVersion != null)
            {
                requestRecipeReference_recipeReference_RecipeVersion = cmdletContext.RecipeReference_RecipeVersion;
            }
            if (requestRecipeReference_recipeReference_RecipeVersion != null)
            {
                request.RecipeReference.RecipeVersion = requestRecipeReference_recipeReference_RecipeVersion;
                requestRecipeReferenceIsNull = false;
            }
             // determine if request.RecipeReference should be set to null
            if (requestRecipeReferenceIsNull)
            {
                request.RecipeReference = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Timeout != null)
            {
                request.Timeout = cmdletContext.Timeout.Value;
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
        
        private Amazon.GlueDataBrew.Model.CreateRecipeJobResponse CallAWSServiceOperation(IAmazonGlueDataBrew client, Amazon.GlueDataBrew.Model.CreateRecipeJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue DataBrew", "CreateRecipeJob");
            try
            {
                #if DESKTOP
                return client.CreateRecipeJob(request);
                #elif CORECLR
                return client.CreateRecipeJobAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.GlueDataBrew.Model.DatabaseOutput> DatabaseOutput { get; set; }
            public List<Amazon.GlueDataBrew.Model.DataCatalogOutput> DataCatalogOutput { get; set; }
            public System.String DatasetName { get; set; }
            public System.String EncryptionKeyArn { get; set; }
            public Amazon.GlueDataBrew.EncryptionMode EncryptionMode { get; set; }
            public Amazon.GlueDataBrew.LogSubscription LogSubscription { get; set; }
            public System.Int32? MaxCapacity { get; set; }
            public System.Int32? MaxRetry { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.GlueDataBrew.Model.Output> Output { get; set; }
            public System.String ProjectName { get; set; }
            public System.String RecipeReference_Name { get; set; }
            public System.String RecipeReference_RecipeVersion { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Int32? Timeout { get; set; }
            public System.Func<Amazon.GlueDataBrew.Model.CreateRecipeJobResponse, NewGDBRecipeJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Name;
        }
        
    }
}
