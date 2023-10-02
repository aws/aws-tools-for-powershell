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
using Amazon.MainframeModernization;
using Amazon.MainframeModernization.Model;

namespace Amazon.PowerShell.Cmdlets.AMM
{
    /// <summary>
    /// Starts a batch job and returns the unique identifier of this execution of the batch
    /// job. The associated application must be running in order to start the batch job.
    /// </summary>
    [Cmdlet("Start", "AMMBatchJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the M2 StartBatchJob API operation.", Operation = new[] {"StartBatchJob"}, SelectReturnType = typeof(Amazon.MainframeModernization.Model.StartBatchJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.MainframeModernization.Model.StartBatchJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MainframeModernization.Model.StartBatchJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartAMMBatchJobCmdlet : AmazonMainframeModernizationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the application associated with this batch job.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter FileBatchJobIdentifier_FileName
        /// <summary>
        /// <para>
        /// <para>The file name for the batch job identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchJobIdentifier_FileBatchJobIdentifier_FileName")]
        public System.String FileBatchJobIdentifier_FileName { get; set; }
        #endregion
        
        #region Parameter FileBatchJobIdentifier_FolderPath
        /// <summary>
        /// <para>
        /// <para>The relative path to the file name for the batch job identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchJobIdentifier_FileBatchJobIdentifier_FolderPath")]
        public System.String FileBatchJobIdentifier_FolderPath { get; set; }
        #endregion
        
        #region Parameter JobParam
        /// <summary>
        /// <para>
        /// <para>The collection of batch job parameters. For details about limits for keys and values,
        /// see <a href="https://www.ibm.com/docs/en/workload-automation/9.3.0?topic=zos-coding-variables-in-jcl">Coding
        /// variables in JCL</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobParams")]
        public System.Collections.Hashtable JobParam { get; set; }
        #endregion
        
        #region Parameter ScriptBatchJobIdentifier_ScriptName
        /// <summary>
        /// <para>
        /// <para>The name of the script containing the batch job definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchJobIdentifier_ScriptBatchJobIdentifier_ScriptName")]
        public System.String ScriptBatchJobIdentifier_ScriptName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExecutionId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MainframeModernization.Model.StartBatchJobResponse).
        /// Specifying the name of a property of type Amazon.MainframeModernization.Model.StartBatchJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExecutionId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-AMMBatchJob (StartBatchJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MainframeModernization.Model.StartBatchJobResponse, StartAMMBatchJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FileBatchJobIdentifier_FileName = this.FileBatchJobIdentifier_FileName;
            context.FileBatchJobIdentifier_FolderPath = this.FileBatchJobIdentifier_FolderPath;
            context.ScriptBatchJobIdentifier_ScriptName = this.ScriptBatchJobIdentifier_ScriptName;
            if (this.JobParam != null)
            {
                context.JobParam = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.JobParam.Keys)
                {
                    context.JobParam.Add((String)hashKey, (String)(this.JobParam[hashKey]));
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
            var request = new Amazon.MainframeModernization.Model.StartBatchJobRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate BatchJobIdentifier
            var requestBatchJobIdentifierIsNull = true;
            request.BatchJobIdentifier = new Amazon.MainframeModernization.Model.BatchJobIdentifier();
            Amazon.MainframeModernization.Model.ScriptBatchJobIdentifier requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier = null;
            
             // populate ScriptBatchJobIdentifier
            var requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifierIsNull = true;
            requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier = new Amazon.MainframeModernization.Model.ScriptBatchJobIdentifier();
            System.String requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier_scriptBatchJobIdentifier_ScriptName = null;
            if (cmdletContext.ScriptBatchJobIdentifier_ScriptName != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier_scriptBatchJobIdentifier_ScriptName = cmdletContext.ScriptBatchJobIdentifier_ScriptName;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier_scriptBatchJobIdentifier_ScriptName != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier.ScriptName = requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier_scriptBatchJobIdentifier_ScriptName;
                requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifierIsNull = false;
            }
             // determine if requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier should be set to null
            if (requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifierIsNull)
            {
                requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier = null;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier != null)
            {
                request.BatchJobIdentifier.ScriptBatchJobIdentifier = requestBatchJobIdentifier_batchJobIdentifier_ScriptBatchJobIdentifier;
                requestBatchJobIdentifierIsNull = false;
            }
            Amazon.MainframeModernization.Model.FileBatchJobIdentifier requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier = null;
            
             // populate FileBatchJobIdentifier
            var requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifierIsNull = true;
            requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier = new Amazon.MainframeModernization.Model.FileBatchJobIdentifier();
            System.String requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier_fileBatchJobIdentifier_FileName = null;
            if (cmdletContext.FileBatchJobIdentifier_FileName != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier_fileBatchJobIdentifier_FileName = cmdletContext.FileBatchJobIdentifier_FileName;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier_fileBatchJobIdentifier_FileName != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier.FileName = requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier_fileBatchJobIdentifier_FileName;
                requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifierIsNull = false;
            }
            System.String requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier_fileBatchJobIdentifier_FolderPath = null;
            if (cmdletContext.FileBatchJobIdentifier_FolderPath != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier_fileBatchJobIdentifier_FolderPath = cmdletContext.FileBatchJobIdentifier_FolderPath;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier_fileBatchJobIdentifier_FolderPath != null)
            {
                requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier.FolderPath = requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier_fileBatchJobIdentifier_FolderPath;
                requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifierIsNull = false;
            }
             // determine if requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier should be set to null
            if (requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifierIsNull)
            {
                requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier = null;
            }
            if (requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier != null)
            {
                request.BatchJobIdentifier.FileBatchJobIdentifier = requestBatchJobIdentifier_batchJobIdentifier_FileBatchJobIdentifier;
                requestBatchJobIdentifierIsNull = false;
            }
             // determine if request.BatchJobIdentifier should be set to null
            if (requestBatchJobIdentifierIsNull)
            {
                request.BatchJobIdentifier = null;
            }
            if (cmdletContext.JobParam != null)
            {
                request.JobParams = cmdletContext.JobParam;
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
        
        private Amazon.MainframeModernization.Model.StartBatchJobResponse CallAWSServiceOperation(IAmazonMainframeModernization client, Amazon.MainframeModernization.Model.StartBatchJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "M2", "StartBatchJob");
            try
            {
                #if DESKTOP
                return client.StartBatchJob(request);
                #elif CORECLR
                return client.StartBatchJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String FileBatchJobIdentifier_FileName { get; set; }
            public System.String FileBatchJobIdentifier_FolderPath { get; set; }
            public System.String ScriptBatchJobIdentifier_ScriptName { get; set; }
            public Dictionary<System.String, System.String> JobParam { get; set; }
            public System.Func<Amazon.MainframeModernization.Model.StartBatchJobResponse, StartAMMBatchJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExecutionId;
        }
        
    }
}
