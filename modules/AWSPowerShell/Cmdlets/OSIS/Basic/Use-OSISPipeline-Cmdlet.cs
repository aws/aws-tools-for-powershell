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
using Amazon.OSIS;
using Amazon.OSIS.Model;

namespace Amazon.PowerShell.Cmdlets.OSIS
{
    /// <summary>
    /// Checks whether an OpenSearch Ingestion pipeline configuration is valid prior to creation.
    /// For more information, see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/creating-pipeline.html">Creating
    /// Amazon OpenSearch Ingestion pipelines</a>.
    /// </summary>
    [Cmdlet("Use", "OSISPipeline", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OSIS.Model.ValidatePipelineResponse")]
    [AWSCmdlet("Calls the Amazon OpenSearch Ingestion ValidatePipeline API operation.", Operation = new[] {"ValidatePipeline"}, SelectReturnType = typeof(Amazon.OSIS.Model.ValidatePipelineResponse))]
    [AWSCmdletOutput("Amazon.OSIS.Model.ValidatePipelineResponse",
        "This cmdlet returns an Amazon.OSIS.Model.ValidatePipelineResponse object containing multiple properties."
    )]
    public partial class UseOSISPipelineCmdlet : AmazonOSISClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PipelineConfigurationBody
        /// <summary>
        /// <para>
        /// <para>The pipeline configuration in YAML format. The command accepts the pipeline configuration
        /// as a string or within a .yaml file. If you provide the configuration as a string,
        /// each new line must be escaped with <c>\n</c>.</para>
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
        public System.String PipelineConfigurationBody { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OSIS.Model.ValidatePipelineResponse).
        /// Specifying the name of a property of type Amazon.OSIS.Model.ValidatePipelineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PipelineConfigurationBody parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PipelineConfigurationBody' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PipelineConfigurationBody' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PipelineConfigurationBody), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Use-OSISPipeline (ValidatePipeline)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OSIS.Model.ValidatePipelineResponse, UseOSISPipelineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PipelineConfigurationBody;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PipelineConfigurationBody = this.PipelineConfigurationBody;
            #if MODULAR
            if (this.PipelineConfigurationBody == null && ParameterWasBound(nameof(this.PipelineConfigurationBody)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineConfigurationBody which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OSIS.Model.ValidatePipelineRequest();
            
            if (cmdletContext.PipelineConfigurationBody != null)
            {
                request.PipelineConfigurationBody = cmdletContext.PipelineConfigurationBody;
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
        
        private Amazon.OSIS.Model.ValidatePipelineResponse CallAWSServiceOperation(IAmazonOSIS client, Amazon.OSIS.Model.ValidatePipelineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Ingestion", "ValidatePipeline");
            try
            {
                #if DESKTOP
                return client.ValidatePipeline(request);
                #elif CORECLR
                return client.ValidatePipelineAsync(request).GetAwaiter().GetResult();
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
            public System.String PipelineConfigurationBody { get; set; }
            public System.Func<Amazon.OSIS.Model.ValidatePipelineResponse, UseOSISPipelineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
