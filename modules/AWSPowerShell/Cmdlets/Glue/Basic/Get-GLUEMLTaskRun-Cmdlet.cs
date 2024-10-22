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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Gets details for a specific task run on a machine learning transform. Machine learning
    /// task runs are asynchronous tasks that Glue runs on your behalf as part of various
    /// machine learning workflows. You can check the stats of any task run by calling <c>GetMLTaskRun</c>
    /// with the <c>TaskRunID</c> and its parent transform's <c>TransformID</c>.
    /// </summary>
    [Cmdlet("Get", "GLUEMLTaskRun")]
    [OutputType("Amazon.Glue.Model.GetMLTaskRunResponse")]
    [AWSCmdlet("Calls the AWS Glue GetMLTaskRun API operation.", Operation = new[] {"GetMLTaskRun"}, SelectReturnType = typeof(Amazon.Glue.Model.GetMLTaskRunResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.GetMLTaskRunResponse",
        "This cmdlet returns an Amazon.Glue.Model.GetMLTaskRunResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGLUEMLTaskRunCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TaskRunId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the task run.</para>
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
        public System.String TaskRunId { get; set; }
        #endregion
        
        #region Parameter TransformId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the machine learning transform.</para>
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
        public System.String TransformId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.GetMLTaskRunResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.GetMLTaskRunResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.GetMLTaskRunResponse, GetGLUEMLTaskRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TaskRunId = this.TaskRunId;
            #if MODULAR
            if (this.TaskRunId == null && ParameterWasBound(nameof(this.TaskRunId)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskRunId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransformId = this.TransformId;
            #if MODULAR
            if (this.TransformId == null && ParameterWasBound(nameof(this.TransformId)))
            {
                WriteWarning("You are passing $null as a value for parameter TransformId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Glue.Model.GetMLTaskRunRequest();
            
            if (cmdletContext.TaskRunId != null)
            {
                request.TaskRunId = cmdletContext.TaskRunId;
            }
            if (cmdletContext.TransformId != null)
            {
                request.TransformId = cmdletContext.TransformId;
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
        
        private Amazon.Glue.Model.GetMLTaskRunResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.GetMLTaskRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "GetMLTaskRun");
            try
            {
                #if DESKTOP
                return client.GetMLTaskRun(request);
                #elif CORECLR
                return client.GetMLTaskRunAsync(request).GetAwaiter().GetResult();
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
            public System.String TaskRunId { get; set; }
            public System.String TransformId { get; set; }
            public System.Func<Amazon.Glue.Model.GetMLTaskRunResponse, GetGLUEMLTaskRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
