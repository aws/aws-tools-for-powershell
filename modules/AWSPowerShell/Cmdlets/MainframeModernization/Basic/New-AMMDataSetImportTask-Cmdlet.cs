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
using Amazon.MainframeModernization;
using Amazon.MainframeModernization.Model;

namespace Amazon.PowerShell.Cmdlets.AMM
{
    /// <summary>
    /// Starts a data set import task for a specific application.
    /// </summary>
    [Cmdlet("New", "AMMDataSetImportTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the M2 CreateDataSetImportTask API operation.", Operation = new[] {"CreateDataSetImportTask"}, SelectReturnType = typeof(Amazon.MainframeModernization.Model.CreateDataSetImportTaskResponse))]
    [AWSCmdletOutput("System.String or Amazon.MainframeModernization.Model.CreateDataSetImportTaskResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MainframeModernization.Model.CreateDataSetImportTaskResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAMMDataSetImportTaskCmdlet : AmazonMainframeModernizationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the application for which you want to import data sets.</para>
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
        
        #region Parameter ImportConfig_DataSet
        /// <summary>
        /// <para>
        /// <para>The data sets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportConfig_DataSets")]
        public Amazon.MainframeModernization.Model.DataSetImportItem[] ImportConfig_DataSet { get; set; }
        #endregion
        
        #region Parameter ImportConfig_S3Location
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location of the data sets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImportConfig_S3Location { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> Unique, case-sensitive identifier you provide to ensure the idempotency of the request
        /// to create a data set import. The service generates the clientToken when the API call
        /// is triggered. The token expires after one hour, so if you retry the API within this
        /// timeframe with the same clientToken, you will get the same response. The service also
        /// handles deleting the clientToken after it expires. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MainframeModernization.Model.CreateDataSetImportTaskResponse).
        /// Specifying the name of a property of type Amazon.MainframeModernization.Model.CreateDataSetImportTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TaskId";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMMDataSetImportTask (CreateDataSetImportTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MainframeModernization.Model.CreateDataSetImportTaskResponse, NewAMMDataSetImportTaskCmdlet>(Select) ??
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
            context.ClientToken = this.ClientToken;
            if (this.ImportConfig_DataSet != null)
            {
                context.ImportConfig_DataSet = new List<Amazon.MainframeModernization.Model.DataSetImportItem>(this.ImportConfig_DataSet);
            }
            context.ImportConfig_S3Location = this.ImportConfig_S3Location;
            
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
            var request = new Amazon.MainframeModernization.Model.CreateDataSetImportTaskRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ImportConfig
            request.ImportConfig = new Amazon.MainframeModernization.Model.DataSetImportConfig();
            List<Amazon.MainframeModernization.Model.DataSetImportItem> requestImportConfig_importConfig_DataSet = null;
            if (cmdletContext.ImportConfig_DataSet != null)
            {
                requestImportConfig_importConfig_DataSet = cmdletContext.ImportConfig_DataSet;
            }
            if (requestImportConfig_importConfig_DataSet != null)
            {
                request.ImportConfig.DataSets = requestImportConfig_importConfig_DataSet;
            }
            System.String requestImportConfig_importConfig_S3Location = null;
            if (cmdletContext.ImportConfig_S3Location != null)
            {
                requestImportConfig_importConfig_S3Location = cmdletContext.ImportConfig_S3Location;
            }
            if (requestImportConfig_importConfig_S3Location != null)
            {
                request.ImportConfig.S3Location = requestImportConfig_importConfig_S3Location;
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
        
        private Amazon.MainframeModernization.Model.CreateDataSetImportTaskResponse CallAWSServiceOperation(IAmazonMainframeModernization client, Amazon.MainframeModernization.Model.CreateDataSetImportTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "M2", "CreateDataSetImportTask");
            try
            {
                #if DESKTOP
                return client.CreateDataSetImportTask(request);
                #elif CORECLR
                return client.CreateDataSetImportTaskAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public List<Amazon.MainframeModernization.Model.DataSetImportItem> ImportConfig_DataSet { get; set; }
            public System.String ImportConfig_S3Location { get; set; }
            public System.Func<Amazon.MainframeModernization.Model.CreateDataSetImportTaskResponse, NewAMMDataSetImportTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskId;
        }
        
    }
}
