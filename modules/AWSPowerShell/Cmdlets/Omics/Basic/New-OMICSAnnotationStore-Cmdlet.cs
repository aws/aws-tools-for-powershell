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
using Amazon.Omics;
using Amazon.Omics.Model;

namespace Amazon.PowerShell.Cmdlets.OMICS
{
    /// <summary>
    /// Creates an annotation store.
    /// </summary>
    [Cmdlet("New", "OMICSAnnotationStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Omics.Model.CreateAnnotationStoreResponse")]
    [AWSCmdlet("Calls the Amazon Omics CreateAnnotationStore API operation.", Operation = new[] {"CreateAnnotationStore"}, SelectReturnType = typeof(Amazon.Omics.Model.CreateAnnotationStoreResponse))]
    [AWSCmdletOutput("Amazon.Omics.Model.CreateAnnotationStoreResponse",
        "This cmdlet returns an Amazon.Omics.Model.CreateAnnotationStoreResponse object containing multiple properties."
    )]
    public partial class NewOMICSAnnotationStoreCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TsvStoreOptions_AnnotationType
        /// <summary>
        /// <para>
        /// <para>The store's annotation type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StoreOptions_TsvStoreOptions_AnnotationType")]
        [AWSConstantClassSource("Amazon.Omics.AnnotationType")]
        public Amazon.Omics.AnnotationType TsvStoreOptions_AnnotationType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter TsvStoreOptions_FormatToHeader
        /// <summary>
        /// <para>
        /// <para>The store's header key to column name mapping.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StoreOptions_TsvStoreOptions_FormatToHeader")]
        public System.Collections.Hashtable TsvStoreOptions_FormatToHeader { get; set; }
        #endregion
        
        #region Parameter SseConfig_KeyArn
        /// <summary>
        /// <para>
        /// <para>An encryption key ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SseConfig_KeyArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Reference_ReferenceArn
        /// <summary>
        /// <para>
        /// <para>The reference's ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Reference_ReferenceArn { get; set; }
        #endregion
        
        #region Parameter TsvStoreOptions_Schema
        /// <summary>
        /// <para>
        /// <para>The store's schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StoreOptions_TsvStoreOptions_Schema")]
        public System.Collections.Hashtable[] TsvStoreOptions_Schema { get; set; }
        #endregion
        
