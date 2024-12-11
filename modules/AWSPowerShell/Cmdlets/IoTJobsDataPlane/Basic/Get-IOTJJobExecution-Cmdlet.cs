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
using Amazon.IoTJobsDataPlane;
using Amazon.IoTJobsDataPlane.Model;

namespace Amazon.PowerShell.Cmdlets.IOTJ
{
    /// <summary>
    /// Gets details of a job execution.
    /// </summary>
    [Cmdlet("Get", "IOTJJobExecution")]
    [OutputType("Amazon.IoTJobsDataPlane.Model.JobExecution")]
    [AWSCmdlet("Calls the AWS IoT Jobs Data Plane DescribeJobExecution API operation.", Operation = new[] {"DescribeJobExecution"}, SelectReturnType = typeof(Amazon.IoTJobsDataPlane.Model.DescribeJobExecutionResponse))]
    [AWSCmdletOutput("Amazon.IoTJobsDataPlane.Model.JobExecution or Amazon.IoTJobsDataPlane.Model.DescribeJobExecutionResponse",
        "This cmdlet returns an Amazon.IoTJobsDataPlane.Model.JobExecution object.",
        "The service call response (type Amazon.IoTJobsDataPlane.Model.DescribeJobExecutionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTJJobExecutionCmdlet : AmazonIoTJobsDataPlaneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExecutionNumber
        /// <summary>
        /// <para>
        /// <para>Optional. A number that identifies a particular job execution on a particular device.
        /// If not specified, the latest job execution is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ExecutionNumber { get; set; }
        #endregion
        
        #region Parameter IncludeJobDocument
        /// <summary>
        /// <para>
        /// <para>Optional. When set to true, the response contains the job document. The default is
        /// false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeJobDocument { get; set; }
        #endregion
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The unique identifier assigned to this job when it was created.</para>
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
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter ThingName
        /// <summary>
        /// <para>
        /// <para>The thing name associated with the device the job execution is running on.</para>
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
        public System.String ThingName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Execution'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTJobsDataPlane.Model.DescribeJobExecutionResponse).
        /// Specifying the name of a property of type Amazon.IoTJobsDataPlane.Model.DescribeJobExecutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Execution";
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
                context.Select = CreateSelectDelegate<Amazon.IoTJobsDataPlane.Model.DescribeJobExecutionResponse, GetIOTJJobExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExecutionNumber = this.ExecutionNumber;
            context.IncludeJobDocument = this.IncludeJobDocument;
            context.JobId = this.JobId;
            #if MODULAR
            if (this.JobId == null && ParameterWasBound(nameof(this.JobId)))
            {
                WriteWarning("You are passing $null as a value for parameter JobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ThingName = this.ThingName;
            #if MODULAR
            if (this.ThingName == null && ParameterWasBound(nameof(this.ThingName)))
            {
                WriteWarning("You are passing $null as a value for parameter ThingName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTJobsDataPlane.Model.DescribeJobExecutionRequest();
            
            if (cmdletContext.ExecutionNumber != null)
            {
                request.ExecutionNumber = cmdletContext.ExecutionNumber.Value;
            }
            if (cmdletContext.IncludeJobDocument != null)
            {
                request.IncludeJobDocument = cmdletContext.IncludeJobDocument.Value;
            }
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
            }
            if (cmdletContext.ThingName != null)
            {
                request.ThingName = cmdletContext.ThingName;
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
        
        private Amazon.IoTJobsDataPlane.Model.DescribeJobExecutionResponse CallAWSServiceOperation(IAmazonIoTJobsDataPlane client, Amazon.IoTJobsDataPlane.Model.DescribeJobExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Jobs Data Plane", "DescribeJobExecution");
            try
            {
                #if DESKTOP
                return client.DescribeJobExecution(request);
                #elif CORECLR
                return client.DescribeJobExecutionAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? ExecutionNumber { get; set; }
            public System.Boolean? IncludeJobDocument { get; set; }
            public System.String JobId { get; set; }
            public System.String ThingName { get; set; }
            public System.Func<Amazon.IoTJobsDataPlane.Model.DescribeJobExecutionResponse, GetIOTJJobExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Execution;
        }
        
    }
}
