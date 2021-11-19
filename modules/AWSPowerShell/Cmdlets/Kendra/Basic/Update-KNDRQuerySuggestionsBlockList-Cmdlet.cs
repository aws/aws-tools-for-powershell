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
using Amazon.Kendra;
using Amazon.Kendra.Model;

namespace Amazon.PowerShell.Cmdlets.KNDR
{
    /// <summary>
    /// Updates a block list used for query suggestions for an index.
    /// 
    ///  
    /// <para>
    /// Updates to a block list might not take effect right away. Amazon Kendra needs to refresh
    /// the entire suggestions list to apply any updates to the block list. Other changes
    /// not related to the block list apply immediately.
    /// </para><para>
    /// If a block list is updating, then you need to wait for the first update to finish
    /// before submitting another update.
    /// </para><para>
    /// Amazon Kendra supports partial updates, so you only need to provide the fields you
    /// want to update.
    /// </para><para><code>UpdateQuerySuggestionsBlockList</code> is currently not supported in the Amazon
    /// Web Services GovCloud (US-West) region.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "KNDRQuerySuggestionsBlockList", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kendra UpdateQuerySuggestionsBlockList API operation.", Operation = new[] {"UpdateQuerySuggestionsBlockList"}, SelectReturnType = typeof(Amazon.Kendra.Model.UpdateQuerySuggestionsBlockListResponse))]
    [AWSCmdletOutput("None or Amazon.Kendra.Model.UpdateQuerySuggestionsBlockListResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Kendra.Model.UpdateQuerySuggestionsBlockListResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateKNDRQuerySuggestionsBlockListCmdlet : AmazonKendraClientCmdlet, IExecutor
    {
        
        #region Parameter SourceS3Path_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket that contains the file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceS3Path_Bucket { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description for a block list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The unique identifier of a block list.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter IndexId
        /// <summary>
        /// <para>
        /// <para>The identifier of the index for a block list.</para>
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
        public System.String IndexId { get; set; }
        #endregion
        
        #region Parameter SourceS3Path_Key
        /// <summary>
        /// <para>
        /// <para>The name of the file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceS3Path_Key { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of a block list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM (Identity and Access Management) role used to access the block list text file
        /// in S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kendra.Model.UpdateQuerySuggestionsBlockListResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IndexId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IndexId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IndexId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KNDRQuerySuggestionsBlockList (UpdateQuerySuggestionsBlockList)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kendra.Model.UpdateQuerySuggestionsBlockListResponse, UpdateKNDRQuerySuggestionsBlockListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IndexId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IndexId = this.IndexId;
            #if MODULAR
            if (this.IndexId == null && ParameterWasBound(nameof(this.IndexId)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.RoleArn = this.RoleArn;
            context.SourceS3Path_Bucket = this.SourceS3Path_Bucket;
            context.SourceS3Path_Key = this.SourceS3Path_Key;
            
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
            var request = new Amazon.Kendra.Model.UpdateQuerySuggestionsBlockListRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.IndexId != null)
            {
                request.IndexId = cmdletContext.IndexId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate SourceS3Path
            var requestSourceS3PathIsNull = true;
            request.SourceS3Path = new Amazon.Kendra.Model.S3Path();
            System.String requestSourceS3Path_sourceS3Path_Bucket = null;
            if (cmdletContext.SourceS3Path_Bucket != null)
            {
                requestSourceS3Path_sourceS3Path_Bucket = cmdletContext.SourceS3Path_Bucket;
            }
            if (requestSourceS3Path_sourceS3Path_Bucket != null)
            {
                request.SourceS3Path.Bucket = requestSourceS3Path_sourceS3Path_Bucket;
                requestSourceS3PathIsNull = false;
            }
            System.String requestSourceS3Path_sourceS3Path_Key = null;
            if (cmdletContext.SourceS3Path_Key != null)
            {
                requestSourceS3Path_sourceS3Path_Key = cmdletContext.SourceS3Path_Key;
            }
            if (requestSourceS3Path_sourceS3Path_Key != null)
            {
                request.SourceS3Path.Key = requestSourceS3Path_sourceS3Path_Key;
                requestSourceS3PathIsNull = false;
            }
             // determine if request.SourceS3Path should be set to null
            if (requestSourceS3PathIsNull)
            {
                request.SourceS3Path = null;
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
        
        private Amazon.Kendra.Model.UpdateQuerySuggestionsBlockListResponse CallAWSServiceOperation(IAmazonKendra client, Amazon.Kendra.Model.UpdateQuerySuggestionsBlockListRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kendra", "UpdateQuerySuggestionsBlockList");
            try
            {
                #if DESKTOP
                return client.UpdateQuerySuggestionsBlockList(request);
                #elif CORECLR
                return client.UpdateQuerySuggestionsBlockListAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Id { get; set; }
            public System.String IndexId { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public System.String SourceS3Path_Bucket { get; set; }
            public System.String SourceS3Path_Key { get; set; }
            public System.Func<Amazon.Kendra.Model.UpdateQuerySuggestionsBlockListResponse, UpdateKNDRQuerySuggestionsBlockListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
