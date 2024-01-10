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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Start an asynchronous job to import Amazon Q resources from an uploaded source file.
    /// Before calling this API, use <a href="https://docs.aws.amazon.com/wisdom/latest/APIReference/API_StartContentUpload.html">StartContentUpload</a>
    /// to upload an asset that contains the resource data.
    /// 
    ///  <ul><li><para>
    /// For importing Amazon Q quick responses, you need to upload a csv file including the
    /// quick responses. For information about how to format the csv file for importing quick
    /// responses, see <a href="https://docs.aws.amazon.com/console/connect/quick-responses/add-data">Import
    /// quick responses</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Start", "QCImportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.ImportJobData")]
    [AWSCmdlet("Calls the Amazon Q Connect StartImportJob API operation.", Operation = new[] {"StartImportJob"}, SelectReturnType = typeof(Amazon.QConnect.Model.StartImportJobResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.ImportJobData or Amazon.QConnect.Model.StartImportJobResponse",
        "This cmdlet returns an Amazon.QConnect.Model.ImportJobData object.",
        "The service call response (type Amazon.QConnect.Model.StartImportJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartQCImportJobCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ImportJobType
        /// <summary>
        /// <para>
        /// <para>The type of the import job.</para><ul><li><para>For importing quick response resource, set the value to <c>QUICK_RESPONSES</c>.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QConnect.ImportJobType")]
        public Amazon.QConnect.ImportJobType ImportJobType { get; set; }
        #endregion
        
        #region Parameter ConnectConfiguration_InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can find the instanceId in the
        /// ARN of the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExternalSourceConfiguration_Configuration_ConnectConfiguration_InstanceId")]
        public System.String ConnectConfiguration_InstanceId { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The identifier of the knowledge base. This should not be a QUICK_RESPONSES type knowledge
        /// base if you're storing Amazon Q Content resource to it. Can be either the ID or the
        /// ARN. URLs cannot contain the ARN.</para><ul><li><para>For importing Amazon Q quick responses, this should be a <c>QUICK_RESPONSES</c> type
        /// knowledge base.</para></li></ul>
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
        public System.String KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para>The metadata fields of the imported Amazon Q resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Metadata { get; set; }
        #endregion
        
        #region Parameter ExternalSourceConfiguration_Source
        /// <summary>
        /// <para>
        /// <para>The type of the external data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QConnect.ExternalSource")]
        public Amazon.QConnect.ExternalSource ExternalSourceConfiguration_Source { get; set; }
        #endregion
        
        #region Parameter UploadId
        /// <summary>
        /// <para>
        /// <para>A pointer to the uploaded asset. This value is returned by <a href="https://docs.aws.amazon.com/wisdom/latest/APIReference/API_StartContentUpload.html">StartContentUpload</a>.</para>
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
        public System.String UploadId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImportJob'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.StartImportJobResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.StartImportJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImportJob";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the KnowledgeBaseId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^KnowledgeBaseId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^KnowledgeBaseId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-QCImportJob (StartImportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.StartImportJobResponse, StartQCImportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.KnowledgeBaseId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.ConnectConfiguration_InstanceId = this.ConnectConfiguration_InstanceId;
            context.ExternalSourceConfiguration_Source = this.ExternalSourceConfiguration_Source;
            context.ImportJobType = this.ImportJobType;
            #if MODULAR
            if (this.ImportJobType == null && ParameterWasBound(nameof(this.ImportJobType)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportJobType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KnowledgeBaseId = this.KnowledgeBaseId;
            #if MODULAR
            if (this.KnowledgeBaseId == null && ParameterWasBound(nameof(this.KnowledgeBaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Metadata != null)
            {
                context.Metadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Metadata.Keys)
                {
                    context.Metadata.Add((String)hashKey, (String)(this.Metadata[hashKey]));
                }
            }
            context.UploadId = this.UploadId;
            #if MODULAR
            if (this.UploadId == null && ParameterWasBound(nameof(this.UploadId)))
            {
                WriteWarning("You are passing $null as a value for parameter UploadId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QConnect.Model.StartImportJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ExternalSourceConfiguration
            var requestExternalSourceConfigurationIsNull = true;
            request.ExternalSourceConfiguration = new Amazon.QConnect.Model.ExternalSourceConfiguration();
            Amazon.QConnect.ExternalSource requestExternalSourceConfiguration_externalSourceConfiguration_Source = null;
            if (cmdletContext.ExternalSourceConfiguration_Source != null)
            {
                requestExternalSourceConfiguration_externalSourceConfiguration_Source = cmdletContext.ExternalSourceConfiguration_Source;
            }
            if (requestExternalSourceConfiguration_externalSourceConfiguration_Source != null)
            {
                request.ExternalSourceConfiguration.Source = requestExternalSourceConfiguration_externalSourceConfiguration_Source;
                requestExternalSourceConfigurationIsNull = false;
            }
            Amazon.QConnect.Model.Configuration requestExternalSourceConfiguration_externalSourceConfiguration_Configuration = null;
            
             // populate Configuration
            var requestExternalSourceConfiguration_externalSourceConfiguration_ConfigurationIsNull = true;
            requestExternalSourceConfiguration_externalSourceConfiguration_Configuration = new Amazon.QConnect.Model.Configuration();
            Amazon.QConnect.Model.ConnectConfiguration requestExternalSourceConfiguration_externalSourceConfiguration_Configuration_externalSourceConfiguration_Configuration_ConnectConfiguration = null;
            
             // populate ConnectConfiguration
            var requestExternalSourceConfiguration_externalSourceConfiguration_Configuration_externalSourceConfiguration_Configuration_ConnectConfigurationIsNull = true;
            requestExternalSourceConfiguration_externalSourceConfiguration_Configuration_externalSourceConfiguration_Configuration_ConnectConfiguration = new Amazon.QConnect.Model.ConnectConfiguration();
            System.String requestExternalSourceConfiguration_externalSourceConfiguration_Configuration_externalSourceConfiguration_Configuration_ConnectConfiguration_connectConfiguration_InstanceId = null;
            if (cmdletContext.ConnectConfiguration_InstanceId != null)
            {
                requestExternalSourceConfiguration_externalSourceConfiguration_Configuration_externalSourceConfiguration_Configuration_ConnectConfiguration_connectConfiguration_InstanceId = cmdletContext.ConnectConfiguration_InstanceId;
            }
            if (requestExternalSourceConfiguration_externalSourceConfiguration_Configuration_externalSourceConfiguration_Configuration_ConnectConfiguration_connectConfiguration_InstanceId != null)
            {
                requestExternalSourceConfiguration_externalSourceConfiguration_Configuration_externalSourceConfiguration_Configuration_ConnectConfiguration.InstanceId = requestExternalSourceConfiguration_externalSourceConfiguration_Configuration_externalSourceConfiguration_Configuration_ConnectConfiguration_connectConfiguration_InstanceId;
                requestExternalSourceConfiguration_externalSourceConfiguration_Configuration_externalSourceConfiguration_Configuration_ConnectConfigurationIsNull = false;
            }
             // determine if requestExternalSourceConfiguration_externalSourceConfiguration_Configuration_externalSourceConfiguration_Configuration_ConnectConfiguration should be set to null
            if (requestExternalSourceConfiguration_externalSourceConfiguration_Configuration_externalSourceConfiguration_Configuration_ConnectConfigurationIsNull)
            {
                requestExternalSourceConfiguration_externalSourceConfiguration_Configuration_externalSourceConfiguration_Configuration_ConnectConfiguration = null;
            }
            if (requestExternalSourceConfiguration_externalSourceConfiguration_Configuration_externalSourceConfiguration_Configuration_ConnectConfiguration != null)
            {
                requestExternalSourceConfiguration_externalSourceConfiguration_Configuration.ConnectConfiguration = requestExternalSourceConfiguration_externalSourceConfiguration_Configuration_externalSourceConfiguration_Configuration_ConnectConfiguration;
                requestExternalSourceConfiguration_externalSourceConfiguration_ConfigurationIsNull = false;
            }
             // determine if requestExternalSourceConfiguration_externalSourceConfiguration_Configuration should be set to null
            if (requestExternalSourceConfiguration_externalSourceConfiguration_ConfigurationIsNull)
            {
                requestExternalSourceConfiguration_externalSourceConfiguration_Configuration = null;
            }
            if (requestExternalSourceConfiguration_externalSourceConfiguration_Configuration != null)
            {
                request.ExternalSourceConfiguration.Configuration = requestExternalSourceConfiguration_externalSourceConfiguration_Configuration;
                requestExternalSourceConfigurationIsNull = false;
            }
             // determine if request.ExternalSourceConfiguration should be set to null
            if (requestExternalSourceConfigurationIsNull)
            {
                request.ExternalSourceConfiguration = null;
            }
            if (cmdletContext.ImportJobType != null)
            {
                request.ImportJobType = cmdletContext.ImportJobType;
            }
            if (cmdletContext.KnowledgeBaseId != null)
            {
                request.KnowledgeBaseId = cmdletContext.KnowledgeBaseId;
            }
            if (cmdletContext.Metadata != null)
            {
                request.Metadata = cmdletContext.Metadata;
            }
            if (cmdletContext.UploadId != null)
            {
                request.UploadId = cmdletContext.UploadId;
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
        
        private Amazon.QConnect.Model.StartImportJobResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.StartImportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "StartImportJob");
            try
            {
                #if DESKTOP
                return client.StartImportJob(request);
                #elif CORECLR
                return client.StartImportJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ConnectConfiguration_InstanceId { get; set; }
            public Amazon.QConnect.ExternalSource ExternalSourceConfiguration_Source { get; set; }
            public Amazon.QConnect.ImportJobType ImportJobType { get; set; }
            public System.String KnowledgeBaseId { get; set; }
            public Dictionary<System.String, System.String> Metadata { get; set; }
            public System.String UploadId { get; set; }
            public System.Func<Amazon.QConnect.Model.StartImportJobResponse, StartQCImportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImportJob;
        }
        
    }
}