        #region Parameter StoreFormat
        /// <summary>
        /// <para>
        /// <para>The annotation file format of the store.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Omics.StoreFormat")]
        public Amazon.Omics.StoreFormat StoreFormat { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags for the store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter SseConfig_Type
        /// <summary>
        /// <para>
        /// <para>The encryption type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.EncryptionType")]
        public Amazon.Omics.EncryptionType SseConfig_Type { get; set; }
        #endregion
        
        #region Parameter VersionName
        /// <summary>
        /// <para>
        /// <para> The name given to an annotation store version to distinguish it from other versions.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.CreateAnnotationStoreResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.CreateAnnotationStoreResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OMICSAnnotationStore (CreateAnnotationStore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.CreateAnnotationStoreResponse, NewOMICSAnnotationStoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Name = this.Name;
            context.Reference_ReferenceArn = this.Reference_ReferenceArn;
            context.SseConfig_KeyArn = this.SseConfig_KeyArn;
            context.SseConfig_Type = this.SseConfig_Type;
            context.StoreFormat = this.StoreFormat;
            #if MODULAR
            if (this.StoreFormat == null && ParameterWasBound(nameof(this.StoreFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter StoreFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TsvStoreOptions_AnnotationType = this.TsvStoreOptions_AnnotationType;
            if (this.TsvStoreOptions_FormatToHeader != null)
            {
                context.TsvStoreOptions_FormatToHeader = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TsvStoreOptions_FormatToHeader.Keys)
                {
                    context.TsvStoreOptions_FormatToHeader.Add((String)hashKey, (System.String)(this.TsvStoreOptions_FormatToHeader[hashKey]));
                }
            }
            if (this.TsvStoreOptions_Schema != null)
            {
                context.TsvStoreOptions_Schema = new List<Dictionary<System.String, System.String>>();
                foreach (var hashTable in this.TsvStoreOptions_Schema)
                {
                    var d = new Dictionary<System.String, System.String>();
                    foreach (var hashKey in hashTable.Keys)
                    {
                        d.Add((String)hashKey, (String)(hashTable[hashKey]));
                    }
                    context.TsvStoreOptions_Schema.Add(d);
                }
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.VersionName = this.VersionName;
            
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
            var request = new Amazon.Omics.Model.CreateAnnotationStoreRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Reference
            var requestReferenceIsNull = true;
            request.Reference = new Amazon.Omics.Model.ReferenceItem();
            System.String requestReference_reference_ReferenceArn = null;
            if (cmdletContext.Reference_ReferenceArn != null)
            {
                requestReference_reference_ReferenceArn = cmdletContext.Reference_ReferenceArn;
            }
            if (requestReference_reference_ReferenceArn != null)
            {
                request.Reference.ReferenceArn = requestReference_reference_ReferenceArn;
                requestReferenceIsNull = false;
            }
             // determine if request.Reference should be set to null
            if (requestReferenceIsNull)
            {
                request.Reference = null;
            }
            
             // populate SseConfig
            var requestSseConfigIsNull = true;
            request.SseConfig = new Amazon.Omics.Model.SseConfig();
            System.String requestSseConfig_sseConfig_KeyArn = null;
            if (cmdletContext.SseConfig_KeyArn != null)
            {
                requestSseConfig_sseConfig_KeyArn = cmdletContext.SseConfig_KeyArn;
            }
            if (requestSseConfig_sseConfig_KeyArn != null)
            {
                request.SseConfig.KeyArn = requestSseConfig_sseConfig_KeyArn;
                requestSseConfigIsNull = false;
            }
            Amazon.Omics.EncryptionType requestSseConfig_sseConfig_Type = null;
            if (cmdletContext.SseConfig_Type != null)
            {
                requestSseConfig_sseConfig_Type = cmdletContext.SseConfig_Type;
            }
            if (requestSseConfig_sseConfig_Type != null)
            {
                request.SseConfig.Type = requestSseConfig_sseConfig_Type;
                requestSseConfigIsNull = false;
            }
             // determine if request.SseConfig should be set to null
            if (requestSseConfigIsNull)
            {
                request.SseConfig = null;
            }
            if (cmdletContext.StoreFormat != null)
            {
                request.StoreFormat = cmdletContext.StoreFormat;
            }
            
             // populate StoreOptions
            var requestStoreOptionsIsNull = true;
            request.StoreOptions = new Amazon.Omics.Model.StoreOptions();
            Amazon.Omics.Model.TsvStoreOptions requestStoreOptions_storeOptions_TsvStoreOptions = null;
            
             // populate TsvStoreOptions
            var requestStoreOptions_storeOptions_TsvStoreOptionsIsNull = true;
            requestStoreOptions_storeOptions_TsvStoreOptions = new Amazon.Omics.Model.TsvStoreOptions();
            Amazon.Omics.AnnotationType requestStoreOptions_storeOptions_TsvStoreOptions_tsvStoreOptions_AnnotationType = null;
            if (cmdletContext.TsvStoreOptions_AnnotationType != null)
            {
                requestStoreOptions_storeOptions_TsvStoreOptions_tsvStoreOptions_AnnotationType = cmdletContext.TsvStoreOptions_AnnotationType;
            }
            if (requestStoreOptions_storeOptions_TsvStoreOptions_tsvStoreOptions_AnnotationType != null)
            {
                requestStoreOptions_storeOptions_TsvStoreOptions.AnnotationType = requestStoreOptions_storeOptions_TsvStoreOptions_tsvStoreOptions_AnnotationType;
                requestStoreOptions_storeOptions_TsvStoreOptionsIsNull = false;
            }
            Dictionary<System.String, System.String> requestStoreOptions_storeOptions_TsvStoreOptions_tsvStoreOptions_FormatToHeader = null;
            if (cmdletContext.TsvStoreOptions_FormatToHeader != null)
            {
                requestStoreOptions_storeOptions_TsvStoreOptions_tsvStoreOptions_FormatToHeader = cmdletContext.TsvStoreOptions_FormatToHeader;
            }
            if (requestStoreOptions_storeOptions_TsvStoreOptions_tsvStoreOptions_FormatToHeader != null)
            {
                requestStoreOptions_storeOptions_TsvStoreOptions.FormatToHeader = requestStoreOptions_storeOptions_TsvStoreOptions_tsvStoreOptions_FormatToHeader;
                requestStoreOptions_storeOptions_TsvStoreOptionsIsNull = false;
            }
            List<Dictionary<System.String, System.String>> requestStoreOptions_storeOptions_TsvStoreOptions_tsvStoreOptions_Schema = null;
            if (cmdletContext.TsvStoreOptions_Schema != null)
            {
                requestStoreOptions_storeOptions_TsvStoreOptions_tsvStoreOptions_Schema = cmdletContext.TsvStoreOptions_Schema;
            }
            if (requestStoreOptions_storeOptions_TsvStoreOptions_tsvStoreOptions_Schema != null)
            {
                requestStoreOptions_storeOptions_TsvStoreOptions.Schema = requestStoreOptions_storeOptions_TsvStoreOptions_tsvStoreOptions_Schema;
                requestStoreOptions_storeOptions_TsvStoreOptionsIsNull = false;
            }
             // determine if requestStoreOptions_storeOptions_TsvStoreOptions should be set to null
            if (requestStoreOptions_storeOptions_TsvStoreOptionsIsNull)
            {
                requestStoreOptions_storeOptions_TsvStoreOptions = null;
            }
            if (requestStoreOptions_storeOptions_TsvStoreOptions != null)
            {
                request.StoreOptions.TsvStoreOptions = requestStoreOptions_storeOptions_TsvStoreOptions;
                requestStoreOptionsIsNull = false;
            }
             // determine if request.StoreOptions should be set to null
            if (requestStoreOptionsIsNull)
            {
                request.StoreOptions = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VersionName != null)
            {
                request.VersionName = cmdletContext.VersionName;
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
        
        private Amazon.Omics.Model.CreateAnnotationStoreResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.CreateAnnotationStoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "CreateAnnotationStore");
            try
            {
                #if DESKTOP
                return client.CreateAnnotationStore(request);
                #elif CORECLR
                return client.CreateAnnotationStoreAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String Reference_ReferenceArn { get; set; }
            public System.String SseConfig_KeyArn { get; set; }
            public Amazon.Omics.EncryptionType SseConfig_Type { get; set; }
            public Amazon.Omics.StoreFormat StoreFormat { get; set; }
            public Amazon.Omics.AnnotationType TsvStoreOptions_AnnotationType { get; set; }
            public Dictionary<System.String, System.String> TsvStoreOptions_FormatToHeader { get; set; }
            public List<Dictionary<System.String, System.String>> TsvStoreOptions_Schema { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String VersionName { get; set; }
            public System.Func<Amazon.Omics.Model.CreateAnnotationStoreResponse, NewOMICSAnnotationStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
