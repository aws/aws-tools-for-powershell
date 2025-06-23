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
using Amazon.GlueDataBrew;
using Amazon.GlueDataBrew.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GDB
{
    /// <summary>
    /// Deletes one or more versions of a recipe at a time.
    /// 
    ///  
    /// <para>
    /// The entire request will be rejected if:
    /// </para><ul><li><para>
    /// The recipe does not exist.
    /// </para></li><li><para>
    /// There is an invalid version identifier in the list of versions.
    /// </para></li><li><para>
    /// The version list is empty.
    /// </para></li><li><para>
    /// The version list size exceeds 50.
    /// </para></li><li><para>
    /// The version list contains duplicate entries.
    /// </para></li></ul><para>
    /// The request will complete successfully, but with partial failures, if:
    /// </para><ul><li><para>
    /// A version does not exist.
    /// </para></li><li><para>
    /// A version is being used by a job.
    /// </para></li><li><para>
    /// You specify <c>LATEST_WORKING</c>, but it's being used by a project.
    /// </para></li><li><para>
    /// The version fails to be deleted.
    /// </para></li></ul><para>
    /// The <c>LATEST_WORKING</c> version will only be deleted if the recipe has no other
    /// versions. If you try to delete <c>LATEST_WORKING</c> while other versions exist (or
    /// if they can't be deleted), then <c>LATEST_WORKING</c> will be listed as partial failure
    /// in the response.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "GDBRecipeVersionBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.GlueDataBrew.Model.BatchDeleteRecipeVersionResponse")]
    [AWSCmdlet("Calls the AWS Glue DataBrew BatchDeleteRecipeVersion API operation.", Operation = new[] {"BatchDeleteRecipeVersion"}, SelectReturnType = typeof(Amazon.GlueDataBrew.Model.BatchDeleteRecipeVersionResponse))]
    [AWSCmdletOutput("Amazon.GlueDataBrew.Model.BatchDeleteRecipeVersionResponse",
        "This cmdlet returns an Amazon.GlueDataBrew.Model.BatchDeleteRecipeVersionResponse object containing multiple properties."
    )]
    public partial class RemoveGDBRecipeVersionBatchCmdlet : AmazonGlueDataBrewClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the recipe whose versions are to be deleted.</para>
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
        
        #region Parameter RecipeVersion
        /// <summary>
        /// <para>
        /// <para>An array of version identifiers, for the recipe versions to be deleted. You can specify
        /// numeric versions (<c>X.Y</c>) or <c>LATEST_WORKING</c>. <c>LATEST_PUBLISHED</c> is
        /// not supported.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("RecipeVersions")]
        public System.String[] RecipeVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlueDataBrew.Model.BatchDeleteRecipeVersionResponse).
        /// Specifying the name of a property of type Amazon.GlueDataBrew.Model.BatchDeleteRecipeVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-GDBRecipeVersionBatch (BatchDeleteRecipeVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GlueDataBrew.Model.BatchDeleteRecipeVersionResponse, RemoveGDBRecipeVersionBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RecipeVersion != null)
            {
                context.RecipeVersion = new List<System.String>(this.RecipeVersion);
            }
            #if MODULAR
            if (this.RecipeVersion == null && ParameterWasBound(nameof(this.RecipeVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter RecipeVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GlueDataBrew.Model.BatchDeleteRecipeVersionRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RecipeVersion != null)
            {
                request.RecipeVersions = cmdletContext.RecipeVersion;
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
        
        private Amazon.GlueDataBrew.Model.BatchDeleteRecipeVersionResponse CallAWSServiceOperation(IAmazonGlueDataBrew client, Amazon.GlueDataBrew.Model.BatchDeleteRecipeVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue DataBrew", "BatchDeleteRecipeVersion");
            try
            {
                return client.BatchDeleteRecipeVersionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public List<System.String> RecipeVersion { get; set; }
            public System.Func<Amazon.GlueDataBrew.Model.BatchDeleteRecipeVersionResponse, RemoveGDBRecipeVersionBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
