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
    /// Get the associated metadata/information for a task run, given a task run ID.
    /// </summary>
    [Cmdlet("Get", "GLUEColumnStatisticsTaskRun")]
    [OutputType("Amazon.Glue.Model.ColumnStatisticsTaskRun")]
    [AWSCmdlet("Calls the AWS Glue GetColumnStatisticsTaskRun API operation.", Operation = new[] {"GetColumnStatisticsTaskRun"}, SelectReturnType = typeof(Amazon.Glue.Model.GetColumnStatisticsTaskRunResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.ColumnStatisticsTaskRun or Amazon.Glue.Model.GetColumnStatisticsTaskRunResponse",
        "This cmdlet returns an Amazon.Glue.Model.ColumnStatisticsTaskRun object.",
        "The service call response (type Amazon.Glue.Model.GetColumnStatisticsTaskRunResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGLUEColumnStatisticsTaskRunCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ColumnStatisticsTaskRunId
        /// <summary>
        /// <para>
        /// <para>The identifier for the particular column statistics task run.</para>
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
        public System.String ColumnStatisticsTaskRunId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ColumnStatisticsTaskRun'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.GetColumnStatisticsTaskRunResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.GetColumnStatisticsTaskRunResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ColumnStatisticsTaskRun";
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
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.GetColumnStatisticsTaskRunResponse, GetGLUEColumnStatisticsTaskRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ColumnStatisticsTaskRunId = this.ColumnStatisticsTaskRunId;
            #if MODULAR
            if (this.ColumnStatisticsTaskRunId == null && ParameterWasBound(nameof(this.ColumnStatisticsTaskRunId)))
            {
                WriteWarning("You are passing $null as a value for parameter ColumnStatisticsTaskRunId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Glue.Model.GetColumnStatisticsTaskRunRequest();
            
            if (cmdletContext.ColumnStatisticsTaskRunId != null)
            {
                request.ColumnStatisticsTaskRunId = cmdletContext.ColumnStatisticsTaskRunId;
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
        
        private Amazon.Glue.Model.GetColumnStatisticsTaskRunResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.GetColumnStatisticsTaskRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "GetColumnStatisticsTaskRun");
            try
            {
                #if DESKTOP
                return client.GetColumnStatisticsTaskRun(request);
                #elif CORECLR
                return client.GetColumnStatisticsTaskRunAsync(request).GetAwaiter().GetResult();
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
            public System.String ColumnStatisticsTaskRunId { get; set; }
            public System.Func<Amazon.Glue.Model.GetColumnStatisticsTaskRunResponse, GetGLUEColumnStatisticsTaskRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ColumnStatisticsTaskRun;
        }
        
    }
}
