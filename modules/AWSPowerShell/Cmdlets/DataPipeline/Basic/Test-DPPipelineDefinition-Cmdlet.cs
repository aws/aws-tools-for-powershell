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
using Amazon.DataPipeline;
using Amazon.DataPipeline.Model;

namespace Amazon.PowerShell.Cmdlets.DP
{
    /// <summary>
    /// Validates the specified pipeline definition to ensure that it is well formed and can
    /// be run without error.
    /// </summary>
    [Cmdlet("Test", "DPPipelineDefinition")]
    [OutputType("Amazon.DataPipeline.Model.ValidatePipelineDefinitionResponse")]
    [AWSCmdlet("Calls the AWS Data Pipeline ValidatePipelineDefinition API operation.", Operation = new[] {"ValidatePipelineDefinition"}, SelectReturnType = typeof(Amazon.DataPipeline.Model.ValidatePipelineDefinitionResponse))]
    [AWSCmdletOutput("Amazon.DataPipeline.Model.ValidatePipelineDefinitionResponse",
        "This cmdlet returns an Amazon.DataPipeline.Model.ValidatePipelineDefinitionResponse object containing multiple properties."
    )]
    public partial class TestDPPipelineDefinitionCmdlet : AmazonDataPipelineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ParameterObject
        /// <summary>
        /// <para>
        /// <para>The parameter objects used with the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ParameterObjects")]
        public Amazon.DataPipeline.Model.ParameterObject[] ParameterObject { get; set; }
        #endregion
        
        #region Parameter ParameterValue
        /// <summary>
        /// <para>
        /// <para>The parameter values used with the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ParameterValues")]
        public Amazon.DataPipeline.Model.ParameterValue[] ParameterValue { get; set; }
        #endregion
        
        #region Parameter PipelineId
        /// <summary>
        /// <para>
        /// <para>The ID of the pipeline.</para>
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
        public System.String PipelineId { get; set; }
        #endregion
        
        #region Parameter PipelineObject
        /// <summary>
        /// <para>
        /// <para>The objects that define the pipeline changes to validate against the pipeline.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("PipelineObjects")]
        public Amazon.DataPipeline.Model.PipelineObject[] PipelineObject { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataPipeline.Model.ValidatePipelineDefinitionResponse).
        /// Specifying the name of a property of type Amazon.DataPipeline.Model.ValidatePipelineDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.DataPipeline.Model.ValidatePipelineDefinitionResponse, TestDPPipelineDefinitionCmdlet>(Select) ??
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
            if (this.ParameterObject != null)
            {
                context.ParameterObject = new List<Amazon.DataPipeline.Model.ParameterObject>(this.ParameterObject);
            }
            if (this.ParameterValue != null)
            {
                context.ParameterValue = new List<Amazon.DataPipeline.Model.ParameterValue>(this.ParameterValue);
            }
            context.PipelineId = this.PipelineId;
            #if MODULAR
            if (this.PipelineId == null && ParameterWasBound(nameof(this.PipelineId)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PipelineObject != null)
            {
                context.PipelineObject = new List<Amazon.DataPipeline.Model.PipelineObject>(this.PipelineObject);
            }
            #if MODULAR
            if (this.PipelineObject == null && ParameterWasBound(nameof(this.PipelineObject)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineObject which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DataPipeline.Model.ValidatePipelineDefinitionRequest();
            
            if (cmdletContext.ParameterObject != null)
            {
                request.ParameterObjects = cmdletContext.ParameterObject;
            }
            if (cmdletContext.ParameterValue != null)
            {
                request.ParameterValues = cmdletContext.ParameterValue;
            }
            if (cmdletContext.PipelineId != null)
            {
                request.PipelineId = cmdletContext.PipelineId;
            }
            if (cmdletContext.PipelineObject != null)
            {
                request.PipelineObjects = cmdletContext.PipelineObject;
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
        
        private Amazon.DataPipeline.Model.ValidatePipelineDefinitionResponse CallAWSServiceOperation(IAmazonDataPipeline client, Amazon.DataPipeline.Model.ValidatePipelineDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Data Pipeline", "ValidatePipelineDefinition");
            try
            {
                #if DESKTOP
                return client.ValidatePipelineDefinition(request);
                #elif CORECLR
                return client.ValidatePipelineDefinitionAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.DataPipeline.Model.ParameterObject> ParameterObject { get; set; }
            public List<Amazon.DataPipeline.Model.ParameterValue> ParameterValue { get; set; }
            public System.String PipelineId { get; set; }
            public List<Amazon.DataPipeline.Model.PipelineObject> PipelineObject { get; set; }
            public System.Func<Amazon.DataPipeline.Model.ValidatePipelineDefinitionResponse, TestDPPipelineDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
