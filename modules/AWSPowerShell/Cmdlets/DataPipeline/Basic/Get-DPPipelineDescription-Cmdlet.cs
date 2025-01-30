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
using Amazon.DataPipeline;
using Amazon.DataPipeline.Model;

namespace Amazon.PowerShell.Cmdlets.DP
{
    /// <summary>
    /// Retrieves metadata about one or more pipelines. The information retrieved includes
    /// the name of the pipeline, the pipeline identifier, its current state, and the user
    /// account that owns the pipeline. Using account credentials, you can retrieve metadata
    /// about pipelines that you or your IAM users have created. If you are using an IAM user
    /// account, you can retrieve metadata about only those pipelines for which you have read
    /// permissions.
    /// 
    ///  
    /// <para>
    /// To retrieve the full pipeline definition instead of metadata about the pipeline, call
    /// <a>GetPipelineDefinition</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DPPipelineDescription")]
    [OutputType("Amazon.DataPipeline.Model.PipelineDescription")]
    [AWSCmdlet("Calls the AWS Data Pipeline DescribePipelines API operation.", Operation = new[] {"DescribePipelines"}, SelectReturnType = typeof(Amazon.DataPipeline.Model.DescribePipelinesResponse))]
    [AWSCmdletOutput("Amazon.DataPipeline.Model.PipelineDescription or Amazon.DataPipeline.Model.DescribePipelinesResponse",
        "This cmdlet returns a collection of Amazon.DataPipeline.Model.PipelineDescription objects.",
        "The service call response (type Amazon.DataPipeline.Model.DescribePipelinesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDPPipelineDescriptionCmdlet : AmazonDataPipelineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PipelineId
        /// <summary>
        /// <para>
        /// <para>The IDs of the pipelines to describe. You can pass as many as 25 identifiers in a
        /// single call. To obtain pipeline IDs, call <a>ListPipelines</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("PipelineIds")]
        public System.String[] PipelineId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PipelineDescriptionList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataPipeline.Model.DescribePipelinesResponse).
        /// Specifying the name of a property of type Amazon.DataPipeline.Model.DescribePipelinesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PipelineDescriptionList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PipelineId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PipelineId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PipelineId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataPipeline.Model.DescribePipelinesResponse, GetDPPipelineDescriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PipelineId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.PipelineId != null)
            {
                context.PipelineId = new List<System.String>(this.PipelineId);
            }
            #if MODULAR
            if (this.PipelineId == null && ParameterWasBound(nameof(this.PipelineId)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DataPipeline.Model.DescribePipelinesRequest();
            
            if (cmdletContext.PipelineId != null)
            {
                request.PipelineIds = cmdletContext.PipelineId;
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
        
        private Amazon.DataPipeline.Model.DescribePipelinesResponse CallAWSServiceOperation(IAmazonDataPipeline client, Amazon.DataPipeline.Model.DescribePipelinesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Data Pipeline", "DescribePipelines");
            try
            {
                #if DESKTOP
                return client.DescribePipelines(request);
                #elif CORECLR
                return client.DescribePipelinesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> PipelineId { get; set; }
            public System.Func<Amazon.DataPipeline.Model.DescribePipelinesResponse, GetDPPipelineDescriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PipelineDescriptionList;
        }
        
    }
}
