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
using Amazon.LexModelsV2;
using Amazon.LexModelsV2.Model;

namespace Amazon.PowerShell.Cmdlets.LMBV2
{
    /// <summary>
    /// The action to start the generation of test set.
    /// </summary>
    [Cmdlet("Start", "LMBV2TestSetGeneration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelsV2.Model.StartTestSetGenerationResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 StartTestSetGeneration API operation.", Operation = new[] {"StartTestSetGeneration"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.StartTestSetGenerationResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.StartTestSetGenerationResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.StartTestSetGenerationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartLMBV2TestSetGenerationCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        #region Parameter ConversationLogsDataSource_BotAliasId
        /// <summary>
        /// <para>
        /// <para>The bot alias Id from the conversation logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationDataSource_ConversationLogsDataSource_BotAliasId")]
        public System.String ConversationLogsDataSource_BotAliasId { get; set; }
        #endregion
        
        #region Parameter ConversationLogsDataSource_BotId
        /// <summary>
        /// <para>
        /// <para>The bot Id from the conversation logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationDataSource_ConversationLogsDataSource_BotId")]
        public System.String ConversationLogsDataSource_BotId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The test set description for the test set generation request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Filter_EndTime
        /// <summary>
        /// <para>
        /// <para>The end time for the conversation log.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationDataSource_ConversationLogsDataSource_Filter_EndTime")]
        public System.DateTime? Filter_EndTime { get; set; }
        #endregion
        
        #region Parameter Filter_InputMode
        /// <summary>
        /// <para>
        /// <para>The selection to filter by input mode for the conversation logs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationDataSource_ConversationLogsDataSource_Filter_InputMode")]
        [AWSConstantClassSource("Amazon.LexModelsV2.ConversationLogsInputModeFilter")]
        public Amazon.LexModelsV2.ConversationLogsInputModeFilter Filter_InputMode { get; set; }
        #endregion
        
        #region Parameter StorageLocation_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an Amazon Web Services Key Management Service (KMS)
        /// key for encrypting the test set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageLocation_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter ConversationLogsDataSource_LocaleId
        /// <summary>
        /// <para>
        /// <para>The locale Id of the conversation log.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationDataSource_ConversationLogsDataSource_LocaleId")]
        public System.String ConversationLogsDataSource_LocaleId { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The roleARN used for any operation in the test set to access resources in the Amazon
        /// Web Services account.</para>
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
        
        #region Parameter StorageLocation_S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket in which the test set is stored.</para>
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
        public System.String StorageLocation_S3BucketName { get; set; }
        #endregion
        
        #region Parameter StorageLocation_S3Path
        /// <summary>
        /// <para>
        /// <para>The path inside the Amazon S3 bucket where the test set is stored.</para>
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
        public System.String StorageLocation_S3Path { get; set; }
        #endregion
        
        #region Parameter Filter_StartTime
        /// <summary>
        /// <para>
        /// <para>The start time for the conversation log.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationDataSource_ConversationLogsDataSource_Filter_StartTime")]
        public System.DateTime? Filter_StartTime { get; set; }
        #endregion
        
        #region Parameter TestSetName
        /// <summary>
        /// <para>
        /// <para>The test set name for the test set generation request.</para>
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
        public System.String TestSetName { get; set; }
        #endregion
        
        #region Parameter TestSetTag
        /// <summary>
        /// <para>
        /// <para>A list of tags to add to the test set. You can only add tags when you import/generate
        /// a new test set. You can't use the <code>UpdateTestSet</code> operation to update tags.
        /// To update tags, use the <code>TagResource</code> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestSetTags")]
        public System.Collections.Hashtable TestSetTag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.StartTestSetGenerationResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.StartTestSetGenerationResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TestSetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-LMBV2TestSetGeneration (StartTestSetGeneration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.StartTestSetGenerationResponse, StartLMBV2TestSetGenerationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.ConversationLogsDataSource_BotAliasId = this.ConversationLogsDataSource_BotAliasId;
            context.ConversationLogsDataSource_BotId = this.ConversationLogsDataSource_BotId;
            context.Filter_EndTime = this.Filter_EndTime;
            context.Filter_InputMode = this.Filter_InputMode;
            context.Filter_StartTime = this.Filter_StartTime;
            context.ConversationLogsDataSource_LocaleId = this.ConversationLogsDataSource_LocaleId;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StorageLocation_KmsKeyArn = this.StorageLocation_KmsKeyArn;
            context.StorageLocation_S3BucketName = this.StorageLocation_S3BucketName;
            #if MODULAR
            if (this.StorageLocation_S3BucketName == null && ParameterWasBound(nameof(this.StorageLocation_S3BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageLocation_S3BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StorageLocation_S3Path = this.StorageLocation_S3Path;
            #if MODULAR
            if (this.StorageLocation_S3Path == null && ParameterWasBound(nameof(this.StorageLocation_S3Path)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageLocation_S3Path which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TestSetName = this.TestSetName;
            #if MODULAR
            if (this.TestSetName == null && ParameterWasBound(nameof(this.TestSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter TestSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TestSetTag != null)
            {
                context.TestSetTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TestSetTag.Keys)
                {
                    context.TestSetTag.Add((String)hashKey, (String)(this.TestSetTag[hashKey]));
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
            var request = new Amazon.LexModelsV2.Model.StartTestSetGenerationRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate GenerationDataSource
            var requestGenerationDataSourceIsNull = true;
            request.GenerationDataSource = new Amazon.LexModelsV2.Model.TestSetGenerationDataSource();
            Amazon.LexModelsV2.Model.ConversationLogsDataSource requestGenerationDataSource_generationDataSource_ConversationLogsDataSource = null;
            
             // populate ConversationLogsDataSource
            var requestGenerationDataSource_generationDataSource_ConversationLogsDataSourceIsNull = true;
            requestGenerationDataSource_generationDataSource_ConversationLogsDataSource = new Amazon.LexModelsV2.Model.ConversationLogsDataSource();
            System.String requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_conversationLogsDataSource_BotAliasId = null;
            if (cmdletContext.ConversationLogsDataSource_BotAliasId != null)
            {
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_conversationLogsDataSource_BotAliasId = cmdletContext.ConversationLogsDataSource_BotAliasId;
            }
            if (requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_conversationLogsDataSource_BotAliasId != null)
            {
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSource.BotAliasId = requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_conversationLogsDataSource_BotAliasId;
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSourceIsNull = false;
            }
            System.String requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_conversationLogsDataSource_BotId = null;
            if (cmdletContext.ConversationLogsDataSource_BotId != null)
            {
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_conversationLogsDataSource_BotId = cmdletContext.ConversationLogsDataSource_BotId;
            }
            if (requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_conversationLogsDataSource_BotId != null)
            {
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSource.BotId = requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_conversationLogsDataSource_BotId;
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSourceIsNull = false;
            }
            System.String requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_conversationLogsDataSource_LocaleId = null;
            if (cmdletContext.ConversationLogsDataSource_LocaleId != null)
            {
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_conversationLogsDataSource_LocaleId = cmdletContext.ConversationLogsDataSource_LocaleId;
            }
            if (requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_conversationLogsDataSource_LocaleId != null)
            {
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSource.LocaleId = requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_conversationLogsDataSource_LocaleId;
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSourceIsNull = false;
            }
            Amazon.LexModelsV2.Model.ConversationLogsDataSourceFilterBy requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter = null;
            
             // populate Filter
            var requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_FilterIsNull = true;
            requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter = new Amazon.LexModelsV2.Model.ConversationLogsDataSourceFilterBy();
            System.DateTime? requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter_filter_EndTime = null;
            if (cmdletContext.Filter_EndTime != null)
            {
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter_filter_EndTime = cmdletContext.Filter_EndTime.Value;
            }
            if (requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter_filter_EndTime != null)
            {
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter.EndTime = requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter_filter_EndTime.Value;
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_FilterIsNull = false;
            }
            Amazon.LexModelsV2.ConversationLogsInputModeFilter requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter_filter_InputMode = null;
            if (cmdletContext.Filter_InputMode != null)
            {
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter_filter_InputMode = cmdletContext.Filter_InputMode;
            }
            if (requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter_filter_InputMode != null)
            {
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter.InputMode = requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter_filter_InputMode;
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_FilterIsNull = false;
            }
            System.DateTime? requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter_filter_StartTime = null;
            if (cmdletContext.Filter_StartTime != null)
            {
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter_filter_StartTime = cmdletContext.Filter_StartTime.Value;
            }
            if (requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter_filter_StartTime != null)
            {
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter.StartTime = requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter_filter_StartTime.Value;
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_FilterIsNull = false;
            }
             // determine if requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter should be set to null
            if (requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_FilterIsNull)
            {
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter = null;
            }
            if (requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter != null)
            {
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSource.Filter = requestGenerationDataSource_generationDataSource_ConversationLogsDataSource_generationDataSource_ConversationLogsDataSource_Filter;
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSourceIsNull = false;
            }
             // determine if requestGenerationDataSource_generationDataSource_ConversationLogsDataSource should be set to null
            if (requestGenerationDataSource_generationDataSource_ConversationLogsDataSourceIsNull)
            {
                requestGenerationDataSource_generationDataSource_ConversationLogsDataSource = null;
            }
            if (requestGenerationDataSource_generationDataSource_ConversationLogsDataSource != null)
            {
                request.GenerationDataSource.ConversationLogsDataSource = requestGenerationDataSource_generationDataSource_ConversationLogsDataSource;
                requestGenerationDataSourceIsNull = false;
            }
             // determine if request.GenerationDataSource should be set to null
            if (requestGenerationDataSourceIsNull)
            {
                request.GenerationDataSource = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate StorageLocation
            var requestStorageLocationIsNull = true;
            request.StorageLocation = new Amazon.LexModelsV2.Model.TestSetStorageLocation();
            System.String requestStorageLocation_storageLocation_KmsKeyArn = null;
            if (cmdletContext.StorageLocation_KmsKeyArn != null)
            {
                requestStorageLocation_storageLocation_KmsKeyArn = cmdletContext.StorageLocation_KmsKeyArn;
            }
            if (requestStorageLocation_storageLocation_KmsKeyArn != null)
            {
                request.StorageLocation.KmsKeyArn = requestStorageLocation_storageLocation_KmsKeyArn;
                requestStorageLocationIsNull = false;
            }
            System.String requestStorageLocation_storageLocation_S3BucketName = null;
            if (cmdletContext.StorageLocation_S3BucketName != null)
            {
                requestStorageLocation_storageLocation_S3BucketName = cmdletContext.StorageLocation_S3BucketName;
            }
            if (requestStorageLocation_storageLocation_S3BucketName != null)
            {
                request.StorageLocation.S3BucketName = requestStorageLocation_storageLocation_S3BucketName;
                requestStorageLocationIsNull = false;
            }
            System.String requestStorageLocation_storageLocation_S3Path = null;
            if (cmdletContext.StorageLocation_S3Path != null)
            {
                requestStorageLocation_storageLocation_S3Path = cmdletContext.StorageLocation_S3Path;
            }
            if (requestStorageLocation_storageLocation_S3Path != null)
            {
                request.StorageLocation.S3Path = requestStorageLocation_storageLocation_S3Path;
                requestStorageLocationIsNull = false;
            }
             // determine if request.StorageLocation should be set to null
            if (requestStorageLocationIsNull)
            {
                request.StorageLocation = null;
            }
            if (cmdletContext.TestSetName != null)
            {
                request.TestSetName = cmdletContext.TestSetName;
            }
            if (cmdletContext.TestSetTag != null)
            {
                request.TestSetTags = cmdletContext.TestSetTag;
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
        
        private Amazon.LexModelsV2.Model.StartTestSetGenerationResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.StartTestSetGenerationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "StartTestSetGeneration");
            try
            {
                #if DESKTOP
                return client.StartTestSetGeneration(request);
                #elif CORECLR
                return client.StartTestSetGenerationAsync(request).GetAwaiter().GetResult();
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
            public System.String ConversationLogsDataSource_BotAliasId { get; set; }
            public System.String ConversationLogsDataSource_BotId { get; set; }
            public System.DateTime? Filter_EndTime { get; set; }
            public Amazon.LexModelsV2.ConversationLogsInputModeFilter Filter_InputMode { get; set; }
            public System.DateTime? Filter_StartTime { get; set; }
            public System.String ConversationLogsDataSource_LocaleId { get; set; }
            public System.String RoleArn { get; set; }
            public System.String StorageLocation_KmsKeyArn { get; set; }
            public System.String StorageLocation_S3BucketName { get; set; }
            public System.String StorageLocation_S3Path { get; set; }
            public System.String TestSetName { get; set; }
            public Dictionary<System.String, System.String> TestSetTag { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.StartTestSetGenerationResponse, StartLMBV2TestSetGenerationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
